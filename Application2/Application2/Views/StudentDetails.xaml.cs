using Application2.Interfaces;
using Application2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
//using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(30);
            Uri uri = new Uri("https://testapiazu.azurewebsites.net/weatherforecast");

            try
            {
                // getting file from server
                var response = await client.GetAsync(uri);
                string tokenresponse = response.StatusCode.ToString();
                var clientresult = response.Content;

                byte[] data = await clientresult.ReadAsByteArrayAsync();

                // asking for permission
                var status = await Permissions.RequestAsync<Permissions.StorageWrite>();
                if (status != PermissionStatus.Granted)
                    return;

                // Downloading the file
                var downloadService = DependencyService.Get<IDownloadService>();
                string path = downloadService.Downloadfile(data);

                // Notify user about file download
                var action = new SnackBarActionOptions
                {
                    Action = async () =>
                    await Launcher.OpenAsync(new OpenFileRequest
                    {
                        File = new ReadOnlyFile(path)
                    }),
                    Text = "Show"
                };

                var options = new SnackBarOptions
                {
                    MessageOptions = new MessageOptions
                    {
                        Message = "Downloaded Successfully"
                    },
                    Duration = TimeSpan.FromSeconds(5),
                    Actions = new[] { action }
                };

                await this.DisplaySnackBarAsync(options);
            
            }
            catch (Exception er)
            {
                Debug.WriteLine(er.Message);
            }
            
        }

        public async Task showFile(string path)
        {
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(path)
            });
        }
    }
}