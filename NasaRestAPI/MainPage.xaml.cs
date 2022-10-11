﻿using System;
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
        public MainPage(string json)
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void Entry_Completed(object sender, EventArgs e)
        {
            const float fakeProgress = 0.3f; ;
            SearchProgressBar.IsVisible = true;
            SearchProgressBar.Progress = fakeProgress;

            await Task.Run(async () =>
            {
                try
                {
                    if(String.IsNullOrWhiteSpace(SearchEntry.Text))
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

        public void LoadJSONResult(string json)
        {
            try
            {
                PostData data = JsonConvert.DeserializeObject<PostData>(json);
  
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if(data.Collection.Items.Count > 0)
                    {
                        StatusLabel.IsVisible = false;
                        PostListView.ItemsSource = data.Collection.Items;
                    }
                    else
                    {
                        StatusLabel.IsVisible = true;
                        StatusLabel.Text = "No items matching your search were found.";
                        PostListView.ItemsSource = null;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
