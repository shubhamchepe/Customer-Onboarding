using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
     public class BranchModel
    {
        public int BranchListId { get; set; }
        public int BankListId { get; set; }
        public string BankCode { get; set; }
        public string BankShortCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string Address { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string STDCode { get; set; }
        public string Phone { get; set; }
    }
}
