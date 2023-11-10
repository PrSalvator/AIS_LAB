using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Controls;
using AIS_LAB.Models;
using System.Configuration;
using AIS_LAB.Commands;

namespace AIS_LAB.ViewModels
{
    public class ViewModelApp: INotifyPropertyChanged
    {
        public Frame InfoFrame { get; set; }

        private RelayCommand getMutualFriendsCommand;
        private RelayCommand getFriendDetailsCommand;

        private List<User> usersList;
        private string userId = ConfigurationManager.AppSettings.Get("UserId");
        private string accessToken = ConfigurationManager.AppSettings.Get("AccessToken");
        private string url = "https://api.vk.com/method/{0}&access_token={1}&v=5.81";

        private Methods methods = new Methods();

        public ViewModelApp()
        {
            Task.Run(() => getFriends(userId));
        }

        public List<User> UsersList
        {
            get
            {
                return usersList;
            }
            set
            {
                usersList = value;
                OnPropertyChanged("UsersList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public User SelectedUser { get; set; }
        public RelayCommand GetMutualFriendsCommand
        {
            get
            {
                return getMutualFriendsCommand ??
                  (getMutualFriendsCommand = new RelayCommand(obj =>
                  {
                      Frame frame = obj as Frame;
                      frame.Content = new Pages.MutualFriends(SelectedUser.Id);
                  }));
            }
        }
        public RelayCommand GetFriendDetailsCommand
        {
            get
            {
                return getFriendDetailsCommand ??
                  (getFriendDetailsCommand = new RelayCommand(obj =>
                  {
                      Frame frame = obj as Frame;
                      frame.Content = new Pages.FriendDetails(SelectedUser.Id);
                  }));
            }
        }
        private async Task getFriends(string userId)
        {
            string method = "friends.get?fields=bdate,photo_100";
            string jsonResponse = await methods.GET(url, method, accessToken);
            Response<Users> response = JsonConvert.DeserializeObject<Response<Users>>(jsonResponse);
            UsersList =  response.TClass.UsersList;
        }
    }
}
