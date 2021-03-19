using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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

        public ICommand LogoutCommand { get; set; }
        public ICommand HamburgerMenuCommand { get; set; }
        public DrawerMenuPageModel()
        {
            LogoutCommand = new Command(OnLogoutClicked);
        }

        public void CreateMenu()
        {
            MenuList = new List<MenuItems>();
            MenuList.Add(new MenuItems { Name = "Browse Products" });
            MenuList.Add(new MenuItems { Name = "Your orders" });
            MenuList.Add(new MenuItems { Name = "Categories" });
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

    }
}
