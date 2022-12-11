using System;
using SQLite;

namespace StudentsRecords
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int studentid { get; set; }
        [NotNull]
        public string studentname { get; set; }
        public string studentcourse { get; set; }
        public int studentage { get; set; }
    }
}
