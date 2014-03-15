using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletPlot
{
    class DataPoint
    {
        public DateTime t;
        public double v = 0;

        public DataPoint(DateTime t, double v)
        {
            this.t = t;
            this.v = v;
        }

        public DataPoint(string csvString, double v)
        {
            this.t = DateTime.ParseExact(csvString, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
