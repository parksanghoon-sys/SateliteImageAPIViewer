using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Services
{
    internal class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigateionStore;
        private readonly Func<TViewModel> _viewModelFactory;
        public NavigationService(NavigationStore navigateionStore, Func<TViewModel> viewModelFactory)
        {
            _navigateionStore = navigateionStore;
            _viewModelFactory = viewModelFactory;
        }
    
        public void Navigate()
        {
            _navigateionStore.CurrentViewModel = _viewModelFactory();
        }
    }
}
