using System.Collections.ObjectModel;
using AndroidX.Lifecycle;
using Newtonsoft.Json;
using StudentsRecords.ViewModels;

namespace StudentsRecords;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage : ContentPage
{
    ObservableCollection<Student> studentslist = new ObservableCollection<Student>();
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var students = await App.Database.GetStudentsAsync();
        if (students.Count == 0)
        {
            APICall();
        }

        StudentsListview.ItemsSource = null;
        studentslist.Clear();
        studentslist = new ObservableCollection<Student>(await App.Database.GetStudentsAsync());
        StudentsListview.ItemsSource = studentslist;
    }
    public MainPage(MainPageViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
        this.Title = "Student List";
        var toolbarItem1 = new ToolbarItem
        {
            IconImageSource = "add.png"
        };
        toolbarItem1.Clicked += async (sender, e) =>
        {
            viewModel.NavigateToAddStudentPageCommand.Execute(sender);
        };
        var toolbarItem2 = new ToolbarItem
        {
            IconImageSource = "about.png"
        };
        toolbarItem2.Clicked += async (sender, e) =>
        {
            viewModel.NavigateToAboutPageCommand.Execute(sender);
        };
        var toolbarItem3 = new ToolbarItem
        {
            IconImageSource = "support.png"
        };
        toolbarItem3.Clicked += async (sender, e) =>
        {
            viewModel.NavigateToSupportPageCommand.Execute(sender);
        };
        ToolbarItems.Add(toolbarItem1);
        ToolbarItems.Add(toolbarItem2);
        ToolbarItems.Add(toolbarItem3);
        StudentsListview.ItemSelected += async (object sender, SelectedItemChangedEventArgs e) =>
        {
            if (e.SelectedItem != null)
            {
                viewModel.NavigateToEditStudentPageCommand.Execute(e.SelectedItem);
            }
        };
    }
   

    private const string url = "https://10.0.2.2:7025/students";
    private HttpClient _Client;
    private List<Student> Studentslist;

    private async void APICall()
    {
        try
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            _Client = new HttpClient(httpClientHandler);
            var httpResponse = await _Client.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                List<Student> responseData = JsonConvert.DeserializeObject<List<Student>>(await httpResponse.Content.ReadAsStringAsync());
                Studentslist = new List<Student>(responseData);
                await App.Database.SaveStudentsAsync(Studentslist);
                StudentsListview.ItemsSource = null;
                studentslist.Clear();
                studentslist = new ObservableCollection<Student>(await App.Database.GetStudentsAsync());
                StudentsListview.ItemsSource = studentslist;
            }
        }
        catch (Exception ex)
        {

        }

    }
}


