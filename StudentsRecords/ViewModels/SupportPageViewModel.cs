using System;
namespace StudentsRecords.ViewModels
{
    public class SupportPageViewModel : ViewModelBase
    {
        readonly Contracts.Services.INavigationService _navigationService;
        public SupportPageViewModel(Contracts.Services.INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
