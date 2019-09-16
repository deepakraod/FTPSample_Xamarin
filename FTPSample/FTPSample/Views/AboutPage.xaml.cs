using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FTPSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();


        }

        public void GetListOfFiles()
        {
            List<string> lstFiles = new List<string>();

            string remoteFTPPath = "ftp://192.168.43.1:2221";
            var request = (FtpWebRequest)WebRequest.Create(remoteFTPPath);

            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential("android", "android");
            request.Proxy = null;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<string> directories = new List<string>();

            string line = reader.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
        }
    }
}