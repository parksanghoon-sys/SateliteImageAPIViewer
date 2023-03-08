using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Services
{
    public class DialogService<TViewModel> : INavigationService 
        where TViewModel : ViewModelBase
    {
        private readonly DialogStore _dialogStore;
        private readonly Func<TViewModel> _createViewModel;
        public DialogService(DialogStore dialogStor, Func<TViewModel> createViewModel)
        {
            _dialogStore = dialogStor;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _dialogStore.CurrentViewModel = _createViewModel();
        }    
    }
}
