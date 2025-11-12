using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class SubmitResponseModel
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string UserID { get; set; }
        public string password { get; set; }
        public int ApplID { get; set; }
    }
}
