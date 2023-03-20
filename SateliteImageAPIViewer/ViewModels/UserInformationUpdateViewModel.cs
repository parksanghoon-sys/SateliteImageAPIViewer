using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SateliteImageAPIViewer.ViewModels
{
    public class UserInformationUpdateViewModel : ViewModelBase
    {
        private readonly ISettingService _settingService;
        public  string UserId 
        {
            get => GetProperty(() => UserId);
            set => SetProperty(() => UserId, value);
        }
        public UserInformationUpdateViewModel(ISettingService settingService)
        {
            _settingService = settingService;
            UserId = _settingService.AccountStore.CurrentAccount.Id;
            UserEmail = _settingService.AccountStore.CurrentAccount.Email;
            UserPhonNumber = _settingService.AccountStore.CurrentAccount.PhoneNumber;
        }
        public string UserPassword
        {
            get => GetProperty(() => UserPassword);
            set => SetProperty(() => UserPassword, value);
        }
        public string UserPhonNumber
        {
            get => GetProperty(() => UserPhonNumber);
            set => SetProperty(() => UserPhonNumber, value);
        }
        public string UserEmail
        {
            get => GetProperty(() => UserEmail);
            set => SetProperty(() => UserEmail, value);
        }
        [Command]
        public async Task<bool> onChangedUserInformationOk()
        {

            return true;
        }
    }
}
