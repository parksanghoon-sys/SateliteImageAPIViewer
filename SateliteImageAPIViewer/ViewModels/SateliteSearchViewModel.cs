using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;

namespace SateliteImageAPIViewer.ViewModels
{
    [POCOViewModel]
    public class SateliteSearchViewModel : ViewModelBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value, nameof(IsBusy)); }
        }
        public virtual SateliteAPISettingsViewModel SateliteSearch
        {
            get => (SateliteAPISettingsViewModel)App.ServiceProvider.GetRequiredService(ViewModelSource.GetPOCOType(typeof(SateliteAPISettingsViewModel)));
        }
        public virtual SateliteAPIResultViewModel SateliteResultView
        {
            get => (SateliteAPIResultViewModel)App.ServiceProvider.GetRequiredService(ViewModelSource.GetPOCOType(typeof(SateliteAPIResultViewModel)));
        }
        public virtual SignUpViewModel SignUpViewModel
        {
            get => (SignUpViewModel)App.ServiceProvider.GetRequiredService(ViewModelSource.GetPOCOType(typeof(SignUpViewModel)));
        }
        //public bool IsBusy { get; set; } = false;
        public SateliteSearchViewModel()
        {
            //string FilePath = @"E:\WPF_Project\VideoViewer\SateliteImageAPIViewer\bin\Debug\net6.0-windows\20230118\sw038_ko020lc_202301170000.jpg";
            //Mat image = Cv2.ImRead(FilePath, ImreadModes.Color);

            Messenger.Default.Register<bool>(this, onSetBusy);
            //IsBusy = false;
        }
        private void onSetBusy(bool obj)
        {
            IsBusy = obj;
        }
    }
}
