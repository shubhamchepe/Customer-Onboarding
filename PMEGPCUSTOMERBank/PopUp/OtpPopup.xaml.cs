using CommunityToolkit.Maui.Views;

namespace PMEGPCUSTOMERBank.PopUp;

public partial class OtpPopup : Popup
{
	public OtpPopup()
	{
		InitializeComponent();


        // Event handlers
        consentCheck.CheckedChanged += ConsentCheck_CheckedChanged;
        otpEntry.TextChanged += OtpEntry_TextChanged;
    }
    private void ConsentCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        ValidateSubmitButton();
    }

    private void OtpEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ValidateSubmitButton();
    }

    private void ValidateSubmitButton()
    {
        // Button tabhi enable hoga jab checkbox checked hai aur OTP likha hai
        submitButton.IsEnabled = consentCheck.IsChecked && !string.IsNullOrWhiteSpace(otpEntry.Text);
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (!consentCheck.IsChecked)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please check consent box", "OK");
            return;
        }

        if (string.IsNullOrEmpty(otpEntry.Text))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter OTP first", "OK");
            return;
        }

        // ✅ Return OTP to caller
        Close(otpEntry.Text);
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}