namespace StrainBrain.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class QuestionPage : ContentPage
{
	public QuestionPage()
	{
		InitializeComponent();

		//ActivityIndicatorFrame.BackgroundColor = Color.FromRgba(204, 0, 0, 0.5);

        this.BindingContext = new QuestionViewModel();
	}
}