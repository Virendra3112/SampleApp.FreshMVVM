using SampleApp.FreshMVVM.CustomControls;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircleView), typeof(CircleViewRenderer))]
namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class CircleViewRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)((CircleView)Element).CornerRadius / 2.0f;
        }

    }
}