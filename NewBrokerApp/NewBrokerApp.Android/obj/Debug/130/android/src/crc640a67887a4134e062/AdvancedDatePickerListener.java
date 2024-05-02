package crc640a67887a4134e062;


public class AdvancedDatePickerListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.editors.DateEditPickerListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dismiss:()V:GetDismissHandler:DevExpress.Xamarin.Android.Editors.IDateEditPickerListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_show:()V:GetShowHandler:DevExpress.Xamarin.Android.Editors.IDateEditPickerListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Wrappers.AdvancedDatePickerListener, DevExpress.XamarinForms.Editors.Android", AdvancedDatePickerListener.class, __md_methods);
	}


	public AdvancedDatePickerListener ()
	{
		super ();
		if (getClass () == AdvancedDatePickerListener.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Wrappers.AdvancedDatePickerListener, DevExpress.XamarinForms.Editors.Android", "", this, new java.lang.Object[] {  });
		}
	}


	public void dismiss ()
	{
		n_dismiss ();
	}

	private native void n_dismiss ();


	public void show ()
	{
		n_show ();
	}

	private native void n_show ();

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
