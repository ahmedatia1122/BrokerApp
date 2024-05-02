package crc640a67887a4134e062;


public abstract class HeaderViewProvider
	extends crc640a67887a4134e062.CellViewProvider_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Wrappers.HeaderViewProvider, DevExpress.XamarinForms.Editors.Android", HeaderViewProvider.class, __md_methods);
	}


	public HeaderViewProvider ()
	{
		super ();
		if (getClass () == HeaderViewProvider.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Wrappers.HeaderViewProvider, DevExpress.XamarinForms.Editors.Android", "", this, new java.lang.Object[] {  });
		}
	}

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
