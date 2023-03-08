using DevExpress.Mvvm;

namespace DxMvvmWpfDataTemplateNavigationExample.ViewModels
{
    public class SubView1ViewModel : ViewModelBase
    {
        public SubView1ViewModel()
        {

        }

        private string _message = nameof(SubView1ViewModel);
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value, "Message"); }
        }

    }
}
