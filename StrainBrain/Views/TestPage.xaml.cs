namespace StrainBrain.Views;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
	}

	void ShowInterstitial_Clicked(System.Object sender, System.EventArgs e)
	{
        CrossMauiMTAdmob.Current.OnInterstitialLoaded += (s, args) =>
        {
            CrossMauiMTAdmob.Current.ShowInterstitial();
        };

        CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712");
	}
}