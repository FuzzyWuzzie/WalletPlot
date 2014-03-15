using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace WalletPlot
{
    class DataTranslator
    {
        public enum DataLineFields { CONFIRMED, DATE, TYPE, LABEL, ADDRESS, AMOUNT, ID };
        public enum GraphTypes { CUMULATIVE_SUM, TRANSACTIONS, RATE };
        public enum SmoothingAlgoritms { NONE, MWA5, MWA9, MWA13, MWA17, EMA05, EMA25, EMA50, EMA75, EMA95 };

        private List<DataLine> data = new List<DataLine>();
        private mainForm gui = null;

        public DataTranslator(mainForm gui)
        {
            this.gui = gui;
        }

        public bool LoadFile(string fileName)
        {
            StreamReader file = null;
            if ((file = new StreamReader(fileName)) != null)
            {
                using (file)
                {
                    string line;
                    bool first = true;
                    data.Clear();
                    while ((line = file.ReadLine()) != null)
                    {
                        // skip the header in the file
                        if (first)
                        {
                            first = false;
                            continue;
                        }

                        // otherwise, parse it!
                        DataLine dataLine = new DataLine(line);
                        data.Add(dataLine);
                    }
                }
            }
            else
                throw new Exception("File was null?");

            // now sort it chronologically, ascending
            data.Sort((a, b) => a.date.CompareTo(b.date));

            return data.Count > 0;
        }

        public DateTime GetFirstLastDate(bool first)
        {
            if(first)
                return data[0].date;
            return data[data.Count - 1].date;
        }

        public HashSet<string> GetUniqueFieldValues(DataLineFields field)
        {
            HashSet<string> types = new HashSet<string>();
            types.Add("All");
            foreach (DataLine line in data)
            {
                switch (field)
                {
                    case DataLineFields.TYPE:
                        types.Add(line.type);
                        break;

                    case DataLineFields.LABEL:
                        types.Add(line.label);
                        break;

                    case DataLineFields.ADDRESS:
                        types.Add(line.address);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            return types;
        }

        protected bool KeepDataPoint(DataLine line, DateTime start, DateTime end, string typeFilter, string labelFilter, string addressFilter)
        {
            // filter based on time
            if (line.date < start || line.date > end)
                return false;

            // filter the combo selections
            if (typeFilter != "All" && line.type != typeFilter)
                return false;
            if (labelFilter != "All" && line.label != labelFilter)
                return false;
            if (addressFilter != "All" && line.address != addressFilter)
                return false;

            return true;
        }

        protected List<DataPoint> BuildDataPoints(GraphTypes type, DateTime start, DateTime end, string typeFilter, string labelFilter, string addressFilter)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            if (type == GraphTypes.CUMULATIVE_SUM)
            {
                double sum = 0;
                foreach (DataLine line in data)
                {
                    if (!KeepDataPoint(line, start, end, typeFilter, labelFilter, addressFilter))
                        continue;

                    sum += line.amount;
                    dataPoints.Add(new DataPoint(line.date, sum));
                }
            }
            else if (type == GraphTypes.TRANSACTIONS)
            {
                foreach (DataLine line in data)
                {
                    if (!KeepDataPoint(line, start, end, typeFilter, labelFilter, addressFilter))
                        continue;

                    dataPoints.Add(new DataPoint(line.date, line.amount));
                }
            }
            else if (type == GraphTypes.RATE)
            {
                DataPoint lastPoint = null;
                foreach (DataLine line in data)
                {
                    if (!KeepDataPoint(line, start, end, typeFilter, labelFilter, addressFilter))
                        continue;

                    if (lastPoint == null)
                    {
                        lastPoint = new DataPoint(line.date, line.amount);
                        continue;
                    }

                    DataPoint dp = new DataPoint(line.date, line.amount / (line.date - lastPoint.t).TotalDays);
                    dataPoints.Add(dp);
                    lastPoint = dp;
                }
            }

            return dataPoints;
        }

        protected List<DataPoint> MovingWindowAverage(List<DataPoint> dataPoints, int numVals)
        {
            List<DataPoint> newData = new List<DataPoint>();
            for (int i = 0; i < dataPoints.Count; i++)
            {
                int offset = numVals / -2;
                double sum = 0;
                int numActualVals = 0;
                for (int x = 0; x < numVals; x++)
                {
                    if (i + offset >= 0 && i + offset < dataPoints.Count)
                    {
                        sum += dataPoints[i + offset].v;
                        numActualVals++;
                    }
                    offset++;
                }
                newData.Add(new DataPoint(dataPoints[i].t, sum / (double)numActualVals));
            }
            return newData;
        }

        protected List<DataPoint> ExponentialMovingAverage(List<DataPoint> dataPoints, double alpha)
        {
            // http://en.wikipedia.org/wiki/Moving_average#Exponential_moving_average
            List<DataPoint> newData = new List<DataPoint>();

            DataPoint lastPoint = null;
            foreach (DataPoint dp in dataPoints)
            {
                // intialize S1 to Y1
                if (lastPoint == null)
                {
                    newData.Add(dp);
                    lastPoint = dp;
                    continue;
                }

                DataPoint newDp = new DataPoint(dp.t, alpha * dp.v + (1 - alpha) * lastPoint.v);
                newData.Add(newDp);
                lastPoint = newDp;
            }

            return newData;
        }

        protected List<DataPoint> SmoothData(List<DataPoint> dataPoints, SmoothingAlgoritms smoothing)
        {
            if (smoothing == SmoothingAlgoritms.MWA5)
                return MovingWindowAverage(dataPoints, 5);
            else if (smoothing == SmoothingAlgoritms.MWA9)
                return MovingWindowAverage(dataPoints, 9);
            else if (smoothing == SmoothingAlgoritms.MWA13)
                return MovingWindowAverage(dataPoints, 13);
            else if (smoothing == SmoothingAlgoritms.MWA17)
                return MovingWindowAverage(dataPoints, 17);
            else if (smoothing == SmoothingAlgoritms.EMA05)
                return ExponentialMovingAverage(dataPoints, 0.05);
            else if (smoothing == SmoothingAlgoritms.EMA25)
                return ExponentialMovingAverage(dataPoints, 0.25);
            else if (smoothing == SmoothingAlgoritms.EMA50)
                return ExponentialMovingAverage(dataPoints, 0.50);
            else if (smoothing == SmoothingAlgoritms.EMA75)
                return ExponentialMovingAverage(dataPoints, 0.75);
            else if (smoothing == SmoothingAlgoritms.EMA95)
                return ExponentialMovingAverage(dataPoints, 0.95);

            return dataPoints;
        }

        public void DrawChartUpdateStats(Chart chart, ListView stats, GraphTypes type, SmoothingAlgoritms smoothing, DateTime start, DateTime end, string typeFilter, string labelFilter, string addressFilter)
        {
            // filter and smooth our data
            List<DataPoint> dataPoints = SmoothData(BuildDataPoints(type, start, end, typeFilter, labelFilter, addressFilter), smoothing);

            // setup the points
            chart.Series[0].Points.Clear();
            foreach (DataPoint d in dataPoints)
            {
                chart.Series[0].Points.AddXY(d.t.ToOADate(), d.v);
            }

            // setup the axes
            chart.ChartAreas[0].AxisX.Title = "Date";
            switch (type)
            {
                case GraphTypes.CUMULATIVE_SUM:
                    chart.ChartAreas[0].AxisY.Title = "Cumulative Sum";
                    break;
                case GraphTypes.TRANSACTIONS:
                    chart.ChartAreas[0].AxisY.Title = "Transaction Values";
                    break;
                case GraphTypes.RATE:
                    chart.ChartAreas[0].AxisY.Title = "Balance Flow (Coins / Day)";
                    break;
            }

            // and calculate some stats
            stats.Items.Clear();
            if (type == GraphTypes.CUMULATIVE_SUM)
            {
                double min = double.MaxValue, max = double.MinValue;
                foreach (DataPoint dp in dataPoints)
                {
                    if (dp.v < min)
                        min = dp.v;
                    if (dp.v > max)
                        max = dp.v;
                }

                double totalDays = (dataPoints.Last().t - dataPoints.First().t).TotalDays;
                double delta = dataPoints.Last().v - dataPoints.First().v;
                double coinsPerDay = delta / totalDays;

                stats.Items.Add(new ListViewItem(new string[] { "Min", String.Format("{0:n}", min) }));
                stats.Items.Add(new ListViewItem(new string[] { "Max", String.Format("{0:n}", max) }));
                stats.Items.Add(new ListViewItem(new string[] { "Total Days", String.Format("{0:n}", totalDays) }));
                stats.Items.Add(new ListViewItem(new string[] { "Balance Difference", String.Format("{0:n}", delta) }));
                stats.Items.Add(new ListViewItem(new string[] { "Balancer Difference per Day", String.Format("{0:n}", coinsPerDay) }));
            }
            else if (type == GraphTypes.TRANSACTIONS)
            {
                double sum = 0, min = double.MaxValue, max = double.MinValue, varSum = 0;
                foreach (DataPoint dp in dataPoints)
                {
                    sum += dp.v;
                    if (dp.v < min)
                        min = dp.v;
                    if (dp.v > max)
                        max = dp.v;
                }
                double mean = sum / (double)dataPoints.Count;
                foreach (DataPoint dp in dataPoints)
                {
                    varSum += (mean - dp.v) * (mean - dp.v);
                }
                double stdDev = Math.Sqrt(varSum / ((double)dataPoints.Count - 1));

                // update the stats view
                stats.Items.Add(new ListViewItem(new string[] { "Mean", String.Format("{0:n}", mean) }));
                stats.Items.Add(new ListViewItem(new string[] { "Std. Dev.", String.Format("{0:n}", stdDev) }));
                stats.Items.Add(new ListViewItem(new string[] { "Min", String.Format("{0:n}", min) }));
                stats.Items.Add(new ListViewItem(new string[] { "Max", String.Format("{0:n}", max) }));
            }
            else if (type == GraphTypes.RATE)
            {
                // integrate and divide by the time delta to get an appropriate mean rate for this graph
                double sum = 0;
                DataPoint lastPoint = null;
                foreach(DataPoint dp in dataPoints)
                {
                    if (lastPoint == null)
                    {
                        lastPoint = dp;
                        continue;
                    }

                    double v = (dp.v + lastPoint.v) / 2;
                    sum += (dp.t - lastPoint.t).TotalDays * v;
                    lastPoint = dp;
                }

                // calculate the total number of days
                // making sure we don't explode if we don't have enough data
                double totalDays = 1;
                if (dataPoints.Count > 1)
                {
                    totalDays = (dataPoints.Last().t - dataPoints.First().t).TotalDays;
                }

                double mean = sum / totalDays;
                stats.Items.Add(new ListViewItem(new string[] { "Mean", String.Format("{0:n}", mean) }));
            }
        }
    }
}
