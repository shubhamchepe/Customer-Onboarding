namespace PMEGPCUSTOMERBank;

public partial class Navbar : ContentView
{
    private RegisteredApplicantsDashboardView _form1;
    private DPRView _form2;
    private ScoreCardView _form3;

    //private readonly ScoreCardView _form3 = new ScoreCardView();
    //private readonly UploadDocsView _form4 = new UploadDocsView();
    //private readonly FinalSubmissionView _form5 = new FinalSubmissionView();
    //private readonly UnderProcessView _form6 = new UnderProcessView();
    //private readonly LoanSanctionView _form7 = new LoanSanctionView();

    public Navbar()
    {
        InitializeComponent();
        LoadForm(1); // default step
        HighlightStep(1);
    }

    private void OnStepTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is string stepId && int.TryParse(stepId, out int stepNumber))
        {
            LoadForm(stepNumber);
            HighlightStep(stepNumber);
        }
    }

    private void LoadForm(int step)
    {
        switch (step)
        {
            case 1:
                _form1 ??= new RegisteredApplicantsDashboardView();
                FormContainer.Content = _form1;
                break;

            case 2:
                _form2 ??= new DPRView();
                FormContainer.Content = _form2;
                break;
            case 3:

                _form3 ??= new ScoreCardView();
                FormContainer.Content = _form3;
                break;

            // add similar logic for other steps
            default:
                FormContainer.Content = null;
                break;
        }
    }


    private void HighlightStep(int stepNumber)
    {
        // Reset all
        Step1Circle.BackgroundColor = Colors.LightGray;
        Step2Circle.BackgroundColor = Colors.LightGray;
        //Step3Circle.BackgroundColor = Colors.LightGray;
        //Step4Circle.BackgroundColor = Colors.LightGray;
        //Step5Circle.BackgroundColor = Colors.LightGray;
        //Step6Circle.BackgroundColor = Colors.LightGray;
        //Step7Circle.BackgroundColor = Colors.LightGray;

        // Highlight selected
        switch (stepNumber)
        {
            case 1: Step1Circle.BackgroundColor = Colors.Orange; break;
            case 2: Step2Circle.BackgroundColor = Colors.Orange; break;
            case 3: Step3Circle.BackgroundColor = Colors.Orange; break;
            case 4: Step4Circle.BackgroundColor = Colors.Orange; break;
            case 5: Step5Circle.BackgroundColor = Colors.Orange; break;
            case 6: Step6Circle.BackgroundColor = Colors.Orange; break;
            case 7: Step7Circle.BackgroundColor = Colors.Orange; break;
        }
    }
}
