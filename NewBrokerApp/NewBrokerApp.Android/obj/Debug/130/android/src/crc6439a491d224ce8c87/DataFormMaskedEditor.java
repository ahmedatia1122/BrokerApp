package crc6439a491d224ce8c87;


public class DataFormMaskedEditor
	extends crc6439a491d224ce8c87.DataFormTextEditor
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormMaskedEditor, DevExpress.XamarinForms.Editors.Android", DataFormMaskedEditor.class, __md_methods);
	}


	public DataFormMaskedEditor (android.view.View p0)
	{
		super (p0);
		if (getClass () == DataFormMaskedEditor.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormMaskedEditor, DevExpress.XamarinForms.Editors.Android", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public DataFormMaskedEditor (android.view.View p0, com.devexpress.editors.dataForm.protocols.DXDataFormEditorItemErrorProvider p1)
	{
		super (p0, p1);
		if (getClass () == DataFormMaskedEditor.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormMaskedEditor, DevExpress.XamarinForms.Editors.Android", "Android.Views.View, Mono.Android:Com.Devexpress.Editors.DataForm.Protocols.DXDataFormEditorItemErrorProvider, DevExpress.Xamarin.Android.Editors", this, new java.lang.Object[] { p0, p1 });
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
