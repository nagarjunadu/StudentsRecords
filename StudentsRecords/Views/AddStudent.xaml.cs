using AndroidX.Lifecycle;
using StudentsRecords.ViewModels;

namespace StudentsRecords;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AddStudent : ContentPage
{
    public AddStudent(AddStudentViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
        Save.Clicked += async (sender, e) =>
        {
            Student student = new Student()
            {
                studentname = viewModel.StudentName,
                studentcourse = viewModel.StudentCourse,
                studentage = viewModel.StudentAge
            };
            await App.Database.SaveStudentAsync(student);
            await Navigation.PopAsync();
        };
        Cancel.Clicked += async (sender, e) =>
        {
            await Navigation.PopAsync();
        };
    }
}
