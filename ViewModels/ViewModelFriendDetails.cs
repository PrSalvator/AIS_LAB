using AIS_LAB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB.ViewModels
{
    class ViewModelFriendDetails: INotifyPropertyChanged
    {
        private ExtendedUser friend;

        private Methods methods = new Methods();

        public ExtendedUser Friend
        {
            get
            {
                return friend;
            }
            set
            {
                friend = value;
                OnPropertyChanged("Friend");
            }
        }
        public ViewModelFriendDetails(string friendId)
        {
            Task.Run(()=>getFriendDetails(friendId));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private async Task getFriendDetails(string friendId)
        {
            if (!(friendId is null))
            {
                string method = "users.get?user_ids=" + friendId + "&fields=bdate,photo_100,sex,city";
                string jsonResponse = await methods.GET(method);
                Response<List<ExtendedUser>> response = JsonConvert.DeserializeObject<Response<List<ExtendedUser>>>(jsonResponse);
                Friend = response.TClass[0];
            }
        }
    }
}
