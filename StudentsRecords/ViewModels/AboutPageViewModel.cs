using System;
namespace StudentsRecords.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        readonly Contracts.Services.INavigationService _navigationService;
        public AboutPageViewModel(Contracts.Services.INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
