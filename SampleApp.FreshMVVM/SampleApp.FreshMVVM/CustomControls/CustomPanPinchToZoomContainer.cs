using System;
using Xamarin.Forms;
namespace SampleApp.FreshMVVM.CustomControls
{
    public class CustomPanPinchToZoomContainer : ContentView
    {
        double currentScale = 1;
        double startScale = 1;
        double xOffset = 0;
        double yOffset = 0;


        public CustomPanPinchToZoomContainer()
        {
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinchGesture);

            var panGestureRecognizer = new PanGestureRecognizer();
            panGestureRecognizer.PanUpdated += MovePicture;
            GestureRecognizers.Add(panGestureRecognizer);


            var doubleTapRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
            doubleTapRecognizer.Tapped += DoubleTapRecognizer_Tapped;
            GestureRecognizers.Add(doubleTapRecognizer);
        }

        private void DoubleTapRecognizer_Tapped(object sender, EventArgs e)
        {
            ResetImage();
            MessagingCenter.Send(this, "Reset", "Reset");

        }

        public void ResetImage()
        {
            xOffset = 0;
            yOffset = 0;
            currentScale = 1;
            startScale = 1;

            Content.TranslationX = 0;
            Content.TranslationY = 0;
            Content.Scale = 1;
        }

        private void MovePicture(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    Content.TranslationX =
                      Math.Max(Math.Min(0, xOffset + e.TotalX), -Math.Abs(Content.Width - App.ScreenWidth));
                    Content.TranslationY =
                      Math.Max(Math.Min(0, yOffset + e.TotalY), -Math.Abs(Content.Height - App.ScreenHeight));
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    xOffset = Content.TranslationX;
                    yOffset = Content.TranslationY;
                    break;
            }
        }


        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,  
                // and zero the components for the center point of the translate transform.  
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.  
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,  
                // so get the X pixel coordinate.  
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,  
                // so get the Y pixel coordinate.  
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.  
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                // Apply translation based on the change in origin.  
                Content.TranslationX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                Content.TranslationY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                // Apply scale factor  
                Content.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation delta's of the wrapped user interface element.  
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }
    }

    public static class DoubleExtensions
    {
        public static double Clamp(this double self, double min, double max)
        {
            return Math.Min(max, Math.Max(self, min));
        }

    }
}

