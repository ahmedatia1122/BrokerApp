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
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace NewBrokerApp.Droid.Renders
{
    [Obsolete]
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.Action == KeyEventActions.Down)
            {
                if (e.KeyCode == Keycode.Del)
                {
                    if (string.IsNullOrWhiteSpace(Control.Text))
                    {
                        var entry = (CustomEntry)Element;
                        entry.OnBackspacePressed();
                    }
                }
            }
            return base.DispatchKeyEvent(e);
        }

        protected override void
        OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.Background = null;
        }

    }
}