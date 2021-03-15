using Acr.UserDialogs;
using FreshMvvm;
using Plugin.Connectivity;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp.FreshMVVM.PageModels
{
    public class BasePageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        private bool _isNetworkAvailable;

        public bool IsNetworkAvailable
        {
            get => _isNetworkAvailable;
            set
            {
                _isNetworkAvailable = value;
                RaisePropertyChanged();
            }
        }

        public bool IsConnected
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }

        bool isBusy;      
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                ShowLoading(value);
                RaisePropertyChanged();
            }
        }


        private void ShowLoading(bool value)
        {
            try
            {
                if (value)
                    UserDialogs.Instance.ShowLoading();

                else
                    UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
            }
        }


        public BasePageModel()
        {
            CheckConnectivity();
        }

        public void CheckConnectivity()
        {
            try
            {
                CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
                {
                    IsNetworkAvailable = args.IsConnected;

                    ToastConfig.DefaultPosition = ToastPosition.Top;

                    if (IsNetworkAvailable)
                    {
                        UserDialogs.Instance.Toast("Internet connected");


                    }

                    else
                        UserDialogs.Instance.Toast("Internet Lost");

                };
            }
            catch (System.Exception ex)
            {
            }
        }



        #region INotifyPropertyChanged implementation

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected new void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
