using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleVideoPlayerTwoPage : ContentPage
    {
        public SampleVideoPlayerTwoPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            videoView.MediaPlayerChanged += MediaPlayerChanged;           
        }

      
        private void MediaPlayerChanged(object sender, System.EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {

            }
        }

    }
}