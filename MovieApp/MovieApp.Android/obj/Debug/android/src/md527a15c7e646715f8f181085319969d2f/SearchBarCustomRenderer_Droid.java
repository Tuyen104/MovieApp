package md527a15c7e646715f8f181085319969d2f;


public class SearchBarCustomRenderer_Droid
	extends md51558244f76c53b6aeda52c8a337f2c37.SearchBarRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MovieApp.Droid.Renderers.SearchBarCustomRenderer_Droid, MovieApp.Android", SearchBarCustomRenderer_Droid.class, __md_methods);
	}


	public SearchBarCustomRenderer_Droid (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SearchBarCustomRenderer_Droid.class)
			mono.android.TypeManager.Activate ("MovieApp.Droid.Renderers.SearchBarCustomRenderer_Droid, MovieApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SearchBarCustomRenderer_Droid (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SearchBarCustomRenderer_Droid.class)
			mono.android.TypeManager.Activate ("MovieApp.Droid.Renderers.SearchBarCustomRenderer_Droid, MovieApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SearchBarCustomRenderer_Droid (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SearchBarCustomRenderer_Droid.class)
			mono.android.TypeManager.Activate ("MovieApp.Droid.Renderers.SearchBarCustomRenderer_Droid, MovieApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
