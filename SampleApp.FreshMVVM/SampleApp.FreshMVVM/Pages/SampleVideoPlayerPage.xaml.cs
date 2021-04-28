//using Plugin.MediaManager;
//using Plugin.MediaManager.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleVideoPlayerPage : ContentPage
    {
        public SampleVideoPlayerPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }

        //private void PlayPauseButton_Clicked(object sender, EventArgs e)
        //{

        //}

        //private async void PlayStop_Clicked(object sender, EventArgs e)
        //{
        //    if (PlayPauseButton.Text == "Play")
        //    {
        //        await CrossMediaManager.Current.Play(VideoEntry.Text, MediaFileType.Video);

        //        PlayPauseButton.Text = "Stop";
        //    }

        //    else if (PlayPauseButton.Text == "Stop")
        //    {
        //        await CrossMediaManager.Current.Stop();

        //        PlayPauseButton.Text = "Play";
        //    }
        //}
    }
}