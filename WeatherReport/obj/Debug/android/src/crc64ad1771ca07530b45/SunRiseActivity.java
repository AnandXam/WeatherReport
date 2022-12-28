package crc64ad1771ca07530b45;


public class SunRiseActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"";
		mono.android.Runtime.register ("WeatherReport.Activities.SunRiseActivity, WeatherReport", SunRiseActivity.class, __md_methods);
	}


	public SunRiseActivity ()
	{
		super ();
		if (getClass () == SunRiseActivity.class) {
			mono.android.TypeManager.Activate ("WeatherReport.Activities.SunRiseActivity, WeatherReport", "", this, new java.lang.Object[] {  });
		}
	}


	public SunRiseActivity (int p0)
	{
		super (p0);
		if (getClass () == SunRiseActivity.class) {
			mono.android.TypeManager.Activate ("WeatherReport.Activities.SunRiseActivity, WeatherReport", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);

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
