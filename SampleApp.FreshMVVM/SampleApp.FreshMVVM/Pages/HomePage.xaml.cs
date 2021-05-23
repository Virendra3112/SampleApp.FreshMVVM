using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
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