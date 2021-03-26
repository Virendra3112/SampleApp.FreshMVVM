using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Models;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.FreshMVVM.PageModels
{
    public class DrawerMenuPageModel : BasePageModel
    {

        private List<MenuItems> _menu;
        public List<MenuItems> MenuList
        {
            get { return _menu; }
            set { SetPropertyValue(ref _menu, value); }
        }

        private MenuItems _menuSelectedItem = null;
        public MenuItems MenuSelectedItem
        {
            get { return _menuSelectedItem; }
            set
            {
                _menuSelectedItem = value;
                if (value != null)
                {
                    NavigateToPage(_menuSelectedItem);
                }

            }
        }

        public ICommand LogoutCommand { get; set; }
        public ICommand HamburgerMenuCommand { get; set; }
        public DrawerMenuPageModel()
        {
            LogoutCommand = new Command(OnLogoutClicked);
        }

        public void CreateMenu()
        {
            MenuList = new List<MenuItems>();
            MenuList.Add(new MenuItems { Name = "Home" });
            MenuList.Add(new MenuItems { Name = "Menu Item 1" });
            MenuList.Add(new MenuItems { Name = "Menu Item 2" });
            MenuList.Add(new MenuItems { Name = "Profile" });
            MenuList.Add(new MenuItems { Name = "Settings" });
            MenuList.Add(new MenuItems { Name = "Logout" });
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            CreateMenu();
        }

        private async void OnLogoutClicked(object obj)
        {

        }

        private async void NavigateToPage(MenuItems menuItem)
        {
            switch (menuItem.Name)
            {
                case "Settings":
                    await CoreMethods.PushPageModel<SettingsPageModel>();
                    AppHelper.MenuIsPresented = false;
                    break;
            }
        }

    }
}
