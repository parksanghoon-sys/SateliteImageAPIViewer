using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Helpers;
using SateliteImageAPIViewer.Models;
using SateliteImageAPIViewer.Services.DataBase;
using SateliteImageAPIViewer.Services.Navigation;

namespace SateliteImageAPIViewer.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        public virtual string? UserId {  get; set; }
        public virtual string? UserPassword { get; set; }
        public virtual string? UserEmail { get; set; }
        public virtual string? UserPhoneNumber { get; set; }
        private readonly INavigation _navigation;
        public SignUpViewModel(INavigation navigation) 
        {
            _navigation = navigation;
        }

        [Command]
        public virtual async Task onSignUpOk()
        {
            using (var context = new UserDataDbContext())
            {
                var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
                var logFactory = serviceProvider.GetService<ILoggerFactory>();
                var isSuecess = context.Database.EnsureCreated();
                var repository = new UserRepository(context,logFactory);
                var encrypedPassword = new PasswordEncryptionHelper(UserPassword).GetSHAEncryptedPassword();
                var userData = new UserData
                {
                    Id = UserId,
                    Password = encrypedPassword,
                    Email = UserEmail,
                    PhoneNumber = UserPhoneNumber,
                    JoinDatetime = DateTime.Now
                };
                var result = await repository.AddAsync(userData);
                if(result.Id != null)
                {
                    _navigation.Navigate<LoginViewModel>();
                }
            }
        }

        [Command]
        public virtual void onSignUpCancel()
        {
            _navigation.Navigate<HomeViewModel>();
        }
    }
}
