using Application2.Models;
using Application2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Application2.Services
{
    public class SaveData
    {
        public static ObservableCollection<Student> studentlist = new ObservableCollection<Student>();
        public Command DeleteCommand { get; set; }
        public Command EditCommand { get; set; }

        public ObservableCollection<Student> StudentList
        {
            get => studentlist;
            set
            {
                if (studentlist == value)
                    return;
                studentlist = value;
            }
        }

        public SaveData()
        {
            Refresh();
            DeleteCommand = new Command<int>(deleteStudentRecord);
        }

        async void deleteStudentRecord(int id)
        {
            bool sure = await Application.Current.MainPage.DisplayAlert("Alert!", "Are you sure?", "Yes", "Cancel");

            if (sure)
            {
                int count = await DBServices.DeleteRecord(id);
                try
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Record deleted successfully!", "Ok");
                    await Refresh();
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Failure", e.Message, "Ok");
                }   
            }
        }

        public async Task<string> editStudentRecord(Student s, int id)
        {
            string status = await DBServices.EditRecord(s, id);
            await Refresh();
            return status;
        }
        public async Task Refresh()
        {
            StudentList.Clear();
            var sl = await GetAllStudents();
            
            foreach (var student in sl)
            {
                StudentList.Add(student);
            }
        }
        public async Task<int> saveStudent(Student s)
        {
            try
            {
                var id = await DBServices.CreateRecord(s);
                await Refresh();
                return id;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await DBServices.GetAllRecords();
        }
    }
}
