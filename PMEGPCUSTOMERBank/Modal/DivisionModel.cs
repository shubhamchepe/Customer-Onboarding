using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class DivisionModel
    {
        public int NIC_DataID { get; set; }
        public string NicCode { get; set; }
        public string NicDesc { get; set; }
        public string CreatedOn { get; set; }   // keep as string for now ("/Date(1728888658250)/")
        public bool IsActive { get; set; }
        public string ActivityType { get; set; }
    }
}
