using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppStarFitness.Droid.CustomRenderer;
using AppStarFitness.CustomeRenderer;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(MyCustomeEntry), typeof(MyEntryRenderer))]
namespace AppStarFitness.Droid.CustomRenderer
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}