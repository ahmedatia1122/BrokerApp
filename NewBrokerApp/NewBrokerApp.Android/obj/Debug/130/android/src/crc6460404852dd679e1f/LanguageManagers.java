package crc6460404852dd679e1f;


public class LanguageManagers
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("NewBrokerApp.Droid.LanguageManagers, NewBrokerApp.Android", LanguageManagers.class, __md_methods);
	}


	public LanguageManagers ()
	{
		super ();
		if (getClass () == LanguageManagers.class) {
			mono.android.TypeManager.Activate ("NewBrokerApp.Droid.LanguageManagers, NewBrokerApp.Android", "", this, new java.lang.Object[] {  });
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
