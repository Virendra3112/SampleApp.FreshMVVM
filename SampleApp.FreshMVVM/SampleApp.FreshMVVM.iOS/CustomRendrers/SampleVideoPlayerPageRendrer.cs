using Foundation;
using SampleApp.FreshMVVM.iOS.CustomRendrers;
using SampleApp.FreshMVVM.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SampleVideoPlayerPage), typeof(SampleVideoPlayerPageRendrer))]
namespace SampleApp.FreshMVVM.iOS.CustomRendrers
{
    public class SampleVideoPlayerPageRendrer : PageRenderer
    {
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));
        }
    }
}