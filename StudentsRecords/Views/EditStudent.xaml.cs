using AndroidX.Lifecycle;

namespace StudentsRecords;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class EditStudent : ContentPage
{
    public EditStudent(ViewModels.EditStudentViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();

        Save.Clicked += async (sender, e) =>
        {
            Student student = new Student()
            {
                studentname = viewModel.StudentName,
                studentcourse = viewModel.StudentCourse,
                studentage = viewModel.StudentAge,
                studentid = viewModel.Studentid,
            };
            await App.Database.SaveStudentAsync(student);
            await Navigation.PopAsync();
        };
        Delete.Clicked += async (sender, e) =>
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                Student student = new Student()
                {
                    studentname = viewModel.StudentName,
                    studentcourse = viewModel.StudentCourse,
                    studentage = viewModel.StudentAge,
                    studentid = viewModel.Studentid,
                };
                await App.Database.DeleteStudentAsync(student);
                await Navigation.PopAsync();
            }
            
        };
    }
}
