using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AIS_LAB.Pages
{
    public partial class Authorization : Page
    {
        ViewModels.ViewModelAuthorization vm;
        public Authorization()
        {
            InitializeComponent();
            vm = new ViewModels.ViewModelAuthorization(this);
            this.DataContext = vm;
            Browser.FrameLoadEnd += vm.Browser_FrameLoadEnd;
        }
    }
}
