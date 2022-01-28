using Application2.Models;
using Application2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Application2.Views
{
    public class StudentSearchHandler : SearchHandler
    {
        public static IEnumerable<Student> students { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        public StudentSearchHandler()
        {
            new Action(async () => await InitializeThingsAsync())();
        }

        public async Task InitializeThingsAsync()
        {
            students = await DBServices.GetAllRecords();
        }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                if (students.Count() != 0)
                {
                    ItemsSource = students
                        .Where(student => student.name.ToLower().Contains(newValue.ToLower()))
                        .ToList<Student>();
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "No data to search", "Ok");
                }
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            string item_detail = JsonConvert.SerializeObject(item);
            Application.Current.Properties["stu_details"] = item_detail;

            await Shell.Current.GoToAsync($"{nameof(StudentDetails)}");
        } 
    }
}
