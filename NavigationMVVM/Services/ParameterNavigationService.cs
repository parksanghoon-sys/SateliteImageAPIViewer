using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Services
{
    public class ParameterNavigationService<TParmeter, TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TParmeter, TViewModel> _viewModelFactory;
        public ParameterNavigationService(NavigationStore navigationStore, Func<TParmeter, TViewModel> viewModelFactory)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
        }
        public void Navigate(TParmeter parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelFactory(parameter);
        }
    }
}
