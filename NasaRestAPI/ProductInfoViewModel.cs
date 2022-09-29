using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NasaRestAPI
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class ProductInfoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductInfo> ItemList { get; set; }
        public ICommand RefreshCommand { get; }

        bool isRefreshing;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ProductInfoViewModel()
        {
            ItemList = new ObservableCollection<ProductInfo>();
            RefreshCommand = new Command(ExecuteRefreshCommand);
            for (int i = 0; i < 2; i++)
            {
                ItemList.Add(new ProductInfo { Name = i.ToString() + "__", ID = i });
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        async void ExecuteRefreshCommand()
        {
            if (IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;

            await Task.Delay(200);
            ItemList.Add(new ProductInfo { Name = "New", ID = 100 });
            IsRefreshing = false;
        }
    }
}
