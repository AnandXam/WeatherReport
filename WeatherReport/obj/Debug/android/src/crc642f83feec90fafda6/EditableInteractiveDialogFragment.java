package crc642f83feec90fafda6;


public class EditableInteractiveDialogFragment
	extends crc642f83feec90fafda6.BaseInteractiveDialogFragment_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("InteractiveAlert.Droid.EditableInteractiveDialogFragment, InteractiveAlert", EditableInteractiveDialogFragment.class, __md_methods);
	}


	public EditableInteractiveDialogFragment ()
	{
		super ();
		if (getClass () == EditableInteractiveDialogFragment.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.EditableInteractiveDialogFragment, InteractiveAlert", "", this, new java.lang.Object[] {  });
		}
	}


	public EditableInteractiveDialogFragment (int p0)
	{
		super (p0);
		if (getClass () == EditableInteractiveDialogFragment.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.EditableInteractiveDialogFragment, InteractiveAlert", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
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
