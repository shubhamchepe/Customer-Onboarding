using Newtonsoft.Json.Linq;
using PMEGPCUSTOMERBank.Modal.Login;
using PMEGPCUSTOMERBank.Util;
using System.Text;
using System.Text.Json;

namespace PMEGPCUSTOMERBank;

public partial class RegistredApplicantLogin : ContentPage
{
    private string? captchaInput;
    private string? userId;
    private string? password;
    public string? captcha;

    public RegistredApplicantLogin()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
         //TrustMethods.StartStopLoader(1);

        var userId = UserIdEntry.Text?.Trim();
        var password = PasswordEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(userId))
        {
            await DisplayAlert("Validation", "User ID is required", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Validation", "Password is required", "OK");
            return;
        }

        try
        {
            string getUrl = "https://192.168.0.16:8054/MobileApp/AuthenticateApplLogin";

            // 🔹 Normal JSON
            string jsonString = $"{{\"UserID\":\"{userId}\",\"Password\":\"{password}\"}}";

          //  string actionNam = "AuthenticateAppLogin";

            string getData = await HttpClientClass.PostRequestAsync(getUrl, jsonString);

            // 🔹 Parse JSON response
            var json = JObject.Parse(getData);

            // Assign values to constants
            AppConstants.ApplCode = json["ApplCode"]?.ToString();
            AppConstants.ApplID = json["ApplID"]?.ToString();  
                                                              

            // Show only message
            string message = json["message"]?.ToString();
            await DisplayAlert("Response", message, "OK");


            await Navigation.PushAsync(new RegisteredApplicantsDashboard());
           // TrustMethods.StartStopLoader(0);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }



    //private async Task PerformRequestsAsyncpost()
    //{

    //    string getUrl = TrustUrls.verifyMobileNoUrl();
    //    string jsonString = $"{{\"mobile_number\":\"{mobileNumber}\",\"custid\":\"{clientId}\"}}";
    //    string actionNam = "VERIFY_MOBILE_NUMBER";

    //    string getData = await HttpClientClass.PostRequestAsync(getUrl, jsonString, actionNam);

    //    VerifyMobileModal verifyMobileModal = JsonSerializer.Deserialize<VerifyMobileModal>(getData);

    //    if (verifyMobileModal.ResponseCode != null)
    //    {
    //        if (verifyMobileModal.ResponseCode == 1)
    //        {
    //            GenerateotpForReg();

    //        }
    //        else
    //        {
    //            if (!string.IsNullOrEmpty(verifyMobileModal.ErrorMessage))
    //            {
    //                TrustMethods.StartStopLoader(0);

    //                await DisplayAlert("Error", verifyMobileModal.ErrorMessage, "OK");
    //            }
    //        }
    //    }

    //}


}