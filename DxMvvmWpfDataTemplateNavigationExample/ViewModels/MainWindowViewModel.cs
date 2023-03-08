using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DxMvvmWpfDataTemplateNavigationExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() 
        {

        }

        //public virtual string ViewName { get; set; }
        //public ICommand<string> NavigateCommand { get; private set; }

        private string _viewName;
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value, "ViewName"); }
        }
        public virtual DataTemplate CurrentTemplate { get; set; }
        public SubView1ViewModel? SubViewModel1
        {
            get => (SubView1ViewModel)App.ServiceProvider.GetRequiredService(ViewModelSource.GetPOCOType(typeof(SubView1ViewModel)));
        }
        public SubView1ViewModel? SubViewModel2
        {
            get => (SubView1ViewModel)App.ServiceProvider.GetRequiredService(ViewModelSource.GetPOCOType(typeof(SubView2ViewModel)));
        }
        [Command]
        public void Navigate(string viewName)
        {
            ViewName = viewName;
        }


    }
}
