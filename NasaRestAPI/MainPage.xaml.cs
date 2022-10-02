using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.IO;

namespace NasaRestAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string json)
        {
            InitializeComponent();
        }

        private async void Entry_Completed(object sender, EventArgs e)
        {
            Debug.WriteLine("||||||||||||||||||||||||||||||||");

            await Task.Run(async () =>
            {
                try
                {
                    string uri = $"https://images-api.nasa.gov/search?q={SearchEntry.Text.Replace(" ", "%20")}&media_type=image";
                    Debug.WriteLine(uri);

                    var httpClient = new HttpClient();
                    Console.WriteLine(await httpClient.GetStringAsync(uri));
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            });

            Debug.WriteLine("||||||||||||||||||||||||||||||||");
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = e.NewTextValue;
            SearchCloseButton.IsVisible = value.Length > 0;
        }

        private void SearchCloseButton_Clicked(object sender, EventArgs e)
        {
            SearchEntry.Text = "";
            SearchEntry.Unfocus();
        }
    }
}
