package scl.alertview;


public class SuccessTickView_SelfAnimation
	extends android.view.animation.Animation
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_applyTransformation:(FLandroid/view/animation/Transformation;)V:GetApplyTransformation_FLandroid_view_animation_Transformation_Handler\n" +
			"";
		mono.android.Runtime.register ("InteractiveAlert.Droid.SuccessTickView+SelfAnimation, InteractiveAlert", SuccessTickView_SelfAnimation.class, __md_methods);
	}


	public SuccessTickView_SelfAnimation ()
	{
		super ();
		if (getClass () == SuccessTickView_SelfAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.SuccessTickView+SelfAnimation, InteractiveAlert", "", this, new java.lang.Object[] {  });
		}
	}


	public SuccessTickView_SelfAnimation (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SuccessTickView_SelfAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.SuccessTickView+SelfAnimation, InteractiveAlert", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public SuccessTickView_SelfAnimation (scl.alertview.SuccessTickView p0)
	{
		super ();
		if (getClass () == SuccessTickView_SelfAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.SuccessTickView+SelfAnimation, InteractiveAlert", "InteractiveAlert.Droid.SuccessTickView, InteractiveAlert", this, new java.lang.Object[] { p0 });
		}
	}


	public void applyTransformation (float p0, android.view.animation.Transformation p1)
	{
		n_applyTransformation (p0, p1);
	}

	private native void n_applyTransformation (float p0, android.view.animation.Transformation p1);

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
