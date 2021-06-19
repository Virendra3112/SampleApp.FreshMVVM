using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleApp.FreshMVVM.Models
{
    public class ItemsGroupViewModel : ObservableCollection<ItemViewModel>
    {
        public string Name { get; set; }

        public ItemsGroupViewModel(string name, IEnumerable<ItemViewModel> items)
            : base(items)
        {
            Name = name;
        }
    }
}
