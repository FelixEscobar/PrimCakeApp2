package crc6462bbb52394a1e0b3;


public class SplashActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("PrimCakeApp2.Droid.SplashActivity, PrimCakeApp2.Android", SplashActivity.class, __md_methods);
	}


	public SplashActivity ()
	{
		super ();
		if (getClass () == SplashActivity.class)
			mono.android.TypeManager.Activate ("PrimCakeApp2.Droid.SplashActivity, PrimCakeApp2.Android", "", this, new java.lang.Object[] {  });
	}


	public SplashActivity (int p0)
	{
		super (p0);
		if (getClass () == SplashActivity.class)
			mono.android.TypeManager.Activate ("PrimCakeApp2.Droid.SplashActivity, PrimCakeApp2.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

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
