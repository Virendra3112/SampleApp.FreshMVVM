using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawerMenuPage : ContentPage
    {
        public DrawerMenuPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
            
            }


        }

       
    }
}