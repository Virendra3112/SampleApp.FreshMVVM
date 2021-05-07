using LibVLCSharp.Shared;
using SampleApp.FreshMVVM.PageModels;
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

        public LibVLC LibVLC;

        public MediaPlayer MediaPlayer;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            videoView.MediaPlayerChanged += MediaPlayerChanged;

            Core.Initialize();

            LibVLC = new LibVLC();

            var media = new Media(LibVLC,
            new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));

            MediaPlayer = new MediaPlayer(LibVLC)
            {
                Media = media,
                EnableHardwareDecoding = true,
                EnableKeyInput = true,
                EnableMouseInput = true,
            };

            videoView.MediaPlayer = MediaPlayer;

            media.Dispose();

            MediaPlayer.Play();
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

       // public string Message;
     


        long _finalTime;
        bool _timeChanged;

        int _finalVolume;
        bool _volumeChanged;

        string FormatSeekingMessage(long timeDiff, long finalTime, Direction direction)
        {
            var timeDiffTimeSpan = TimeSpan.FromMilliseconds((double)new decimal(timeDiff));
            var finalTimeSpan = TimeSpan.FromMilliseconds((double)new decimal(finalTime));
            var diffSign = direction == Direction.Right ? "+" : "-";
            return $"Seeking ({direction} swipe): {diffSign}{timeDiffTimeSpan.Minutes}:{Math.Abs(timeDiffTimeSpan.Seconds)} ({finalTimeSpan.Minutes}:{Math.Abs(finalTimeSpan.Seconds)})";
        }

        string FormatVolumeMessage(int volume, Direction direction) => $"Volume ({direction} swipe): {volume}%";

        bool WillOverflow => _finalTime > TimeSpan.MaxValue.TotalMilliseconds || _finalTime < TimeSpan.MinValue.TotalMilliseconds;

        int VolumeRangeCheck(int volume)
        {
            if (volume < 0)
                volume = 0;
            else if (volume > 200)
                volume = 200;
            return volume;
        }

        void PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (e.TotalX < 0 && Math.Abs(e.TotalX) > Math.Abs(e.TotalY))
                    {
                        var timeDiff = Convert.ToInt64(e.TotalX * 1000);
                        _finalTime = MediaPlayer.Time + timeDiff;

                        if (WillOverflow)
                            break;

                        MsgLabel.Text = FormatSeekingMessage(timeDiff, _finalTime, Direction.Left);
                        _timeChanged = true;
                    }
                    else if (e.TotalX > 0 && Math.Abs(e.TotalX) > Math.Abs(e.TotalY))
                    {
                        var timeDiff = Convert.ToInt64(e.TotalX * 1000);
                        _finalTime = MediaPlayer.Time + timeDiff;

                        if (WillOverflow)
                            break;

                        MsgLabel.Text = FormatSeekingMessage(timeDiff, _finalTime, Direction.Right);
                        _timeChanged = true;
                    }
                    else if (e.TotalY < 0 && Math.Abs(e.TotalY) > Math.Abs(e.TotalX))
                    {
                        var volume = (int)(MediaPlayer.Volume + e.TotalY * -1);
                        _finalVolume = VolumeRangeCheck(volume);

                        MsgLabel.Text = FormatVolumeMessage(_finalVolume, Direction.Top);
                        _volumeChanged = true;
                    }
                    else if (e.TotalY > 0 && e.TotalY > Math.Abs(e.TotalX))
                    {
                        var volume = (int)(MediaPlayer.Volume + e.TotalY * -1);
                        _finalVolume = VolumeRangeCheck(volume);

                        MsgLabel.Text = FormatVolumeMessage(_finalVolume, Direction.Bottom);
                        _volumeChanged = true;
                    }
                    break;
                case GestureStatus.Started:
                case GestureStatus.Canceled:
                    MsgLabel.Text = string.Empty;
                    break;
                case GestureStatus.Completed:
                    if (_timeChanged)
                        MediaPlayer.Time = _finalTime;
                    if (_volumeChanged && MediaPlayer.Volume != _finalVolume)
                        MediaPlayer.Volume = _finalVolume;

                    MsgLabel.Text = string.Empty;
                    _timeChanged = false;
                    _volumeChanged = false;
                    break;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MediaPlayer.Play();
        }
    }
}