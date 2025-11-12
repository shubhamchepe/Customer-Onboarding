using Newtonsoft.Json;
using PMEGPCUSTOMERBank.Modal;
using PMEGPCUSTOMERBank.Util;
using System.Collections.ObjectModel;

namespace PMEGPCUSTOMERBank;

public partial class ScoreCardView : ContentView
{

    // ObservableCollection for dynamic binding
    public ObservableCollection<ScoreParameter> ScoreParametersCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> NoOfDependencies { get; set; } = new();
    public ObservableCollection<ScoreParameter> OwningAhouseCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> ResidingAtTheSameAddressCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> AcademicQualificationsCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> ExperienceLineOfTradeCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> AnyotherSourceofIncomeCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> AssessedForIncomeTaxCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> HavingLifeInsurancePolicyCollection  { get; set; } = new();
    public ObservableCollection<ScoreParameter> RelationshipwithlendingBankCollection   { get; set; } = new();
    public ObservableCollection<ScoreParameter> CreditHistoryCollection   { get; set; } = new();
    public ObservableCollection<ScoreParameter> LocationAdvantageCollection   { get; set; } = new();
    public ObservableCollection<ScoreParameter> SkillCertificationCourseCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> MarketingCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> LineofActivityCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> GovtAuthoritiesCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> RepaymentperiodCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> EmploymentGenerationCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> DSCRCollection { get; set; } = new();
    public ObservableCollection<ScoreParameter> CollateralCollection { get; set; } = new();







    public ScoreCardView()
	{
		InitializeComponent();
        BindingContext = this; // Bind ObservableCollection and properties
        GetScoreCardData();

    }

    private Applicant _applicantData;

    private async void GetScoreCardData()
    {
        string apiUrl = $"{AppConstants.AppIP}/MobileApp/ScoreCard";
        int AppID = 7490;

        var payload = new { ApplID = AppID };
        string jsonString = JsonConvert.SerializeObject(payload);

        string response = await HttpClientClass.PostAsyncTask(apiUrl, jsonString);

        var result = JsonConvert.DeserializeObject<ScoreCardResponse>(response);

        if (result != null && result.status && result.applicant != null)
        {
            _applicantData = result.applicant;

            // Set Labels manually
            Total.Text = result.maximumMarks.ToString();
            Percentange.Text = "0.00%";

            // Clear old items and add new dynamically
            ScoreParametersCollection.Clear();
            foreach (var item in result.scoreParameters
                         .Where(x => x.ScrParameter == "Applicant's Age :"))
            {
                ScoreParametersCollection.Add(item);
            }

            // NoOfDependencies
            NoOfDependencies.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "No. of dependencies"))
            {
                NoOfDependencies.Add(item);
            }

            // OwningAhouseCollection
            OwningAhouseCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Owning a house/parental house"))
            {
                OwningAhouseCollection.Add(item);
            }

            // ResidingAtTheSameAddressCollection
            ResidingAtTheSameAddressCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Residing at the same address / location"))
            {
                ResidingAtTheSameAddressCollection.Add(item);
            }

            // AcademicQualificationsCollection
            AcademicQualificationsCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Academic Qualifications"))
            {
                AcademicQualificationsCollection.Add(item);
            }


            // ExperienceLineOfTrade
            ExperienceLineOfTradeCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Experience in the line of trade"))
            {
                ExperienceLineOfTradeCollection.Add(item);
            }


            // AnyotherSourceofIncomeCollection
            AnyotherSourceofIncomeCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Any other source of income including family"))
            {
                AnyotherSourceofIncomeCollection.Add(item);
            }
            // AssessedForIncomeTaxCollection
            AssessedForIncomeTaxCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Assessed for Income Tax"))
            {
                AssessedForIncomeTaxCollection.Add(item);
            }

            // HavingLifeInsurancePolicyCollection
            HavingLifeInsurancePolicyCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Experience in the line of trade"))
            {
                HavingLifeInsurancePolicyCollection.Add(item);
            }


            // RelationshipwithlendingBankCollection
            RelationshipwithlendingBankCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Relationship with lending bank ( Opening Date of Bank Account) (dd-mmm-yyyy)"))
            {
                RelationshipwithlendingBankCollection.Add(item);
            }
            // CreditHistoryCollection
            CreditHistoryCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Credit History"))
            {
                CreditHistoryCollection.Add(item);
            }
            // LocationAdvantageCollection
            LocationAdvantageCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Location Advantage (availability of infrastructure, raw materials, labour, proximity to markets etc.)"))
            {
                LocationAdvantageCollection.Add(item);
            }

            // SkillCertificationCourseCollection
            SkillCertificationCourseCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Skill Certification Course / RSETI / ITS / Computer knowledge"))
            {
                SkillCertificationCourseCollection.Add(item);
            }
            // MarketingCollection
            MarketingCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Marketing Tie ups for sale of products"))
            {
                MarketingCollection.Add(item);
            }
            // LineofActivity
            LineofActivityCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Line of Activity"))
            {
                LineofActivityCollection.Add(item);
            }
            // GovtAuthoritiesCollection
            GovtAuthoritiesCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Registered with Govt. authorities viz for sales Tax/Vat/licence from local bodies/shop act etc."))
            {
                GovtAuthoritiesCollection.Add(item);
            }
            // RepaymentperiodCollection
            RepaymentperiodCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Repayment period (not applicable for only working capital loans)."))
            {
                RepaymentperiodCollection.Add(item);
            }
            // Employment Generation
            EmploymentGenerationCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Employment Generation"))
            {
                EmploymentGenerationCollection.Add(item);
            }
            // DSCRCollection Generation
            DSCRCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Avg. DSCR (not applicable for working capital loans)"))
            {
                DSCRCollection.Add(item);
            }
            // CollateralCollection Generation
            CollateralCollection.Clear();
            foreach (var item in result.scoreParameters
                        .Where(x => x.ScrParameter == "Collateral Securities Coverage:"))
            {
                CollateralCollection.Add(item);
            }
        }
    }


}