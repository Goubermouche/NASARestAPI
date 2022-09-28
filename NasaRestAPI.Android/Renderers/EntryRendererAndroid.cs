using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using NasaRestAPI.Droid.Renderers;
using NasaRestAPI.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(NasaRestAPI.Renderers.Entry), typeof(EntryRendererAndroid))]
namespace NasaRestAPI.Droid.Renderers
{
    public class EntryRendererAndroid : EntryRenderer
    {
        NasaRestAPI.Renderers.Entry customEntry;

        public EntryRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                customEntry = (NasaRestAPI.Renderers.Entry)e.NewElement;
                var gradientDrawable = new GradientDrawable();

                gradientDrawable.SetColor(customEntry.BackgroundColor.ToAndroid());
                gradientDrawable.SetCornerRadius(customEntry.CornerRadius);
                gradientDrawable.SetStroke(customEntry.BorderWidth, customEntry.BorderColor.ToAndroid());

                Control.SetBackground(gradientDrawable);
                Control.SetPadding((int)customEntry.Padding.Left, (int)customEntry.Padding.Top, (int)customEntry.Padding.Right, (int)customEntry.Padding.Bottom);
            }
        }
    }
}