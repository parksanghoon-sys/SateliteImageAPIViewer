
using NavigationMVVM.Commands;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class LoginViewModel :ViewModelBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName =value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        private RelayCommand _loginCommand;
        public ICommand LoginCommand
        {
            get => _loginCommand ?? (this._loginCommand = new RelayCommand(this.OnLoginCommand));
        }
        private void OnLoginCommand(object obj)
        {
            Account acount = new Account()
            {
                Email = $"{UserName}@naver.com",
                UsrName = UserName
            };
            account.CurrentAccount = acount;
            navigation.Navigate();
        }

        private readonly AccountStore account;
        private readonly INavigationService navigation;
        public LoginViewModel(AccountStore accountStore, INavigationService navigationService)
        {
            account = accountStore;
            navigation = navigationService;
        }

    }
}
