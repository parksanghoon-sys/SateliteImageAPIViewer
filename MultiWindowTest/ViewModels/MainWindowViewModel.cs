using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using MultiWindowTest.Bases;
using MultiWindowTest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiWindowTest.ViewModels
{  
    public class MainWindowViewModel : ViewModelBase
    {
        public virtual string Title { get; set; }
        //private string? _title = "Prisim";   
        //public string Title
        //{
        //    get { return _title = "Prisim"; }
        //    set { SetProperty(ref _title, value); }
        //}
        [Command]
        public virtual void ShowWindow()
        {
            var popupVM = App.Current.Services.GetService<WindowToOpenViewModel>();
            Messenger.Default.Send("Test is messanger");
            (_view as WindowToOpen).DataContext = popupVM;
            _view.Open();
            
        }
        private readonly IView _view;
        public MainWindowViewModel(IView view)
        {
            this._view = view;
            //ShowWindow = new RelayCommand(ExcuteMethod, CanExcuteMoethod);
        }

        //private bool CanExcuteMoethod(object obj)
        //{
        //    return true;
        //}

        //private void ExcuteMethod(object obj)
        //{
        //    _view.Open();
        //}
        //#region MyCommand Command

        ///// <summary>
        ///// myCommand
        ///// </summary>

        ///// <summary>
        ///// Get MyCommand
        ///// </summary>
        //public ICommand ShowWindow { get; set; }    
        //#endregion

    }
}
