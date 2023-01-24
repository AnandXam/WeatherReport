package crc642f83feec90fafda6;


public class BaseInteractiveDialogFragment_1
	extends androidx.appcompat.app.AppCompatDialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onCreateDialog:(Landroid/os/Bundle;)Landroid/app/Dialog;:GetOnCreateDialog_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("InteractiveAlert.Droid.BaseInteractiveDialogFragment`1, InteractiveAlert", BaseInteractiveDialogFragment_1.class, __md_methods);
	}


	public BaseInteractiveDialogFragment_1 ()
	{
		super ();
		if (getClass () == BaseInteractiveDialogFragment_1.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.BaseInteractiveDialogFragment`1, InteractiveAlert", "", this, new java.lang.Object[] {  });
		}
	}


	public BaseInteractiveDialogFragment_1 (int p0)
	{
		super (p0);
		if (getClass () == BaseInteractiveDialogFragment_1.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.BaseInteractiveDialogFragment`1, InteractiveAlert", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public android.app.Dialog onCreateDialog (android.os.Bundle p0)
	{
		return n_onCreateDialog (p0);
	}

	private native android.app.Dialog n_onCreateDialog (android.os.Bundle p0);

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
