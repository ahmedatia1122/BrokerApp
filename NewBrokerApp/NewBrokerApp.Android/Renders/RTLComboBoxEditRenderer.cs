using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DevExpress.XamarinForms.Editors.Android;
using NewBrokerApp.Droid.Renders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(DevExpress.XamarinForms.Editors.ComboBoxEdit), typeof(RTLComboBoxEditRenderer), new[] { typeof(VisualMarker.MaterialVisual) }, Priority = short.MinValue)]
namespace NewBrokerApp.Droid.Renders
{
    public class RTLComboBoxEditRenderer : ComboBoxEditRenderer
    {
        public RTLComboBoxEditRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DevExpress.XamarinForms.Editors.ComboBoxEdit> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.LayoutDirection = Android.Views.LayoutDirection.Rtl;
            }
        }
    }
}