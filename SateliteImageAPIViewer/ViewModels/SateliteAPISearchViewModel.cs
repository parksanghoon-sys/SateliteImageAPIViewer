using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.enums;
using SateliteImageAPIViewer.Services.DataBase;
using SateliteImageAPIViewer.Services.Navigation;
using SateliteImageAPIViewer.Stores;

namespace SateliteImageAPIViewer.ViewModels
{
    public class SateliteAPISearchViewModel : ViewModelBase
    {
        private readonly INavigation _navigation;
        public SateliteAPISearchViewModel(INavigation navigation)
        {
            _navigation = navigation;
            EndSearchDate = DateTime.Now;
            StartSearchDate = EndSearchDate.AddMonths(-1);
            CameraType = eCameraType.vi006;
            CameraArea = eCameraArea.ko;
        }
        public virtual eCameraType CameraType { get; set; }
        public virtual eCameraArea CameraArea { get; set; }
        public virtual List<eCameraType> CameraTypes => Enum.GetValues(typeof(eCameraType)).Cast<eCameraType>().ToList();
        public virtual List<eCameraArea> CameraAreas => Enum.GetValues(typeof(eCameraArea)).Cast<eCameraArea>().ToList();
        public string UserId
        {
            get { return GetValue<string>(nameof(UserId)); }
            set { SetValue(value, nameof(UserId)); }
        }
        //public virtual string UserId { get; set; }
        //public string CameraType
        //{
        //    get { return GetValue<string>(nameof(CameraType)); }
        //    set { SetValue(value, nameof(CameraType)); }
        //}
        //public string CameraArea
        //{
        //    get { return GetValue<string>(nameof(CameraArea)); }
        //    set { SetValue(value, nameof(CameraArea)); }
        //}
        public string FileName
        {
            get { return GetValue<string>(nameof(FileName)); }
            set { SetValue(value, nameof(FileName)); }
        }
        public string Test
        {
            get { return GetValue<string>(nameof(Test)); }
            set { SetValue(value, nameof(Test)); }
        }
        //public string Test2
        //{
        //    get { return GetValue<string>(nameof(Test2)); }
        //    set { SetValue(value, nameof(Test2)); }
        //}
        public DateTime StartSearchDate
        {
            get { return GetValue<DateTime>(nameof(StartSearchDate)); }
            set { SetValue(value, nameof(StartSearchDate)); }
        }
        //private string test2;
        //public string Test2
        //{
        //    get { return test2; }
        //    set { SetProperty(ref test2, value, nameof(test2)); }
        //}

        public virtual string Test2 { get; set; }
        //public virtual DateTime StartSearchDate { get; set; }
        public virtual DateTime EndSearchDate { get; set; }
        [Command]
        public async void OnSearch()
        {
            using (var context = new SateliteDbContext())
            {
                var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
                var factory = serviceProvider.GetService<ILoggerFactory>();

                var isSuecess = context.Database.EnsureCreated(); //데이터 베이스가 만들어져 있는지 확인
                                                                  //[A] Arrange :1 번 데이터를 아래 항목으로 저장
                var repository = new SatelliteRepository(context, factory);

                var result = await repository.GetSearchSatelliteData(UserId,CameraType.ToString(),CameraArea.ToString(), 
                    StartSearchDate , EndSearchDate, FileName);
                int data = 1;
            }
        }
        [Command]
        public void OnCancel()
        {
            Messenger.Default.Send(new DialogDataStore
            {
                DilaogType = enums.eDialog.None,
            });
        }
    }
}
