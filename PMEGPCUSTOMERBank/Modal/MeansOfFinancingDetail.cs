using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class MeansOfFinancingDetail
    {
        public int MeansOfFinancingID { get; set; }
        public int ApplID { get; set; }
        public string ApplCode { get; set; }
        public string Particulars { get; set; }
        public double Percentage { get; set; }
        public string CreatedOn { get; set; }
        public string ModifyOn { get; set; }
    }
}
