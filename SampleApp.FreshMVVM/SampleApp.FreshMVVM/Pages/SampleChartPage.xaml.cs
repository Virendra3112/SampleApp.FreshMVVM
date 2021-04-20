using SampleApp.FreshMVVM.Helpers;
using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Formatters;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleChartPage : ContentPage
    {
        public SampleChartPage()
        {
            InitializeComponent();
        }

        private void BtnLoad_Clicked(object sender, EventArgs e)
        {
            LoadChart();
        }

        String[] products = new string[] {"Mobiles","Tablets","Earphones","Headphones","Speakers",
"USB Cables","Laptops","Backcase","Screencover" };

        public void LoadChart()
        {
            try
            {
                var entries = new List<EntryChart>();
                //var entries2 = new List<EntryChart>();
                var labels = new List<string>();

                var random = new Random();
                for (int i = 0; i < 4; i++)
                {
                    entries.Add(new EntryChart(i, random.Next(1000, 50000)));
                    //entries2.Add(new EntryChart(i, random.Next(1000, 50000)));
                    labels.Add(products[i]);
                }
                var FontFamily = "";
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        FontFamily = "Pacifico-Regular";
                        break;
                    case Device.Android:
                        FontFamily = "Fonts/Pacifico-Regular.ttf";
                        break;
                    default:
                        break;
                }
                var dataSet4 = new LineDataSetXF(entries, "Product Summary 1")
                {
                    CircleRadius = 0,
                    CircleColors = new List<Color>(){
                        Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black },
                    CircleHoleColor = Color.Green,
                    CircleHoleRadius=10f,
                    DrawCircleHole = true,
                    ValueColors = new List<Color>()
                    {
                        Color.FromHex("#3696e0"), Color.FromHex("#9958bc"),
                        Color.FromHex("#35ad54"), Color.FromHex("#2d3e52"),
                        Color.FromHex("#e55137"), Color.FromHex("#ea9940"),
                        Color.Black
                    },
                    Mode = LineDataSetMode.STEPPED,
                    ValueFormatter = new CustomDataSetValueFormatter(),
                    ValueFontFamily = FontFamily,
                    HighlightLineWidth =2,
                    LineWidth = 5,
                    
                    
                    
                };

                //var dataSet5 = new LineDataSetXF(entries2, "Product Summary 2")
                //{
                //    Colors = new List<Color>{Color.Green},
                //    CircleHoleColor = Color.Blue,
                //    CircleColors = new List<Color>{Color.Blue},
                //    CircleRadius = 3,
                //    DrawValues = false,

                //};

                var data4 = new LineChartData(new List<ILineDataSetXF>() { dataSet4 });

                chart.ChartData = data4;
                chart.DescriptionChart.Text = "Product chart description";
                chart.AxisLeft.DrawGridLines = false;
                chart.AxisLeft.DrawAxisLine = true;
                chart.AxisLeft.Enabled = true;

                chart.AxisRight.DrawAxisLine = false;
                chart.AxisRight.DrawGridLines = false;
                chart.AxisRight.Enabled = false;

                chart.AxisRight.FontFamily = FontFamily;
                chart.AxisLeft.FontFamily = FontFamily;
                chart.XAxis.FontFamily = FontFamily;

                chart.XAxis.XAXISPosition = XAXISPosition.BOTTOM;
                chart.XAxis.DrawGridLines = false;
                chart.XAxis.AxisValueFormatter = new TextByIndexXAxisFormatter(labels);

            }
            catch (Exception ex)
            {

            }
        }
    }
}