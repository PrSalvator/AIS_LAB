using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AIS_LAB.Commands;
using System.Web;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using CefSharp;
using AIS_LAB.Pages;
using System.Threading;
using System.Configuration;

namespace AIS_LAB.ViewModels
{
    class ViewModelAuthorization : INotifyPropertyChanged
    {
        private Pages.Authorization page;
        private static string appId = ConfigurationManager.AppSettings.Get("AppId");
        private string address = "https://oauth.vk.com/authorize?client_id=" + appId +
            "&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=friends offline&response_type=token&v=5.52";
        private string accessToken;
        private string userId;

        public ViewModelAuthorization(Pages.Authorization page)
        {
            this.page = page;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            if (Address.Contains("access_token"))
            {
                string url = Address.Replace("#", "&");
                accessToken = HttpUtility.ParseQueryString(url).Get("access_token");
                ConfigurationManager.AppSettings.Set("AccessToken", accessToken);
                userId = HttpUtility.ParseQueryString(url).Get("user_id");
                ConfigurationManager.AppSettings.Set("UserId", userId);
                page.Dispatcher.Invoke(() => page.NavigationService.Navigate(new Pages.App()));
            }
        }
    }
}
