using Newtonsoft.Json;
using PMEGPCUSTOMERBank.Modal;
using PMEGPCUSTOMERBank.Util;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace PMEGPCUSTOMERBank.PopUp;

public partial class IndustryPopup : CommunityToolkit.Maui.Views.Popup
{
    public List<EdpOfficeModel> Offices { get; set; }

    public IndustryPopup(List<EdpOfficeModel> offices)
    {
        InitializeComponent();
        Offices = offices;
        BindingContext = this;
    }

    private void OnSelectClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is EdpOfficeModel selectedOffice)
        {
            Close(selectedOffice); // return selected object
        }
    }

}

public class NICModel
{
    //[JsonPropertyName("NicCode")]
    //public string NicCode { get; set; }

    //[JsonPropertyName("NicDesc")]
    //public string NicDesc { get; set; }

    //public bool IsSelected { get; set; }

    //public int SrNo { get; set; }


    public int NIC_DataID { get; set; }
    public string NicCode { get; set; }
    public string NicDesc { get; set; }
    public bool IsActive { get; set; }
    public string ActivityType { get; set; }
    public bool IsSelected { get; set; }



    // 👇 Add this
    public int SrNo { get; set; }
}
