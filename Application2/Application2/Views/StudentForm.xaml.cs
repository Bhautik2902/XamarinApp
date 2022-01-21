using Application2.Models;
using Application2.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentForm : ContentPage
    {
        public StudentForm()
        {
            InitializeComponent();
            BindingContext = this;
        }

        string gender = string.Empty;
        public void RadioButton_CheckedChanged (object sender, CheckedChangedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            gender = rb.Content as string;
        }

        public int totalstudent = 0;
        public int TotalStudents
        {
            get => totalstudent;

            set
            {
                if (totalstudent == value)
                    return;
                totalstudent = value;
                OnPropertyChanged(nameof(TotalStudents));
            }
        }
       
        SaveData saveData = new SaveData();
        private async void submit_Clicked(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                name = Name.Text.ToString(),
                email = Email.Text.ToString(),
                phone = Phone.Text.ToString(),
                gender = gender,
                std = Int32.Parse(Std.Text),
             
            };
            TotalStudents = await saveData.saveStudent(student);
            if (TotalStudents > 0)
                await DisplayAlert("Success", "Record added successfully", "Ok");
            else
                await DisplayAlert("Failure", "Submission failed!", "Cancel");

        }

        private async void SeeList_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(About)}");
        }
    }
}