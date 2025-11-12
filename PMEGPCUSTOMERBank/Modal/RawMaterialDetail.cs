using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class RawMaterialDetail
    {
        public int RawMaterialID { get; set; }
        public int ApplID { get; set; }
        public string ApplCode { get; set; }
        public string Particulars { get; set; }
        public double Unit { get; set; }
        public double RatePerUnit { get; set; }
        public double RequiredUnit { get; set; }
        public double Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }
    }

}
