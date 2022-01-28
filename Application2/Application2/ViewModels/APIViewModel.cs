using Application2.Models;
using Application2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Application2.ViewModels
{
    class APIViewModel
    {
        public static ObservableCollection<Contact> apiRecords = new ObservableCollection<Contact>();
        public static ObservableCollection<Contact> APIRecords
        {
            get => apiRecords;
            set
            {
                if (apiRecords == value)
                    return;
                apiRecords = value;
            }
        }
        
        public APIViewModel()
        {
            Refresh();
        }
        public void Refresh()
        {
            APIRecords.Clear();
            var sl = GetAllApiRecords();

            foreach (var record in sl)
            {
                APIRecords.Add(record);
            }
        }

        public IEnumerable<Contact> GetAllApiRecords()
        {
            var allResult = APIServices.GetAllRecords();
            return allResult;
        }
    }
}
