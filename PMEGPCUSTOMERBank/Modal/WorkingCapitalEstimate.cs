using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class WorkingCapitalEstimate
    {
        public int WorkingCapitalEstimateID { get; set; }
        public int ApplID { get; set; }
        public string ApplCode { get; set; }
        public string Particulars { get; set; }
        public int NoOfDays { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }
    }
}
