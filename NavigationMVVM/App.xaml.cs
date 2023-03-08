using Microsoft.Extensions.DependencyInjection;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
            //IServiceCollection service = new ServiceCollection();

            //service.AddSingleton<PeopleStore>();
            //service.AddSingleton<NavigationStore>();
            //service.AddSingleton<DialogStore>();
            //service.AddSingleton<AccountStore>();

            //service.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            //service.AddTransient<HomeViewModel>();
            //service.AddTransient<NavigationBarViewModel>();
            //service.AddTransient<MainViewModel>();

            //service.AddSingleton<MainWindow>(s => new MainWindow()
            //{
            //    DataContext = s.GetRequiredService<MainViewModel>()
            //});
            //_serviceProvider = service.BuildServiceProvider();
            new Bootstrapper();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigateionService = Ioc.Get<INavigationService>();
            initialNavigateionService.Navigate();

            MainWindow = Ioc.GetService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }


    }
    public class Bootstrapper
    {
        private readonly IServiceProvider service;
        public Bootstrapper()
        {
            service = ConfigureServices();
            Ioc.Configure(service);
        }
        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<PeopleStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<DialogStore>();
            services.AddSingleton<AccountStore>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            
            services.AddTransient<HomeViewModel>(s => new HomeViewModel(CreateLoginNavigationService(s)));
            services.AddTransient<LoginViewModel>(CreateLoginViewModel);

            services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                s.GetRequiredService<AccountStore>(), 
                CreateHomeNavigationService(s)));

            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarModel);
            services.AddTransient<MainViewModel>();


            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            return services.BuildServiceProvider();
        }
        private INavigationService CreateHomeNavigationService(IServiceProvider s)
        {
            return new LayoutNavigationService<HomeViewModel>(
               service.GetRequiredService<NavigationStore>(),
               () => service.GetRequiredService<HomeViewModel>(),
               () => service.GetRequiredService<NavigationBarViewModel>());
        }
        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountViewModel>(
                    service.GetRequiredService<NavigationStore>(),
                () => service.GetRequiredService<AccountViewModel>(),
                () => service.GetRequiredService<NavigationBarViewModel>());
        }
        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new DialogService<LoginViewModel>(
                service.GetRequiredService<DialogStore>(),
                () => service.GetRequiredService<LoginViewModel>());
        }
        private LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService compositeNavigationService = new CompositeNavigationService(
                service.GetRequiredService<CloseModalNavigationService>(),
                CreateAccountNavigationService(serviceProvider));

            return new LoginViewModel(
                service.GetRequiredService<AccountStore>(),
                compositeNavigationService);
        }
        private NavigationBarViewModel CreateNavigationBarModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                service.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateLoginNavigationService(serviceProvider)
                );
        }
    }
    public static class Ioc
    {
        private static IServiceProvider _serviceProvider;
        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public static T Get<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
