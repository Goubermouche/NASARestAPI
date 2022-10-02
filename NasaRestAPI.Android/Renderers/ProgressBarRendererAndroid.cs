﻿using Android.App;
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
using Android.Text;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(NasaRestAPI.Renderers.ProgressBar), typeof(ProgressBarRenderer))]
namespace NasaRestAPI.Droid.Renderers
{
    public class ProgressBarRendererAndroid : ProgressBarRenderer
    {
        NasaRestAPI.Renderers.ProgressBar customProgress;

        public ProgressBarRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                customProgress = (NasaRestAPI.Renderers.ProgressBar)e.NewElement;
            }
        }
    }
}