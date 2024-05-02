using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using NewBrokerApp.Helpers;
using NewBrokerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

using Xamarin.Forms.Xaml;

namespace NewBrokerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class testMapPage : ContentPage
    {
        public testMapPage()
        {
            InitializeComponent();
            var datax = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                WidthRequest = 120,
                HeightRequest = 20,
                BackgroundColor = Color.FromHex("#034C82") /*: Color.FromHex("#C8A455")*/,
            };
            var stack = new AbsoluteLayout
            {

            };
            var image = new SvgCachedImage
            {
                Source = "Pin_Blue.svg",
                WidthRequest = 50,
                HeightRequest = 50,
            };
            stack.Children.Add(image);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0, 0, 100, 100));
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);
            stack.Children.Add(datax);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(1, 0.5, 25, 100));
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);
            datax.Children.Add(new CachedImage { Source = "Pin_Bluee.png", WidthRequest = 35, Margin = new Thickness(0, 0, 0, 0), HeightRequest = 35, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, Aspect = Aspect.AspectFit, BackgroundColor = Color.Yellow });
            datax.Children.Add(new Label { Text = "122", FontSize = 20, TextColor = Color.White ,Margin=new Thickness(20,20,20,20)});
            var label = new Label
            {
                Text = "My Label",
                FontSize = 12,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            var svgImage = new SvgCachedImage
            {
                Source = "Pin_Blue.svg",
                WidthRequest = 50,
                HeightRequest = 50,
            };
            var grid = new Grid
            {
               
                BackgroundColor = Color.Red,
                RowDefinitions =
    {
        new RowDefinition { Height = 300 },
        new RowDefinition { Height = 200
        },
    },
                Children =
    {
        //svgImage,
        label,
    },
                WidthRequest = 150,
                HeightRequest = 150, // adjust the height to fit the image and the label
            };
            var stackr = new StackLayout
            {
                Children = { grid },
                WidthRequest = 100
            };
            var icon = BitmapDescriptorFactory.FromView(stackr);
            var svgImager = new CachedImage
            {
                Source = "Pin_Bluee.png",
                HeightRequest = 50,
                Aspect = Aspect.AspectFit,
                WidthRequest = 150,
            };
            var contentView = new ContentView
            {
                BackgroundColor = Color.Transparent,
                Content = svgImage,

                WidthRequest = 100,
                HeightRequest = 30,
            };
            var stackk = new StackLayout();
            stackk.Children.Add(svgImage);
            Pin pinItem = new Pin()
            {
                Type = PinType.Place,
                //Icon = BitmapDescriptorFactory.FromView(new mapIconPage("100")),
                Label = "",
                Address = "",
                Position = new Position(30.033333, 31.233334),
            };
            Pin pinItem1 = new Pin()
            {
                Type = PinType.Place,
             //   Icon = BitmapDescriptorFactory.FromView(new mapIconPage("100")),
                Label = "",
                Address = "",
                ZIndex = 1,
                
                Position = new Position(30.033903514513014,31.235828438636613),
            };
            Pin pinItem2 = new Pin()
            {
                Type = PinType.Place,
                //Icon = BitmapDescriptorFactory.FromView(new mapIconPage("100")),
                Label = "",
                Address = "",
                

                Position = new Position(30.033929565662948, 31.237424745181066),
            };
           
            MyMap.Pins.Add(pinItem1);
            MyMap.Pins.Add(pinItem);

            MyMap.Pins.Add(pinItem2);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(30.033333, 31.233334), Distance.FromKilometers(2)).WithZoom(3));
            //CustomPin pin = new CustomPin
            //{
            //    Type = PinType.Place,
            //    Position = new Position(37.79752, -122.40183),
            //    Label = "Xamarin San Francisco Office",
            //    Address = "394 Pacific Ave, San Francisco CA",
            //    Name = "Xamarin",
            //    Url = "http://xamarin.com/about/"
            //};
            //customMap.CustomPins = new List<CustomPin> { pin };
            //customMap.Pins.Add(pin);
            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
        }
        //MyMap.InfoWindowTemplate = new CustomMapInfoWindow();
        //// Add a pin to the map
        //var pin = new Pin
        //{
        //    Type = PinType.Place,
        //    Position = new Position(37.785834, -122.406417),
        //    Label = "Custom Pin",
        //    Address = "San Francisco, CA"
        //};
        //MyMap.Pins.Add(pin);

        //// Set the custom pin's icon
        //var androidMap = MyMap.Android as MapRenderer;
        //var iosMap = MyMap.iOS as MapRenderer;
        //if (androidMap != null)
        //{
        //    var bitmapDescriptorFactory = new BitmapDescriptorFactory();
        //    var bitmapDescriptor = bitmapDescriptorFactory.FromResource("YourNamespace.Resources.YourImage.png");
        //    var icon = bitmapDescriptor.ToBitmap();
        //    pin.Icon = BitmapDescriptorFactory.FromBitmap(icon);
        //}


        //// Set the custom marker window template
        //MyMap.InfoWindowTemplate = new DataTemplate(() =>
        //{
        //    var image = new Image();
        //    image.Source = ImageSource.FromResource("YourNamespace.Resources.YourImage.png");

        //    var label = new Label();
        //    label.Text = $"{pin.Label}\n{pin.Address}";

        //    var stackLayout = new StackLayout();
        //    stackLayout.Children.Add(image);
        //    stackLayout.Children.Add(label);

        //    return stackLayout;
        //});

        //// Show the marker window for the pin
        //MyMap.ShowInfoWindow(pin);

    }
    }

        