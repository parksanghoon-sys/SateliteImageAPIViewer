using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Models;
using SateliteImageAPIViewer.Services;
using SateliteImageAPIViewer.Services.DataBase;
using SateliteImageAPIViewer.Stores;
using SateliteImageAPIViewer.Views.Windows;

namespace SateliteImageAPIViewer.ViewModels
{
    [POCOViewModel]
    public class SateliteAPIResultViewModel :ViewModelBase
    {
        
        public virtual ObservableCollection<SatelliteData>? SateliteItems { get; set; }
        public virtual SatelliteData SelectedItem { get; set; }
        public SateliteAPIResultViewModel()
        {
            SateliteItems = new ObservableCollection<SatelliteData>();
            Messenger.Default.Register<ObservableCollection<SatelliteData>>(this, ReceiveData);
            
            //TestItemAdd();
        }

        private void ReceiveData(ObservableCollection<SatelliteData> obj)
        {
            SateliteItems = new ObservableCollection<SatelliteData>();
            SateliteItems = obj;
        }
        private void TestItemAdd()
        {
            SateliteItems.Add(new SatelliteData
            {
                NumberID = 1,
                FileCreateDate = DateTime.Now,
                FilePath = $@"E:\WPF_Project\VideoViewer\SateliteImageAPIViewer\bin\Debug\net6.0-windows\20230228\ir105_ko020lc_202302270000.jpg",
                SatelliteArea = "ea",
                SatelliteType = "ko",
                UserID = "test"
            });
        }
        public  virtual async Task onSave()
        {
            if (SateliteItems.Any() == false)
                return;

            using (var context = new SateliteDbContext())
            {
                var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();                

                var isSuecess = context.Database.EnsureCreated(); //데이터 베이스가 만들어져 있는지 확인
                                                  //[A] Arrange :1 번 데이터를 아래 항목으로 저장
                var repository = new SatelliteRepository(context);
                foreach(var item in SateliteItems)
                {
                    await repository.AddAsync(item);
                }               
            }
        }
        [Command]
        public virtual void onButtonLoad()
        {
            var dialogData = new SateliteDataStore();

            if (SelectedItem != null)
                dialogData.ImageFilePath = SelectedItem.FilePath;            

            Messenger.Default.Send(new DialogDataStore
            {
                DilaogType = enums.eDialog.ImageLode,
                ResponseData = dialogData
            });
        }
        [Command]
        public void onSearchLoad()
        {
            Messenger.Default.Send(new DialogDataStore
            {
                DilaogType = enums.eDialog.Search,                
            });
        }
        [Command]
        public void onSeltedDelete()
        {

        }

    }
}
