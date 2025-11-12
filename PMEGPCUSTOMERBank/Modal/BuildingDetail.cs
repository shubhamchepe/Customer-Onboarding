using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class BuildingDetail
    {
        public int BuildingDetailID { get; set; }
        public int ApplID { get; set; }
        public string ApplCode { get; set; }
        public string Particulars { get; set; }
        public double Area { get; set; }
        public double RatePerSqFt { get; set; }
        public double Amount { get; set; }
    }
}
