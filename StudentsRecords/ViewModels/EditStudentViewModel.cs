using System;
namespace StudentsRecords.ViewModels
{
    public class EditStudentViewModel : ViewModelBase
    {
        readonly Contracts.Services.INavigationService _navigationService;

        public Command NavigateToAddStudentPageCommand
            => new Command(async () => await _navigationService.NavigateToAddStudentPage());

        public EditStudentViewModel(Contracts.Services.INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        private string _StudentName;
        public string StudentName
        {
            get => _StudentName;
            set
            {
                if (_StudentName != value)
                {
                    _StudentName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _StudentCourse;
        public string StudentCourse
        {
            get => _StudentCourse;
            set
            {
                if (_StudentCourse != value)
                {
                    _StudentCourse = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _StudentAge;
        public int StudentAge
        {
            get => _StudentAge;
            set
            {
                if (_StudentAge != value)
                {
                    _StudentAge = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _Studentid;
        public int Studentid
        {
            get => _Studentid;
            set
            {
                if (_Studentid != value)
                {
                    _Studentid = value;
                    OnPropertyChanged();
                }
            }
        }

        public override Task OnNavigatingTo(object? parameter)
        {
            var student = parameter as Student;
            StudentName = student.studentname;
            StudentCourse = student.studentcourse;
            StudentAge = student.studentage;
            Studentid = student.studentid;
            return base.OnNavigatingTo(parameter);
        }
    }

}