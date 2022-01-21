
using Application2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Application2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StudentDetails), typeof(StudentDetails));
        }    
    }
}
