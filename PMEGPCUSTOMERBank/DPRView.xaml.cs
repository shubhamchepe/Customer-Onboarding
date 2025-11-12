using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMEGPCUSTOMERBank.Modal;
using PMEGPCUSTOMERBank.Util;
using System.Collections.ObjectModel;

namespace PMEGPCUSTOMERBank;

public partial class DPRView : ContentView
{
    private string _machineryTotal;
    private int _applId;
    private string _applCode;

    public string MachineryTotal
    {
        get => _machineryTotal;
        set
        {
            _machineryTotal = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<BuildingRow> BuildingRows { get; set; }
    public ObservableCollection<MachineryRow> MachineryRows { get; set; }
    public ObservableCollection<WorkingCapitalRow> WorkingCapitalRows { get; set; }

    public ObservableCollection<MeansOfFinancingRow> FinancingRows { get; set; }
    public ObservableCollection<SalesRow> SalesRows { get; set; }
    public ObservableCollection<RawMaterialRow> RawMaterialRows { get; set; }
    public ObservableCollection<WagesRow> WagesRows { get; set; }
    public ObservableCollection<SalaryRow> SalaryRows { get; set; }
    public ObservableCollection<WorkingCapitalEstimateRow> WorkingCapitalEstimateRows { get; set; }
    public ObservableCollection<PowerEstimateRow> PowerEstimateRows { get; set; }



    public DPRView()
	{
		InitializeComponent();
        // ✅ 1. Initialize collection FIRST
        // ✅ 1. Initialize first
        BuildingRows = new ObservableCollection<BuildingRow>();
        MachineryRows = new ObservableCollection<MachineryRow>();
        WorkingCapitalRows = new ObservableCollection<WorkingCapitalRow>();
        FinancingRows = new ObservableCollection<MeansOfFinancingRow>();
        SalesRows = new ObservableCollection<SalesRow>();
        RawMaterialRows = new ObservableCollection<RawMaterialRow>();
        WagesRows = new ObservableCollection<WagesRow>();
        SalaryRows = new ObservableCollection<SalaryRow>();
        WorkingCapitalEstimateRows = new ObservableCollection<WorkingCapitalEstimateRow>();
        PowerEstimateRows = new ObservableCollection<PowerEstimateRow>();


        // ✅ 2. Bind context before loading data
        BindingContext = this;

        // ✅ 3. Add 1 test row
        //BuildingRows.Add(new BuildingRow
        //{
        //    SrNo = 1,
        //    Particulars = "Test Building",
        //    Area = "200",
        //    Rate = "1500",
        //    Amount = "300000"
        //});

        // ✅ 4. Load other data (if needed)
        GetDPRData();
        GetDPRMasterData();
      //  LoadSchemes();
       // SaveDPRData();

    }
    private async Task LoadSchemes()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetUnitTypeActivity";

        string response = await HttpClientClass.GetStateAsyncTask(apiUrl);

        var schemeList = JsonConvert.DeserializeObject<List<SchemeModel>>(response);

        if (schemeList != null && schemeList.Count > 0)
        {
            // Insert default option at top
            schemeList.Insert(0, new SchemeModel { SchemeName = "Select Scheme" });

            schemePicker.ItemsSource = schemeList;
            schemePicker.SelectedIndex = 0;
        }
        else
        {
           // await DisplayAlert("Error", "No schemes found", "OK");
        }
    }


    private void AddWorkingCapitalEstimateRow_Clicked(object sender, EventArgs e)
    {
        WorkingCapitalEstimateRows.Add(new WorkingCapitalEstimateRow
        {
            SrNo = WorkingCapitalEstimateRows.Count + 1
        });
    }

    private void DeleteWorkingCapitalEstimateRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is WorkingCapitalEstimateRow row)
        {
            WorkingCapitalEstimateRows.Remove(row);
            for (int i = 0; i < WorkingCapitalEstimateRows.Count; i++)
                WorkingCapitalEstimateRows[i].SrNo = i + 1;
        }
    }
    private void AddSalaryRow_Clicked(object sender, EventArgs e)
    {
        SalaryRows.Add(new SalaryRow
        {
            SrNo = SalaryRows.Count + 1
        });
    }

    private void DeleteSalaryRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is SalaryRow row)
        {
            SalaryRows.Remove(row);
            for (int i = 0; i < SalaryRows.Count; i++)
                SalaryRows[i].SrNo = i + 1;
        }
    }
    private void AddWagesRow_Clicked(object sender, EventArgs e)
    {
        WagesRows.Add(new WagesRow
        {
            SrNo = WagesRows.Count + 1
        });
    }

    private void DeleteWagesRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is WagesRow row)
        {
            WagesRows.Remove(row);
            for (int i = 0; i < WagesRows.Count; i++)
                WagesRows[i].SrNo = i + 1;
        }
    }
    private void AddMachineryRow_Clicked(object sender, EventArgs e)
    {
        MachineryRows.Add(new MachineryRow
        {
            SrNo = MachineryRows.Count + 1
        });
        UpdateMachineryTotal();
    }

    private void DeleteMachineryRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is MachineryRow row)
        {
            MachineryRows.Remove(row);

            // Update SrNo after deletion
            for (int i = 0; i < MachineryRows.Count; i++)
                MachineryRows[i].SrNo = i + 1;

            UpdateMachineryTotal();
        }
    }

    private void UpdateMachineryTotal()
    {
        double total = MachineryRows.Sum(r => r.Amount);
        MachineryTotal = total.ToString("0.00");
    }

    private void DeleteRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is BuildingRow row)
        {
            BuildingRows.Remove(row);

            // Update SrNo after deletion
            for (int i = 0; i < BuildingRows.Count; i++)
            {
                BuildingRows[i].SrNo = i + 1;
            }
        }
    }

    private void AddRow_Clicked(object sender, EventArgs e)
    {
        BuildingRows.Add(new BuildingRow
        {
            SrNo = BuildingRows.Count + 1
        });
    }
    private void AddSalesRow_Clicked(object sender, EventArgs e)
    {
        SalesRows.Add(new SalesRow
        {
            SrNo = SalesRows.Count + 1
        });
    }

    private void DeleteSalesRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is SalesRow row)
        {
            SalesRows.Remove(row);

            // Reset SrNo
            for (int i = 0; i < SalesRows.Count; i++)
                SalesRows[i].SrNo = i + 1;
        }
    }

    private void AddRawMaterialRow_Clicked(object sender, EventArgs e)
    {
        RawMaterialRows.Add(new RawMaterialRow
        {
            SrNo = RawMaterialRows.Count + 1
        });
    }

    private void DeleteRawMaterialRow_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is RawMaterialRow row)
        {
            RawMaterialRows.Remove(row);

            for (int i = 0; i < RawMaterialRows.Count; i++)
                RawMaterialRows[i].SrNo = i + 1;
        }
    }

    private async void GetDPRMasterData()
    {
        try
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetSavedDPRMasterData";
            int AppID = 19645;

            var payload = new { ApplID = AppID };
            string jsonString = JsonConvert.SerializeObject(payload);

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var result = JsonConvert.DeserializeObject<DPRResponse>(response);

            if (result?.success == true && result.data != null && result.data.BuildingDetails.Any())
            {
                // ===== Building Rows =====
                BuildingRows.Clear();
                int srNo = 1;
                if (result.data.BuildingDetails != null)
                {
                    // ✅ Store ApplID and ApplCode from first row
                    _applId = result.data.BuildingDetails[0].ApplID;
                    _applCode = result.data.BuildingDetails[0].ApplCode;

                    foreach (var b in result.data.BuildingDetails)
                    {
                        BuildingRows.Add(new BuildingRow
                        {
                            SrNo = srNo++,
                            Particulars = b.Particulars,
                            Area = b.Area.ToString(),
                            Rate = b.RatePerSqFt.ToString(),
                            Amount = b.Amount.ToString()
                        });
                    }
                }

                // ===== Machinery Rows =====
                MachineryRows.Clear();
                srNo = 1;
                if (result.data.MachineryDetails != null)
                {
                    foreach (var m in result.data.MachineryDetails)
                    {
                        MachineryRows.Add(new MachineryRow
                        {
                            SrNo = srNo++,
                            Particulars = m.Particulars,
                            Quantity = m.Quantity,
                            Rate = m.Rate,
                            Amount = m.Amount
                        });
                    }
                }

                // ===== Update Machinery Total =====
                UpdateMachineryTotal();

                // ===== Working Capital Rows =====
                WorkingCapitalRows.Clear();
                srNo = 1;
                if (result.data.WorkingCapitalDetails != null)
                {
                    foreach (var w in result.data.WorkingCapitalDetails)
                    {
                        WorkingCapitalRows.Add(new WorkingCapitalRow
                        {
                            SrNo = srNo++,
                            Particulars = w.Particulars,
                            Amount = w.Amount
                        });
                    }
                }
                // =====  Means of Financing =====
                FinancingRows.Clear();
                srNo = 1;
                if (result.data.MeansOfFinancing != null)
                {
                    foreach (var w in result.data.MeansOfFinancing)
                    {
                        FinancingRows.Add(new MeansOfFinancingRow
                        {
                            SrNo = srNo++,
                            Particulars = w.Particulars,
                            Percentage = w.Percentage
                        });
                    }
                }

                // ===== Sales Rows =====
                SalesRows.Clear();
                srNo = 1;
                if (result.data.DetailsOfSales != null)
                {
                    foreach (var s in result.data.DetailsOfSales)
                    {
                        SalesRows.Add(new SalesRow
                        {
                            SrNo = srNo++,
                            Particulars = s.Particulars,
                            RatePerUnit = s.RatePerUnit,
                            Quantity = s.Quantity,
                            Amount = s.Amount
                        });
                    }
                }

                // ===== Raw Material Rows =====
                RawMaterialRows.Clear();
                srNo = 1;
                if (result.data.RawMaterials != null)
                {
                    foreach (var r in result.data.RawMaterials)
                    {
                        RawMaterialRows.Add(new RawMaterialRow
                        {
                            SrNo = srNo++,
                            Particulars = r.Particulars,
                            Unit = r.Unit,
                            RatePerUnit = r.RatePerUnit,
                            RequiredUnit = r.RequiredUnit,
                            Amount = r.Amount
                        });
                    }
                }
                // ===== Wages Rows =====
                WagesRows.Clear();
                srNo = 1;
                if (result.data.WagesDetails != null)
                {
                    foreach (var w in result.data.WagesDetails)
                    {
                        WagesRows.Add(new WagesRow
                        {
                            SrNo = srNo++,
                            Particulars = w.Particulars,
                            NoOfWorkers = w.NoOfWorkers,
                            WagesPerMonth = w.WagesPerMonth,
                            Amount = w.Amount
                        });
                    }
                }
                // ===== Salary Rows =====
                SalaryRows.Clear();
                srNo = 1;
                if (result.data.SalaryDetails != null)
                {
                    foreach (var s in result.data.SalaryDetails)
                    {
                        SalaryRows.Add(new SalaryRow
                        {
                            SrNo = srNo++,
                            Particulars = s.Particulars,
                            NoOfStaff = s.NoOfStaff,
                            WagesPerMonth = s.WagesPerMonth,
                            Amount = s.Amount
                        });
                    }
                }

                // ===== Working Capital Estimate Rows =====
                WorkingCapitalEstimateRows.Clear();
                srNo = 1;
                if (result.data.WorkingCapitalEstimate != null)
                {
                    foreach (var wc in result.data.WorkingCapitalEstimate)
                    {
                        WorkingCapitalEstimateRows.Add(new WorkingCapitalEstimateRow
                        {
                            SrNo = srNo++,
                            Particulars = wc.Particulars,
                            NoOfDays = wc.NoOfDays
                        });
                    }
                }
                PowerEstimateRows.Clear();
                srNo = 1;
                if (result.data.PowerEstimateExpenditure != null)
                {
                    foreach (var p in result.data.PowerEstimateExpenditure)
                    {
                        PowerEstimateRows.Add(new PowerEstimateRow
                        {
                            SrNo = srNo++,
                            PowerEstimateID = p.PowerEstimateID,
                            ApplID = p.ApplID,
                            ApplCode = p.ApplCode,
                            Particulars = p.Particulars,
                            Cost = p.Cost,
                            AmountInRs = p.AmountInRs,
                            CreatedOn = p.CreatedOn,
                            ModifyOn = p.ModifyOn
                        });
                    }
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Info", "No data found", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void GetDPRData()
    {
        try
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetDprData";
            int AppID = 19645;

            var payload = new { ApplID = AppID };
            string jsonString = JsonConvert.SerializeObject(payload);

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var result = JsonConvert.DeserializeObject<DPRResponse>(response);

            if (result?.success == true && result.data != null)
            {
                var data = result.data;

                // ✅ Create List
                var nicList = new List<NICActivity>();

                if (!string.IsNullOrEmpty(data.UnitActivityName) && !string.IsNullOrEmpty(data.ProdDescr))
                {
                    nicList.Add(new NICActivity
                    {
                        SrNo = 1,
                        NICCode = data.UnitActivityName,
                        ProductDescription = data.ProdDescr
                    });
                }

                if (!string.IsNullOrEmpty(data.UnitActivityName2) && !string.IsNullOrEmpty(data.ProdDescr2))
                {
                    nicList.Add(new NICActivity
                    {
                        SrNo = 2,
                        NICCode = data.UnitActivityName2,
                        ProductDescription = data.ProdDescr2
                    });
                }

                if (!string.IsNullOrEmpty(data.UnitActivityName3) && !string.IsNullOrEmpty(data.ProdDescr3))
                {
                    nicList.Add(new NICActivity
                    {
                        SrNo = 3,
                        NICCode = data.UnitActivityName3,
                        ProductDescription = data.ProdDescr3
                    });
                }

                // ✅ Bind to CollectionView
                nicCollection.ItemsSource = nicList;
                 // ✅ Load schemes and auto-select based on UnitActivityName
                await LoadSchemesAndSelect((int)data.UnitActivityType);
               // await LoadSchemesAndSelect(1);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No data found", "OK");
            }
        }
        catch (Exception ex)
        {
           // await Application.Current.MainPage.DisplayAlert("Exception", ex.Message, "OK");
        }
    }
    private async Task LoadSchemesAndSelect(int? unitActivityType)
    {
        // 🛑 If unitActivityType is null, skip everything
        if (unitActivityType == null)
            return;
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetUnitTypeActivity";

        string response = await HttpClientClass.GetStateAsyncTask(apiUrl);

        var schemeList = JsonConvert.DeserializeObject<List<SchemeModel>>(response);

        if (schemeList != null && schemeList.Count > 0)
        {
            // Insert default item
            schemeList.Insert(0, new SchemeModel { SchemeName = "Select Scheme", SchemeCode = null });

            schemePicker.ItemsSource = schemeList;

            // Match SchemeCode with UnitActivityName (e.g., "05101")
            var selectedScheme = schemeList.FirstOrDefault(s => s.ActivityTyp == unitActivityType);

            if (selectedScheme != null)
            {
                schemePicker.SelectedItem = selectedScheme;
            }
            else
            {
                schemePicker.SelectedIndex = 0;
            }
        }
    }

    private async void SaveDPRData(object sender, EventArgs e)
    {
        try
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/SaveDPRData";
            int applId = _applId;
            string applCode = _applCode;

        // DPR Detail
        var dprDetail = new[]
        {
        new
        {
            ApplID = applId,
            ApplCode = applCode,
            OnBuilding = OnBuildingEntry.Text,
            OnMachinery = OnMachineryEntry.Text,
            Land = LandEntry.Text,
            PowerRequirement = powerRequirement.Text,
            RateOfInterest = rateofinterest.Text,
            Introduction = "745",
            AboutBeneficiary = "575",
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null,
            PayBackPeriod = PayBackPeriodEntry.Text,
            ProjectImplementationPeriod = ProjectImplementationEntry.Text,
            IntroductionOffice = "5245",
            AboutThePromoter = "7452"
        }
    };

        // Applicant
        var applicant = new[]
        {
        new
        {
            ApplID = applId,
            ApplCode = applCode,
            IsDPRVerified = true
        }
    };

        // Building Details
        var buildingDetails = BuildingRows.Select(row =>
        {
            double.TryParse(row.Area, out double area);
            double.TryParse(row.Rate, out double rate);
            double amount = area * rate;

            return new
            {
                ApplID = applId,
                ApplCode = applCode,
                Particulars = row.Particulars ?? "",
                Area = area,
                RatePerSqFt = rate,
                Amount = amount,
                CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                ModifyOn = (string)null
            };
        }).ToList();

        // Machinery Details
        var machineryDetails = MachineryRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            Quantity = row.Quantity,
            Rate = row.Rate,
            Amount = row.Amount,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Working Capital Details
        var workingCapitalDetails = WorkingCapitalRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            Amount = row.Amount,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Means of Financing
        var financingDetails = FinancingRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            Percentage = row.Percentage,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Sales Details
        var salesDetails = SalesRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            RatePerUnit = row.RatePerUnit,
            Quantity = row.Quantity,
            Amount = row.Amount,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Raw Materials
        var rawMaterialDetails = RawMaterialRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            Unit = row.Unit,
            RatePerUnit = row.RatePerUnit,
            RequiredUnit = row.RequiredUnit,
            Amount = row.Amount,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Wages Details
        var wagesDetails = WagesRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            NoOfWorkers = row.NoOfWorkers,
            WagesPerMonth = row.WagesPerMonth,
            Amount = row.Amount,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Salary Details
        var salaryDetails = SalaryRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            NoOfStaff = row.NoOfStaff,
            WagesPerMonth = row.WagesPerMonth,
            Amount = row.Amount,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Working Capital Estimate
        var workingCapitalEstimateDetails = WorkingCapitalEstimateRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            NoOfDays = row.NoOfDays,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Power Estimate Expenditure
        var powerEstimateDetails = PowerEstimateRows.Select(row => new
        {
            ApplID = applId,
            ApplCode = applCode,
            Particulars = row.Particulars ?? "",
            Cost = row.Cost,
            AmountInRs = row.AmountInRs,
            CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            ModifyOn = (string)null
        }).ToList();

        // Combine payload
        var payload = new
        {
            DPRDetail = dprDetail,
            Applicant = applicant,
            BuildingDetails = buildingDetails,
            MachineryDetails = machineryDetails,
            WorkingCapitalDetails = workingCapitalDetails,
            MeansOfFinancing = financingDetails,
            DetailsOfSales = salesDetails,
            RawMaterials = rawMaterialDetails,
            WagesDetails = wagesDetails,
            SalaryDetails = salaryDetails,
            WorkingCapitalEstimate = workingCapitalEstimateDetails,
            PowerEstimateExpenditure = powerEstimateDetails
        };

        // Serialize & send
        string jsonString = JsonConvert.SerializeObject(payload);
        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        var result = JsonConvert.DeserializeObject<DPRResponse>(response); 
            await Application.Current.MainPage.DisplayAlert("API Response", response, "OK");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

   

}
public class WorkingCapitalRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public double Amount { get; set; }
}
public class MachineryRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public int Quantity { get; set; }
    public double Rate { get; set; }
    public double Amount { get; set; }
}

public class BuildingRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public string Area { get; set; }
    public string Rate { get; set; }
    public string Amount { get; set; }
}

public class MeansOfFinancingRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public double Percentage { get; set; }
}
public class RawMaterialRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public double Unit { get; set; }
    public double RatePerUnit { get; set; }
    public double RequiredUnit { get; set; }
    public double Amount { get; set; }
}
public class RawMaterialDetail
{
    public int RawMaterialID { get; set; }
    public int ApplID { get; set; }
    public string ApplCode { get; set; }
    public string Particulars { get; set; }
    public double Unit { get; set; }
    public double RatePerUnit { get; set; }
    public double RequiredUnit { get; set; }
    public double Amount { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifyOn { get; set; }
}
public class WagesRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public int NoOfWorkers { get; set; }
    public double WagesPerMonth { get; set; }
    public double Amount { get; set; }
}
public class SalaryRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public int NoOfStaff { get; set; }
    public double WagesPerMonth { get; set; }
    public double Amount { get; set; }
}
public class WorkingCapitalEstimateRow
{
    public int SrNo { get; set; }
    public string Particulars { get; set; }
    public int NoOfDays { get; set; }
}
