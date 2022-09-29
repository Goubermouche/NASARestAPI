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

namespace NasaRestAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string json)
        {
            InitializeComponent();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            Debug.WriteLine("submit");
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
