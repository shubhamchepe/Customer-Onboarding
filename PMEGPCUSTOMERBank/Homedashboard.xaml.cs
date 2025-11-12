namespace PMEGPCUSTOMERBank;

public partial class Homedashboard : ContentPage
{
    public List<string> BannerImages { get; set; }

    public Homedashboard()
    {
        InitializeComponent();

        BannerImages = new List<string>
        {
            "image1.png",
            "image2.png",
            "image3.png",
            "image4.png"
        };

        BindingContext = this;

        // Start Auto Slide after load
        Loaded += (s, e) => StartAutoSlide();
    }

    private void StartAutoSlide()
    {
        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        {
            if (bannerCarousel?.ItemsSource is IList<string> items && items.Count > 0)
            {
                var nextIndex = (bannerCarousel.Position + 1) % items.Count;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    bannerCarousel.Position = nextIndex;
                });
            }
            return true; // keep repeating
        });
    }

    private async void OnNewUnitTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ApplicationForNewUnit());
    }

    private async void OnRegisteredApplicantTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistredApplicantLogin());
    }

    private async void OnRegisteredApplicantTappedd(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisteredApplicant());
    }
}
