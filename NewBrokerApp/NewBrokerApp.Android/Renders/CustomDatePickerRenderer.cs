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
[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace NewBrokerApp.Droid.Renders
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
                CustomDatePicker element = Element as CustomDatePicker;
                if (!string.IsNullOrWhiteSpace(element.Placeholder))
                {
                    Control.Text = element.Placeholder;
                }
                //Control.TextSize = 20;

                this.Control.TextChanged += (sender, arg) => {
                    var selectedDate = arg.Text.ToString();
                    if (selectedDate == element.Placeholder)
                    {
                        Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                };
            }
        }
    }
}