using System.Collections.ObjectModel;

namespace PMEGPCUSTOMERBank.PopUp;

public partial class IndustrySelectionPage : ContentPage
{
    public ObservableCollection<IndustryModel> IndustryList { get; set; }
    public IndustrySelectionPage()
	{
		InitializeComponent();
        IndustryList = new ObservableCollection<IndustryModel>
        {
            new IndustryModel { NICCode="05101", Description="Opencast mining of hard coal" },
            new IndustryModel { NICCode="05102", Description="Belowground mining of hard coal" },
            new IndustryModel { NICCode="05201", Description="Opencast mining of lignite (brown coal)" },
            new IndustryModel { NICCode="08101", Description="Off shore extraction of crude petroleum" }
        };

        BindingContext = this;
    }

    private void OnClearFilters(object sender, EventArgs e)
    {
        searchEntry.Text = string.Empty;
    }

    private async void OnSelectClicked(object sender, EventArgs e)
    {
        var selected = IndustryList.Where(x => x.IsSelected).ToList();

        if (selected.Count == 0)
        {
            await DisplayAlert("Alert", "Please select at least one industry.", "OK");
            return;
        }

        string selectedIndustries = string.Join(", ", selected.Select(x => x.NICCode + " - " + x.Description));
        await DisplayAlert("Selected Industries", selectedIndustries, "OK");
    }
}
public class IndustryModel
{
    public bool IsSelected { get; set; }
    public string NICCode { get; set; }
    public string Description { get; set; }
}