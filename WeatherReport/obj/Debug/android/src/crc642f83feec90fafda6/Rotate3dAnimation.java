package crc642f83feec90fafda6;


public class Rotate3dAnimation
	extends android.view.animation.Animation
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_initialize:(IIII)V:GetInitialize_IIIIHandler\n" +
			"n_applyTransformation:(FLandroid/view/animation/Transformation;)V:GetApplyTransformation_FLandroid_view_animation_Transformation_Handler\n" +
			"";
		mono.android.Runtime.register ("InteractiveAlert.Droid.Rotate3dAnimation, InteractiveAlert", Rotate3dAnimation.class, __md_methods);
	}


	public Rotate3dAnimation ()
	{
		super ();
		if (getClass () == Rotate3dAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.Rotate3dAnimation, InteractiveAlert", "", this, new java.lang.Object[] {  });
		}
	}


	public Rotate3dAnimation (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == Rotate3dAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.Rotate3dAnimation, InteractiveAlert", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public Rotate3dAnimation (int p0, float p1, float p2)
	{
		super ();
		if (getClass () == Rotate3dAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.Rotate3dAnimation, InteractiveAlert", "System.Int32, mscorlib:System.Single, mscorlib:System.Single, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public Rotate3dAnimation (int p0, float p1, float p2, float p3, float p4)
	{
		super ();
		if (getClass () == Rotate3dAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.Rotate3dAnimation, InteractiveAlert", "System.Int32, mscorlib:System.Single, mscorlib:System.Single, mscorlib:System.Single, mscorlib:System.Single, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
		}
	}

	public Rotate3dAnimation (int p0, float p1, float p2, int p3, float p4, int p5, float p6)
	{
		super ();
		if (getClass () == Rotate3dAnimation.class) {
			mono.android.TypeManager.Activate ("InteractiveAlert.Droid.Rotate3dAnimation, InteractiveAlert", "System.Int32, mscorlib:System.Single, mscorlib:System.Single, mscorlib:Android.Views.Animations.Dimension, Mono.Android:System.Single, mscorlib:Android.Views.Animations.Dimension, Mono.Android:System.Single, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5, p6 });
		}
	}


	public void initialize (int p0, int p1, int p2, int p3)
	{
		n_initialize (p0, p1, p2, p3);
	}

	private native void n_initialize (int p0, int p1, int p2, int p3);


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
