
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SALoginPage : ContentPage
    {
        public SALoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}