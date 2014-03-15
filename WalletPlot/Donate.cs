using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalletPlot
{
    public partial class Donate : Form
    {
        public Donate()
        {
            InitializeComponent();
        }

        private void copyBTC_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(btcAddress.Text);
        }

        private void copyLTC_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ltcAddress.Text);
        }

        private void copyVTC_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(vtcAddress.Text);
        }

        private void copyDOGE_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dogeAddress.Text);
        }
    }
}
