using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace NasaRestAPI.Data
{
    public class ItemLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class ItemData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Item
    {
        /// <summary>
        /// Link leading to dotailed images of the item.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("links")]
        public List<ItemLink> Links { get; set; }

        [JsonProperty("data")]
        public List<ItemData> Data { get; set; }
    }

    public class PostContextMetadata
    {
        [JsonProperty("total_hits")]
        public int TotalHits { get; set; }
    }

    public class CollectionLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; } // Prev / Next
    }

    public class Collection
    {
        [JsonProperty("items")]
        public ObservableCollection<Item> Items { get; set; }

        [JsonProperty("metadata")]
        public PostContextMetadata Metadata { get; set; }

        /// <summary>
        /// A collection of links leading to the previous and next page of images, if there is one available. 
        /// </summary>
        [JsonProperty("links")]
        public List<CollectionLink> Links { get; set; }
    }

    public class PostData
    {
        [JsonProperty("collection")]
        public Collection Collection { get; set; }
    }
}
