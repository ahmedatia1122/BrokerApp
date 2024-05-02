package crc64e58ce59a6d1a044d;


public class DXPopupRenderer
	extends crc64706ee4e716956d52.DXViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getVisibility:()I:GetGetVisibilityHandler\n" +
			"n_setVisibility:(I)V:GetSetVisibility_IHandler\n" +
			"n_measureAndLayout:(IIIIII)V:GetMeasureAndLayout_IIIIIIHandler\n" +
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Editors.Android.DXPopupRenderer, DevExpress.XamarinForms.Editors.Android", DXPopupRenderer.class, __md_methods);
	}


	public DXPopupRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == DXPopupRenderer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DXPopupRenderer, DevExpress.XamarinForms.Editors.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public DXPopupRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == DXPopupRenderer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DXPopupRenderer, DevExpress.XamarinForms.Editors.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public DXPopupRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DXPopupRenderer.class) {
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Editors.Android.DXPopupRenderer, DevExpress.XamarinForms.Editors.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public int getVisibility ()
	{
		return n_getVisibility ();
	}

	private native int n_getVisibility ();


	public void setVisibility (int p0)
	{
		n_setVisibility (p0);
	}

	private native void n_setVisibility (int p0);


	public void measureAndLayout (int p0, int p1, int p2, int p3, int p4, int p5)
	{
		n_measureAndLayout (p0, p1, p2, p3, p4, p5);
	}

	private native void n_measureAndLayout (int p0, int p1, int p2, int p3, int p4, int p5);


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

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
