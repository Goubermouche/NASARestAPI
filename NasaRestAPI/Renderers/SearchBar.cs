using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NasaRestAPI.Renderers
{
    public class SearchBar : Xamarin.Forms.SearchBar
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(int), typeof(Entry), 0);

        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(Entry), Color.Red);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty =
           BindableProperty.Create("BorderWidth", typeof(int), typeof(Entry), 2);

        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(Entry), new Thickness(0, 0, 0, 0));

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty BackgroundColorProperty =
          BindableProperty.Create("BackgroundColor", typeof(Color), typeof(Entry), Color.Red);

        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SearchIconColorProperty =
        BindableProperty.Create("SearchIconColor", typeof(Color), typeof(Entry), Color.Red);

        public Color SearchIconColor
        {
            get { return (Color)GetValue(SearchIconColorProperty); }
            set { SetValue(SearchIconColorProperty, value); }
        }
    }
}
