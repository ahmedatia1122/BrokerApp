using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NewBrokerApp.Helpers
{
    public class SquareView : StackLayout
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            HeightRequest = Width;
        }
    }
}