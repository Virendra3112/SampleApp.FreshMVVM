using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Biometric;

namespace SampleApp.FreshMVVM.Droid
{
    public class MyCustomDialogFragment :  FingerprintDialogFragment
    {
        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    var view = base.OnCreateView(inflater, container, savedInstanceState);

        //    var image = view.FindViewById<ImageView>(Resource.Id.fingerprint_icon);

        //    image.SetColorFilter(Color.ParseColor("#FF0000"));

        //    view.FindViewById<TextView>(Resource.Id.fingerprint_description).SetTextColor(Color.Green);

        //    view.Background = new ColorDrawable(Color.Red);

        //    return view;
        //}

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var image = view?.FindViewById<ImageView>(Resource.Id.fingerprint_icon);

            image?.SetColorFilter(Color.Red);
            // black 

            if (view != null)
            {
                //view.FindViewById<TextView>(Resource.Id.textinput_helper_text).Visibility = ViewStates.Visible;
                // view.FindViewById<Button>(Resource.Id.fingerprint_btnFallback).Visibility = ViewStates.Gone;
            }

            //view?.FindViewById<TextView>(Resource.Id.textinput_helper_text)?.SetTypeface(null, TypefaceStyle.Bold);
            //view?.FindViewById<TextView>(Resource.Id.textinput_helper_text).SetTextColor(Color.Black);
            //view?.FindViewById<TextView>(Resource.Id.textinput_helper_text)
            //    .SetText("Test App", TextView.BufferType.Normal);

            //view?.FindViewById<TextView>(Resource.Id.textinput_counter).SetTextColor(Color.Black);
            var cancelImg = view?.FindViewById<Button>(Resource.Id.cancel_button);

            cancelImg.SetTextColor(Color.Pink);

            cancelImg.Text = "tototoot";

            return view;
        }

    }
}