using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.ObjectModel;

namespace SampleApp.FreshMVVM.PageModels
{
    public class SettingsPageModel : BasePageModel
    {
        private ObservableCollection<MenuItems> _settingsMenuList;
        public ObservableCollection<MenuItems> SettingsMenuList
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



        private MenuItems _selectedSettingsItem = null;
        public MenuItems SelectedSettingsItem
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

            _settingsMenuList = new ObservableCollection<MenuItems>();

            _settingsMenuList.Add(new MenuItems { Id = 1, Name = "Set Theme" });
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        private void ExecuteOperation(MenuItems menuItems)
        {

        }
    }
}
