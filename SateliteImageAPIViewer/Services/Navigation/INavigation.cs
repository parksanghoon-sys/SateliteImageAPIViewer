using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SateliteImageAPIViewer.Services.Navigation
{
    public interface INavigation
    {
        void Navigate(Type viewModelType);
        void Navigate<TViewModel>() where TViewModel : ViewModelBase;
        void GoBack();
    }
}
