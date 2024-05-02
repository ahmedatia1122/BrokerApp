package crc640a67887a4134e062;


public class DXPopupListenerImplementation
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.editors.dropdown.DXDropdownContainer.DropdownListener,
		com.devexpress.editors.dropdown.DXDropdownContainer.DropdownAnimationListener,
		com.devexpress.editors.dropdown.DXDropdownContainer.CoerceValueListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dropdownClosed:()V:GetDropdownClosedHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_dropdownOpened:()V:GetDropdownOpenedHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_dropdownResized:()V:GetDropdownResizedHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_dropdownWillClose:()Z:GetDropdownWillCloseHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_dropdownWillOpen:()Z:GetDropdownWillOpenHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_closingAnimationComplete:()V:GetClosingAnimationCompleteHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownAnimationListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_closingAnimationWillStart:()V:GetClosingAnimationWillStartHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownAnimationListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_openingAnimationComplete:()V:GetOpeningAnimationCompleteHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownAnimationListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_openingAnimationWillStart:()V:GetOpeningAnimationWillStartHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/IDropdownAnimationListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"n_coerceIsDropdownOpen:()V:GetCoerceIsDropdownOpenHandler:DevExpress.Xamarin.Android.Dropdown.DXDropdownContainer/ICoerceValueListenerInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Wrappers.DXPopupListenerImplementation, DevExpress.XamarinForms.Editors.Android", DXPopupListenerImplementation.class, __md_methods);
	}


	public DXPopupListenerImplementation ()
	{
		super ();
		if (getClass () == DXPopupListenerImplementation.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Wrappers.DXPopupListenerImplementation, DevExpress.XamarinForms.Editors.Android", "", this, new java.lang.Object[] {  });
		}
	}


	public void dropdownClosed ()
	{
		n_dropdownClosed ();
	}

	private native void n_dropdownClosed ();


	public void dropdownOpened ()
	{
		n_dropdownOpened ();
	}

	private native void n_dropdownOpened ();


	public void dropdownResized ()
	{
		n_dropdownResized ();
	}

	private native void n_dropdownResized ();


	public boolean dropdownWillClose ()
	{
		return n_dropdownWillClose ();
	}

	private native boolean n_dropdownWillClose ();


	public boolean dropdownWillOpen ()
	{
		return n_dropdownWillOpen ();
	}

	private native boolean n_dropdownWillOpen ();


	public void closingAnimationComplete ()
	{
		n_closingAnimationComplete ();
	}

	private native void n_closingAnimationComplete ();


	public void closingAnimationWillStart ()
	{
		n_closingAnimationWillStart ();
	}

	private native void n_closingAnimationWillStart ();


	public void openingAnimationComplete ()
	{
		n_openingAnimationComplete ();
	}

	private native void n_openingAnimationComplete ();


	public void openingAnimationWillStart ()
	{
		n_openingAnimationWillStart ();
	}

	private native void n_openingAnimationWillStart ();


	public void coerceIsDropdownOpen ()
	{
		n_coerceIsDropdownOpen ();
	}

	private native void n_coerceIsDropdownOpen ();

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
