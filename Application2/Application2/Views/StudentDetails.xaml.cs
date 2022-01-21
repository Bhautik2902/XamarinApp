using Application2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetails : ContentPage
    {
        public StudentDetails()
        {
            InitializeComponent();
            string stu_details = Application.Current.Properties["stu_details"].ToString();
            Student s = JsonConvert.DeserializeObject<Student>(stu_details);

            id.Text = s.id.ToString();
            fname.Text = s.name;
            femail.Text = s.email;
            fcontact.Text = s.phone;
            fstd.Text = s.std.ToString();
            fgender.Text = s.gender;

        }
    }
}