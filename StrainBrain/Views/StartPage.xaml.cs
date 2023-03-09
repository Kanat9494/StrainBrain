namespace StrainBrain.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();

		this.BindingContext = new StartViewModel();
	}
}