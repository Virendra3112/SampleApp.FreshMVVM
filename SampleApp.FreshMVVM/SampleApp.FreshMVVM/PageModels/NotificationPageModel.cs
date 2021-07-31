using SampleApp.FreshMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleApp.FreshMVVM.PageModels
{
    public class NotificationPageModel : BasePageModel
    {
        private ObservableCollection<Notification> _menuList;
        public ObservableCollection<Notification> NotificationList
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
        
        private bool _isDataAvailable;
        public bool IsDataAvailable
        {
            get
            {
                return _isDataAvailable;
            }
            set
            {
                _isDataAvailable = value;
                RaisePropertyChanged();
            }
        }

        public NotificationPageModel()
        {

        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            try
            {
                NotificationList = new ObservableCollection<Notification>();
                //NotificationList.Add(new Notification
                //{
                //    Body = "Test body 1234",
                //    Title = "Test Title",
                //    IsDeleted = false,
                //    IsFavourite = false,
                //    IsRead = false,
                //    IsSelected = false,
                //    NotificationId = 002,
                //    ReceivedDateTime = DateTime.Now
                //});

                //NotificationList.Add(new Notification
                //{
                //    Body = "Test body 123456 kkdskf ofkpodskpfo fodsokfokds foodskfoksodf fodskfodsokfo ofkodskfo ",
                //    Title = "Test Titel",
                //    IsDeleted = false,
                //    IsFavourite = false,
                //    IsRead = false,
                //    IsSelected = false,
                //    NotificationId = 002,
                //    ReceivedDateTime = DateTime.Now
                //});

                if (NotificationList != null && NotificationList.Count != 0)
                    IsDataAvailable = true;

                else
                    IsDataAvailable = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
