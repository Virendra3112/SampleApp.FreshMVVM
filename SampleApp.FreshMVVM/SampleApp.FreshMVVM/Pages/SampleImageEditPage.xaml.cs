using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleImageEditPage : ContentPage
    {
        public SampleImageEditPage()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {

            }
        }
    }
}