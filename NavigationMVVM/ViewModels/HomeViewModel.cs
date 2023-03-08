using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my App";
        //public ICommand NavigateLoginCommand { get; }

        private RelayCommand _closeCommand;
        public ICommand NavigateLoginCommand
        {
            get => _closeCommand ?? (this._closeCommand = new RelayCommand(this.NavigateCommand));
        }

        private void NavigateCommand(object obj)
        {
            _navigationService.Navigate();
        }

        private readonly INavigationService _navigationService;
        public HomeViewModel(INavigationService loginNavigationService)
        {
            _navigationService = loginNavigationService;
        }
    }
}
