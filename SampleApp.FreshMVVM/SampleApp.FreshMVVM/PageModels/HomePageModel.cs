using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.ObjectModel;

namespace SampleApp.FreshMVVM.PageModels
{
    public class HomePageModel : BasePageModel
    {
        private ObservableCollection<MenuItems> _menuList;
        public ObservableCollection<MenuItems> MenuList
        {
            get
            {
                return _menuList;
            }
            set
            {
                _menuList = value;
                RaisePropertyChanged();
            }
        }


        private MenuItems _selectedItem = null;
        public MenuItems SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (value != null)
                {
                    NavigateToPage(_selectedItem);
                }

            }
        }

        public HomePageModel()
        {

        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            MenuList = new ObservableCollection<MenuItems>();

            MenuList.Add(new MenuItems { Id = 1, Name = "CustomLoader" });
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        private void NavigateToPage(MenuItems selectedItem)
        {
            switch (selectedItem.Name)
            {
                case "Home":
                    AppHelper.MenuIsPresented = false;
                    break;

                case "CustomLoader":
                    CoreMethods.PushPageModel<CustomLoaderSamplePageModel>();
                    AppHelper.MenuIsPresented = false;

                    break;
            }
        }
    }
}
