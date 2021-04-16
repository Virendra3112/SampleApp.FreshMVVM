using SkiaSharp;
using SkiaSharp.Views.Forms;
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
    public partial class CustomLineChartPage : ContentPage
    {
        public CustomLineChartPage()
        {
            InitializeComponent();
        }

        SKSurface vSurface = null;
        SKCanvas skCanvas = null;
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            vSurface = args.Surface;
            skCanvas = vSurface.Canvas;

            //Reactabgle
            SKPaint vBlackPaint = new SKPaint
            {
                Color = SKColors.Black,
                StrokeWidth = 5,
                StrokeCap = SKStrokeCap.Square,
                TextSize = 60
            };
            SKPaint vWhitePaint = new SKPaint
            {
                Color = SKColors.White
            };

            var vWhiteRectangle = new SKRect(0, 0, 1000, 1000);
            skCanvas.DrawRect(vWhiteRectangle, vWhitePaint);


            DrawCircle(50, 150);
            DrawLine(50, 150, 300, 700);

            DrawCircle(300, 700);

            DrawCircle(600, 340);
            DrawLine(300, 700, 600, 340);

            DrawCircle(800, 950);
            DrawLine(600, 340, 800, 950);


            DrawCircle(920, 620);
            DrawLine( 800, 950, 920, 620);




            //using (SKPaint skPaint = new SKPaint())
            //{
            //    skPaint.Style = SKPaintStyle.Fill;
            //    skPaint.IsAntialias = true;
            //    skPaint.Color = SKColors.Red;
            //    skPaint.StrokeWidth = 10;

            //    skCanvas.DrawCircle(50, 150, 20, skPaint);
            //}

            //using (SKPaint skPaint = new SKPaint())
            //{
            //    skPaint.Style = SKPaintStyle.Fill;
            //    skPaint.IsAntialias = true;
            //    skPaint.Color = SKColors.Yellow;
            //    skPaint.StrokeWidth = 10;

            //    skCanvas.DrawCircle(400, 890, 20, skPaint);
            //}


            //using (SKPaint skPaint = new SKPaint())
            //{
            //    skPaint.Style = SKPaintStyle.Fill;
            //    skPaint.IsAntialias = true;
            //    skPaint.Color = SKColors.Green;
            //    skPaint.StrokeWidth = 10;

            //    skCanvas.DrawLine(50, 150, 100, 700, skPaint);
            //}





        }

        private void DrawCircle(int x, int y)
        {
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Fill;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.Red;
                skPaint.StrokeWidth = 10;

                skCanvas.DrawCircle(x, y, 20, skPaint);
            }
        }

        private void DrawLine(int x, int y, int p, int q)
        {
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Fill;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.Blue;
                skPaint.StrokeWidth = 10;

                skCanvas.DrawLine(x, y, p, q, skPaint);
            }
        }
    }
}