package crc642f83feec90fafda6;


public class InteractiveDialogFragment
	extends crc642f83feec90fafda6.BaseInteractiveDialogFragment_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("InteractiveAlert.Droid.InteractiveDialogFragment, InteractiveAlert", InteractiveDialogFragment.class, __md_methods);
	}


	public InteractiveDialogFragment ()
	{
		super ();
		if (getClass () == InteractiveDialogFragment.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.InteractiveDialogFragment, InteractiveAlert", "", this, new java.lang.Object[] {  });
		}
	}


	public InteractiveDialogFragment (int p0)
	{
		super (p0);
		if (getClass () == InteractiveDialogFragment.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.InteractiveDialogFragment, InteractiveAlert", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
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
