using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace NasaRestAPI
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class ProductInfoViewModel
    {
        public ObservableCollection<ProductInfo> ItemList { get; set; }

        public ProductInfoViewModel()
        {
            ItemList = new ObservableCollection<ProductInfo>();

            for (int i = 0; i < 100; i++)
            {
                ItemList.Add(new ProductInfo { Name = i.ToString() + "__", ID = i });
            }
        }
    }
}
