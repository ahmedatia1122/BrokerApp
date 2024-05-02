using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NewBrokerApp.Helpers
{
    public class PikerCustom : Picker
    {
        public PikerCustom()
        {
          //  this.FontFamily = "Regular";
        }
        public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(PikerCustom), defaultValue: default(string));
        public string Placeholder { get; set; }
        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(string), typeof(PikerCustom), string.Empty);

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(PikerCustom), Color.Gray);
        // Gets or sets BorderColor value  
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(PikerCustom), Color.Gray);
        // Gets or sets BorderColor value  
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }


        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(PikerCustom), Color.White);

        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(PikerCustom), 30);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(PikerCustom), 30);

        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(PikerCustom), ImageAlignment.Left);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }



        public ImageAlignment ImageAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }


    }
    public enum ImageAlignment
    {
        Left,
        Right
    }

}
