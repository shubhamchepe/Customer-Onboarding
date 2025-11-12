using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class SalesRow
    {
        public int SrNo { get; set; }
        public string Particulars { get; set; }
        public double RatePerUnit { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
    }
}
