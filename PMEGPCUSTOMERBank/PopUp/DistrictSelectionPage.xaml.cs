using PMEGPCUSTOMERBank.Modal;

namespace PMEGPCUSTOMERBank.PopUp;

public partial class DistrictSelectionPage : ContentPage
{

    public List<DistrictModel> Districts { get; set; }
    private TaskCompletionSource<DistrictModel> _tcs;

    public DistrictSelectionPage(List<DistrictModel> districts)
    {
        InitializeComponent();
        Districts = districts;
        BindingContext = this;
        _tcs = new TaskCompletionSource<DistrictModel>();
    }

    public Task<DistrictModel> ShowAsync()
    {
        return _tcs.Task;
    }

    private void OnSelectClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var district = (DistrictModel)button.BindingContext;
        _tcs.SetResult(district);
        Navigation.PopModalAsync();
    }

    //private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    var filtered = string.IsNullOrWhiteSpace(e.NewTextValue)
    //        ? Districts
    //        : Districts.Where(d => d.District_Name.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase)
    //                            || d.District_Code.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase))
    //                   .ToList();

    //    districtCollection.ItemsSource = filtered;
    //}
    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            var text = e.NewTextValue?.Trim() ?? string.Empty;

            var filtered = string.IsNullOrWhiteSpace(text)
                ? Districts
                : Districts.Where(d =>
                       (!string.IsNullOrEmpty(d.District_Name) &&
                        d.District_Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                    || (!string.IsNullOrEmpty(d.District_Code) &&
                        d.District_Code.Contains(text, StringComparison.OrdinalIgnoreCase))
                  ).ToList();

            districtCollection.ItemsSource = filtered;
        }
        catch (Exception ex)
        {
            Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }


    private void OnBackClicked(object sender, EventArgs e)
    {
        _tcs.SetResult(null); // Nothing selected
        Navigation.PopModalAsync();
    }
}