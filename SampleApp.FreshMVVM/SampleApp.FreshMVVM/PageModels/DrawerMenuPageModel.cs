using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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

        public DrawerMenuPageModel()
        {
            CreateMenu();
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

    }
}
