using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.ViewModels
{
    public class MainViewModel :ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly DialogStore _modalNavigationStore;
        //private bool _isOpen;
        //public bool IsOpen
        //{
        //    get { return _isOpen; }
        //    set { 
        //        _isOpen = value;
        //        OnPropertyChanged();
        //    }
        //}        
        //public ViewModelBase CurrentModalViewModel => Ioc.GetService<LoginViewModel>();
        //public ViewModelBase CurrentViewModel =>Ioc.Get<LayoutViewModel>();

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsOpen => _modalNavigationStore.IsOpen;

        public MainViewModel(NavigationStore navigateionStroe, DialogStore dialogStore)
        {
            _navigationStore = navigateionStroe;
            _modalNavigationStore = dialogStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentDialogViewModelChanged;
        }

        private void OnCurrentDialogViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsOpen));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
