using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class WorkingCapitalDetail
    {
        public int WorkingCapitalID { get; set; }
        public int ApplID { get; set; }
        public string ApplCode { get; set; }
        public string Particulars { get; set; }
        public double Amount { get; set; }
        public string CreatedOn { get; set; }
        public string ModifyOn { get; set; }
    }
}
