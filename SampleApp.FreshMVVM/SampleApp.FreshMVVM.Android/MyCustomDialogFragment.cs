using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using AndroidX.Biometric;

namespace SampleApp.FreshMVVM.Droid
{
    public class MyCustomDialogFragment : FingerprintDialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            view.Background = new ColorDrawable(Color.Magenta);
            return view;
        }
    }
}