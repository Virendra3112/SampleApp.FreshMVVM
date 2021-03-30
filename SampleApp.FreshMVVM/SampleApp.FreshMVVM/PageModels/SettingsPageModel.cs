using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Models;
using SampleApp.FreshMVVM.Models.Enum;
using SampleApp.FreshMVVM.Resources;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class SettingsPageModel : BasePageModel
    {
        private ObservableCollection<SettingsMenuItems> _settingsMenuList;
        public ObservableCollection<SettingsMenuItems> SettingsMenuList
        {
            get
            {
                return _settingsMenuList;
            }
            set
            {
                _settingsMenuList = value;
                RaisePropertyChanged();
            }
        }


        private bool _isSelectThemeVisible;
        public bool IsSelectThemeVisible
        {
            get { return _isSelectThemeVisible; }
            set { SetPropertyValue(ref _isSelectThemeVisible, value); }
        }



        private SettingsMenuItems _selectedSettingsItem = null;
        public SettingsMenuItems SelectedSettingsItem
        {
            get { return _selectedSettingsItem; }
            set
            {
                _selectedSettingsItem = value;
                if (value != null)
                {
                    ExecuteOperationAsync(_selectedSettingsItem);
                }

            }
        }
        public ICommand SelectThemeCommand { get; set; }
        public ICommand CancelThemeCommand { get; set; }


        public SettingsPageModel()
        {
            SelectThemeCommand = new Command(OnThemeSelected);
            CancelThemeCommand = new Command(OnThemeCancelSelected);
        }


        public override void Init(object initData)
        {
            base.Init(initData);
        }


        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            try
            {
                SettingsMenuList = new ObservableCollection<SettingsMenuItems>();

                SettingsMenuList.Add(new SettingsMenuItems { Id = 1, MenuName = SettingsMenuEnum.Theme });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 2, MenuName = SettingsMenuEnum.Language });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 3, MenuName = SettingsMenuEnum.Profile });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 4, MenuName = SettingsMenuEnum.Security });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 5, MenuName = SettingsMenuEnum.Logout });
            }
            catch (Exception ex)
            {

            }
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        private async Task ExecuteOperationAsync(SettingsMenuItems menuItems)
        {
            try
            {
                switch (menuItems.MenuName.ToString())
                {
                    case "Theme":
                        //Todo: Select app theme
                        IsSelectThemeVisible = true;
                        break;

                    case "Language":
                        //Todo: Select app languagte

                        //var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains(picker.SelectedItem.ToString())); ;
                        //Thread.CurrentThread.CurrentUICulture = language;
                        //AppResources.Culture = language;
                        break;

                    case "Profile":
                        //Todo: Edit user profile page

                        break;

                    case "Security":
                        //Todo: Add biomatric or face id setting
                        break;

                    case "Logout":
                        {
                            if (await CoreMethods.DisplayAlert(AppResources.LogoutTitle, AppResources.LogoutMessage, AppResources.ButtonOk, AppResources.ButtonCancel))
                            {
                                CoreMethods.SwitchOutRootNavigation("login");
                                AppSettings.IsUserLoggedIn = false;
                                AppSettings.CurrentLanguage = "en";
                                AppSettings.CurrentSecurity = null;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", ex.Message, AppResources.ButtonOk);
            }

        }

        private void OnThemeSelected(object obj)
        {
            //set theme

            IsSelectThemeVisible = false;

        }

        private void OnThemeCancelSelected(object obj)
        {
            IsSelectThemeVisible = false;
        }

    }
}
