using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMVVM.Services
{
    public class CloseModalNavigationService : INavigationService
    {
        private readonly DialogStore _dialogStore;
        public CloseModalNavigationService(DialogStore dialogStore)
        {
            _dialogStore = dialogStore;
        }
        public void Navigate()
        {
            _dialogStore.Close();
        }
    }
}
