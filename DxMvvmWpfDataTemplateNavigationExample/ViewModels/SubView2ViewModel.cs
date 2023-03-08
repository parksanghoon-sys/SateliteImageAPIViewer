using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxMvvmWpfDataTemplateNavigationExample.ViewModels
{
    public class SubView2ViewModel : ViewModelBase
    {
        public SubView2ViewModel()
        {

        }

        private string _message = nameof(SubView2ViewModel);
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value, "Message"); }
        }

    }

}
