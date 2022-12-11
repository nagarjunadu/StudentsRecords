using Java.Net;
using System.Collections.ObjectModel;
using StudentsRecords.Contracts.Services;
using Newtonsoft.Json;
using System.Net.Http;

namespace StudentsRecords;

public partial class App : Application
{
    static StudentDB database;
    static Platforms.Android.LocalFileHelper localFileHelper;
    public App(INavigationService navigationService)
    {
        InitializeComponent();
        localFileHelper = new Platforms.Android.LocalFileHelper();
        MainPage = new NavigationPage();
        navigationService.NavigateToMainPage();
    }

    public static StudentDB Database
    {
        get
        {
            if (database == null)
            {
                database = new StudentDB(localFileHelper.GetLocalFilePath());
            }
            return database;
        }
    }
    
}

