using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class PowerEstimateExpenditure
    {
        public int PowerEstimateID { get; set; }
        public int ApplID { get; set; }
        public string ApplCode { get; set; }
        public string Particulars { get; set; }
        public double Cost { get; set; }
        public double AmountInRs { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }
    }
}
