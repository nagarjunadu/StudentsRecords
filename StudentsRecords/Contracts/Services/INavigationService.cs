using System;
namespace StudentsRecords.Contracts.Services
{
    public interface INavigationService
    {
        Task NavigateToAddStudentPage();
        Task NavigateToAboutPage();
        Task NavigateToSupportPage();
        Task NavigateToEditStudentPage(Student student);
        Task NavigateBack();
        Task NavigateToMainPage();
    }
}

