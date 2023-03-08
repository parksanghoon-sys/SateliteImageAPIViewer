using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Stores;

namespace SateliteImageAPIViewer.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ISettingService _settingService;
        public virtual string UserId { get; set; }
        public HomeViewModel(ISettingService settingService)
        {
            this._settingService = settingService;
            if(_settingService.AccountStore.CurrentAccount is not null)
                UserId = _settingService.AccountStore.CurrentAccount.Id;
        }
    }
}
