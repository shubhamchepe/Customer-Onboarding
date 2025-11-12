using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class MachineryDetails
    {
        public int MachineryDetailID { get; set; }
        public int ApplID { get; set; }
        public string ApplCode { get; set; }
        public string Particulars { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }
        public object t_ApplicantData { get; set; }
    }
}
