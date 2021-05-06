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
                MediaPlayer.TimeChanged += TimeChanged;
                MediaPlayer.PositionChanged += PositionChanged;
                MediaPlayer.LengthChanged += LengthChanged;
                MediaPlayer.EndReached += EndReached;
                MediaPlayer.Playing += Playing;
                MediaPlayer.Paused += Paused;


            }
            catch (Exception ex)
            {

            }
        }

        private void PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
        }

        private void LengthChanged(object sender, MediaPlayerLengthChangedEventArgs e)
        {
        }

        private void EndReached(object sender, EventArgs e)
        {
        }

        private void Playing(object sender, EventArgs e)
        {
        }

        private void Paused(object sender, EventArgs e)
        {
        }

        private void TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
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


    }

    enum Direction
    {
        Left,
        Right,
        Top,
        Bottom
    }

}
