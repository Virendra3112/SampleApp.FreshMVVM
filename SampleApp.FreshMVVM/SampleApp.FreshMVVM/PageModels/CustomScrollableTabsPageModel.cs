using System.Collections.ObjectModel;

namespace SampleApp.FreshMVVM.PageModels
{
    public class CustomScrollableTabsPageModel : BasePageModel
    {
        private string _title = null;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;

            }
        }

        private string _content = null;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;

            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;

            }
        }

        private ObservableCollection<string> _menuList;
        public ObservableCollection<string> TabVms
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
        public CustomScrollableTabsPageModel()
        {
            TabVms = new ObservableCollection<string>();

            TabVms.Add("Test 1");
            TabVms.Add("Test 2");
            TabVms.Add("Test 3");
            TabVms.Add("Test 4");
        }
    }
}
