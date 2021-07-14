﻿using SampleApp.FreshMVVM.Helpers;
using SampleApp.FreshMVVM.Interfaces;
using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

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

            try
            {
                MenuList = new ObservableCollection<MenuItems>();

                MenuList.Add(new MenuItems { Id = 1, Name = "Custom Loader" });
                //MenuList.Add(new MenuItems { Id = 2, Name = "Custom Tabs" });//Todo
                //MenuList.Add(new MenuItems { Id = 3, Name = "Image Compression" });
                //MenuList.Add(new MenuItems { Id = 4, Name = "Line Chart" });//Todo
                MenuList.Add(new MenuItems { Id = 5, Name = "Ultimate XF Line Chart" });
                //MenuList.Add(new MenuItems { Id = 6, Name = "Video Player" });
                //MenuList.Add(new MenuItems { Id = 7, Name = "Sample App Wireframe" });
                //MenuList.Add(new MenuItems { Id = 8, Name = "Video Player2" });
                //MenuList.Add(new MenuItems { Id = 9, Name = "Sample Stepper" });
                //MenuList.Add(new MenuItems { Id = 10, Name = "Video Player3" });
                MenuList.Add(new MenuItems { Id = 11, Name = "Fingerprint" });
                //MenuList.Add(new MenuItems { Id = 12, Name = "ImageEdit" });
                MenuList.Add(new MenuItems { Id = 13, Name = "PanPinchSVG" });
                MenuList.Add(new MenuItems { Id = 14, Name = "CarouselWithSVG" });
                MenuList.Add(new MenuItems { Id = 15, Name = "Notifications" });
                MenuList.Add(new MenuItems { Id = 16, Name = "Export Logs" });
                MenuList.Add(new MenuItems { Id = 16, Name = "DragDropList" });
                MenuList.Add(new MenuItems { Id = 16, Name = "NotificationList" });
            }
            catch (Exception ex)
            {

            }


        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }

        private void NavigateToPage(MenuItems selectedItem)
        {
            try
            {
                switch (selectedItem.Name)
                {
                    case "Home":
                        AppHelper.MenuIsPresented = false;
                        break;

                    case "Custom Loader":
                        CoreMethods.PushPageModel<CustomLoaderSamplePageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Custom Tabs":
                        CoreMethods.PushPageModel<CustomScrollableTabsPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Image Compression":
                        CoreMethods.PushPageModel<CustomImageCompressionPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Line Chart":
                        CoreMethods.PushPageModel<CustomLineChartPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Ultimate XF Line Chart":
                        CoreMethods.PushPageModel<SampleChartPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Video Player":
                        CoreMethods.PushPageModel<SampleVideoPlayerPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Sample App Wireframe":
                        CoreMethods.PushPageModel<SALoginPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "video player2":
                        //CoreMethods.PushPageModel<SampleVideoPlayerTwoPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Sample Stepper":
                        CoreMethods.PushPageModel<SampleStepperPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Video Player3":
                        CoreMethods.PushPageModel<SampleVideoPlayerThreePageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Fingerprint":
                        CoreMethods.PushPageModel<CustomFingerprintPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "ImageEdit":
                        CoreMethods.PushPageModel<SampleImageEditPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "PanPinchSVG":
                        CoreMethods.PushPageModel<CustomPanPinchSamplePageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "CarouselWithSVG":
                        CoreMethods.PushPageModel<CarouselWithSVGPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Notifications":
                        CoreMethods.PushPageModel<AppNotificationPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "DragDropList":
                        CoreMethods.PushPageModel<DragDropListPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "NotificationList":
                        CoreMethods.PushPageModel<NotificationPageModel>();
                        AppHelper.MenuIsPresented = false;

                        break;

                    case "Export Logs":
                        {
                            AppHelper.MenuIsPresented = false;
                            ExportLogs();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                DependencyService.Resolve<IAppLogger>()
                    .AddErrorLog(nameof(HomePageModel), nameof(NavigateToPage), ex, selectedItem.Name);
            }
        }

        private async void ExportLogs()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = AppSettings.LoggerFilePath,
                Title = "Share App logger file"
            });
        }
    }
}
