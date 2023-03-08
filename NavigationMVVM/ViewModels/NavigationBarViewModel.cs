using NavigationMVVM.Commands;
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
    public class NavigationBarViewModel : ViewModelBase
    {        
        private RelayCommand? _homeCommand;
        public ICommand NavigateHomeCommand {
            get => _homeCommand ?? (this._homeCommand = new RelayCommand(this.OnNavigationHomeCommand));
        }
        private void OnNavigationHomeCommand(object obj)
        {
            _homeNavigationService.Navigate();
        }
        private RelayCommand? _accountCommand;
        public ICommand NavigateAccountCommand
        {
            get => _accountCommand ?? (this._accountCommand = new RelayCommand(this.OnNavigateAccountCommand));
        }
        private void OnNavigateAccountCommand(object obj)
        {
            _accountNavigationService.Navigate();
        }
        private RelayCommand? _loginCommand;
        public ICommand NavigateLoginCommand
        {
            get => _loginCommand ?? (this._loginCommand = new RelayCommand(this.OnNavigateLoginCommand));
        }
        private void OnNavigateLoginCommand(object obj)
        {
            _loginNavigationService.Navigate();
        }
        private RelayCommand? _peopleListCommand;
        public ICommand NavigatePeopleListingCommand
        {
            get => _peopleListCommand ?? (this._peopleListCommand = new RelayCommand(this.OnNavigatePeopleListingCommand));
        }
        private void OnNavigatePeopleListingCommand(object obj)
        {
            _peopleListingNavigationService.Navigate();
        }
        private RelayCommand? _logoutComand;
        public ICommand LogoutCommand
        {
            get => _loginCommand ?? (this._loginCommand = new RelayCommand(this.OnLogoutCommand));
        }
        private void OnLogoutCommand(object obj)
        {
            _accountStore.Logout();
        }
        public bool IsLoggedIn => _accountStore.IsLoggedIn;

        private readonly AccountStore _accountStore;
        private readonly INavigationService _homeNavigationService;
        private readonly INavigationService _accountNavigationService;
        private readonly INavigationService _loginNavigationService;
        private readonly INavigationService _peopleListingNavigationService;
        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService homeNavigationService,          
            INavigationService loginNavigationService
            )
        {
            _accountStore = accountStore;
            _homeNavigationService = homeNavigationService;
            _loginNavigationService = loginNavigationService;
            //_peopleListingNavigationService = peopleListingNavigationService;

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }
    }
}
