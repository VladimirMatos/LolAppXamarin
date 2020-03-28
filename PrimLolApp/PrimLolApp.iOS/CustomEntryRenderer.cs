using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using Foundation;
using PrimLolApp.iOS;
using PrimLolApp.Models.Utility;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomRenders), typeof(CustomEntryRenderer))]
namespace PrimLolApp.iOS
{

   public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}