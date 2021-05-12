using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomFingerprintPage : ContentPage
    {
        public CustomFingerprintPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await AuthenticationAsync("Auth user");
            }
            catch (Exception ex)
            {

            }
        }

        private CancellationTokenSource _cancel;

        private async Task AuthenticationAsync
      (string reason, string cancel = null, string fallback = null, string tooFast = null)
        {
            _cancel = swAutoCancel.IsToggled ? new CancellationTokenSource
                      (TimeSpan.FromSeconds(10)) : new CancellationTokenSource();

            var dialogConfig = new AuthenticationRequestConfiguration("Test App111", reason)
            {
                CancelTitle = cancel,
                FallbackTitle = "",
                AllowAlternativeAuthentication = true,
                ConfirmationRequired = false,
            };

            dialogConfig.HelpTexts.MovedTooFast = tooFast;

            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync
                         (dialogConfig);

            await SetResultAsync(result);
        }

        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {
            if (result.Authenticated)
            {
                //await CoreMethods.DisplayAlert("FingerPrint Sample", "Success", "Ok");
            }
            else
            {
                //await CoreMethods.DisplayAlert("FingerPrint Sample", result.ErrorMessage, "Ok");
            }
        }
    }
}