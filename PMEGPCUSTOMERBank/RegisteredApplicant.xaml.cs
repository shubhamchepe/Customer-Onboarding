using Newtonsoft.Json.Linq;
using PMEGPCUSTOMERBank.Util;

namespace PMEGPCUSTOMERBank;

public partial class RegisteredApplicant : ContentPage
{
    private string userId;
    private string password;
    private string captcha;
    private string captchaInput;

    public RegisteredApplicant()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        //var page = new ContentPage
        //{
        //   // Title = "Dashboard", // Optional
        //    Content = new Navbar() // ✅ Embed ContentView inside a Page
        //};
        //NavigationPage.SetHasNavigationBar(page, false);
        //await Navigation.PushAsync(page);




        //var userId = UserIdEntry.Text?.Trim();
        //var password = PasswordEntry.Text?.Trim();

        //if (string.IsNullOrWhiteSpace(userId))
        //{
        //    await DisplayAlert("Validation", "User ID is required", "OK");
        //    return;
        //}
        //if (string.IsNullOrWhiteSpace(password))
        //{
        //    await DisplayAlert("Validation", "Password is required", "OK");
        //    return;
        //}

        try
        {
            //string getUrl = "https://192.168.0.16:8054/MobileApp/AuthenticateApplLogin";

            //// 🔹 Normal JSON
            //string jsonString = $"{{\"UserID\":\"{userId}\",\"Password\":\"{password}\"}}";

            ////  string actionNam = "AuthenticateAppLogin";

            //string getData = await HttpClientClass.PostRequestAsync(getUrl, jsonString);

            //// 🔹 Parse JSON response
            //var json = JObject.Parse(getData);

            //// Assign values to constants
            //AppConstants.ApplCode = json["ApplCode"]?.ToString();
            //AppConstants.ApplID = json["ApplID"]?.ToString();

            var dashboardView = new Navbar();
            var page = new ContentPage
            {
                Title = "Dashboard",
                Content = dashboardView
            };

            NavigationPage.SetHasNavigationBar(page, false);

            // Push to navigation stack
            await Navigation.PushAsync(page);

            //// Show only message
            //string message = json["message"]?.ToString();
            //await DisplayAlert("Response", message, "OK");



        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }


}