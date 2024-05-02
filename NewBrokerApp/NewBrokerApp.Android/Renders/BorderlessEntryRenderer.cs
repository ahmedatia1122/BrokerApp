using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NewBrokerApp.Droid.Renders;
using NewBrokerApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static System.Net.Mime.MediaTypeNames;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace NewBrokerApp.Droid.Renders
{
   
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
            if (e.NewElement != null)
            {
                
                Control.AfterTextChanged += OnTextChanged;
            }
        }
    
    private void OnTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        
            {
        // Handle text changed event
        var customEntry = (BorderlessEntry)Element;
            // Do something with the updated text value
            if (e.Editable != null)
            {
                var text = e.Editable.ToString();

                String[] map = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

                for (int i = 0; i <= 9; i++)
                {
                    text = text.Replace(map[i], i.ToString());
                }
                customEntry.Text = text;    
                //sender.Text = text;
            }
        
        }
    //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //    {
    //        base.OnElementPropertyChanged(sender, e);
    //        if ( e.PropertyName == BorderlessEntry.TextProperty.PropertyName)
    //        {
    //            // Handle the property change
    //            var customEntry = (CustomEntry)Element;
    //            // Do something with the updated property value
    //            var text = customEntry.Text;

    //            String[] map = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

    //            for (int i = 0; i <= 9; i++)
    //            {
    //                text = text.Replace(map[i], i.ToString());
    //            }
    //            ((BorderlessEntry)sender).Text = text;
               
    //        }
           
    //    }
        

    }
}
