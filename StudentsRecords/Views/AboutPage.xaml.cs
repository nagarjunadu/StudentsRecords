namespace StudentsRecords.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AboutPage : ContentPage
{
	public AboutPage(ViewModels.AboutPageViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
