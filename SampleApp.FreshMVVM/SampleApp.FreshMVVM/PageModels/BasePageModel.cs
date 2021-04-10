using Acr.UserDialogs;
using FreshMvvm;
using Plugin.Connectivity;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class BasePageModel : FreshBasePageModel, INotifyPropertyChanged, IDisposable
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

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetPropertyValue(ref _pageTitle, value); }
        }

        private string _currentLangauge;
        public string CurrentLangauge
        {
            get { return _currentLangauge; }
            set { SetPropertyValue(ref _currentLangauge, value); }
        }

        public ICommand SelectLanguageCommand { get; set; }
        public ICommand SetLanguageCommand { get; set; }
        public ICommand CancelLanguageCommand { get; set; }

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

            SelectLanguageCommand = new Command(OnSelectlanguageClicked);
            SetLanguageCommand = new Command(OnSetlanguageClicked);
            CancelLanguageCommand = new Command(OnCancellanguageClicked);

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



        public void OnSelectlanguageClicked(object obj)
        {

        }
        public void OnSetlanguageClicked(object obj)
        {

        }
        public void OnCancellanguageClicked(object obj)
        {

        }




        //        #region INotifyPropertyChanged implementation

        //#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        //        public event PropertyChangedEventHandler PropertyChanged;
        //#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        //        /// <summary>
        //        /// Raises the property changed.
        //        /// </summary>
        //        /// <param name="propertyName">Property name.</param>
        //        protected new void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        //        {
        //            if (PropertyChanged != null)
        //            {
        //                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //            }
        //        }
        //        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// An event that fires when any of the property values change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #region Raise Property Changed

        /// <summary>
        /// Raise Property Changed using an expression function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpr"></param>
        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpr)
        {
            var propertyName = GetMemberInfo(propertyExpr).Name;
            RaisePropertyChangedExplicit(propertyName);
        }

        /// <summary>
        /// Raise Property Changed using the CallerMemberName
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            RaisePropertyChangedExplicit(propertyName);
        }


        /// <summary>
        /// Raise Propery Changed explicitly passing the property name
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChangedExplicit(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion

        #region Set Property Value

        /// <summary>
        /// Set the property value using an expression function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storageField"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyExpr"></param>
        /// <returns></returns>
        protected bool SetPropertyValue<T>(ref T storageField, T newValue, Expression<Func<T>> propertyExpr)
        {
            if (Equals(storageField, newValue))
                return false;

            storageField = newValue;

            var propertyName = GetMemberInfo(propertyExpr).Name;
            RaisePropertyChangedExplicit(propertyName);

            return true;
        }

        /// <summary>
        /// Set the property value using the CallerMemberName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storageField"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetPropertyValue<T>(ref T storageField, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (Equals(storageField, newValue))
                return false;

            storageField = newValue;
            RaisePropertyChangedExplicit(propertyName);

            return true;
        }

        #endregion

        #region Helper Methods

        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }

        #endregion

        #endregion

        #region IDisposable implementation

        public virtual void Dispose()
        {
        }

        #endregion
    }
}
