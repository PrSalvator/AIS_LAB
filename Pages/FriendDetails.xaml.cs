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
    /// Логика взаимодействия для FriendDetails.xaml
    /// </summary>
    public partial class FriendDetails : Page
    {
        ViewModels.ViewModelFriendDetails vm;
        public FriendDetails(string friendId)
        {
            vm = new ViewModels.ViewModelFriendDetails(friendId);
            DataContext = vm;
            InitializeComponent();
        }
    }
}
