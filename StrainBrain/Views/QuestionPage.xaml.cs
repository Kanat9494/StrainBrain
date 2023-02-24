namespace StrainBrain.Views;

public partial class QuestionPage : ContentPage
{
	public QuestionPage()
	{
		InitializeComponent();

		this.BindingContext = new QuestionViewModel();
	}
}