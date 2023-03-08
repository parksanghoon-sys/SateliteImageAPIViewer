using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Helpers;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Services.DataBase;
using SateliteImageAPIViewer.Services.Navigation;
using SateliteImageAPIViewer.Stores;

namespace SateliteImageAPIViewer.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public virtual string UserPassword { get; set; }
        public virtual string UserId { get; set; }
        private readonly ISettingService _settingService;
        private readonly INavigation _navigation;
        public LoginViewModel(ISettingService accountStore, INavigation navigation) 
        {
            _settingService = accountStore;
            _navigation = navigation;
        }
        [Command]
        public void onSignUp()
        {            
            Messenger.Default.Send(new DialogDataStore
            {
                DilaogType = enums.eDialog.SingnUp,                
            });
        }
        [Command]
        public async Task onSigIn()
        {
            using (var context = new UserDataDbContext())
            {
                var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
                var logFactory = serviceProvider.GetService<ILoggerFactory>();
                var isSuecess = context.Database.EnsureCreated();
                var repository = new UserRepository(context, logFactory);
                var checedCncrypedPassword = new PasswordEncryptionHelper(UserPassword).GetSHAEncryptedPassword();

                var user = await repository.GetByIdAsync(UserId);
                if (user == null)
                    return;
                if(string.Compare(user.Password, checedCncrypedPassword, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Console.WriteLine("로그인 성공");
                    _settingService.AccountStore.CurrentAccount = user;
                    _navigation.Navigate<HomeViewModel>();
                }
                else
                {
                    Console.WriteLine("로그인 실패");
                }

            }
        }
    }
}
