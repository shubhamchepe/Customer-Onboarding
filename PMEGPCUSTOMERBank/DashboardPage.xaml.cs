namespace PMEGPCUSTOMERBank;
using Microsoft.Maui.Controls;

public partial class DashboardPage : ContentView
{
	public DashboardPage()
	{
		InitializeComponent();

        // Set title bar background and text color
        //Microsoft.Maui.Controls.NavigationPage.SetBarBackgroundColor(this, Color.FromArgb("#0f9d58"));
        //Microsoft.Maui.Controls.NavigationPage.SetBarTextColor(this, Colors.White);
    }
    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        if (Shell.Current != null)
            Shell.Current.GoToAsync(".."); 

        // await Navigation.PopAsync();
    }

}