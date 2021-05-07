using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class SampleVideoPlayerTwoPageModel : BasePageModel
    {
        private LibVLC _libVLC;

        public LibVLC LibVLC
        {
            get { return _libVLC; }
            set { SetPropertyValue(ref _libVLC, value); }
        }

        private MediaPlayer _mediaPlayer;

        public MediaPlayer MediaPlayer
        {
            get { return _mediaPlayer; }
            set { SetPropertyValue(ref _mediaPlayer, value); }
        }

        public ICommand PlayCommand { get; set; }

        public SampleVideoPlayerTwoPageModel()
        {
            PlayCommand = new Command(PlayClicked);
        }

        private void PlayClicked(object obj)
        {
            try
            {
                Core.Initialize();

                LibVLC = new LibVLC();

                var media = new Media(LibVLC,
                new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));

                MediaPlayer = new MediaPlayer(_libVLC)
                {
                    Media = media,
                    EnableHardwareDecoding = true,
                    EnableKeyInput = true,
                    EnableMouseInput = true,


                };

                //videoView.MediaPlayer = MediaPlayer;

                media.Dispose();

                MediaPlayer.Play();

                // subscribe to libvlc playback events
                //MediaPlayer.TimeChanged += TimeChanged;
                //MediaPlayer.PositionChanged += PositionChanged;
                //MediaPlayer.LengthChanged += LengthChanged;
                //MediaPlayer.EndReached += EndReached;
                //MediaPlayer.Playing += Playing;
                //MediaPlayer.Paused += Paused;


            }
            catch (Exception ex)
            {

            }
        }

      
   

        public override void Init(object initData)
        {
            base.Init(initData);



        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            try
            {
                //MediaPlayer.Play();
            }
            catch (Exception)
            {

            }
        }


        string _message = string.Empty;

        public string Message
        {
            get { return _message; }
            set { SetPropertyValue(ref _message, value); }
        }


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

        public void OnGesture(PanUpdatedEventArgs e)
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

                        Message = FormatSeekingMessage(timeDiff, _finalTime, Direction.Left);
                        _timeChanged = true;
                    }
                    else if (e.TotalX > 0 && Math.Abs(e.TotalX) > Math.Abs(e.TotalY))
                    {
                        var timeDiff = Convert.ToInt64(e.TotalX * 1000);
                        _finalTime = MediaPlayer.Time + timeDiff;

                        if (WillOverflow)
                            break;

                        Message = FormatSeekingMessage(timeDiff, _finalTime, Direction.Right);
                        _timeChanged = true;
                    }
                    else if (e.TotalY < 0 && Math.Abs(e.TotalY) > Math.Abs(e.TotalX))
                    {
                        var volume = (int)(MediaPlayer.Volume + e.TotalY * -1);
                        _finalVolume = VolumeRangeCheck(volume);

                        Message = FormatVolumeMessage(_finalVolume, Direction.Top);
                        _volumeChanged = true;
                    }
                    else if (e.TotalY > 0 && e.TotalY > Math.Abs(e.TotalX))
                    {
                        var volume = (int)(MediaPlayer.Volume + e.TotalY * -1);
                        _finalVolume = VolumeRangeCheck(volume);

                        Message = FormatVolumeMessage(_finalVolume, Direction.Bottom);
                        _volumeChanged = true;
                    }
                    break;
                case GestureStatus.Started:
                case GestureStatus.Canceled:
                    Message = string.Empty;
                    break;
                case GestureStatus.Completed:
                    if (_timeChanged)
                        MediaPlayer.Time = _finalTime;
                    if (_volumeChanged && MediaPlayer.Volume != _finalVolume)
                        MediaPlayer.Volume = _finalVolume;

                    Message = string.Empty;
                    _timeChanged = false;
                    _volumeChanged = false;
                    break;
            }

        }

    }

    enum Direction
    {
        Left,
        Right,
        Top,
        Bottom
    }

}
