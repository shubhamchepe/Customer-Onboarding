using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMEGPCUSTOMERBank.Modal
{
    public class DPRData
    {
        public int? UnitActivityType { get; set; }
        public string UnitActivityName { get; set; }
        public string ProdDescr { get; set; }
        public string UnitActivityName2 { get; set; }
        public string ProdDescr2 { get; set; }
        public string UnitActivityName3 { get; set; }
        public string ProdDescr3 { get; set; }

        public List<BuildingDetail> BuildingDetails { get; set; }
        public List<MachineryDetails> MachineryDetails { get; set; }
        public List<WorkingCapitalDetail> WorkingCapitalDetails { get; set; }
        public List<MeansOfFinancingDetail> MeansOfFinancing { get; set; }
        public List<SalesDetail> DetailsOfSales { get; set; }
        public List<RawMaterialDetail> RawMaterials { get; set; }
        public List<WagesDetail> WagesDetails { get; set; }
        public List<SalaryDetail> SalaryDetails { get; set; }

        public List<WorkingCapitalEstimate> WorkingCapitalEstimate { get; set; }
        public List<PowerEstimateExpenditure> PowerEstimateExpenditure { get; set; }

    }

    public class DPRResponse
    {
        public bool success { get; set; }
        public DPRData data { get; set; }
    }
}
