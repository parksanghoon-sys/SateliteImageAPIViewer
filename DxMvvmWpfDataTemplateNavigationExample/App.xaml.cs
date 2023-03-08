using DevExpress.Mvvm;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm.POCO;
using DxMvvmWpfDataTemplateNavigationExample.ViewModels;
using DxMvvmWpfDataTemplateNavigationExample.Views;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DxMvvmWpfDataTemplateNavigationExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }
        public App()
        {
            Messenger.Default = new Messenger(isMultiThreadSafe: true, actionReferenceType: ActionReferenceType.WeakReference);

            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //IHostEnvironment env = hostingContext.HostingEnvironment;
                    //config.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    //config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, service) =>
                {
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(SubView1ViewModel)));
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(SubView2ViewModel)));                    
                    service.AddTransient(ViewModelSource.GetPOCOType(typeof(MainWindowViewModel)));
                    service.AddTransient<SubView1>();
                    service.AddTransient<SubView2>();                    
                    service.AddTransient<MainWindow>();
                })
                .Build();

            ServiceProvider = host.Services;
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            base.OnStartup(e);

            var mainWindowViewModel = (MainWindowViewModel)App.ServiceProvider.GetRequiredService
                (ViewModelSource.GetPOCOType(typeof(MainWindowViewModel)));

            var mainview = new MainWindow();
            mainview.DataContext = mainWindowViewModel;
            mainview.ShowDialog();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
