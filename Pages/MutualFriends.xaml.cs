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
    /// <summary>
    /// Логика взаимодействия для MutualFriends.xaml
    /// </summary>
    public partial class MutualFriends : Page
    {
        private ViewModels.ViewModelMutualFriends vm;
        public MutualFriends(string friendId)
        {
            vm = new ViewModels.ViewModelMutualFriends(friendId);
            DataContext = vm;
            InitializeComponent();
        }
    }
}
