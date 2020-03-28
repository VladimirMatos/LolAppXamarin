using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Util;
using PrimLolApp.Droid;
using PrimLolApp.Models.Utility;

[assembly: ExportRenderer(typeof(CustomRenders), typeof(CustomEntryRenderer))]
namespace PrimLolApp.Droid
{
    [Obsolete]
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context): base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);  
            if(Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}