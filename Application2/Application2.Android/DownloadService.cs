using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Application2.Droid;
using Application2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(DownloadService))]
namespace Application2.Droid
{   
    public class DownloadService : IDownloadService
    {
        public string Downloadfile(byte[] filedata)
        {
            var dirpath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
            var filepath = Path.Combine(dirpath, "Receipt2.pdf");
            File.WriteAllBytes(filepath, filedata);

            return filepath;
        }
    }
}