using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.FreshMVVM.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrollableTabs : ContentView
    {
        public ScrollableTabs()
        {
            InitializeComponent();
        }
    }
}