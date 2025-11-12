using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal.Login
{
    public class LoginResponse
    {
        public bool status { get; set; }
        public string ApplCode { get; set; }
        public int AppID { get; set; }
        public string message { get; set; }
    }
}
