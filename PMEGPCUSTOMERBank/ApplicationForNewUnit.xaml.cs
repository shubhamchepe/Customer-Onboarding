using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMEGPCUSTOMERBank.Modal;
using PMEGPCUSTOMERBank.PopUp;
using PMEGPCUSTOMERBank.Util;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace PMEGPCUSTOMERBank;

public partial class ApplicationForNewUnit : ContentPage
{
    public ObservableCollection<Modal.NICModel> PagedList { get; set; } = new();
    public ObservableCollection<BankModel> BankList { get; set; } = new();
    private List<Modal.NICModel> _allIndustries = new();
    private List<Modal.NICModel> _currentSource = new();

    private int _pageSize = 10;
    private int _currentPage = 1;
    private int activityType1;
    private string _selectedAgencyCode;
    private string _selectedAgencyShortCode;
    private int _agencyID;
    private int agencyOfId;
    private Popup currentPopup;
    private int isAdharverfied;

    public ObservableCollection<Modal.NICModel> SelectedIndustries { get; set; }
    public ObservableCollection<InfoSourceModel> InfoSourceList { get; set; } = new ObservableCollection<InfoSourceModel>();


    public ICommand DeleteCommand { get; set; }
    public ApplicationForNewUnit()
    {
        InitializeComponent();

        SelectedIndustries = new ObservableCollection<Modal.NICModel>();
        DeleteCommand = new Command<Modal.NICModel>(OnDeleteIndustry);
        BindingContext = this;

        // ✅ Load data asynchronously
        _ = LoadInitialDataAsync();
    }

    private async Task LoadInitialDataAsync()
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("🔄 Loading initial data...");

            // ✅ Run all in parallel for faster loading
            await Task.WhenAll(
                GetGender(),
                GetSocialCategory(),
                GetSpecialCategory(),
                GetQualification(),
                GetState(),
                GetAgency(),
                LoadSchemes(),
                GetBankList(),
                GetinfoSources()
            );

            LoadTitles(); // Synchronous - runs immediately

            System.Diagnostics.Debug.WriteLine("✅ All data loaded successfully");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"❌ LoadInitialDataAsync Error: {ex.Message}");
            await DisplayAlert("Error", $"Failed to load initial data: {ex.Message}", "OK");
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

    private async void SubmitForm(object sender, EventArgs e)
    {
        await SubmitForm();
    }

    private async Task SubmitForm()
    {
        try
        {
            string AadharNo = adharEntry.Text?.Trim();
            string panNo = "AAPSR2820T";
            string ApplName = txtApplicantName.Text?.Trim();
            string DateofBirth = txtDOB.Text?.Trim();
            string Age = txtAge.Text?.Trim();
            // ✅ CORRECT
            string Gender = (genderPicker.SelectedItem as GenderModel)?.LKDescription ?? string.Empty;

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

            int? unitActivityType = null;
            if (selectedActivity == "Manufacturing")
                unitActivityType = 0;
            else if (selectedActivity == "Service")
                unitActivityType = 1;



            var nicData = new Dictionary<string, string>();
            //int nicIndex = 0;
            //foreach (var item in SelectedIndustries)
            //{
            //    nicData[$"UnitActivityName{nicIndex}"] = item.NicCode;
            //    nicData[$"ProdDescr{nicIndex}"] = item.NicDesc;
            //    nicIndex++;
            //}
            int nicIndex = 0;
            foreach (var item in SelectedIndustries)
            {
                if (nicIndex == 0)
                {
                    // First item without number
                    nicData["UnitActivityName"] = item.NicCode;
                    nicData["ProdDescr"] = item.NicDesc;
                }
                else
                {
                    // Next items with suffix
                    nicData[$"UnitActivityName{nicIndex + 1}"] = item.NicCode;
                    nicData[$"ProdDescr{nicIndex + 1}"] = item.NicDesc;
                }
                nicIndex++;
            }


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
            var selectedTitle = titlePicker.SelectedItem as TitleModel;

            if (selectedTitle == null)
            {
                await App.Current.MainPage.DisplayAlert("Validation", "Please select a title", "OK");
                return;
            }

            string ApplTitle = selectedTitle.Id;


            string lgdCode = "535843";
            int TrainingMode = 0;

            var formData = new Dictionary<string, object>
        {
            { "AadharNo", AadharNo },
            { "ApplTitle", ApplTitle },
            { "ApplName", ApplName },
            { "AgencyID", agencyId },
            { "AgencyCode", AgencyCode },
            { "nodalCode", nodalcode },
            { "StateID", stateId },
            { "DistID", DistrictId },
            { "stateCode", stateCode },
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
            { "UnitDistrict", UnitDistrict },
            { "UnitPin", UnitPin },
            { "UnitActivityType", unitActivityType },
            { "IsEDPTraining", IsEDPTraining },
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
            { "IsDeclrAccept", 1 },
            { "FinalSubDate", null },
            { "IsFinalSub", null },
            { "CreatedOn", DateTime.Now },
            { "ModifyOn", null },
            { "ModifyBy", null },
            { "IsAadharVerified", isAdharverfied},
            { "IsPanVerified", 1 },
            { "IsUnitLocationSame", 1 },
            { "SchemeWrkFlowID", 2 },
            { "IsAltnBank", "1" },
            { "UserType", "APPL" },
            { "StateName", stateName },
            { "DistrictName", DistrictName },
            { "SchemeID", 1 },
            { "IsUnderAlternativeBank", 0 },
            { "IsAltBankRejected", 0 },
            { "isCharAppliAccepted", 1 },
            { "ComnStateID", ComnStateID },
            { "ComnStateName", ComnStateName },
            { "MaskAadharNo", "XXXX XXXX 2019" },
            { "State_Code", stateId },
            { "State_Name", stateName },
            { "lgdCode", lgdCode },
            { "TrainingMode", TrainingMode },
            { "Village_Name", villageNAme },

            { "lgdCodeId", lgCodeID },
            { "IsGenerateChallan", 0 },
            { "IsDPRVerified", 0 }
        };

            // Add NIC codes like UnitActivityName1, ProdDescr1, ...
            foreach (var pair in nicData)
            {
                formData.Add(pair.Key, pair.Value);
            }

            string apiUrl = $"{AppConstants.AppIP}/MobileApp/SaveApplicantData";
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
                await App.Current.MainPage.DisplayAlert("Success", "Form submitted successfully!", "OK");
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



    private async Task GetinfoSources()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetInformationSource";
        string jsonString = "{\"mainCode\":\"INFOSRC\"}";

        try
        {
            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            // Check if response is empty or invalid
            if (string.IsNullOrWhiteSpace(response) || response == "[]" || response == "{}")
            {
                System.Diagnostics.Debug.WriteLine("Empty or invalid response from GetInformationSource API");

                // Add default item only
                InfoSourceList.Clear();
                InfoSourceList.Add(new InfoSourceModel { LKDescription = "Select Information Source" });
                infoSourcePicker.ItemsSource = InfoSourceList;
                infoSourcePicker.SelectedIndex = 0;
                return;
            }

            var infoSources = JsonConvert.DeserializeObject<List<InfoSourceModel>>(response);

            if (infoSources != null && infoSources.Count > 0)
            {
                InfoSourceList.Clear();
                InfoSourceList.Add(new InfoSourceModel { LKDescription = "Select Information Source" });

                foreach (var source in infoSources.Where(s => s.IsActive))
                    InfoSourceList.Add(source);

                infoSourcePicker.ItemsSource = InfoSourceList;
                infoSourcePicker.SelectedIndex = 0;
            }
            else
            {
                // API returned empty list
                InfoSourceList.Clear();
                InfoSourceList.Add(new InfoSourceModel { LKDescription = "Select Information Source" });
                infoSourcePicker.ItemsSource = InfoSourceList;
                infoSourcePicker.SelectedIndex = 0;
            }
        }
        catch (JsonException jsonEx)
        {
            System.Diagnostics.Debug.WriteLine($"JSON Parse Error in GetinfoSources: {jsonEx.Message}");

            // Set default values to prevent crash
            InfoSourceList.Clear();
            InfoSourceList.Add(new InfoSourceModel { LKDescription = "Select Information Source" });
            infoSourcePicker.ItemsSource = InfoSourceList;
            infoSourcePicker.SelectedIndex = 0;

            // Optionally show user-friendly message (don't crash the app)
            // await DisplayAlert("Notice", "Unable to load information sources. Please check your connection.", "OK");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in GetinfoSources: {ex.Message}");

            // Set default values
            InfoSourceList.Clear();
            InfoSourceList.Add(new InfoSourceModel { LKDescription = "Select Information Source" });
            infoSourcePicker.ItemsSource = InfoSourceList;
            infoSourcePicker.SelectedIndex = 0;
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

    private async void OnSelectAlternateBankIfscClicked(object sender, EventArgs e)
    {
        // ✅ Alternate bank selection
        if (primaryBankPicker1.SelectedItem is not BankModel selectedAltBank)
        {
            await DisplayAlert("Alert", "Please select an Alternate Bank first.", "OK");
            return;
        }

        // ✅ Primary bank selection
        if (primaryBankPicker.SelectedItem is BankModel selectedPrimaryBank)
        {
            if (selectedPrimaryBank.BankListId == selectedAltBank.BankListId)
            {
                await DisplayAlert("Error", "Alternate Bank cannot be the same as Primary Bank.", "OK");
                return;
            }
        }
        // Check District selection
        if (districtPicker1.SelectedItem is not DistrictModel selectedDistrict)
        {
            await DisplayAlert("Alert", "Please select a District first.", "OK");
            return;
        }

        string bankId = selectedAltBank.BankListId.ToString();
        string districtName = selectedDistrict.District_Name;


        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetBranchListData";
        string jsonString = $"{{\"bankListId\":\"{bankId}\", \"CityName\":\"{districtName}\"}}";

        try
        {
            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var branches = JsonConvert.DeserializeObject<List<BranchModel>>(response);

            if (branches?.Any() == true)
            {
                var branch = branches.First();

                altIfscEntry.Text = branch.IFSCCode;
                altBranchEntry.Text = branch.BranchName;
                altAddressEntry.Text = branch.Address;
                altDistrictEntry.Text = branch.CityName;
            }
            else
            {
                await DisplayAlert("Alert", "No branch data found for this Alternate Bank.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Something went wrong: {ex.Message}", "OK");
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

            //// Handle Response
            //if (!string.IsNullOrEmpty(response))
            //{
            //    await DisplayAlert("Response", response, "OK");
            //    // TODO: Parse JSON and auto-fill IFSC, Branch, Address fields
            //}
            //else
            //{
            //    await DisplayAlert("Alert", "No data found for selected Bank and District.", "OK");
            //}
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Something went wrong: {ex.Message}", "OK");
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

        // Change arrow icon of the clicked expander
        if (expanderArrowMap.TryGetValue(changedExpander, out var arrow))
        {
            arrow.Source = e.IsExpanded ? "upload.png" : "arrow.png";
        }

        // ✅ Accordion behavior: Close all other expanders when one is opened
        if (e.IsExpanded)
        {
            foreach (var expander in expanderArrowMap.Keys)
            {
                if (expander != changedExpander && expander.IsExpanded)
                {
                    expander.IsExpanded = false;
                }
            }
        }
    }




    private async void OnValidateAdharClicked(object sender, EventArgs e)
    {
        try
        {
            string adharNo = adharEntry.Text?.Trim();

            if (string.IsNullOrEmpty(adharNo))
            {
                await DisplayAlert("Error", "Please enter Aadhar number", "OK");
                return;
            }

            if (adharNo.Length != 12 || !adharNo.All(char.IsDigit))
            {
                await DisplayAlert("Error", "Please enter 12 digit Aadhaar number", "OK");
                return;
            }

            // Step 1: Get OTP
            string apiUrl1 = $"{AppConstants.AppIP}/MobileApp/GETAadharOTP";
            string jsonString1 = $"{{\"aadhaarNo\":\"{adharNo}\"}}";

            string getData1 = await HttpClientClass.PostAsyncTask(apiUrl1, jsonString1);
            // Add after receiving getData1
            System.Diagnostics.Debug.WriteLine($"API Response: {getData1}");

            // If response is "[]" or starts with "[", handle it:
            if (getData1.TrimStart().StartsWith("["))
            {
                await DisplayAlert("Error", "Invalid Aadhaar number or API returned empty result", "OK");
                return;
            }

            var json1 = JObject.Parse(getData1);

            // ✅ FIXED: Check success at root level
            if (json1["success"]?.ToObject<bool>() != true)
            {
                string errorMsg = json1["message"]?.ToString() ?? "Failed to send OTP";
                await DisplayAlert("Error", errorMsg, "OK");
                return;
            }

            // ✅ Store guidKey
            AppConstants.GuidKey = json1["guidKey"]?.ToString();

            if (string.IsNullOrEmpty(AppConstants.GuidKey))
            {
                await DisplayAlert("Error", "Invalid response from server", "OK");
                return;
            }

            // Step 2: Show OTP popup
            var popup = new OtpPopup();
            var result = await this.ShowPopupAsync(popup);

            if (result == null)
            {
                await DisplayAlert("Info", "OTP verification cancelled", "OK");
                return;
            }

            string enteredOtp = result.ToString();

            // Step 3: Validate OTP
            string validateUrl = $"{AppConstants.AppIP}/MobileApp/ValidateAadharOTP";
            string validateJson = $"{{\"aadhaarNo\":\"{adharNo}\",\"AadharOTP\":\"{enteredOtp}\",\"guidKey\":\"{AppConstants.GuidKey}\"}}";

            string validateResponse = await HttpClientClass.PostAsyncTask(validateUrl, validateJson);
            var otpResponse = JObject.Parse(validateResponse);

            if (otpResponse["success"]?.ToObject<bool>() == true)
            {
                var data = otpResponse["data"];

                if (data == null)
                {
                    await DisplayAlert("Error", "No data returned from Aadhaar verification", "OK");
                    return;
                }

                // ✅ Store all data
                AppConstants.Name = data["name"]?.ToString();
                AppConstants.DOB = data["dob"]?.ToString();
                AppConstants.Gender = data["gender"]?.ToString();
                AppConstants.State = data["state"]?.ToString();
                AppConstants.District = data["dist"]?.ToString();
                AppConstants.SubDistrict = data["subdist"]?.ToString();
                AppConstants.Pincode = data["pincode"]?.ToString();
                AppConstants.Location = data["loc"]?.ToString();
                AppConstants.Street = data["street"]?.ToString();
                AppConstants.House = data["house"]?.ToString();

                // ✅ Update UI
                // ✅ Update UI
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    txtApplicantName.Text = AppConstants.Name;
                    districtEntry.Text = AppConstants.District;
                    comnAddressEntry.Text = AppConstants.Location;
                    pinEntry.Text = AppConstants.Pincode;

                    // Parse and set DOB
                    if (DateTime.TryParseExact(AppConstants.DOB, "MM-dd-yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
                    {
                        txtDOB.Text = dob.ToString("dd/MM/yyyy");

                        int age = DateTime.Today.Year - dob.Year;
                        if (dob.Date > DateTime.Today.AddYears(-age)) age--;
                        txtAge.Text = age.ToString();
                    }

                    // ✅ FIXED: Set gender using SelectedItem
                    if (!string.IsNullOrEmpty(AppConstants.Gender))
                    {
                        string gender = AppConstants.Gender.ToUpper();
                        string genderText = gender == "M" ? "Male" :
                                           gender == "F" ? "Female" :
                                           "Transgender";

                        if (genderPicker.ItemsSource is IEnumerable<GenderModel> genderList)
                        {
                            var matchedGender = genderList.FirstOrDefault(g =>
                                g.LKDescription != null &&
                                g.LKDescription.Equals(genderText, StringComparison.OrdinalIgnoreCase));

                            if (matchedGender != null)
                                genderPicker.SelectedItem = matchedGender;
                        }
                    }

                    // Set state
                    if (!string.IsNullOrWhiteSpace(AppConstants.State) &&
                        statePicker.ItemsSource is IEnumerable<StateModel> stateList)
                    {
                        var matchedState = stateList.FirstOrDefault(s =>
                            s.State_Name.Trim().Equals(AppConstants.State, StringComparison.OrdinalIgnoreCase));

                        if (matchedState != null)
                            statePicker.SelectedItem = matchedState;
                    }
                });

                isAdharverfied = 1;
                await DisplayAlert("Success", "Aadhaar verified successfully!", "OK");
            }
            else
            {
                string errorCode = otpResponse["data"]?["code"]?.ToString() ?? "ERROR";
                string errorDesc = otpResponse["data"]?["description"]?.ToString() ?? "OTP verification failed";
                await DisplayAlert("Failed", $"{errorCode}: {errorDesc}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Aadhaar validation failed: {ex.Message}", "OK");
            System.Diagnostics.Debug.WriteLine($"❌ Aadhaar Error: {ex}");
        }
    }


    private async Task GetGender()
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("🔵 GetGender: Starting...");

            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetGender";
            System.Diagnostics.Debug.WriteLine($"🔵 GetGender: URL = {apiUrl}");

            string jsonString = "{\"mainCode\":\"GEND\"}";
            System.Diagnostics.Debug.WriteLine($"🔵 GetGender: Request = {jsonString}");

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
            System.Diagnostics.Debug.WriteLine($"🔵 GetGender: Response = {response}");

            var genderList = JsonConvert.DeserializeObject<List<GenderModel>>(response);
            System.Diagnostics.Debug.WriteLine($"🔵 GetGender: Deserialized {genderList?.Count ?? 0} items");

            if (genderList != null && genderList.Count > 0)
            {
                genderList.Insert(0, new GenderModel { LKDescription = "Select Gender", GenderCode = "" });

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    genderPicker.ItemsSource = genderList;
                    genderPicker.ItemDisplayBinding = new Binding("LKDescription");
                    genderPicker.SelectedIndex = 0;
                    System.Diagnostics.Debug.WriteLine("✅ GetGender: UI Updated Successfully");
                });
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("⚠️ GetGender: No data received");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"❌ GetGender Error: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"❌ Stack Trace: {ex.StackTrace}");
            await DisplayAlert("Error", $"Failed to load genders: {ex.Message}", "OK");
        }
    }
    private async Task GetSocialCategory()
    {
        try
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetSocialCategory";
            string jsonString = "{\"mainCode\":\"SPCCT\"}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
            var categoryList = JsonConvert.DeserializeObject<List<GenderModel>>(response);

            if (categoryList != null && categoryList.Count > 0)
            {
                categoryList.Insert(0, new GenderModel { LKDescription = "Select Social Category", GenderCode = "" });

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    socialCategoryPicker.ItemsSource = categoryList;
                    socialCategoryPicker.ItemDisplayBinding = new Binding("LKDescription");
                    socialCategoryPicker.SelectedIndex = 0;
                });
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load social categories: {ex.Message}", "OK");
        }
    }

    // ✅ FIXED: GetSpecialCategory
    private async Task GetSpecialCategory()
    {
        try
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetSpecialCategory";
            string jsonString = "{\"mainCode\":\"SPCLCT\"}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
            var categoryList = JsonConvert.DeserializeObject<List<GenderModel>>(response);

            if (categoryList != null && categoryList.Count > 0)
            {
                categoryList.Insert(0, new GenderModel { LKDescription = "Select Special Category", GenderCode = "" });

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    specialCategoryPicker.ItemsSource = categoryList;
                    specialCategoryPicker.ItemDisplayBinding = new Binding("LKDescription");
                    specialCategoryPicker.SelectedIndex = 0;
                });
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load special categories: {ex.Message}", "OK");
        }
    }

    // ✅ FIXED: GetQualification
    private async Task GetQualification()
    {
        try
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetQualification";
            string jsonString = "{\"mainCode\":\"QUAL\"}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
            var qualList = JsonConvert.DeserializeObject<List<GenderModel>>(response);

            if (qualList != null && qualList.Count > 0)
            {
                qualList.Insert(0, new GenderModel { LKDescription = "Select Qualification", GenderCode = "" });

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    qualifictionPicker.ItemsSource = qualList;
                    qualifictionPicker.ItemDisplayBinding = new Binding("LKDescription");
                    qualifictionPicker.SelectedIndex = 0;
                });
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load qualifications: {ex.Message}", "OK");
        }
    }


    private async Task GetState()
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("🔵 GetState: Starting...");

            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetStates";
            System.Diagnostics.Debug.WriteLine($"🔵 GetState: URL = {apiUrl}");

            // Verify AppIP is set
            if (string.IsNullOrEmpty(AppConstants.AppIP))
            {
                System.Diagnostics.Debug.WriteLine("❌ GetState: AppIP is NULL or empty!");
                await DisplayAlert("Error", "API URL not configured", "OK");
                return;
            }

            string response = await HttpClientClass.GetStateAsyncTask(apiUrl);
            System.Diagnostics.Debug.WriteLine($"🔵 GetState: Response received, length = {response?.Length ?? 0}");

            // Check if response is empty
            if (string.IsNullOrWhiteSpace(response))
            {
                System.Diagnostics.Debug.WriteLine("⚠️ GetState: Empty response from API");
                await DisplayAlert("Error", "No data received from server", "OK");
                return;
            }

            // Deserialize JSON array into List<StateModel>
            var stateList = JsonConvert.DeserializeObject<List<StateModel>>(response);
            System.Diagnostics.Debug.WriteLine($"🔵 GetState: Deserialized {stateList?.Count ?? 0} states");

            if (stateList == null || stateList.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("⚠️ GetState: Deserialization returned empty list");
                await DisplayAlert("Error", "No states found", "OK");
                return;
            }

            // Insert default option at the top
            stateList.Insert(0, new StateModel { State_Name = "Select State", State_Code = "", State_ID = 0 });
            System.Diagnostics.Debug.WriteLine($"🔵 GetState: Added default option, total = {stateList.Count}");

            // Update UI on main thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("🔵 GetState: Updating UI...");

                    // Verify pickers exist
                    if (statePicker == null)
                    {
                        System.Diagnostics.Debug.WriteLine("❌ GetState: statePicker is NULL!");
                        return;
                    }

                    if (statePickerforAgency == null)
                    {
                        System.Diagnostics.Debug.WriteLine("❌ GetState: statePickerforAgency is NULL!");
                        return;
                    }

                    // Communication Address State Picker
                    statePicker.ItemsSource = stateList;
                    statePicker.ItemDisplayBinding = new Binding("State_Name");
                    statePicker.SelectedIndex = 0;
                    System.Diagnostics.Debug.WriteLine("✅ GetState: statePicker updated");

                    // Implementing Agency State Picker
                    statePickerforAgency.ItemsSource = stateList;
                    statePickerforAgency.ItemDisplayBinding = new Binding("State_Name");
                    statePickerforAgency.SelectedIndex = 0;
                    System.Diagnostics.Debug.WriteLine("✅ GetState: statePickerforAgency updated");

                    System.Diagnostics.Debug.WriteLine("✅ GetState: All pickers updated successfully");
                }
                catch (Exception uiEx)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ GetState UI Update Error: {uiEx.Message}");
                }
            });
        }
        catch (JsonException jsonEx)
        {
            System.Diagnostics.Debug.WriteLine($"❌ GetState JSON Error: {jsonEx.Message}");
            await DisplayAlert("Error", "Invalid data format received from server", "OK");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"❌ GetState Error: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"❌ Stack Trace: {ex.StackTrace}");
            await DisplayAlert("Error", $"Failed to load states: {ex.Message}", "OK");
        }
    }

    private async void OnStateSelected(object sender, EventArgs e)
    {
        try
        {
            var picker = sender as Picker;

            System.Diagnostics.Debug.WriteLine($"🔵 OnStateSelected: SelectedIndex = {picker?.SelectedIndex}");

            // Do not do anything on default selection
            if (picker == null || picker.SelectedItem == null || picker.SelectedIndex == 0)
            {
                System.Diagnostics.Debug.WriteLine("⚠️ OnStateSelected: Default selection, skipping");
                return;
            }

            var selectedState = picker.SelectedItem as StateModel;

            if (selectedState != null)
            {
                string stateCode = selectedState.State_Code;
                System.Diagnostics.Debug.WriteLine($"🔵 OnStateSelected: Selected {selectedState.State_Name} (Code: {stateCode})");

                // You can add district loading logic here if needed
                // await LoadDistrictsForCommunicationAddress(stateCode);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"❌ OnStateSelected Error: {ex.Message}");
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
    private async void OnChangeDistrictClicked(object sender, EventArgs e)
    {


        string stateCode = (statePicker.SelectedItem as StateModel)?.State_Code;


        if (string.IsNullOrEmpty(stateCode))
        {
            await DisplayAlert("Error", "Please select state first", "OK");
        }
        else
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetDistricts";
            string jsonString = $"{{\"State_Code\":\"{stateCode}\"}}";
            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var districtList = JsonConvert.DeserializeObject<List<DistrictModel>>(response);

            // Insert default option at the top
            districtList.Insert(0, new DistrictModel { District_Name = "Select District", State_Code = "" });

            // Bind to Picker
            districtPicker1.ItemsSource = districtList;
            districtPicker1.ItemDisplayBinding = new Binding("District_Name");
            districtPicker1.SelectedIndex = 0;




            if (districtList == null || districtList.Count == 0)
            {
                await DisplayAlert("Error", "No districts found", "OK");
                return;
            }

            // Open district selection popup
            var districtPage = new DistrictSelectionPage(districtList);
            await Navigation.PushModalAsync(districtPage);

            var selectedDistrict = await districtPage.ShowAsync();

            if (selectedDistrict != null)
            {
                districtEntry.Text = selectedDistrict.District_Name;
                string districtCode = selectedDistrict.District_Code;
            }
        }


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

        // Default selection par kuch mat karo
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

    private async void OnVillageSelected(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;

        if (picker.SelectedItem is VillageModel selectedVillage)
        {
            string villageCode = selectedVillage.Village_Code;

            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetVillageDetails";
            string jsonString = $"{{\"villageCode\":\"{villageCode}\"}}";

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var result = JsonConvert.DeserializeObject<JObject>(response);

            if (result["status"]?.ToObject<bool>() == true)
            {
                var data = result["data"];

                txtLGDCode.Text = data["lgdCodeId"]?.ToString();

                txtPincode.Text = data["Pincode"]?.ToString();

                string ruralUrban = data["Rural_Urban"]?.ToString();

                if (!string.IsNullOrEmpty(ruralUrban))
                {
                    for (int i = 0; i < pickerUnitLocation.Items.Count; i++)
                    {
                        if (pickerUnitLocation.Items[i].Equals(ruralUrban, StringComparison.OrdinalIgnoreCase))
                        {
                            pickerUnitLocation.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Village details not found", "OK");
            }
        }
    }

    private async void GetDistrictByState(object sender, EventArgs e)
    {
        try
        {
            var picker = sender as Picker;

            System.Diagnostics.Debug.WriteLine($"🔵 GetDistrictByState: SelectedIndex = {picker?.SelectedIndex}");

            // Do not do anything on default selection
            if (picker == null || picker.SelectedItem == null || picker.SelectedIndex == 0)
            {
                System.Diagnostics.Debug.WriteLine("⚠️ GetDistrictByState: Default selection, skipping");
                return;
            }

            string stateCode = (statePickerforAgency.SelectedItem as StateModel)?.State_Code;

            if (string.IsNullOrEmpty(stateCode))
            {
                System.Diagnostics.Debug.WriteLine("❌ GetDistrictByState: State code is empty");
                await DisplayAlert("Error", "Please select a state first.", "OK");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"🔵 GetDistrictByState: Loading districts for state code: {stateCode}");

            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetDistricts";
            string jsonString = $"{{\"State_Code\":\"{stateCode}\"}}";

            System.Diagnostics.Debug.WriteLine($"🔵 GetDistrictByState: URL = {apiUrl}");
            System.Diagnostics.Debug.WriteLine($"🔵 GetDistrictByState: Payload = {jsonString}");

            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);
            System.Diagnostics.Debug.WriteLine($"🔵 GetDistrictByState: Response received");

            var districtList = JsonConvert.DeserializeObject<List<DistrictModel>>(response);
            System.Diagnostics.Debug.WriteLine($"🔵 GetDistrictByState: Deserialized {districtList?.Count ?? 0} districts");

            if (districtList == null || districtList.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("⚠️ GetDistrictByState: No districts found");
                await DisplayAlert("Info", "No districts found for selected state", "OK");
                return;
            }

            // Insert default option at the top
            districtList.Insert(0, new DistrictModel { District_Name = "Select District", District_Code = "" });

            MainThread.BeginInvokeOnMainThread(() =>
            {
                // Bind to implementing agency district picker
                districtPicker1.ItemsSource = districtList;
                districtPicker1.ItemDisplayBinding = new Binding("District_Name");
                districtPicker1.SelectedIndex = 0;

                // Also bind to unit address district picker
                districtPicker.ItemsSource = districtList;
                districtPicker.ItemDisplayBinding = new Binding("District_Name");
                districtPicker.SelectedIndex = 0;

                System.Diagnostics.Debug.WriteLine("✅ GetDistrictByState: District pickers updated");
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"❌ GetDistrictByState Error: {ex.Message}");
            await DisplayAlert("Error", $"Failed to load districts: {ex.Message}", "OK");
        }
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


        await FetchAgencyDetails();

        // Pass ID to API call
        await FetchAgencyDetail(agencyTypeId);
    }

    private async Task FetchAgencyDetail(int agencyId)
    {

        try
        {
            string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetAgencyShortCode";


            string jsonString = $"{{\"Agency_ID\":\"{agencyId}\"}}";


            string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

            var root = JObject.Parse(response);

            if (root["success"]?.Value<bool>() == true)
            {
                var dataArray = root["data"] as JArray;
                if (dataArray != null && dataArray.Count > 0)
                {
                    var agency = dataArray[0].ToObject<AgencyModelShortCode>();

                    // Save directly
                    _agencyID = agencyId;
                    _selectedAgencyCode = agency.Agency_Code;
                    _selectedAgencyShortCode = agency.Short_Code;

                }
            }


        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // State Picker
    private async void StatePickerforAgency_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        // Do not do anything on default selection
        if (picker.SelectedItem == null || picker.SelectedIndex == 0)
            return;
        if (statePickerforAgency.SelectedItem == null) return;

        //var selectedState = (StateModel)statePickerforAgency.SelectedItem;
        //agencyOffStateID = selectedState.State_ID;

        await FetchAgencyDetails();
    }
    // District Picker
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
            districtPicker.SelectedItem = selectedDistrict;



            // Step 3: Call your agency details method (existing logic)
            await FetchAgencyDetails();
        }
    }
    private async Task FetchAgencyDetails()
    {
        var selectedAgency = (AgencyModel)agencyPicker.SelectedItem;
        var selectedState = (StateModel)statePickerforAgency.SelectedItem;
        var selectedDistrict = (DistrictModel)districtPicker1.SelectedItem;

        if (agencyPicker.SelectedItem == null || statePickerforAgency.SelectedItem == null || districtPicker1.SelectedItem == null)
            return;


        string apiUrl = $"{AppConstants.AppIP}/MobileApp/GetAgencyOffDetails";

        // JSON string manually
        string jsonString = $"{{\"agencyTypeId\":\"{selectedAgency.Agency_ID}\", \"agencyOffStateID\":\"{selectedState.State_ID}\", \"agencyOffDistId\":\"{selectedDistrict.District_ID}\"}}";

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
            await DisplayAlert("Error", $"Something went wrong: {ex.Message}", "OK");
        }
    }



    //////  Project Information /////

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

    private async Task test()
    {
        BindingContext = this;

        LoadIndustries();  // default list
        LoadDivision();    // division dropdown
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




    private async void OnSelectIndustryClicked(object sender, EventArgs e)
    {

        var selectedScheme = schemePicker.SelectedItem as SchemeModel;

        if (selectedScheme == null || selectedScheme.ActivityTyp == 0)
        {
            await DisplayAlert("Error", "Please select an Activity Type first.", "OK");
            return;
        }

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


    private View CloneView(View original)
    {
        // 🟡 Warning: This is only a workaround. Ideally, recreate full layout.
        // But this resets the visual tree properly.
        return new ContentView { Content = original };
    }
    private Popup CreateIndustryPopup()
    {
        var popup = new Popup
        {
            Color = Colors.Transparent,
            CanBeDismissedByTappingOutsideOfPopup = true
        };

        var frame = new Frame
        {
            BackgroundColor = Colors.White,
            CornerRadius = 12,
            HasShadow = true,
            WidthRequest = 350,
            HeightRequest = 700,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Padding = 15
        };

        var layoutGrid = new Grid
        {
            RowDefinitions =
        {
            new RowDefinition { Height = GridLength.Auto },
            new RowDefinition { Height = GridLength.Auto },
            new RowDefinition { Height = GridLength.Auto },
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            new RowDefinition { Height = GridLength.Auto },
            new RowDefinition { Height = GridLength.Auto },
        },
            RowSpacing = 10
        };

        // Title
        var titleLabel = new Label
        {
            Text = "Select Industry (NIC Data)",
            FontSize = 20,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 0, 0, 10)
        };
        Grid.SetRow(titleLabel, 0);
        layoutGrid.Children.Add(titleLabel);

        // Filters
        var filtersStack = new StackLayout
        {
            Spacing = 8,
            Children =
        {
            new Label { Text = "Division", VerticalOptions = LayoutOptions.Center },
            new Picker { Title = "Select Division" },
            new Label { Text = "Group", VerticalOptions = LayoutOptions.Center },
            new Picker { Title = "Select Group" },
            new Label { Text = "Class", VerticalOptions = LayoutOptions.Center },
            new Picker { Title = "Select Class" },
        }
        };
        Grid.SetRow(filtersStack, 1);
        layoutGrid.Children.Add(filtersStack);

        // Search Area
        var searchStack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 10,
            Margin = new Thickness(0, 10, 0, 10),
            Children =
        {
            new Label { Text = "Search:", VerticalOptions = LayoutOptions.Center },
            new Entry { Placeholder = "Search...", WidthRequest = 200 },
            new Button
            {
                Text = "Clear",
                BackgroundColor = Colors.Green,
                TextColor = Colors.White,
                CornerRadius = 6
            }
        }
        };
        Grid.SetRow(searchStack, 2);
        layoutGrid.Children.Add(searchStack);

        // Table Grid
        var tableGrid = new Grid
        {
            RowDefinitions =
        {
            new RowDefinition { Height = GridLength.Auto },
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
        }
        };

        var headerGrid = new Grid
        {
            BackgroundColor = Color.FromArgb("#f2f2f2"),
            Padding = 6,
            ColumnDefinitions =
        {
            new ColumnDefinition { Width = new GridLength(60) },
            new ColumnDefinition { Width = new GridLength(100) },
            new ColumnDefinition { Width = GridLength.Star }
        }
        };

        var selectLabel = new Label { Text = "Select", FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center };
        var nicCodeLabel = new Label { Text = "NIC Code", FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center };
        var descLabel = new Label { Text = "Description", FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center };

        Grid.SetColumn(selectLabel, 0);
        Grid.SetColumn(nicCodeLabel, 1);
        Grid.SetColumn(descLabel, 2);

        headerGrid.Children.Add(selectLabel);
        headerGrid.Children.Add(nicCodeLabel);
        headerGrid.Children.Add(descLabel);

        tableGrid.Children.Add(headerGrid);

        var collectionView = new CollectionView
        {
            ItemTemplate = new DataTemplate(() =>
            {
                var rowGrid = new Grid
                {
                    Padding = 6,
                    ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(60) },
                    new ColumnDefinition { Width = new GridLength(100) },
                    new ColumnDefinition { Width = GridLength.Star }
                },
                    BackgroundColor = Colors.White
                };

                var checkBox = new CheckBox { HorizontalOptions = LayoutOptions.Center };
                var nicLabel = new Label { VerticalOptions = LayoutOptions.Center, FontSize = 14 };
                var descText = new Label { VerticalOptions = LayoutOptions.Center, FontSize = 14, LineBreakMode = LineBreakMode.WordWrap };

                Grid.SetColumn(checkBox, 0);
                Grid.SetColumn(nicLabel, 1);
                Grid.SetColumn(descText, 2);

                rowGrid.Children.Add(checkBox);
                rowGrid.Children.Add(nicLabel);
                rowGrid.Children.Add(descText);

                return rowGrid;
            })
        };
        Grid.SetRow(collectionView, 1);
        tableGrid.Children.Add(collectionView);

        Grid.SetRow(tableGrid, 3);
        layoutGrid.Children.Add(tableGrid);

        // Pagination controls
        var paginationStack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.Center,
            Spacing = 20,
            Margin = new Thickness(0, 10, 0, 10),
            Children =
        {
            new Button { Text = "Prev", BackgroundColor = Colors.Green, TextColor = Colors.White, WidthRequest = 80, CornerRadius = 8 },
            new Label { Text = "Page 1/1", VerticalOptions = LayoutOptions.Center, FontSize = 14, TextColor = Colors.Black },
            new Button { Text = "Next", BackgroundColor = Colors.Green, TextColor = Colors.White, WidthRequest = 80, CornerRadius = 8 }
        }
        };
        Grid.SetRow(paginationStack, 4);
        layoutGrid.Children.Add(paginationStack);

        // Bottom Select Button
        var selectButton = new Button
        {
            Text = "Select",
            BackgroundColor = Colors.Green,
            TextColor = Colors.White,
            HeightRequest = 45,
            CornerRadius = 8,
            FontAttributes = FontAttributes.Bold
        };
        Grid.SetRow(selectButton, 5);
        layoutGrid.Children.Add(selectButton);

        // Set final content
        frame.Content = new ScrollView { Content = layoutGrid };
        popup.Content = frame;

        return popup;
    }

    private void OnDeleteIndustry(Modal.NICModel industry)
    {
        if (industry != null && SelectedIndustries.Contains(industry))
            SelectedIndustries.Remove(industry);
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




}