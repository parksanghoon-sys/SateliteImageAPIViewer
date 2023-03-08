using System;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SateliteImageAPIViewer.ViewModels;
using SateliteImageAPIViewer.Interfaces;
using SateliteImageAPIViewer.Services;
using DevExpress.Mvvm;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using SateliteImageAPIViewer.enums;
using SateliteImageAPIViewer.Views.Windows;
using SateliteImageAPIViewer.Services.Navigation;
using SateliteImageAPIViewer.Stores;

namespace SateliteImageAPIViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        private readonly IHost host;
        
        public App()
        {
            
            Messenger.Default = new Messenger(isMultiThreadSafe: true, actionReferenceType: ActionReferenceType.WeakReference);
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(ShellViewModel)));
                    
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(SateliteAPISettingsViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(SateliteAPIResultViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(ImageLoadViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(LoginViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(SignUpViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(MenuBarViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(SateliteSearchViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(HomeViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(SateliteAPISearchViewModel)));

                    service.AddSingleton(ViewModelSource.GetPOCOType(typeof(MainViewModel)));
                    service.AddSingleton<ISettingService, SettingService>(obj => new SettingService());
                    //service.AddSingleton<Interfaces.IDialogService, DialogService>(obj => new DialogService());
                    service.AddSingleton<INavigation, NavigateionService>(obj => new NavigateionService());
                    //service.AddSingleton<AccountStore>();
                })
                .Build();
            
            
            ServiceProvider = host.Services;
            
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            base.OnStartup(e);

            //var dialogService = (DialogService)App.ServiceProvider.GetRequiredService
            //                    (typeof(Interfaces.IDialogService));
            //dialogService.Register(enums.EDialogHostType.BasicType, typeof(Views.Windows.Dialog));

            var shellViewModel = (ShellViewModel)App.ServiceProvider.GetRequiredService
                                (ViewModelSource.GetPOCOType(typeof(ShellViewModel)));
            shellViewModel.CurrentDataContext = (MainViewModel)App.ServiceProvider.GetRequiredService(ViewModelSource.GetPOCOType(typeof(MainViewModel)));
            var shellWindow = new WPFMainShell();
            shellWindow.DataContext = shellViewModel;
            shellWindow.ShowDialog();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
        //private static IServiceProvider ConfigureServices()
        //{
        //    var services = new ServiceCollection();
        //    services.AddTransient(typeof(MainViewModel));
        //    services.AddTransient(typeof(SateliteAPISettingsViewModel));

        //    services.AddSingleton<IDataBase, MssqlDatabase>(obj => new MssqlDatabase());
        //    services.AddSingleton<ISettingService, SettingService>(obj => new SettingService());

        //    return services.BuildServiceProvider();
        //}
    }
}
