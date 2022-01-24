using Application2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadioBinding : ContentPage
    {
        public List<Person> PersonList { get; set; }
        public RadioBinding()
        {
            InitializeComponent();

            PersonList = new List<Person>()
            {
                new Person {Index=1, Name="Bhautik", Travel=true, Dance = false, Reading = false, Sports = false },
                new Person {Index=2, Name="Rohil", Travel=false, Dance = false, Reading = true, Sports = false },
                new Person {Index=3, Name="Nirav", Travel=false, Dance = false, Reading = false, Sports = true },
                new Person {Index=4, Name="Hiral", Travel=false, Dance = true, Reading = false, Sports = false },
                new Person {Index=5, Name="Anand", Travel=false, Dance = false, Reading = false, Sports = true },
            };

            BindingContext = this;
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var rb = sender as RadioButton;
            var item = (Person)rb.BindingContext;

            string val = rb.Value as string;
            if (val == "Travel")
            {
                item.Dance = false;
                item.Reading = false;
                item.Sports = false;
                item.Travel = true;
            }
            else if (val == "Dance")
            {
                item.Dance = true;
                item.Reading = false;
                item.Sports = false;
                item.Travel = false;
            }
            else if (val == "Reading")
            {
                item.Dance = false;
                item.Reading = true;
                item.Sports = false;
                item.Travel = false;
            }
            else if (val == "Sports")
            {
                item.Dance = false;
                item.Reading = false;
                item.Sports = true;
                item.Travel = false;
            }

            // make update call with updated 'item' to dbservice.
        }

        
    }
}