using Application2.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Application2.Services
{
    class DBServices
    {
        static SQLiteAsyncConnection db;

        // create database connection
        public static async Task Init()
        {
            if (db != null)
                return;

            // get absolute path to database
            var dbpath = Path.Combine(FileSystem.AppDataDirectory, "StudentData.db");

            // connect to database
            db = new SQLiteAsyncConnection(dbpath);

            // create table
            await db.CreateTableAsync<Student>();
        }

        public static async Task<int> CreateRecord(Student student)
        {
            // check that database is already created
            await Init();
            return await db.InsertAsync(student);
        }

        public static async Task<string> EditRecord(Student student, int id)
        {
            await Init();
            student.id = id;
            int rows_affected = await db.UpdateAsync(student);
            if (rows_affected > 0)
                return "Update Successful";
            else
                return "Error Occured";
        }

        public static async Task<int> DeleteRecord(int id)
        {
            await Init();
            return await db.DeleteAsync<Student>(id);
        }

        public static async Task<IEnumerable<Student>> GetAllRecords()
        {
            await Init();
            var students = await db.Table<Student>().ToListAsync();

            return students;
        }
    }
}
