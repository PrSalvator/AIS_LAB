using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AIS_LAB.Models;
using AIS_LAB.ViewModels;
using Newtonsoft.Json;

namespace AIS_LAB.ViewModels
{
    class ViewModelMutualFriends: INotifyPropertyChanged
    {
        private List<User> mutualFriendsList;
        private Methods methods = new Methods();
        public ViewModelMutualFriends(string friendId)
        {
            Task.Run(() => GetMutualFriends(friendId));
        }

        public List<User> MutualFriendsList
        {
            get
            {
                return mutualFriendsList;
            }
            set
            {
                mutualFriendsList = value;
                OnPropertyChanged("MutualFriendsList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private async Task GetMutualFriends(string friendId)
        {
            if(!(friendId is null))
            {
                string method = "friends.getMutual?target_uid=" + friendId;
                string jsonResponse = await methods.GET(method);
                Response<List<string>> responseId = JsonConvert.DeserializeObject<Response<List<string>>>(jsonResponse);
                List<string> mutualFriendsId = responseId.TClass;
                if(!(mutualFriendsId is null))
                {
                    method = "users.get?fields=bdate,photo_100&user_ids=";
                    foreach (string id in mutualFriendsId)
                    {
                        method += id + ",";
                    }
                    jsonResponse = await methods.GET(method);
                    Response<List<User>> responseMutualFriends = JsonConvert.DeserializeObject<Response<List<User>>>(jsonResponse);
                    MutualFriendsList = responseMutualFriends.TClass;
                }
            }
        }
    }
}
