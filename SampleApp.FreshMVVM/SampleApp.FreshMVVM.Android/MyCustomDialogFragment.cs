using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Biometric;

namespace SampleApp.FreshMVVM.Droid
{
    public class MyCustomDialogFragment : FingerprintDialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var image = view.FindViewById<ImageView>(Resource.Id.fingerprint_icon);

            image.SetColorFilter(Color.ParseColor("#FF0000"));

            view.FindViewById<TextView>(Resource.Id.fingerprint_description).SetTextColor(Color.Green);

            view.Background = new ColorDrawable(Color.Red);
            
            return view;
        }
    }
}