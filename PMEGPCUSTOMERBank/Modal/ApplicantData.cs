using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class ApplicantData
    {
        public string AadharNo { get; set; }
        public string PANNo { get; set; }
        public string ApplTitle { get; set; }
        public string ApplName { get; set; }
        public string DateofBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string SocialCatID { get; set; }
        public string SpecialCatID { get; set; }
        public string QualID { get; set; }
        public string QualDesc { get; set; }
        public string ComnAddress { get; set; }
        public string ComnStateName { get; set; }
        public int ComnStateID { get; set; }
        public string ComnDistrict { get; set; }
        public string ComnTaluka { get; set; }
        public string ComnPin { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string eMail { get; set; }

        public int AgencyID { get; set; }
        public int StateID { get; set; }
        public int DistID { get; set; }

        public  string UnitAddress { get; set; }
        public  string UnitPin { get; set; }
        public  string lgdCode { get; set; }
        public  string UnitLocation { get; set; }
        public  string Village_Name { get; set; }
        public  string UnitTaluka { get; set; }

        // ✅ Project Information Fields
        public string UnitActivityType { get; set; }
        public string UnitActivityName { get; set; }
        public string ProdDescr { get; set; }
        public string UnitActivityName2 { get; set; }
        public string ProdDescr2 { get; set; }
        public string UnitActivityName3 { get; set; }
        public string ProdDescr3 { get; set; }
        public bool IsEDPTraining { get; set; }
        public string EDPTrainingInst { get; set; }
        public decimal? CapitalExpd { get; set; }
        public decimal? WorkingCapital { get; set; }
        public decimal? TotalProjectCost { get; set; }

        public int Employment { get; set; }

        // ✅ Primary Financing Bank
        public int FinBankID1 { get; set; }
        public string FinBank1 { get; set; }
        public string BankIFSC1 { get; set; }
        public string BankBranch1 { get; set; }
        public string BankAddress1 { get; set; }
        public string BankDist1 { get; set; }

        public int FinBankID2 { get; set; }
        public string FinBank2 { get; set; }
        public string BankIFSC2 { get; set; }
        public string BankBranch2 { get; set; }
        public string BankAddress2 { get; set; }
        public string BankDist2 { get; set; }

        //////////////
        public bool IsAvailCGTMSE {  get; set; }
        public string PMEGPRef { get; set; } 
        public string IsDeclrAccept { get; set; }



    }
    public class ApplicantResponse
    {
        public bool success { get; set; }
        public ApplicantData data { get; set; }
    }
}
