using System;

[assembly: Dependency(typeof(StudentsRecords.Platforms.Android.LocalFileHelper))]
namespace StudentsRecords.Platforms.Android
{
    public class LocalFileHelper
    {
        public string GetLocalFilePath()
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, "Student1.db3");
        }
    }
}