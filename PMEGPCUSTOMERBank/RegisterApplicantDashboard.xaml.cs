using CommunityToolkit.Maui.Views;

namespace PMEGPCUSTOMERBank;

public partial class RegisterApplicantDashboard : ContentPage
{
	public RegisterApplicantDashboard()
	{
        // unuse file //
		InitializeComponent();
	}
    private void OnStepTapped(object sender, EventArgs e)
    {
        Step1Circle.BackgroundColor = Colors.LightGray;
        Step2Circle.BackgroundColor = Colors.LightGray;
        Step3Circle.BackgroundColor = Colors.LightGray;
        Step4Circle.BackgroundColor = Colors.LightGray;
        Step5Circle.BackgroundColor = Colors.LightGray;
        Step6Circle.BackgroundColor = Colors.LightGray;
        Step7Circle.BackgroundColor = Colors.LightGray;
        Step8Circle.BackgroundColor = Colors.LightGray;



        if (sender == Step1Circle)
        {
            Step1Circle.BackgroundColor = Colors.Orange;
        }
        else if (sender == Step2Circle)
        {
            Step2Circle.BackgroundColor = Colors.Orange;
        }
        else if (sender == Step3Circle)
        {
            Step3Circle.BackgroundColor = Colors.Orange;
        }
        else if (sender == Step4Circle)
        {
            Step4Circle.BackgroundColor = Colors.Orange;
        }
        else if (sender == Step4Circle)
        {
            Step5Circle.BackgroundColor = Colors.Orange;
        }
        else if (sender == Step4Circle)
        {
            Step6Circle.BackgroundColor = Colors.Orange;
        }
        else if (sender == Step4Circle)
        {
            Step7Circle.BackgroundColor = Colors.Orange;
        }
        else if (sender == Step4Circle)
        {
            Step7Circle.BackgroundColor = Colors.Orange;
        }
    }

    private void OnExpanderChanged(object sender, CommunityToolkit.Maui.Core.ExpandedChangedEventArgs e)
    {
        if (sender is not Expander openedExpander || !openedExpander.IsExpanded)
            return;

        foreach (var child in ExpanderContainer.Children)
        {
            if (child is Expander expander && expander != openedExpander)
            {
                expander.IsExpanded = false;
            }
        }
    }
}