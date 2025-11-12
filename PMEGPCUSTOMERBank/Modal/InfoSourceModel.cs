using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class InfoSourceModel
    {
        public int LKId { get; set; }
        public string LKMainCode { get; set; }
        public string LKMainDesc { get; set; }
        public string LKShortCode { get; set; }
        public string LKDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
