using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace WalletPlot
{
    public partial class mainForm : Form
    {
        private DataTranslator translator = null;

        public mainForm()
        {
            InitializeComponent();
            translator = new DataTranslator(this);

            // set up our graph combo boxes
            graphTypeComboBox.SelectedIndex = 0;
            smoothingComboBox.SelectedIndex = 0;

            // set up our default date pickers to look better
            startDatePicker.Value = DateTime.Today.Subtract(TimeSpan.FromDays(30));
            endDatePicker.Value = DateTime.Today;
        }

        void UpdateChart(object sender, EventArgs e)
        {
            translator.DrawChartUpdateStats(chart,
                statsListView,
                (DataTranslator.GraphTypes)graphTypeComboBox.SelectedIndex,
                (DataTranslator.SmoothingAlgoritms)smoothingComboBox.SelectedIndex,
                startDatePicker.Value,
                endDatePicker.Value,
                (string)dataTypeComboBox.SelectedValue,
                (string)labelComboBox.SelectedValue,
                (string)addressComboBox.SelectedValue);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) ? Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            dialog.InitialDirectory = homePath;
            dialog.Filter = "csv files (*.csv)|*.csv|All files (*)|*";
            dialog.FilterIndex = 0;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (translator.LoadFile(dialog.FileName))
                    {
                        // enable all the controls
                        graphTypeComboBox.Enabled = true;
                        smoothingComboBox.Enabled = true;
                        startDatePicker.Enabled = true;
                        endDatePicker.Enabled = true;
                        dataTypeComboBox.Enabled = true;
                        labelComboBox.Enabled = true;
                        addressComboBox.Enabled = true;
                        statsListView.Enabled = true;
                        chart.Enabled = true;

                        // fill in the controls
                        startDatePicker.Value = translator.GetFirstLastDate(true);
                        endDatePicker.Value = translator.GetFirstLastDate(false);
                        dataTypeComboBox.DataSource = translator.GetUniqueFieldValues(DataTranslator.DataLineFields.TYPE).ToList();
                        labelComboBox.DataSource = translator.GetUniqueFieldValues(DataTranslator.DataLineFields.LABEL).ToList();
                        addressComboBox.DataSource = translator.GetUniqueFieldValues(DataTranslator.DataLineFields.ADDRESS).ToList();

                        // bind events to update the chart
                        graphTypeComboBox.SelectedIndexChanged += UpdateChart;
                        smoothingComboBox.SelectedIndexChanged += UpdateChart;
                        startDatePicker.ValueChanged += UpdateChart;
                        endDatePicker.ValueChanged += UpdateChart;
                        dataTypeComboBox.SelectedIndexChanged += UpdateChart;
                        labelComboBox.SelectedIndexChanged += UpdateChart;
                        addressComboBox.SelectedIndexChanged += UpdateChart;

                        // and draw the chart
                        UpdateChart(this, null);
                    }
                    else
                    {
                        // disable all the controls
                        graphTypeComboBox.Enabled = false;
                        smoothingComboBox.Enabled = false;
                        startDatePicker.Enabled = false;
                        endDatePicker.Enabled = false;
                        dataTypeComboBox.Enabled = false;
                        labelComboBox.Enabled = false;
                        addressComboBox.Enabled = false;
                        statsListView.Enabled = false;
                        chart.Enabled = false;

                        // clear the controls
                        dataTypeComboBox.DataSource = new List<string>();
                        labelComboBox.DataSource = new List<string>();
                        addressComboBox.DataSource = new List<string>();

                        // unbind events to update the chart
                        graphTypeComboBox.SelectedIndexChanged -= UpdateChart;
                        smoothingComboBox.SelectedIndexChanged -= UpdateChart;
                        startDatePicker.ValueChanged -= UpdateChart;
                        endDatePicker.ValueChanged -= UpdateChart;
                        dataTypeComboBox.SelectedIndexChanged -= UpdateChart;
                        labelComboBox.SelectedIndexChanged -= UpdateChart;
                        addressComboBox.SelectedIndexChanged -= UpdateChart;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: Could not read file from disk: " + exc.Message);
                }
            }
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/FuzzyWuzzie/WalletPlot");
        }

        private void bugReportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/FuzzyWuzzie/WalletPlot/issues");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            Form aboutForm = new WalletPlot.About();
            aboutForm.ShowDialog(this);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A help file is forthcoming...", "Help");
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            Form donateForm = new WalletPlot.Donate();
            donateForm.ShowDialog(this);
        }

        /*ToolTip toolTip = new ToolTip();
        void chart_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            HitTestResult result = chart.HitTest(pos.X, pos.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                System.Windows.Forms.DataVisualization.Charting.DataPoint point = chart.Series[0].Points[result.PointIndex];
            }
        }*/
        
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
 
        void chart_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as System.Windows.Forms.DataVisualization.Charting.DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
 
                        // check if the cursor is really close to the point
                        /*if (Math.Abs(pos.X - pointXPixel) < 15 &&
                            Math.Abs(pos.Y - pointYPixel) < 15)
                        {
                        }*/
                        tooltip.Show(DateTime.FromOADate(prop.XValue).ToString("g") + ": " + prop.YValues[0], this.chart, pos.X, pos.Y - 15);
                    }
                }
            }
        }
    }
}
