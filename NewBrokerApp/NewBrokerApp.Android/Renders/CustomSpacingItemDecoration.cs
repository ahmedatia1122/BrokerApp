using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.Graphics;
using Android.Support.V7.Widget;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;
using Rect = Android.Graphics.Rect;
using ItemViewType = Xamarin.Forms.Platform.Android.ItemViewType;

namespace NewBrokerApp.Droid.Renders
{
    public class CustomSpacingItemDecoration : RecyclerView.ItemDecoration
    {
        readonly ItemsLayoutOrientation _orientation;
        readonly double _verticalSpacing;
        double _adjustedVerticalSpacing = -1;
        readonly double _horizontalSpacing;
        double _adjustedHorizontalSpacing = -1;
        int spanCount = 1;

        public CustomSpacingItemDecoration(IItemsLayout itemsLayout)
        {
            if (itemsLayout == null)
            {
                throw new ArgumentNullException(nameof(itemsLayout));
            }

            switch (itemsLayout)
            {
                case GridItemsLayout gridItemsLayout:
                    _orientation = gridItemsLayout.Orientation;
                    _horizontalSpacing = gridItemsLayout.HorizontalItemSpacing;
                    _verticalSpacing = gridItemsLayout.VerticalItemSpacing;
                    spanCount = gridItemsLayout.Span;
                    break;
                case LinearItemsLayout listItemsLayout:
                    _orientation = listItemsLayout.Orientation;
                    if (_orientation == ItemsLayoutOrientation.Horizontal)
                        _horizontalSpacing = listItemsLayout.ItemSpacing;
                    else
                        _verticalSpacing = listItemsLayout.ItemSpacing;
                    break;
            }
        }

        public override void GetItemOffsets(Rect outRect, AView view, RecyclerView parent, RecyclerView.State state)
        {
            base.GetItemOffsets(outRect, view, parent, state);

            if (_adjustedVerticalSpacing == -1)
            {
                _adjustedVerticalSpacing = parent.Context.ToPixels(_verticalSpacing);
            }

            if (_adjustedHorizontalSpacing == -1)
            {
                _adjustedHorizontalSpacing = parent.Context.ToPixels(_horizontalSpacing);
            }

            var itemViewType = parent.GetChildViewHolder(view).ItemViewType;

            if (itemViewType == ItemViewType.Header)
            {
                outRect.Bottom = (int)_adjustedVerticalSpacing;
                return;
            }

            if (itemViewType == ItemViewType.Footer)
            {
                return;
            }

            var spanIndex = 0;
            if (view.LayoutParameters is GridLayoutManager.LayoutParams gridLayoutParameters)
            {
                spanIndex = gridLayoutParameters.SpanIndex;
            }

            if (_orientation == ItemsLayoutOrientation.Vertical)
            {
                int dividedHorizontalSpacing = (int)_adjustedHorizontalSpacing / spanCount;
                outRect.Left = spanIndex * dividedHorizontalSpacing;
                outRect.Right = (int)_adjustedHorizontalSpacing - (spanIndex + 1) * dividedHorizontalSpacing;
                outRect.Bottom = (int)_adjustedVerticalSpacing;
            }

            if (_orientation == ItemsLayoutOrientation.Horizontal)
            {
                var dividedVerticalSpacing = (int)_adjustedVerticalSpacing / spanCount;
                outRect.Top = spanIndex * dividedVerticalSpacing;
                outRect.Bottom = (int)_adjustedHorizontalSpacing - (spanIndex + 1) * dividedVerticalSpacing;
                outRect.Right = (int)_adjustedHorizontalSpacing;
            }
        }
    }
}
