namespace StrainBrain.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HomePage : ContentPage
{
    public HomePage()
	{
		InitializeComponent();

		HomeContent.SetAppThemeColor(BackgroundProperty, light: Color.FromRgb(255, 255, 255), dark: Color.FromRgb(255, 255, 255));

		this.BindingContext = new HomeViewModel();
	}
}