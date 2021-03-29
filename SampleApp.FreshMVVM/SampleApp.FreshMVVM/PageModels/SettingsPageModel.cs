using SampleApp.FreshMVVM.Models;
using SampleApp.FreshMVVM.Models.Enum;
using SampleApp.FreshMVVM.Resources;
using System;
using System.Collections.ObjectModel;

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
        public SettingsPageModel()
        {

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

        private async System.Threading.Tasks.Task ExecuteOperationAsync(SettingsMenuItems menuItems)
        {
            try
            {
                switch (menuItems.MenuName.ToString())
                {
                    case "Theme":
                        //Todo: Select app theme

                        break;

                    case "Language":
                        //Todo: Select app languagte

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
    }
}
