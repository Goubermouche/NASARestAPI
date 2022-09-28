using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using NasaRestAPI.Droid.Renderers;
using NasaRestAPI.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NasaRestAPI.Renderers.SearchBar), typeof(SearchBarRendererAndroid))]
namespace NasaRestAPI.Droid.Renderers
{
    public  class SearchBarRendererAndroid : SearchBarRenderer
    {
        NasaRestAPI.Renderers.SearchBar customSearchBar;

        public SearchBarRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                customSearchBar = (NasaRestAPI.Renderers.SearchBar)e.NewElement;
                var gradientDrawable = new GradientDrawable();

                gradientDrawable.SetColor(customSearchBar.BackgroundColor.ToAndroid());
                gradientDrawable.SetCornerRadius(customSearchBar.CornerRadius);
                gradientDrawable.SetStroke(customSearchBar.BorderWidth, customSearchBar.BorderColor.ToAndroid());

                Control.SetBackground(gradientDrawable);
                Control.SetPadding((int)customSearchBar.Padding.Left, (int)customSearchBar.Padding.Top, (int)customSearchBar.Padding.Right, (int)customSearchBar.Padding.Bottom);
                Control.SetInputType(InputTypes.TextFlagNoSuggestions | InputTypes.TextVariationVisiblePassword);

                var searchIcon = (Control?.FindViewById(Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null))) as ImageView;
                searchIcon.SetColorFilter(customSearchBar.SearchIconColor.ToAndroid());
                searchIcon.ScaleX = 1.2f;
                searchIcon.ScaleY = 1.2f;

                var closeIcon = (Control?.FindViewById(Context.Resources.GetIdentifier("android:id/search_close_btn", null, null))) as ImageView;
                closeIcon.ScaleX = 1.2f;
                closeIcon.ScaleY = 1.2f;
            }
        }
    }
}