using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

////https://www.linkedin.com/pulse/biometrics-authentication-xamarin-forms-ravinder-singh
namespace SampleApp.FreshMVVM.PageModels
{
    public class CustomFingerprintPageModel : BasePageModel
    {
        public ICommand AuthCommand { get; set; }

        private CancellationTokenSource _cancel;



        public CustomFingerprintPageModel()
        {
            AuthCommand = new Command(OnAuthClicked);
        }

        private async void OnAuthClicked(object obj)
        {
            //try
            //{
            //    await AuthenticationAsync("Auth user", null, null, null);
            //}
            //catch(Exception ex)
            //{

            //}
        }

        private async Task AuthenticationAsync
        (string reason, string cancel = null, string fallback = null, string tooFast = null)
        {
            //_cancel = swAutoCancel.IsToggled ? new CancellationTokenSource
            //          (TimeSpan.FromSeconds(10)) : new CancellationTokenSource();

            var dialogConfig = new AuthenticationRequestConfiguration("Test",reason)
            {
                //CancelTitle = cancel,
                //FallbackTitle = fallback,
                //UseDialog = true
            };

            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync
                         (dialogConfig);

            await SetResultAsync(result);
        }

        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {
            if (result.Authenticated)
            {
                await CoreMethods.DisplayAlert("FingerPrint Sample", "Success", "Ok");
            }
            else
            {
                await CoreMethods.DisplayAlert("FingerPrint Sample", result.ErrorMessage, "Ok");
            }
        }
    }
}
