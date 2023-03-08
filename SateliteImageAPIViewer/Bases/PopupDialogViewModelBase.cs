using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SateliteImageAPIViewer.Base
{
    public class PopupDialogViewModelBase : ViewModelBase
    {
        //private ViewModelBase? _popupVM;
        //public ViewModelBase? PopupVM
        //{
        //    get { return GetProperty(() => _popupVM); }
        //    set { SetProperty(() => _popupVM, value); }
        //}
        public virtual ViewModelBase? PopupVM { get; set; }
        //private DelegateCommand? _closeCommand;
        [Command]
        public virtual void Close()
        {
            PopupVM = null;
            this.Cleanup();
        }
        //{
        //    get
        //    {
        //        return _closeCommand ??
        //            (_closeCommand = new DelegateCommand(
        //                () =>
        //                {

        //                }));
        //    }
        //}
        public virtual void Cleanup()
        {
            Messenger.Default.Unregister(this);
        }
    }
}
