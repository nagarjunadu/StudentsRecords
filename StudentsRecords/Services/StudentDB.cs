using System;
using SQLite;

namespace StudentsRecords
{
    public class StudentDB
    {
        readonly SQLiteAsyncConnection database;
        public StudentDB(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Student>().Wait();
        }
        public Task<List<Student>> GetStudentsAsync()
        {
            return database.Table<Student>().ToListAsync();
        }
        public Task<Student> GetStudentAsync(int id)
        {
            return database.Table<Student>().Where(i => i.studentid == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveStudentAsync(Student student)
        {
            if (student.studentid != 0)
            {
                return database.UpdateAsync(student);
            }
            else
            {
                return database.InsertAsync(student);
            }
        }

        public Task<int> SaveStudentsAsync(List<Student> students)
        {
            database.Table<Student>().DeleteAsync();
            return database.InsertAllAsync(students);
        }
        public Task<int> DeleteStudentAsync(Student student)
        {
            return database.DeleteAsync(student);
        }

        public Task<int> EditStudent(Student student)
        {
            return database.UpdateAsync(student);
        }
    }
}
