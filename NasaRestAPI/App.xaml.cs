using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace NasaRestAPI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            if (Application.Current.Properties.ContainsKey("lastKnownState"))
            {

            }

            MainPage = new MainPage("blah");
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
