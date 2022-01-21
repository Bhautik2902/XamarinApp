using Application2.Models;
using Application2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public Student StudentObj { get; set; }
        
        public About()
        {
            InitializeComponent();
            BindingContext = new SaveData();
            EditPopUp.BindingContext = this;
        }

        private async void ShowStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student student = e.CurrentSelection[0] as Student;
            string stu_details = JsonConvert.SerializeObject(student);
            Application.Current.Properties["stu_details"] = stu_details;
            await Navigation.PushAsync(new StudentDetails());
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            myrefreshView.IsRefreshing = false;
        }

        private int swipedItemId = 0;
        private void Edit_Invoked(object sender, EventArgs e)
        {
            EditPopUp.IsVisible = true;
            var item = sender as SwipeItem;
            var student = item.BindingContext as Student;

            StudentObj = student;
            Name.Text = student.name;
            Email.Text = student.email;
            Phone.Text = student.phone;
            Std.Text = student.std.ToString();
            swipedItemId = student.id;

            if (student.gender == "Male")
                male.IsChecked = true;
            else if (student.gender == "Female")
                female.IsChecked = true;
            else
                others.IsChecked = true;
        }

        private async void save_Clicked(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                name = Name.Text.ToString(),
                email = Email.Text.ToString(),
                phone = Phone.Text.ToString(),
                gender = Gender,
                std = Int32.Parse(Std.Text),
            };
            string status = await new SaveData().editStudentRecord(student, swipedItemId);
            await DisplayAlert("Status", status, "Ok");
        }
        private void cancel_Clicked(object sender, EventArgs e)
        {
            EditPopUp.IsVisible = false;
        }

        string Gender = string.Empty;
        public void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            Gender = rb.Content as string;
        }

        public async Task<bool> DisplayConfirmation(string title, string msg)
        {
            return await DisplayAlert(title, msg, "Yes", "No");
        }
    }
}