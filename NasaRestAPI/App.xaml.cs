using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using NasaRestAPI.Data;
using System.Diagnostics;

namespace NasaRestAPI
{
    public partial class App : Application
    {

        public DataContext Context { get; set; } = new DataContext();

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            if (Current.Properties.ContainsKey("dataContext"))
            {
                Context = JsonConvert.DeserializeObject<DataContext>((string)Current.Properties["dataContext"]);
            }

            MainPage = new MainPage();
        }

        async protected override void OnSleep()
        {
            Current.Properties["dataContext"] = JsonConvert.SerializeObject(Context);
            await Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {

        }
    }
}
