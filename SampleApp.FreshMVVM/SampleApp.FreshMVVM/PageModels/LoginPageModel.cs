using SampleApp.FreshMVVM.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class LoginPageModel : BasePageModel
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetPropertyValue(ref _email, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetPropertyValue(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        public LoginPageModel()
        {
            LoginCommand = new Command(OnLoginButtonClicked);
        }

        private void OnLoginButtonClicked(object obj)
        {
            AppHelper.InitializeAndShowMasterDetailPage();
        }
    }
}
