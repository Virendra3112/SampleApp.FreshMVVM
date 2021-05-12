using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using Plugin.Fingerprint;
using System;

namespace SampleApp.FreshMVVM.Droid
{
	//#if DEBUG
	//    [Application(Debuggable = true)]
	//#else
	//[Application(Debuggable = false)]
	//#endif
	[Application]
	public class MainApplication : Application, Application.IActivityLifecycleCallbacks
	{
		//public MainApplication(IntPtr handle, JniHandleOwnership transer)
		//	: base(handle, transer)
		//{
		//}

		//public override void OnCreate()
		//{
		//	base.OnCreate();
		//	CrossCurrentActivity.Current.Init(this);
		//}

		public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
		{
		}
		public override void OnCreate()
		{
			base.OnCreate();
			RegisterActivityLifecycleCallbacks(this);
			CrossFingerprint.SetCurrentActivityResolver(() => CrossCurrentActivity.Current.Activity);

			//CrossFingerprint.
		}
		public override void OnTerminate()
		{
			base.OnTerminate();
			UnregisterActivityLifecycleCallbacks(this);
		}
		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}
		public void OnActivityDestroyed(Activity activity)
		{
		}
		public void OnActivityPaused(Activity activity)
		{
		}
		public void OnActivityResumed(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}
		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
		}
		public void OnActivityStarted(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}
		public void OnActivityStopped(Activity activity)
		{
		}
	}
}