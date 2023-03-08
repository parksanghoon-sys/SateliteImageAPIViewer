using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using SateliteImageAPIViewer.enums;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Models;
using SateliteImageAPIViewer.Services;
using Microsoft.Extensions.DependencyInjection;
using SateliteImageAPIViewer.Stores;

namespace SateliteImageAPIViewer.ViewModels
{
    //Test
    [POCOViewModel]
    public class SateliteAPISettingsViewModel : ViewModelBase
    {
        private readonly ISettingService _settingServices;
        
        public virtual bool IsSelected { get; set; }    
        public virtual eCameraType CameraType {
            get => _settingServices.SeteliteAPISetting.CameraType;
            set => _settingServices.SeteliteAPISetting.CameraType = value;
        }
        public virtual eCameraArea CameraArea {
            get => _settingServices.SeteliteAPISetting.CameraArea;
            set => _settingServices.SeteliteAPISetting.CameraArea = value;
        }
        public virtual DateTime YesterdayDateTIme { get; set; } 

        public SateliteAPISettingsViewModel(ISettingService settingservice)
        {
            _settingServices = settingservice;            

            CameraType = _settingServices.SeteliteAPISetting.CameraType;
            CameraArea = _settingServices.SeteliteAPISetting.CameraArea;
            YesterdayDateTIme = DateTime.ParseExact(_settingServices.SeteliteAPISetting.Datetime,"yyyyMMdd", CultureInfo.InvariantCulture);            
        }

        #region Requset Command  
        public virtual async void OnRequset()
        {
            Messenger.Default.Send(true);
            ObservableCollection<SatelliteData> SateliteDataList = new ObservableCollection<SatelliteData>();
            SateliteAPIService APIService = new SateliteAPIService(_settingServices);
            var data = await APIService.ResponseAPI();
            SateliteJSONParsingService jsonParsing = new SateliteJSONParsingService(data);
            var fileList = await jsonParsing.DownLoadIMage();
            foreach (var file in fileList)
            {

                SatelliteData model = new SatelliteData();
                model.FileCreateDate = DateTime.Now;
                model.FilePath = file;
                model.UserID = _settingServices.AccountStore.CurrentAccount.Id;
                model.SatelliteArea = _settingServices.SeteliteAPISetting.CameraArea.ToString();
                model.SatelliteType = _settingServices.SeteliteAPISetting.CameraType.ToString();
                SateliteDataList.Add(model);
            }

            //SateliteDataList.Add(new SatelliteData
            //{
            //    NumberID = 1,
            //    FileCreateDate = DateTime.Now,
            //    //FilePath = @"E:\WPF_Project\VideoViewer\SateliteImageAPIViewer\bin\Debug\net6.0-windows\20230118\sw038_ko020lc_202301170000.jpg",
            //    FilePath = @"F:\wpf\VideoViewer\SateliteImageAPIViewer\bin\Debug\net6.0-windows\20230113\ir105_ko020lc_202301120000.jpg",
            //    SatelliteArea = "test",
            //    SatelliteType = "Phone",
            //    UserID = "Park"
            //}); ;
            var resultViewModel = (SateliteAPIResultViewModel)App.ServiceProvider.GetRequiredService
                                (ViewModelSource.GetPOCOType(typeof(SateliteAPIResultViewModel)));
            var mainViewModel = (MainViewModel)App.ServiceProvider.GetRequiredService
                                (ViewModelSource.GetPOCOType(typeof(MainViewModel)));
            Messenger.Default.Send(SateliteDataList);
            Messenger.Default.Send(false);
        }
        public void OnTest()
        {
            var ImageLoadViewModel = (ImageLoadViewModel)App.ServiceProvider.GetRequiredService
                                (ViewModelSource.GetPOCOType(typeof(ImageLoadViewModel)));
            Messenger.Default.Send(ImageLoadViewModel,@"F:\wpf\VideoViewer\SateliteImageAPIViewer\bin\Debug\net6.0-windows\20230113\ir105_ko020lc_202301120000.jpg");
        }
        #endregion
    }
}
