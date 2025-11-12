using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class SchemeModel
    {
        public int SchemeID { get; set; }
        public string SchemeCode { get; set; }
        public string SchemeName { get; set; }
        public string SchemeDesc { get; set; }
        public int ActivityTyp { get; set; }
        public decimal MaxProjCost { get; set; }
        public string SchemeType { get; set; }
    }
}
