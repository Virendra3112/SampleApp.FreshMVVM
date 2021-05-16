using System;

namespace SampleApp.FreshMVVM.PageModels
{
    public class SampleVideoPlayerPageModel : BasePageModel
    {
        public SampleVideoPlayerPageModel()
        {

        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            //http://tradeplusresources.com/demo/images/test.mp4
        }
    }
}
