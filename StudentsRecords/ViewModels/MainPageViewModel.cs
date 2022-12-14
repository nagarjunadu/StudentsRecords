using System;
using StudentsRecords.Contracts.Services;

namespace StudentsRecords.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;

       
        public Command NavigateToAboutPageCommand
            => new Command(async () => await _navigationService.NavigateToAboutPage());
        public Command NavigateToAddStudentPageCommand
           => new Command(async () => await _navigationService.NavigateToAddStudentPage());


        public Command NavigateToSupportPageCommand
            => new Command(async () => await _navigationService.NavigateToSupportPage());

        public Command NavigateToEditStudentPageCommand
            => new Command(async (e) => await _navigationService.NavigateToEditStudentPage(e as Student));

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
