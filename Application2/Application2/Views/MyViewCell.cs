using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace Application2.Views
{
    class MyViewCell : ViewCell
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!(Parent is ListView listView))
                throw new Exception(
                    $"The Binding Context is not {typeof(ListView)}. This component works only with {typeof(ListView)}.");

            int index;
            if (listView.IsGroupingEnabled)
            {
                index = listView.TemplatedItems.GetGroupAndIndexOfItem(BindingContext).Item2;
            }
            else
            {
                index = listView.TemplatedItems.IndexOf(this);
            }

            if (index != -1)
                View.BackgroundColor = index % 2 == 0 ? Color.Azure : Color.White;
        }
    }
}
