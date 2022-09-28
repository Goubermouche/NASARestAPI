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

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRendererAndroid))]
namespace NasaRestAPI.Droid.Renderers
{
    public class CustomEntryRendererAndroid : EntryRenderer
    {
        CustomEntry customEntry;
        bool keyboardActive;

        public CustomEntryRendererAndroid(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                customEntry = (CustomEntry)e.NewElement;
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