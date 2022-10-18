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
using Xamarin.Essentials;
using NasaRestAPI.Data;
using Newtonsoft.Json;
using System.Globalization;

namespace NasaRestAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            var data = ((App)Application.Current).Context.Data;

            if (data != null && data.Collection.Items.Count > 0)
            {
                SetViewContextValid();
                SearchEntry.Text = ((App)Application.Current).Context.KeyWord;
            }
            else
            {
                SetViewContextInvalid("Welcome back!");
            }
        }

        private async void OnSearchEntryCompleted(object sender, EventArgs e)
        {
            const float fakeProgress = 0.3f; ;
            SearchProgressBar.IsVisible = true;
            SearchProgressBar.Progress = fakeProgress;

            await Task.Run(async () =>
            {
                try
                {
                    if(string.IsNullOrWhiteSpace(SearchEntry.Text))
                    {
                        return;
                    }

                    string uri = $"https://images-api.nasa.gov/search?q={SearchEntry.Text.Replace(" ", "%20")}&media_type=image";
                    Debug.WriteLine(uri);

                    var webRequest = WebRequest.Create(uri);
                    HttpWebResponse response = (HttpWebResponse)await webRequest.GetResponseAsync();

                    int max = (int)((float)response.ContentLength * (1.0f - fakeProgress));
                    var list = new List<byte>();
                    var bytes = new byte[1024];
                    var stream = response.GetResponseStream();
                    int bytesRead = 0;
                    int curr = 0;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        StatusLabel.IsVisible = true;
                        StatusLabel.Text = $"ERROR: {response.StatusCode.ToString()}";
                        SearchProgressBar.IsVisible = false;
                        return;
                    }

                    do
                    {
                        bytesRead = await stream.ReadAsync(bytes, 0, 1024);
                        list.AddRange(bytes.Take(bytesRead));
                        curr += bytesRead;

                        MainThread.BeginInvokeOnMainThread(async () =>
                        {
                            await SearchProgressBar.ProgressTo((float)curr / ((float)max), 1, Easing.Linear);
                        });
                    } while (bytesRead > 0);

                    ((App)Application.Current).Context.KeyWord = SearchEntry.Text;


                    ASCIIEncoding encoding = new ASCIIEncoding();
                    LoadJSONResult(encoding.GetString(list.ToArray()));
                    await Task.Delay(200);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            });

            SearchProgressBar.IsVisible = false;
        }

        private void OnSearchEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string value = e.NewTextValue;
            SearchCloseButton.IsVisible = value.Length > 0;
        }

        private void OnSearchEntryCloseButtonClicked(object sender, EventArgs e)
        {
            SearchEntry.Text = "";
            SearchEntry.Unfocus();
        }

        public void LoadJSONResult(string json)
        {
            try
            {
                ((App)Application.Current).Context.Data = JsonConvert.DeserializeObject<PostData>(json);
  
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if(((App)Application.Current).Context.Data.Collection.Items.Count > 0)
                    {
                        SetViewContextValid();
                    }
                    else
                    {
                        SetViewContextInvalid("No items matching your search were found.");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void SetViewContextValid()
        {
            StatusLabel.IsVisible = false;
            PostListView.ItemsSource = ((App)Application.Current).Context.Data.Collection.Items;
        }

        private void SetViewContextInvalid(string message)
        {
            StatusLabel.IsVisible = true;
            StatusLabel.Text = message;
            PostListView.ItemsSource = null;
        }
    }
}
