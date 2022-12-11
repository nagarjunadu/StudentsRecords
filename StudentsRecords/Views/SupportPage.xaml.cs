namespace StudentsRecords.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SupportPage : ContentPage
{
	public SupportPage(ViewModels.AboutPageViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
