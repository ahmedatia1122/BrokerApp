package crc640a67887a4134e062;


public class YearHeaderViewProvider
	extends crc640a67887a4134e062.HeaderViewProvider
	implements
		mono.android.IGCUserPeer,
		com.devexpress.editors.pickers.providers.YearHeaderViewProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_check:(Landroid/view/View;I)Z:GetCheck_Landroid_view_View_IHandler:DevExpress.Xamarin.Android.Editors.Pickers.Providers.IYearHeaderViewProviderInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_recycle:(Landroid/view/View;)V:GetRecycle_Landroid_view_View_Handler:DevExpress.Xamarin.Android.Editors.Pickers.Providers.IYearHeaderViewProviderInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_request:(I)Landroid/view/View;:GetRequest_IHandler:DevExpress.Xamarin.Android.Editors.Pickers.Providers.IYearHeaderViewProviderInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_update:(Landroid/view/View;I)V:GetUpdate_Landroid_view_View_IHandler:DevExpress.Xamarin.Android.Editors.Pickers.Providers.IYearHeaderViewProviderInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Wrappers.YearHeaderViewProvider, DevExpress.XamarinForms.Editors.Android", YearHeaderViewProvider.class, __md_methods);
	}


	public YearHeaderViewProvider ()
	{
		super ();
		if (getClass () == YearHeaderViewProvider.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Wrappers.YearHeaderViewProvider, DevExpress.XamarinForms.Editors.Android", "", this, new java.lang.Object[] {  });
		}
	}


	public boolean check (android.view.View p0, int p1)
	{
		return n_check (p0, p1);
	}

	private native boolean n_check (android.view.View p0, int p1);


	public void recycle (android.view.View p0)
	{
		n_recycle (p0);
	}

	private native void n_recycle (android.view.View p0);


	public android.view.View request (int p0)
	{
		return n_request (p0);
	}

	private native android.view.View n_request (int p0);


	public void update (android.view.View p0, int p1)
	{
		n_update (p0, p1);
	}

	private native void n_update (android.view.View p0, int p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
