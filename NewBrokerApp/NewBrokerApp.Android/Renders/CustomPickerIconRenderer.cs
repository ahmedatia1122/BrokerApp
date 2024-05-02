using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
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

[assembly: ExportRenderer(typeof(PikerCustom), typeof(CustomPickerIconRenderer))]
namespace NewBrokerApp.Droid.Renders
{
    public class CustomPickerIconRenderer : PickerRenderer
    {


        PikerCustom element;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            element = (PikerCustom)this.Element;

            if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))

                Control.SetTextColor(element.TextColor.ToAndroid());
            Control.SetHintTextColor(Android.Graphics.Color.Black);
            Control.Background = AddPickerStyles(element.Image);
            Control.CompoundDrawablePadding = 25;


        }

        public LayerDrawable AddPickerStyles(string imagePath)
        {
            ShapeDrawable border = new ShapeDrawable();
            border.Paint.Color = element.BorderColor.ToAndroid();
            border.SetPadding(10, 10, 10, 10);
            border.Paint.SetStyle(Paint.Style.Stroke);


            Drawable[] layers = { border, GetDrawable(imagePath) };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);
            layerDrawable.SetBounds(5, 5, 5, 5);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth, element.ImageHeight, true));
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }

    }
}