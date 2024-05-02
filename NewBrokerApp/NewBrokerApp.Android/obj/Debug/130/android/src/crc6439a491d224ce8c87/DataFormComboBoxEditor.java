package crc6439a491d224ce8c87;


public class DataFormComboBoxEditor
	extends crc6439a491d224ce8c87.DataFormEditorBase_2
	implements
		mono.android.IGCUserPeer,
		com.devexpress.editors.dataForm.protocols.DataFormPickerItem
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setPickerDataProvider:(Lcom/devexpress/editors/dataForm/protocols/DataFormPickerItemDataProvider;)V:GetSetPickerDataProvider_Lcom_devexpress_editors_dataForm_protocols_DataFormPickerItemDataProvider_Handler:Com.Devexpress.Editors.DataForm.Protocols.IDataFormPickerItemInvoker, DevExpress.Xamarin.Android.Editors\n" +
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormComboBoxEditor, DevExpress.XamarinForms.Editors.Android", DataFormComboBoxEditor.class, __md_methods);
	}


	public DataFormComboBoxEditor (android.view.View p0)
	{
		super (p0);
		if (getClass () == DataFormComboBoxEditor.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormComboBoxEditor, DevExpress.XamarinForms.Editors.Android", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public DataFormComboBoxEditor (android.view.View p0, com.devexpress.editors.dataForm.protocols.DXDataFormEditorItemErrorProvider p1)
	{
		super (p0, p1);
		if (getClass () == DataFormComboBoxEditor.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DataForm.Editors.DataFormComboBoxEditor, DevExpress.XamarinForms.Editors.Android", "Android.Views.View, Mono.Android:Com.Devexpress.Editors.DataForm.Protocols.DXDataFormEditorItemErrorProvider, DevExpress.Xamarin.Android.Editors", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void setPickerDataProvider (com.devexpress.editors.dataForm.protocols.DataFormPickerItemDataProvider p0)
	{
		n_setPickerDataProvider (p0);
	}

	private native void n_setPickerDataProvider (com.devexpress.editors.dataForm.protocols.DataFormPickerItemDataProvider p0);

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
