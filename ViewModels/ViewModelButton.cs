using AIS_LAB.Commands;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB.ViewModels
{
    class ViewModelButton
    {
        private RelayCommand logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return logInCommand ??
                  (logInCommand = new RelayCommand(obj =>
                  {
                      Pages.Button page = obj as Pages.Button;
                      page.NavigationService.Navigate(new Pages.Authorization());
                  }));
            }
        }
    }
}
