using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Models;
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
                    ExecuteOperation(_selectedSettingsItem);
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

                SettingsMenuList.Add(new SettingsMenuItems { Id = 1, MenuName = "Theme" });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 2, MenuName = "Language" });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 3, MenuName = "Profile" });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 4, MenuName = "Security" });
                SettingsMenuList.Add(new SettingsMenuItems { Id = 5, MenuName = "Logout" });
            }
            catch (Exception ex)
            {

            }
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        private void ExecuteOperation(SettingsMenuItems menuItems)
        {
            switch (menuItems.MenuName)
            {
                case "Theme":

                    break;

                case "Language":

                    break;
            }

        }
    }
}
