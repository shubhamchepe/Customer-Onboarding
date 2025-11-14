using PMEGPCUSTOMERBank.Util;

namespace PMEGPCUSTOMERBank
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AppConstants.AppIP = "https://115.124.125.153";

            NavigateToHome();
        }

        private async void NavigateToHome()
        {
            await Task.Delay(3000); // 3 seconds wait
            await Navigation.PushAsync(new Homedashboard());
        }
    }
}
