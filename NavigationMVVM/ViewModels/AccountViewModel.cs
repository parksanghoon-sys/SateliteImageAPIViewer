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
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;
        public string? UserName => _accountStore.CurrentAccount?.UsrName;
        public string? Email => _accountStore.CurrentAccount?.Email;
        private RelayCommand _homeCommand;
        public ICommand NavigateHomeCommand
        {
            get => _homeCommand?? (_homeCommand = new RelayCommand(OnNavigateHome));
        }

        private void OnNavigateHome(object obj)
        {
            _navigationService.Navigate();
        }
        public AccountViewModel(AccountStore accountStore, INavigationService homeNavigationService)
        {
            _navigationService = homeNavigationService;
            _accountStore = accountStore;            
            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }
        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(UserName));
        }
        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
