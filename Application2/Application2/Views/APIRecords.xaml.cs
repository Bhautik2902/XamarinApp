using Application2.ViewModels;
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
    public partial class APIRecords : ContentPage
    {
        public APIRecords()
        {
            InitializeComponent();
            BindingContext = new APIViewModel();
        }

        private void myrefreshView_Refreshing(object sender, EventArgs e)
        {

        }

        private void ShowRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

        }
    }
}