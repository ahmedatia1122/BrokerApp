package crc6439a491d224ce8c87;


public abstract class DataFormTextEditorBase_2
	extends crc6439a491d224ce8c87.DataFormEditorBase_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormTextEditorBase`2, DevExpress.XamarinForms.Editors.Android", DataFormTextEditorBase_2.class, __md_methods);
	}


	public DataFormTextEditorBase_2 (android.view.View p0)
	{
		super (p0);
		if (getClass () == DataFormTextEditorBase_2.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormTextEditorBase`2, DevExpress.XamarinForms.Editors.Android", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public DataFormTextEditorBase_2 (android.view.View p0, com.devexpress.editors.dataForm.protocols.DXDataFormEditorItemErrorProvider p1)
	{
		super (p0, p1);
		if (getClass () == DataFormTextEditorBase_2.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormTextEditorBase`2, DevExpress.XamarinForms.Editors.Android", "Android.Views.View, Mono.Android:Com.Devexpress.Editors.DataForm.Protocols.DXDataFormEditorItemErrorProvider, DevExpress.Xamarin.Android.Editors", this, new java.lang.Object[] { p0, p1 });
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
