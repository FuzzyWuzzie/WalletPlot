using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletPlot
{
    class DataLine
    {
        public bool confirmed = false;
        public DateTime date;
        public string type;
        public string label;
        public string address;
        public double amount;
        public string id;

        public DataLine(string fromFile)
        {
            string[] parts = fromFile.Split(new string[] { "\",\"" }, StringSplitOptions.None);

            if (parts.Length != 7)
                throw new FormatException("Incorrect number of fields (" + parts.Length + ") in line '" + fromFile + "'!");

            // start parsing
            if(parts[0].Replace("\"", "") == "true")
                this.confirmed = true;
            this.date = DateTime.ParseExact(parts[1], "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            this.type = (parts[2] == null) ? "" : parts[2];
            this.label = (parts[3] == null) ? "" : parts[3];
            this.address = (parts[4] == null) ? "" : parts[4];
            this.amount = (parts[5] == null) ? 0 : double.Parse(parts[5]);
            this.id = ((parts[6] == null) ? "" : parts[6]).Replace("\"", "");
        }
    }
}
