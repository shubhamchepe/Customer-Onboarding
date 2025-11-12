using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class AgencyOfficeModel
    {
        public int AgencyOffID { get; set; }
        public int AgencyTypeId { get; set; }
        public string AgencyOffCode { get; set; }
        public string AgencyOffName { get; set; }
        public string AgencyOffAddress { get; set; }
        public int AgencyOffStateId { get; set; }
        public string AgencyOffState { get; set; }
        public int AgencyOffDistId { get; set; }
        public string AgencyOffDist { get; set; }
        public string AgencyOffContactNo { get; set; }
        public string AgencyOffContactEmail { get; set; }
    }
}
