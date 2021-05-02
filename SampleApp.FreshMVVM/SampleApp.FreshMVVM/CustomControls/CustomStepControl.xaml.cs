using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomStepControl : ContentView
    {
        public CustomStepControl()
        {
            InitializeComponent();

            SkCanvasView.PaintSurface += draw_Circle;

        }

        public void draw_Circle(object sender, SKPaintSurfaceEventArgs args)
        {
            try
            {
                SKImageInfo info = args.Info;
                SKSurface surface = args.Surface;
                SKCanvas canvas = surface.Canvas;

                canvas.Clear();

                using (SKPaint paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Stroke;
                    paint.Color = Color.FromHex("#cb2dec").ToSKColor();
                    paint.StrokeWidth = 25;
                    canvas.DrawCircle(new SKPoint(530, 550), 500, paint);
                }
            }
            catch (Exception ex)
            {

            }
        }

        //void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        //{
        //    SKImageInfo info = args.Info;
        //    SKSurface surface = args.Surface;
        //    SKCanvas canvas = surface.Canvas;

        //    canvas.Clear();

        //}
    }
}