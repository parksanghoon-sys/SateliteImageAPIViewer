using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.ViewModels;

namespace SateliteImageAPIViewer.Services.Navigation
{
    public class NavigateionService :INavigation        
    {
        public NavigateionService() { }
        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void Navigate(Type viewModelType)
        {
            var context =  (ViewModelBase)App.ServiceProvider.GetRequiredService(ViewModelSource.GetPOCOType(viewModelType));
            var mainViewModel = (MainViewModel)App.ServiceProvider.GetService(ViewModelSource.GetPOCOType(typeof(MainViewModel)));
            mainViewModel.CurrentViewModel = context;
        }

        public void Navigate<TViewModel1>() where TViewModel1 : ViewModelBase
        {
            Navigate(typeof(TViewModel1));
        }
    }
}
