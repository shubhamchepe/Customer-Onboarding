using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class NICModel
    {
        public int NIC_DataID { get; set; }
        public string NicCode { get; set; }
        public string NicDesc { get; set; }
        public bool IsActive { get; set; }
        public string ActivityType { get; set; }
        public bool IsSelected { get; set; }



        // 👇 Add this
        public int SrNo { get; set; }
    }
}
