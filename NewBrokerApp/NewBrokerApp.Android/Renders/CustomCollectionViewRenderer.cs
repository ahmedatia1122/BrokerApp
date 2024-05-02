using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidX.RecyclerView.Widget;
using NewBrokerApp.Droid.Renderers;
using NewBrokerApp.Droid.Renders;

[assembly: ExportRenderer(typeof(CollectionView), typeof(CustomCollectionViewRenderer))]
namespace NewBrokerApp.Droid.Renderers
{
    public class CustomCollectionViewRenderer : CollectionViewRenderer
    {
        public CustomCollectionViewRenderer(Context context) : base(context)
        {
        }

        //protected override ItemDecoration CreateSpacingDecoration(IItemsLayout itemsLayout)
        //{
        //    return new CustomSpacingItemDecoration(itemsLayout);
          
        //}
    }

}
