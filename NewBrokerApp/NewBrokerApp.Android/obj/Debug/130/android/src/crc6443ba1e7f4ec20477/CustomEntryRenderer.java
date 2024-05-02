package crc6443ba1e7f4ec20477;


public class CustomEntryRenderer
	extends crc643f46942d9dd1fff9.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchKeyEvent:(Landroid/view/KeyEvent;)Z:GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("NewBrokerApp.Droid.Renders.CustomEntryRenderer, NewBrokerApp.Android", CustomEntryRenderer.class, __md_methods);
	}


	public CustomEntryRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomEntryRenderer.class) {
			mono.android.TypeManager.Activate ("NewBrokerApp.Droid.Renders.CustomEntryRenderer, NewBrokerApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public CustomEntryRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomEntryRenderer.class) {
			mono.android.TypeManager.Activate ("NewBrokerApp.Droid.Renders.CustomEntryRenderer, NewBrokerApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public CustomEntryRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomEntryRenderer.class) {
			mono.android.TypeManager.Activate ("NewBrokerApp.Droid.Renders.CustomEntryRenderer, NewBrokerApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public boolean dispatchKeyEvent (android.view.KeyEvent p0)
	{
		return n_dispatchKeyEvent (p0);
	}

	private native boolean n_dispatchKeyEvent (android.view.KeyEvent p0);

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
