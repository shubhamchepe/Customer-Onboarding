
using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMEGPCUSTOMERBank.Modal;
using PMEGPCUSTOMERBank.PopUp;
using PMEGPCUSTOMERBank.Util;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace PMEGPCUSTOMERBank;

public partial class RegisteredApplicantsDashboard : ContentPage
{
    // ====== Collections for Each Expander ======
    public ObservableCollection<RowData> SalesRows { get; set; }
    public ObservableCollection<RowData> RawMaterialRows { get; set; }
    public ObservableCollection<RowData> WagesRows { get; set; }
    public ObservableCollection<RowData> SalaryRows { get; set; }
    public ObservableCollection<RowData> BuildingRows { get; set; }
    public ObservableCollection<RowData> MachineryRows { get; set; }
    public ObservableCollection<Modal.NICModel> PagedList { get; set; } = new();




    // ====== Totals ======
    private double salesTotal;
    private int isAdharverfied;

    public double SalesTotal { get => salesTotal; set { salesTotal = value; OnPropertyChanged(); } }

    private double rawTotal;
    public double RawTotal { get => rawTotal; set { rawTotal = value; OnPropertyChanged(); } }

    private double wagesTotal;
    public double WagesTotal { get => wagesTotal; set { wagesTotal = value; OnPropertyChanged(); } }

    private double salaryTotal;
    public double SalaryTotal { get => salaryTotal; set { salaryTotal = value; OnPropertyChanged(); } }

    public double buildingTotal;
    public double BuildingTotal { get => buildingTotal; set { buildingTotal = value; OnPropertyChanged(); } }

    private int _agencyID;
    private int agencyOfId;
    private string _selectedAgencyCode;
    private string _selectedAgencyShortCode;
    private int StateCode;
    private int agencyId;
    private int StateId;
    private int DistrictId;
    private int activityType1;

    private int _pageSize = 10;
    private int _currentPage = 1;
    private Popup currentPopup;

    public double machineryTotal { get; set; }
    public double MachineryTotal { get => machineryTotal; set { machineryTotal = value; OnPropertyChanged(); } }

    private List<Modal.NICModel> _allIndustries = new();
    private List<Modal.NICModel> _currentSource = new();
    public ObservableCollection<Modal.NICModel> SelectedIndustries { get; set; }
    public ObservableCollection<InfoSourceModel> InfoSourceList { get; set; } = new ObservableCollection<InfoSourceModel>();
    public ICommand DeleteCommand { get; set; }




    public RegisteredApplicantsDashboard()
    {
        InitializeComponent();
        GetGender();
        GetSocialCategory();
        GetSpecialCategory();
        GetQualification();
        LoadTitles();

        GetState();
        GetAgency();
        LoadSchemes();

        // Init collections
        SalesRows = new ObservableCollection<RowData>();
        RawMaterialRows = new ObservableCollection<RowData>();
        WagesRows = new ObservableCollection<RowData>();
        SalaryRows = new ObservableCollection<RowData>();
        BuildingRows = new ObservableCollection<RowData>();
        MachineryRows = new ObservableCollection<RowData>();



        // Add one row initially
        AddRow(SalesRows, UpdateSalesTotal);
        AddRow(RawMaterialRows, UpdateRawTotal);
        AddRow(WagesRows, UpdateWagesTotal);
        AddRow(SalaryRows, UpdateSalaryTotal);
        AddRow(BuildingRows, UpdateBuildingTotal);
        AddRow(MachineryRows, UpdateMachineryTotal);

        GetApplicantData();
        FetchAgencyDetails(agencyId, StateId, DistrictId);
        GetBankList();
        GetinfoSources();



        SelectedIndustries = new ObservableCollection<Modal.NICModel>();
        DeleteCommand = new Command<Modal.NICModel>(OnDeleteIndustry);
        BindingContext = this;

    }


    private async void UpdateForm(object sender, EventArgs e)
    {
        try
        {

            //string ApplID = AppConstants.ApplID;
            //string ApplCode = AppConstants.ApplCode;

            string ApplID = "22707";
            string ApplCode = "KVMH-2025000465";

            string AadharNo = adharEntry.Text?.Trim();
            var selectedTitle = titlePicker.SelectedItem as TitleModel;

     
            string ApplTitle = selectedTitle.Id;
            string ApplName = txtApplicantName.Text?.Trim();


            string panNo = "AAPSR2820T";
            string DateofBirth = txtDOB.Text?.Trim();
            string Age = txtAge.Text?.Trim();
            string Gender = genderPicker.Text?.Trim();

            var socialCat = socialCategoryPicker.SelectedItem as GenderModel;
            string SocialCatID = socialCat?.LKDescription;

            var specialCat = specialCategoryPicker.SelectedItem as GenderModel;
            string SpecialCatID = specialCat?.LKShortCode;

            string ComnAddress = comnAddressEntry.Text?.Trim();
            string ComnTaluka = talukaEntry.Text?.Trim();
            string ComnDistrict = districtEntry.Text?.Trim();
            string ComnPin = pinEntry.Text?.Trim();
            string MobileNo1 = mobile1Entry.Text?.Trim();
            string MobileNo2 = mobile2Entry.Text?.Trim();
            string eMail = emailEntry.Text?.Trim();

            var selectedState = statePicker.SelectedItem as StateModel;
            int ComnStateID = selectedState?.State_ID ?? 0;
            string ComnStateName = selectedState?.State_Name ?? "";

            string UnitLocation = pickerUnitLocation.SelectedItem?.ToString();
            string UnitAddress = txtUnitAddress.Text?.Trim();
            var selectedSubDistrict = subDistrictPicker.SelectedItem as SubDistrictModel;
            string UnitTaluka = selectedSubDistrict?.SubDistrict_Name;
            var selectedDistrict = districtPicker.SelectedItem as DistrictModel;
            string UnitDistrict = selectedDistrict?.District_Name;
            string UnitPin = txtPincode.Text?.Trim();

            //string selectedActivity = schemePicker.SelectedItem?.ToString();
            //if (selectedActivity == "Manufacturing") unitActivityType = 0;
            //else if (selectedActivity == "Service") unitActivityType = 1;
            var selectedScheme = schemePicker.SelectedItem as SchemeModel;
            string selectedActivity = selectedScheme?.SchemeName;

            string? unitActivityType = null;
            if (selectedActivity == "Manufacturing")
                unitActivityType = "Manufacturing";
            else if (selectedActivity == "Service")
                unitActivityType = "Service";



 

            int IsEDPTraining = edpPicker.SelectedIndex == 1 ? 1 : 0;
            int trainingMode = onlineLayout.IsVisible ? 0 : 1;
            string edpTrainingInst = onlineLayout.IsVisible ? onlineEntry.Text?.Trim() : offlineEntry.Text?.Trim();

            string CapitalExpd = capitalEntry.Text?.Trim();
            string WorkingCapital = workingCapEntry.Text?.Trim();
            string TotalProjectCost = totalCostEntry.Text?.Trim();
            string Employment = employeeEntry.Text?.Trim();

            var stateModel = statePickerforAgency.SelectedItem as StateModel;
            int stateId = stateModel?.State_ID ?? 0;
            string stateCode = stateModel?.Zone_Code;
            //
            string stateName = stateModel?.State_Name;

            var selectedDistrict1 = districtPicker1.SelectedItem as DistrictModel;
            int DistrictId = selectedDistrict1?.District_ID ?? 0;
            string DistrictName = selectedDistrict1?.District_Name ?? "";
            string unitStateCode = selectedDistrict1?.State_Code ?? "";
            string unitStateName = selectedDistrict1?.State_Name ?? "";

            int lgCodeID = (villagePicker.SelectedItem as VillageModel)?.lgdCodeId ?? 0;
            string villageNAme = (villagePicker.SelectedItem as VillageModel)?.Village_Name ?? "";

            string legalType = "INDIVIDUAL";
            int AgencyOfId = agencyOfId;
            var agencyId = _agencyID;
            var AgencyCode = _selectedAgencyCode;
            var nodalcode = _selectedAgencyShortCode;

            var qualification = qualifictionPicker.SelectedItem as GenderModel;
            string qualificationDesc = qualification?.LKDescription;
            string qualificationID = qualification?.LKShortCode;

            var selectedBank = primaryBankPicker.SelectedItem as BankModel;
            int bankID = selectedBank?.BankListId ?? 0;
            string bankName = selectedBank?.BankName ?? string.Empty;
            string ifsc = ifscEntry.Text?.Trim();
            string branchName = branchEntry.Text?.Trim();
            string bankAddress = addressEntry.Text?.Trim();
            string bankDistrict = districtEntryBox1.Text?.Trim();

            var selectedAltBank = primaryBankPicker1.SelectedItem as BankModel;
            int altBankID = selectedAltBank?.BankListId ?? 0;
            string altBankName = selectedAltBank?.BankName ?? string.Empty;
            string altIfsc = altIfscEntry.Text?.Trim();
            string altBranchName = altBranchEntry.Text?.Trim();
            string altBankAddress = altAddressEntry.Text?.Trim();
            string altBankDistrict = altDistrictEntry.Text?.Trim();

            int cgtmseValue = cgtmsePicker.SelectedItem?.ToString() == "Yes" ? 1 : 2;
            //string pmegpInfoText = infoSourcePicker.SelectedItem?.ToString();
            string pmegpInfoText = "";
            if (infoSourcePicker.SelectedItem is InfoSourceModel selectedInfo)
            {
                pmegpInfoText = selectedInfo.LKDescription;

            }
            else
            {
                pmegpInfoText = ""; // fallback if nothing selected
            }

            //var selectedTitle = titlePicker.SelectedItem as TitleModel;
            //string ApplTitle = selectedTitle?.Id;



            string lgdCode = "535843";
            int TrainingMode = 0;





            var formData = new Dictionary<string, object>
        {
            { "ApplID", ApplID },
            { "ApplCode", ApplCode },
            { "AadharNo", AadharNo },
            { "ApplTitle", ApplTitle },
            { "ApplName", ApplName },
            { "AgencyID", agencyId },
            { "AgencyCode", AgencyCode },
            { "StateID", stateId },
            { "State_Name", stateName },
            { "ComnStateID", ComnStateID },
            { "ComnStateName", ComnStateName },
            { "DistID", DistrictId },
            { "DistrictName", DistrictName },
            { "AgencyOffID", AgencyOfId },
            { "LegalType", legalType },
            { "Gender", Gender },
            { "DateofBirth", DateofBirth },
            { "Age", Convert.ToInt32(Age) },
            { "SocialCatID", SocialCatID },
            { "SpecialCatID", SpecialCatID },
            { "QualID", qualificationID },
            { "QualDesc", qualificationDesc },
            { "ComnAddress", ComnAddress },
            { "ComnTaluka", ComnTaluka },
            { "ComnDistrict", ComnDistrict },
            { "ComnPin", ComnPin },
            { "MobileNo1", MobileNo1 },
            { "MobileNo2", MobileNo2 },
            { "eMail", eMail },
            { "PANNo", panNo },
            { "UnitLocation", UnitLocation },
            { "UnitAddress", UnitAddress },
            { "UnitTaluka", UnitTaluka },
            { "Village_Name", villageNAme },
            { "lgdCodeId", lgCodeID },
            { "UnitDistrict", UnitDistrict },
            { "lgdCode", lgdCode },
            { "UnitPin", UnitPin },
            { "UnitActivityType", unitActivityType },
            { "IsEDPTraining", IsEDPTraining },
            { "IsUnitLocationSame", 1 },
            { "EDPTrainingInst", edpTrainingInst },
            { "CapitalExpd", Convert.ToDecimal(CapitalExpd) },
            { "WorkingCapital", Convert.ToDecimal(WorkingCapital) },
            { "TotalProjectCost", Convert.ToDecimal(TotalProjectCost) },
            { "Employment", Convert.ToInt32(Employment) },
            { "FinBankID1", bankID },
            { "FinBank1", bankName },
            { "BankIFSC1", ifsc },
            { "BankBranch1", branchName }, 
            { "BankAddress1", bankAddress },
            { "BankDist1", bankDistrict },
            { "FinBankID2", altBankID },
            { "FinBank2", altBankName },
            { "BankIFSC2", altIfsc },
            { "BankBranch2", altBranchName },
            { "BankAddress2", altBankAddress },
            { "BankDist2", altBankDistrict },
            { "IsAvailCGTMSE", cgtmseValue },
            { "PMEGPRef", pmegpInfoText },
            { "IsAadharVerified", isAdharverfied},
            { "IsPanVerified", 1 },
            { "IsDeclrAccept", 1 },
            { "SchemeID", 1 },
            { "isCharAppliAccepted", 1 },
            { "State_Code", stateId },
            { "StateName", stateName },





        };


            string apiUrl = $"{AppConstants.AppIP}/MobileApp/UpdateApplicantData";
            string json = JsonConvert.SerializeObject(formData);
            string response = await HttpClientClass.PostAsyncTask(apiUrl, json);
            // Parse response
            var result = JsonConvert.DeserializeObject<SubmitResponseModel>(response);
            if (result != null && result.success)
            {
                // Store data in Preferences
                Preferences.Set("UserID", result.UserID);
                Preferences.Set("Password", result.password);
                Preferences.Set("ApplID", result.ApplID);

                AppConstants.UserID = result.UserID;
                AppConstants.Password = result.password;
                AppConstants.ApplID1 = result.ApplID;

                // Show success message
                //await App.Current.MainPage.DisplayAlert("Success", result.message, "OK");
                await App.Current.MainPage.DisplayAlert("Success", "Applicant data updated successfully.", "OK");
            }
            else
            {
                // Show error message from API
                await App.Current.MainPage.DisplayAlert("Error", result?.message ?? "Unknown error", "OK");
            }


        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void DivisionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;

        if (divisionPicker.SelectedItem is DivisionModel selectedDivision && !string.IsNullOrEmpty(selectedDivision.NicCode))
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetNIC_DataLevelTwo";
            string jsonString = $"{{\"NicCode\":\"{selectedDivision.NicCode}\"}}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var groupList = JsonConvert.DeserializeObject<List<GroupModel>>(response);

            if (groupList != null && groupList.Count > 0)
            {
                groupList.Insert(0, new GroupModel { NicDesc = "Select Group" });

                groupPicker.ItemsSource = groupList;
                groupPicker.ItemDisplayBinding = new Binding("NicDesc");
                groupPicker.SelectedIndex = 0;
            }
        }
    }



    private void OnExpanderChanged(object sender, CommunityToolkit.Maui.Core.ExpandedChangedEventArgs e)
    {
        if (sender is not Expander changedExpander)
            return;

        // Dictionary of all expanders and their arrow images
        var expanderArrowMap = new Dictionary<Expander, Image>
    {
        { basicInfoExpander, basicInfoArrow },
        { CommAddForm, commAddrArrow },
        { implementingAgencyExpander, implementingAgencyArrow },
        { unitAddressExpander, unitAddressArrow },
        { projectInfoExpander, projectInfoArrow },
        { primaryBankExpander, primaryBankArrow },
        { alternateBankExpander, alternateBankArrow },
        { otherInfoExpander, otherInfoArrow }
    };

        // Only change the arrow icon of the one that was clicked
        if (expanderArrowMap.TryGetValue(changedExpander, out var arrow))
        {
            arrow.Source = e.IsExpanded ? "upload.png" : "arrow.png";
        }
    }

    private async Task GetinfoSources()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetInformationSource";
        string jsonString = "{\"mainCode\":\"INFOSRC\"}";

        try
        {
            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            if (!string.IsNullOrEmpty(response))
            {
                var infoSources = JsonConvert.DeserializeObject<List<InfoSourceModel>>(response);

                if (infoSources != null && infoSources.Count > 0)
                {
                    InfoSourceList.Clear();

                    // Optionally insert default item
                    InfoSourceList.Add(new InfoSourceModel { LKDescription = "Select Information Source" });

                    foreach (var source in infoSources.Where(s => s.IsActive))
                        InfoSourceList.Add(source);

                    infoSourcePicker.ItemsSource = InfoSourceList;
                    infoSourcePicker.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load information sources: {ex.Message}", "OK");
        }
    }

    private void cgtmsePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cgtmsePicker.SelectedItem?.ToString() == "Yes")
        {
            cgtmseNoteLayout.IsVisible = true;
        }
        else
        {
            cgtmseNoteLayout.IsVisible = false;
        }
    }

    // Primary Financing BAnk // 
    private async Task GetBankList()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetBankList";
        string response = await HttpClientClass.GetStateAsyncTask(apiUrl);

        var bankList = JsonConvert.DeserializeObject<List<BankModel>>(response);

        // Insert default option at the top
        bankList.Insert(0, new BankModel
        {
            BankCode = "",
            BankName = "Select Bank Name",
            BankShortCode = ""
        });

        primaryBankPicker.ItemsSource = bankList;
        primaryBankPicker1.ItemsSource = bankList;


        // ✅ Default select "Select Bank" option
        primaryBankPicker.SelectedIndex = 0;
        primaryBankPicker1.SelectedIndex = 0;



        // string districtCode = selectedDistrict.District_Code;

    }
    private void OnDeleteIndustry(Modal.NICModel industry)
    {
        if (industry != null && SelectedIndustries.Contains(industry))
            SelectedIndustries.Remove(industry);
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
            await DisplayAlert("Error", "No schemes found", "OK");
        }
    }
    private void OnCostChanged(object sender, TextChangedEventArgs e)
    {
        double capital = double.TryParse(capitalEntry.Text, out var cap) ? cap : 0;
        double working = double.TryParse(workingCapEntry.Text, out var work) ? work : 0;
        double total = capital + working;

        totalCostEntry.Text = total.ToString("F2");

        capitalWordsLabel.Text = $"Rupees {NumberToWords((int)capital)} Only";
        workingWordsLabel.Text = $"Rupees {NumberToWords((int)working)} Only";
        totalWordsLabel.Text = $"Rupees {NumberToWords((int)total)} Only";

        // ✅ Auto-set No. of Employees = 1 if capital > 0, else 0
        employeeEntry.Text = capital > 0 ? "1" : "0";
    }

    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0)
            return "Minus " + NumberToWords(Math.Abs(number));

        string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
        "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        string[] tensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "") words += "And ";

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }

        return words.Trim();
    }

    private async void OnSelectIndustryClicked(object sender, EventArgs e)
    {

        var selectedScheme = schemePicker.SelectedItem as SchemeModel;

        //if (selectedScheme == null || selectedScheme.ActivityTyp == 0)
        //{
        //    await DisplayAlert("Error", "Please select an Activity Type first.", "OK");
        //    return;
        //}

        activityType1 = selectedScheme.ActivityTyp;

        // ✅ Get popup from resources
        if (Resources.TryGetValue("IndustryPopup", out var popupObj) && popupObj is Popup originalPopup)
        {
            // ✅ Create new instance with same content
            var popup = new Popup
            {
                Color = originalPopup.Color,
                CanBeDismissedByTappingOutsideOfPopup = originalPopup.CanBeDismissedByTappingOutsideOfPopup,

                // NOTE: Content is reused — if this causes problem, only then clone
                Content = CloneView(originalPopup.Content)

            };

            test(); // if any data initialization needed

            // ✅ Show the popup
            currentPopup = popup; // ✅ store the actual popup shown
            await this.ShowPopupAsync(popup);
        }
    }
    private void LoadPage(int pageNumber)
    {
        _currentPage = pageNumber;
        PagedList.Clear();

        var items = _currentSource.Skip((pageNumber - 1) * _pageSize).Take(_pageSize);

        foreach (var item in items)
            PagedList.Add(item);

        int totalPages = (int)Math.Ceiling((double)_currentSource.Count / _pageSize);
        pageLabel.Text = $"Page {_currentPage} / {(totalPages == 0 ? 1 : totalPages)}";
    }

    private View CloneView(View original)
    {
        // 🟡 Warning: This is only a workaround. Ideally, recreate full layout.
        // But this resets the visual tree properly.
        return new ContentView { Content = original };
    }
    private async Task test()
    {
        BindingContext = this;

        LoadIndustries();  // default list
        LoadDivision();    // division dropdown
    }

    private void OnSelectClicked(object sender, EventArgs e)
    {

        if (currentPopup != null)
            currentPopup.CanBeDismissedByTappingOutsideOfPopup = false;

        var selected = PagedList.Where(x => x.IsSelected)
                                .Select(x => new Modal.NICModel
                                {
                                    NicCode = x.NicCode,
                                    NicDesc = x.NicDesc,
                                    IsSelected = x.IsSelected
                                })
                                .ToList();

        if (selected.Count == 0)
        {
            App.Current.MainPage.DisplayAlert("Error", "Please select at least one industry.", "OK");
            return;
        }

        SelectedIndustries.Clear();
        int srNo = 1;
        foreach (var item in selected)
        {
            item.SrNo = srNo++;
            SelectedIndustries.Add(item);
        }

        // ✅ Close actual popup
        currentPopup?.Close();
        currentPopup = null;
    }


    private void OnEdpPickerChanged(object sender, EventArgs e)
    {
        if (edpPicker.SelectedItem?.ToString() == "Yes")
        {
            edpOptionsLayout.IsVisible = true;   // Show radio buttons
        }
        else
        {
            edpOptionsLayout.IsVisible = false;  // Hide everything
            onlineLayout.IsVisible = false;
            offlineLayout.IsVisible = false;
        }
    }
    private void OnEdpModeChanged(object sender, CheckedChangedEventArgs e)
    {
        var radio = sender as RadioButton;
        if (radio == null || !e.Value) return;

        if (radio.Content.ToString() == "Online EDP")
        {
            onlineLayout.IsVisible = true;
            offlineLayout.IsVisible = false;
        }
        else if (radio.Content.ToString() == "Offline EDP")
        {
            onlineLayout.IsVisible = false;
            offlineLayout.IsVisible = true;
        }
    }

    private async void OnSelectEdpClicked(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;

        string stateCode = (statePickerforAgency.SelectedItem as StateModel)?.State_Code;
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetEDPData";
        string jsonString = $"{{\"stateCode\":\"{stateCode}\"}}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        var result = JsonConvert.DeserializeObject<JObject>(response);
        var offices = result["data"].ToObject<List<EdpOfficeModel>>();

        var popup = new IndustryPopup(offices);
        var selectedOffice = await this.ShowPopupAsync(popup) as EdpOfficeModel;

        if (selectedOffice != null)
        {
            offlineEntry.Text = selectedOffice.Off_Name;
        }
    }


    private async void GroupPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;
        if (groupPicker.SelectedItem is GroupModel selectedGroup && !string.IsNullOrEmpty(selectedGroup.NicCode))
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetNIC_DataLevelThree";
            string jsonString = $"{{\"NicCode\":\"{selectedGroup.NicCode}\"}}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var classList = JsonConvert.DeserializeObject<List<ClassModel>>(response);

            if (classList != null && classList.Count > 0)
            {
                classList.Insert(0, new ClassModel { NicDesc = "Select Class" });

                classPicker.ItemsSource = classList;
                classPicker.ItemDisplayBinding = new Binding("NicDesc");
                classPicker.SelectedIndex = 0;
            }
        }
    }

    private void OnPrevClicked(object sender, EventArgs e)
    {
        if (_currentPage > 1)
            LoadPage(_currentPage - 1);
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        int totalPages = (int)Math.Ceiling((double)_currentSource.Count / _pageSize);
        if (_currentPage < totalPages)
            LoadPage(_currentPage + 1);
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        // reset dropdowns
        divisionPicker.SelectedIndex = 0;  // "Select Division"
        groupPicker.ItemsSource = null;    // group reset
        classPicker.ItemsSource = null;    // class reset
        searchEntry.Text = "";

        // reset data to original list
        _currentSource = _allIndustries;
        LoadPage(1);
    }
    private async void ClassPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;
        if (classPicker.SelectedItem is ClassModel selectedClass && !string.IsNullOrEmpty(selectedClass.NicCode))
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetNIC_DataLevelFour";
            string jsonString = $"{{\"NicCode\":\"{selectedClass.NicCode}\"}}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var industries = JsonConvert.DeserializeObject<List<Modal.NICModel>>(response);

            if (industries != null && industries.Count > 0)
            {
                _currentSource = industries;
                LoadPage(1);
            }
        }
    }

    private async void LoadIndustries()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetNICInitialData";
        string jsonString = $"{{\"ActivityType\":\"{activityType1}\"}}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        _allIndustries = System.Text.Json.JsonSerializer.Deserialize<List<Modal.NICModel>>(response) ?? new List<Modal.NICModel>();

        _currentSource = _allIndustries;   // default data
        LoadPage(1);
    }
    private async void LoadDivision()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetNIC_DataLevelOne";
        string jsonString = $"{{\"ActivityType\":\"{activityType1}\"}}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        var divisionList = JsonConvert.DeserializeObject<List<DivisionModel>>(response);

        if (divisionList != null && divisionList.Count > 0)
        {
            divisionList.Insert(0, new DivisionModel { NicCode = "", NicDesc = "Select Division" });

            divisionPicker.ItemsSource = divisionList;
            divisionPicker.ItemDisplayBinding = new Binding("NicDesc");
            divisionPicker.SelectedIndex = 0;
        }
    }
    // Unit Address
    private async void OnDistrictSelected(object sender, EventArgs e)
    {

        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;

        if (districtPicker.SelectedItem is DistrictModel selectedDistrict)
        {
            string districtCode = selectedDistrict.District_Code;

            // Pass this districtCode to your Sub District API function
            await LoadSubDistricts(districtCode);
        }
    }
   
    private async Task LoadSubDistricts(string districtCode)
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetSubDistricts";
        string jsonString = $"{{\"District_Code\":\"{districtCode}\"}}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        var subDistrictList = JsonConvert.DeserializeObject<List<SubDistrictModel>>(response);

        if (subDistrictList == null || subDistrictList.Count == 0)
        {
            await DisplayAlert("Error", "No sub districts found", "OK");
            return;
        }

        // Insert a default option
        subDistrictList.Insert(0, new SubDistrictModel { SubDistrict_Name = "Select Sub District" });

        // Bind to picker
        subDistrictPicker.ItemsSource = subDistrictList;
        subDistrictPicker.SelectedIndex = 0;
    }

    private async void OnSubDistrictSelected(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;

        if (picker.SelectedItem is SubDistrictModel selectedSubDistrict)
        {
            string subdistrictCode = selectedSubDistrict.SubDistrict_Code;

            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetVillages";
            string jsonString = $"{{\"subDistrictCode\":\"{subdistrictCode}\"}}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
            var villageList = JsonConvert.DeserializeObject<List<VillageModel>>(response);

            if (villageList == null || villageList.Count == 0)
            {
                await DisplayAlert("Error", "No villages found", "OK");
                return;
            }

            // Default option
            villageList.Insert(0, new VillageModel { Village_Name = "Select Village" });

            // Bind to picker
            villagePicker.ItemsSource = villageList;
            villagePicker.SelectedIndex = 0;
        }
    }

    private async Task GetState()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetStates";

        string response = await HttpClientClass.GetStateAsyncTask(apiUrl);

        // Deserialize JSON array into List<StateModel>
        var stateList = JsonConvert.DeserializeObject<List<StateModel>>(response);

        // Insert default option at the top
        stateList.Insert(0, new StateModel { State_Name = "Select State", State_Code = "" });

        // Bind to Picker
        statePicker.ItemsSource = stateList;
        statePicker.ItemDisplayBinding = new Binding("State_Name");
        statePicker.SelectedIndex = 0;

        statePickerforAgency.ItemsSource = stateList;
        statePickerforAgency.ItemDisplayBinding = new Binding("State_Name");
        statePickerforAgency.SelectedIndex = 0;


    }
    private async Task GetAgency()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetAgency";

        string response = await HttpClientClass.GetStateAsyncTask(apiUrl);

        // ✅ Deserialize into AgencyModel list
        var agencyList = JsonConvert.DeserializeObject<List<AgencyModel>>(response);

        // Insert default option at top
        agencyList.Insert(0, new AgencyModel { Agency_ID = 0, Agency_Code = "Select Implementing Agency" });

        // Bind to Picker
        agencyPicker.ItemsSource = agencyList;
        agencyPicker.ItemDisplayBinding = new Binding("Agency_Code");

        // Set default index
        agencyPicker.SelectedIndex = 0;
    }
    private async void GetApplicantData()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetApplicantData";
        int AppID = 22707;

        var payload = new { ApplID = AppID };
        string jsonString = JsonConvert.SerializeObject(payload);

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
        var result = JsonConvert.DeserializeObject<ApplicantResponse>(response);

        if (result != null && result.success && result.data != null)
        {
            var data = result.data;

            agencyId = data.AgencyID;
            StateId = data.StateID;
            DistrictId = data.DistID;

            // Basic Info
            adharEntry.Text = data.AadharNo;
            pancardNo.Text = data.PANNo;
            txtApplicantName.Text = data.ApplName;
            txtDOB.Text = ConvertJsonDateToDate(data.DateofBirth)?.ToString("dd-MM-yyyy") ?? "";
            txtAge.Text = data.Age.ToString();
            genderPicker.Text = data.Gender;

            // Title
            if (!string.IsNullOrEmpty(data.ApplTitle) && titlePicker.ItemsSource is List<TitleModel> titleList)
            {
                var selectedTitle = titleList.FirstOrDefault(t => t.Id == data.ApplTitle);
                if (selectedTitle != null)
                    titlePicker.SelectedItem = selectedTitle;
            }

            await Task.Delay(200); // Ensure pickers are loaded

            // Social, Special, Qualification
            SelectPickerItemByLKDescription(socialCategoryPicker, data.SocialCatID);
            SelectPickerItemByShortCode(specialCategoryPicker, data.SpecialCatID);
            SelectPickerItemByLKDescription(qualifictionPicker, data.QualDesc);

            // Communication Address
            comnAddressEntry.Text = data.ComnAddress;
            talukaEntry.Text = data.ComnTaluka;
            districtEntry.Text = data.ComnDistrict;
            pinEntry.Text = data.ComnPin;
            mobile1Entry.Text = data.MobileNo1;
            mobile2Entry.Text = data.MobileNo2;
            emailEntry.Text = data.eMail;

            // Communication State
            SelectStateByName(statePicker, data.ComnStateName);

            // ✅ Implementing Agency
            if (agencyPicker.ItemsSource is List<AgencyModel> agencyList)
            {
                var selectedAgency = agencyList.FirstOrDefault(a => a.Agency_ID == data.AgencyID);
                if (selectedAgency != null)
                    agencyPicker.SelectedItem = selectedAgency;
            }

            // ✅ Implementing State and District
            if (statePickerforAgency.ItemsSource is List<StateModel> agencyStates)
            {
                var selectedState = agencyStates.FirstOrDefault(s => s.State_Code == data.StateID.ToString());
                if (selectedState != null)
                {
                    statePickerforAgency.SelectedItem = selectedState;

                    string stateCode = selectedState.State_Code;
                    string distApi = $"{AppConstants.AppIP}/MobileApp/GetDistricts";
                    string distPayload = $"{{\"State_Code\":\"{stateCode}\"}}";

                    string districtResponse = await HttpClientClass.PostAsyncTask(distApi, distPayload);
                    var districtList = JsonConvert.DeserializeObject<List<DistrictModel>>(districtResponse);

                    districtList.Insert(0, new DistrictModel { District_Name = "Select District", District_Code = "" });

                    // Bind to both district pickers
                    districtPicker1.ItemsSource = districtList;
                    districtPicker1.ItemDisplayBinding = new Binding("District_Name");

                    districtPicker.ItemsSource = districtList;
                    districtPicker.ItemDisplayBinding = new Binding("District_Name");

                    var selectedDistrict = districtList.FirstOrDefault(d => d.District_ID == data.DistID);
                    if (selectedDistrict != null)
                    {
                        districtPicker1.SelectedItem = selectedDistrict;
                        districtPicker.SelectedItem = selectedDistrict;

                        // ✅ Load sub-districts
                        await LoadSubDistricts(selectedDistrict.District_Code);

                        if (!string.IsNullOrEmpty(data.UnitTaluka) && subDistrictPicker.ItemsSource is List<SubDistrictModel> subDistrictList)
                        {
                            var selectedSubDistrict = subDistrictList.FirstOrDefault(sd =>
                                sd.SubDistrict_Name.Trim().Equals(data.UnitTaluka.Trim(), StringComparison.OrdinalIgnoreCase));

                            if (selectedSubDistrict != null)
                            {
                                subDistrictPicker.SelectedItem = selectedSubDistrict;

                                // ⏳ Wait briefly to ensure OnSubDistrictSelected() populates the village list
                                await Task.Delay(300); // ← enough to allow villages to load (adjust if needed)

                                // ✅ Select Village by Name
                                if (!string.IsNullOrEmpty(data.Village_Name) && villagePicker.ItemsSource is List<VillageModel> villageList)
                                {
                                    var matchedVillage = villageList.FirstOrDefault(v =>
                                        v.Village_Name.Trim().Equals(data.Village_Name.Trim(), StringComparison.OrdinalIgnoreCase));

                                    if (matchedVillage != null)
                                    {
                                        villagePicker.SelectedItem = matchedVillage;
                                    }
                                }
                            }

                    
                        }
                    }
                }
            }

            // ✅ Unit Address Details
            txtUnitAddress.Text = data.UnitAddress;
            txtPincode.Text = data.UnitPin;
            txtLGDCode.Text = data.lgdCode;

            // ✅ Unit Location
            if (!string.IsNullOrEmpty(data.UnitLocation))
            {
                var matchingLocation = pickerUnitLocation.Items.FirstOrDefault(loc =>
                    loc.ToString().Equals(data.UnitLocation, StringComparison.OrdinalIgnoreCase));

                if (matchingLocation != null)
                    pickerUnitLocation.SelectedItem = matchingLocation;
            }


            // ✅ NIC Codes (loop through 3 possible codes)
            SelectedIndustries.Clear();
            var nicCodes = new List<(string? code, string? desc)>
        {
            (data.UnitActivityName, data.ProdDescr),
            (data.UnitActivityName2, data.ProdDescr2),
            (data.UnitActivityName3, data.ProdDescr3)
        };

            int srNo = 1;
            foreach (var (code, desc) in nicCodes)
            {
                if (!string.IsNullOrWhiteSpace(code) && !string.IsNullOrWhiteSpace(desc))
                {
                    SelectedIndustries.Add(new Modal.NICModel
                    {
                        SrNo = srNo++,
                        NicCode = code,
                        NicDesc = desc,
                        IsSelected = true
                    });
                }
            }

            // ✅ Capital / Working / Total Cost
            capitalEntry.Text = data.CapitalExpd.ToString() ?? "0";
            workingCapEntry.Text = data.WorkingCapital.ToString() ?? "0";
            totalCostEntry.Text = data.TotalProjectCost.ToString() ?? "0";

            capitalWordsLabel.Text = ConvertToWords(data.CapitalExpd ?? 0) + " Only";
            workingWordsLabel.Text = ConvertToWords(data.WorkingCapital ?? 0) + " Only";
            totalWordsLabel.Text = ConvertToWords(data.TotalProjectCost ?? 0) + " Only";

            // ✅ Type of Activity (Manufacturing/Service)
            if (schemePicker.ItemsSource is List<SchemeModel> schemes)
            {
                if (data.UnitActivityType == "0")
                    schemePicker.SelectedItem = schemes.FirstOrDefault(s => s.SchemeName == "Manufacturing");
                else if (data.UnitActivityType == "1")
                    schemePicker.SelectedItem = schemes.FirstOrDefault(s => s.SchemeName == "Service");
            }

            // ✅ EDP Training Mode
            if (data.IsEDPTraining == true)
            {
                edpPicker.SelectedIndex = 1;
                edpOptionsLayout.IsVisible = true;

                if (data.EDPTrainingInst?.Contains("Samadhan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    onlineLayout.IsVisible = true;
                    offlineLayout.IsVisible = false;
                    onlineEntry.Text = data.EDPTrainingInst;

                    // ✅ CHECK Online EDP radio button
                    radioOnlineEDP.IsChecked = true;
                }
                else
                {
                    onlineLayout.IsVisible = false;
                    offlineLayout.IsVisible = true;
                    offlineEntry.Text = data.EDPTrainingInst;

                    // ✅ CHECK Offline EDP radio button
                    radioOfflineEDP.IsChecked = true;
                }
            }
            else
            {
                edpPicker.SelectedIndex = 2;
                edpOptionsLayout.IsVisible = false;
                onlineLayout.IsVisible = false;
                offlineLayout.IsVisible = false;
                // ✅ Uncheck both EDP modes just in case
                radioOnlineEDP.IsChecked = false;
                radioOfflineEDP.IsChecked = false;
            }


            // ✅ EDP Training Mode
            if (data.IsEDPTraining == true)
            {
                edpPicker.SelectedIndex = 1;
                edpOptionsLayout.IsVisible = true;

                if (data.EDPTrainingInst?.Contains("Samadhan", StringComparison.OrdinalIgnoreCase) == true)
                {
                    onlineLayout.IsVisible = true;
                    offlineLayout.IsVisible = false;
                    onlineEntry.Text = data.EDPTrainingInst;
                }
                else
                {
                    onlineLayout.IsVisible = false;
                    offlineLayout.IsVisible = true;
                    offlineEntry.Text = data.EDPTrainingInst;
                }
            }
            else
            {
                edpPicker.SelectedIndex = 2;
                edpOptionsLayout.IsVisible = false;
                onlineLayout.IsVisible = false;
                offlineLayout.IsVisible = false;
            }

            // ✅ Employment
            employeeEntry.Text = data.Employment.ToString() ?? "0";


            // ✅ Primary Financing Bank
            if (primaryBankPicker.ItemsSource is List<BankModel> bankList)
            {
                var selectedBank = bankList.FirstOrDefault(b => b.BankListId == data.FinBankID1);
                if (selectedBank != null)
                {
                    primaryBankPicker.SelectedItem = selectedBank;
                }
            }

            ifscEntry.Text = data.BankIFSC1;
            branchEntry.Text = data.BankBranch1;
            addressEntry.Text = data.BankAddress1;
            districtEntryBox1.Text = data.BankDist1;

            // Alternate 
            if (primaryBankPicker.ItemsSource is List<BankModel> bankList1)
            {
                var selectedBank = bankList1.FirstOrDefault(b => b.BankListId == data.FinBankID2);
                if (selectedBank != null)
                {
                    primaryBankPicker1.SelectedItem = selectedBank;
                }
            }

            altIfscEntry.Text = data.BankIFSC1;
            altBranchEntry.Text = data.BankBranch2;
            altAddressEntry.Text = data.BankAddress2;
            altDistrictEntry.Text = data.BankDist2;

            // 🔹 Set CGTMSE Picker
            if (data.IsAvailCGTMSE != null)
            {
                // Index: 0 = "Select", 1 = "Yes", 2 = "No"
                cgtmsePicker.SelectedIndex = data.IsAvailCGTMSE == true ? 1 : 2;

                // Show the CGTMSE note layout if Yes is selected
                cgtmseNoteLayout.IsVisible = data.IsAvailCGTMSE == true;
            }

            // 🔹 Set PMEGP Info Source Picker
            if (!string.IsNullOrEmpty(data.PMEGPRef) && infoSourcePicker.ItemsSource is List<InfoSourceModel> sourceList)
            {
                var matchedSource = sourceList.FirstOrDefault(x =>
                    x.LKDescription.Equals(data.PMEGPRef, StringComparison.OrdinalIgnoreCase));

                if (matchedSource != null)
                    infoSourcePicker.SelectedItem = matchedSource;
            }



            int retries = 10;
            while (infoSourcePicker.ItemsSource == null && retries-- > 0)
            {
                await Task.Delay(100); // wait up to 1 second total
            }

            if (!string.IsNullOrWhiteSpace(data.PMEGPRef) &&
                infoSourcePicker.ItemsSource is IEnumerable<InfoSourceModel> sourceList1)
            {
                var matched = sourceList1.FirstOrDefault(x =>
                    x.LKDescription.Equals(data.PMEGPRef.Trim(), StringComparison.OrdinalIgnoreCase));

                if (matched != null)
                {
                    infoSourcePicker.SelectedItem = matched;
                }
                else
                {
                    var customItem = new InfoSourceModel
                    {
                        LKDescription = data.PMEGPRef.Trim()
                    };

                    // Convert to List to allow Add()
                    var updatedList = sourceList1.ToList();
                    updatedList.Add(customItem);

                    // Refresh the picker
                    infoSourcePicker.ItemsSource = null;
                    infoSourcePicker.ItemsSource = updatedList;
                    infoSourcePicker.SelectedItem = customItem;
                }
            }



        }
    }


    private async void OnSelectBankIfscClicked(object sender, EventArgs e)
    {
        // Check Bank selection
        if (primaryBankPicker.SelectedItem is not BankModel selectedBank)
        {
            await DisplayAlert("Alert", "Please select a Bank first.", "OK");
            return;
        }

        // Check District selection
        if (districtPicker1.SelectedItem is not DistrictModel selectedDistrict)
        {
            await DisplayAlert("Alert", "Please select a District first.", "OK");
            return;
        }

        string bankId = selectedBank.BankListId.ToString();
        string districtName = selectedDistrict.District_Name;
        //string bankId = "1";
        //string districtName = "Nagpur";

        // API URL
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetBranchListData";

        // Prepare JSON
        string jsonString = $"{{\"bankListId\":\"{bankId}\", \"CityName\":\"{districtName}\"}}";

        try
        {
            // Call API
            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            if (!string.IsNullOrEmpty(response))
            {
                var branchList = JsonConvert.DeserializeObject<List<BranchModel>>(response);

                if (branchList != null && branchList.Count > 0)
                {
                    var firstBranch = branchList[0]; // ✅ You can also show a list to pick

                    // Auto-fill entries
                    ifscEntry.Text = firstBranch.IFSCCode;
                    branchEntry.Text = firstBranch.BranchName;
                    addressEntry.Text = firstBranch.Address;
                    districtEntryBox1.Text = firstBranch.CityName;
                }
                else
                {
                    await DisplayAlert("Alert", "No branch found for selected Bank and District.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "No data received from server.", "OK");
            }

        
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Something went wrong: {ex.Message}", "OK");
        }
    }

    private string ConvertToWords(decimal number)
    {
        return number == 0 ? "Rupees Zero" : $"Rupees {number}";
    }
    // Agency Picker
    private async void AgencyPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;

        var selectedAgency = (AgencyModel)agencyPicker.SelectedItem;
        int agencyTypeId = selectedAgency.Agency_ID;

    }
    private async Task FetchAgencyDetails(int agencyId, int stateId, int districtId)
    {
     


        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetAgencyOffDetails";

        // JSON string manually
        string jsonString = $"{{\"agencyTypeId\":\"{agencyId}\", \"agencyOffStateID\":\"{stateId}\", \"agencyOffDistId\":\"{districtId}\"}}";

        try
        {
            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
            var agencyDetails = JsonConvert.DeserializeObject<List<AgencyDetailModel>>(response);

            if (agencyDetails != null && agencyDetails.Count > 0)
            {
                var detail = agencyDetails[0];
                agencyOfId = detail.AgencyOffID;
                agencyNameLabel.Text = $"Agency: {detail.AgencyOffName}";
                agencyDistrictLabel.Text = $"District: {detail.AgencyOffDist}";
                agencyStateLabel.Text = $"State: {detail.AgencyOffState}";
                agencyContactLabel.Text = $"Phone: {detail.AgencyOffContactNo}";
                agencyEmailLabel.Text = $"Email: {detail.AgencyOffContactEmail}";
                agencyDetailsLayout.IsVisible = true;
            }
            else
            {
                agencyDetailsLayout.IsVisible = true;
                // No records: show empty agency card with message
                agencyNameLabel.Text = "No agency record found for selected combination.";
                agencyDistrictLabel.Text = "";
                agencyStateLabel.Text = "";
                agencyContactLabel.Text = "";
                agencyEmailLabel.Text = "";
            }
        }
        catch (Exception ex)
        {
            // You can optionally show error message here if needed
            agencyDetailsLayout.IsVisible = true;
            agencyNameLabel.Text = $"Error loading agency details.";
            agencyDistrictLabel.Text = "";
            agencyStateLabel.Text = "";
            agencyContactLabel.Text = "";
            agencyEmailLabel.Text = "";
        }
    }

    private async void DistrictPicker1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;

        if (districtPicker1.SelectedItem == null) return;



        if (districtPicker1.SelectedItem is DistrictModel selectedDistrict)
        {
            // Step 1: Set district in Unit Address section
            districtPicker1.SelectedItem = selectedDistrict;

        }
    }
    private async void GetDistrictByState(object sender, EventArgs e)
    {

        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;
        string stateCode = (statePickerforAgency.SelectedItem as StateModel)?.State_Code;

        if (string.IsNullOrEmpty(stateCode))
        {
            await DisplayAlert("Error", "Please select a state first.", "OK");
            return;
        }

        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetDistricts";
        string jsonString = $"{{\"State_Code\":\"{stateCode}\"}}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        var districtList = JsonConvert.DeserializeObject<List<DistrictModel>>(response);

        // Insert default option at the top
        districtList.Insert(0, new DistrictModel { District_Name = "Select District", District_Code = "" });

 

        districtPicker1.ItemsSource = districtList;
        districtPicker1.ItemDisplayBinding = new Binding("District_Name");
        districtPicker1.SelectedIndex = 0;



    }

    private void SelectStateByName(Picker picker, string stateName)
    {
        if (picker?.ItemsSource == null || string.IsNullOrWhiteSpace(stateName)) return;

        for (int i = 0; i < picker.ItemsSource.Count; i++)
        {
            var item = picker.ItemsSource[i];
            var prop = item.GetType().GetProperty("State_Name");
            if (prop != null)
            {
                var value = prop.GetValue(item)?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(value) &&
                    value.Equals(stateName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    picker.SelectedIndex = i;
                    return;
                }
            }
        }

        picker.SelectedIndex = 0; 
    }

    private DateTime? ConvertJsonDateToDate(string jsonDate)
    {
        if (string.IsNullOrEmpty(jsonDate)) return null;

        var match = Regex.Match(jsonDate, @"\/Date\((\d+)\)\/");
        if (match.Success && long.TryParse(match.Groups[1].Value, out long milliseconds))
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).DateTime;
        }

        return null;
    }

    private void SelectPickerItemByLKDescription(Picker picker, string target)
    {
        if (picker?.ItemsSource == null) return;

        for (int i = 0; i < picker.ItemsSource.Count; i++)
        {
            var item = picker.ItemsSource[i];
            var prop = item.GetType().GetProperty("LKDescription");
            if (prop != null)
            {
                var value = prop.GetValue(item)?.ToString();
                if (value == target)
                {
                    picker.SelectedIndex = i;
                    return;
                }
            }
        }
    }
    private void SelectPickerItemByShortCode(Picker picker, string shortCode)
    {
        if (picker?.ItemsSource == null || string.IsNullOrWhiteSpace(shortCode)) return;

        for (int i = 0; i < picker.ItemsSource.Count; i++)
        {
            var item = picker.ItemsSource[i];
            var prop = item.GetType().GetProperty("LKShortCode");
            if (prop != null)
            {
                var value = prop.GetValue(item)?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(value) &&
                    value.Equals(shortCode.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    picker.SelectedIndex = i;
                    return;
                }
            }
        }

        // If not found, select default (first) item
        picker.SelectedIndex = 0;
    }


    private void LoadTitles()
    {
        var titleList = new List<TitleModel>
    {
        new TitleModel { Id = "1", Name = "Shri." },
        new TitleModel { Id = "2", Name = "Smt." },
        new TitleModel { Id = "3", Name = "Kum." },
        new TitleModel { Id = "4", Name = "Ms." }
    };

        titlePicker.ItemsSource = titleList;
    }
    private async Task GetGender()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetGender";

        string jsonString = "{\"mainCode\":\"GEND\"}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        // Deserialize JSON array
        var genderList = JsonConvert.DeserializeObject<List<GenderModel>>(response);

        // Insert default option at the top
        genderList.Insert(0, new GenderModel { LKDescription = "Select Gender", GenderCode = "" });

  
    }

    private async Task GetSocialCategory()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetSocialCategory";

        string jsonString = "{\"mainCode\":\"SPCCT\"}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        // Deserialize JSON array
        var genderList = JsonConvert.DeserializeObject<List<GenderModel>>(response);

        // Insert default option at the top
        genderList.Insert(0, new GenderModel { LKDescription = "Select Social Category", GenderCode = "" });


        // Bind to Picker
        socialCategoryPicker.ItemsSource = genderList;
        socialCategoryPicker.ItemDisplayBinding = new Binding("LKDescription");

        // Set default index to "Select Gender"
        socialCategoryPicker.SelectedIndex = 0;
    }

    private async Task GetSpecialCategory()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetSpecialCategory";

        string jsonString = "{\"mainCode\":\"SPCLCT\"}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        // Deserialize JSON array
        var genderList = JsonConvert.DeserializeObject<List<GenderModel>>(response);

        // Insert default option at the top
        genderList.Insert(0, new GenderModel { LKDescription = "Select Special Category", GenderCode = "" });


        // Bind to Picker
        specialCategoryPicker.ItemsSource = genderList;
        specialCategoryPicker.ItemDisplayBinding = new Binding("LKDescription");

        // Set default index to "Select Gender"
        specialCategoryPicker.SelectedIndex = 0;
    }


    private async Task GetQualification()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetQualification";

        string jsonString = "{\"mainCode\":\"QUAL\"}";

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        // Deserialize JSON array
        var genderList = JsonConvert.DeserializeObject<List<GenderModel>>(response);

        // Insert default option at the top
        genderList.Insert(0, new GenderModel { LKDescription = "Select Qualification", GenderCode = "" });

        // Bind to Picker
        qualifictionPicker.ItemsSource = genderList;
        qualifictionPicker.ItemDisplayBinding = new Binding("LKDescription");

        // Set default index to "Select Gender"
        socialCategoryPicker.SelectedIndex = 0;
    }





    private async void OnStepTapped(object sender, EventArgs e)
    {
        // Reset all circle colors
        Step1Circle.BackgroundColor = Colors.LightGray;
        Step2Circle.BackgroundColor = Colors.LightGray;
        Step3Circle.BackgroundColor = Colors.LightGray;
        Step4Circle.BackgroundColor = Colors.LightGray;
        Step5Circle.BackgroundColor = Colors.LightGray;
        Step6Circle.BackgroundColor = Colors.LightGray;
        Step7Circle.BackgroundColor = Colors.LightGray;

        // Hide ApplicationForm by default
        ApplicationForm.IsVisible = false;

        // Clear FormContainer content
        FormContainer.Content = null;

        if (sender == Step1Circle)
        {
            Step1Circle.BackgroundColor = Colors.Orange;

            ApplicationForm.IsVisible = true;
        }
        else if (sender == Step2Circle)
        {
            Step2Circle.BackgroundColor = Colors.Orange;

           // var page = new DPRForm();

    

            // Add new content
            //FormContainer.Content = page.Content;
            //  ApplicationForm.IsVisible = false;

            //var page = new NewPage1();
            //FormContainer.Content = page.Content;


        }

        else if (sender == Step3Circle)
        {
            Step3Circle.BackgroundColor = Colors.Orange;
            // FormContainer.Content = new ScoreCardForm();
        }
        else if (sender == Step4Circle)
        {
            Step4Circle.BackgroundColor = Colors.Orange;
            //  FormContainer.Content = new UploadDocument();
        }
        else if (sender == Step5Circle)
        {
            Step5Circle.BackgroundColor = Colors.Orange;
            // FormContainer.Content = new FinalSubmission();
        }
        else if (sender == Step6Circle)
        {
            Step6Circle.BackgroundColor = Colors.Orange;
            //  FormContainer.Content = new UnderProcess();
        }
        else if (sender == Step7Circle)
        {
            Step7Circle.BackgroundColor = Colors.Orange;
            // FormContainer.Content = new LoanSanction();
        }
    }



    // ========= Add Row =========
    private void OnAddRowClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is string target)
        {
            switch (target)
            {
                case "Sales":
                    AddRow(SalesRows, UpdateSalesTotal);
                    break;
                case "Raw":
                    AddRow(RawMaterialRows, UpdateRawTotal);
                    break;
                case "Wages":
                    AddRow(WagesRows, UpdateWagesTotal);
                    break;
                case "Salary":
                    AddRow(SalaryRows, UpdateSalaryTotal);
                    break;
                case "Building":
                    AddRow(BuildingRows, UpdateBuildingTotal);
                    break;
                case "Machinery":
                    AddRow(MachineryRows, UpdateMachineryTotal);
                    break;
            }
        }
    }

    private void AddRow(ObservableCollection<RowData> rows, Action updateTotal)
    {
        var row = new RowData { SrNo = rows.Count + 1 };
        row.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(RowData.Area) || e.PropertyName == nameof(RowData.Rate))
                updateTotal();
        };
        rows.Add(row);
        updateTotal();
    }

    // ========= Delete Row =========
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is string target)
        {
            switch (target)
            {
                case "Sales":
                    if (SalesRows.Any())
                        RemoveRow(SalesRows.Last(), SalesRows, UpdateSalesTotal);
                    break;
                case "Raw":
                    if (RawMaterialRows.Any())
                        RemoveRow(RawMaterialRows.Last(), RawMaterialRows, UpdateRawTotal);
                    break;
                case "Wages":
                    if (WagesRows.Any())
                        RemoveRow(WagesRows.Last(), WagesRows, UpdateWagesTotal);
                    break;
                case "Salary":
                    if (SalaryRows.Any())
                        RemoveRow(SalaryRows.Last(), SalaryRows, UpdateSalaryTotal);
                    break;
                case "Building":
                    if (BuildingRows.Any())
                        RemoveRow(BuildingRows.Last(), BuildingRows, UpdateBuildingTotal);
                    break;
                case "Machinery":
                    if (MachineryRows.Any())
                        RemoveRow(MachineryRows.Last(), MachineryRows, UpdateMachineryTotal);
                    break;
            }
        }
    }
    private void RemoveRow(RowData row, ObservableCollection<RowData> rows, Action updateTotal)
    {
        rows.Remove(row);
        for (int i = 0; i < rows.Count; i++)
        {
            rows[i].SrNo = i + 1;
        }
        updateTotal();
    }
    // ========= Totals =========
    private void UpdateBuildingTotal() => BuildingTotal = BuildingRows.Sum(r => r.Amount);
    private void UpdateMachineryTotal() => MachineryTotal = MachineryRows.Sum(r => r.Amount);

    private void UpdateSalesTotal() => SalesTotal = SalesRows.Sum(r => r.Amount);
    private void UpdateRawTotal() => RawTotal = RawMaterialRows.Sum(r => r.Amount);
    private void UpdateWagesTotal() => WagesTotal = WagesRows.Sum(r => r.Amount);
    private void UpdateSalaryTotal() => SalaryTotal = SalaryRows.Sum(r => r.Amount);

    #region INotifyPropertyChanged
    public new event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    #endregion



}


// ========= RowData Class =========
public class RowData : INotifyPropertyChanged
{
    private int srNo;
    private string particulars;
    private double area;
    private double rate;

    public int SrNo
    {
        get => srNo;
        set { srNo = value; OnPropertyChanged(); }
    }

    public string Particulars
    {
        get => particulars;
        set { particulars = value; OnPropertyChanged(); }
    }

    public double Area
    {
        get => area;
        set { area = value; OnPropertyChanged(); OnPropertyChanged(nameof(Amount)); }
    }

    public double Rate
    {
        get => rate;
        set { rate = value; OnPropertyChanged(); OnPropertyChanged(nameof(Amount)); }
    }

    public double Amount => Area * Rate;

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}