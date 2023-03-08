using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MultiWindowTest.ViewModels;
using MultiWindowTest.Views;

namespace MultiWindowTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            //Ioc.Default.ConfigureServices(Services);
            
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IView, WindowToOpen>();
            services.AddTransient<WindowToOpenViewModel>();
            services.AddTransient<MainWindowViewModel>();
            return services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainViewModel = Services.GetService<MainWindowViewModel>();
                //Ioc.Default.GetService<MainWindowViewModel>();
            var MainView = new MainWindow();
            MainView.DataContext = mainViewModel;
            MainView.ShowDialog();
        }
    }
}
