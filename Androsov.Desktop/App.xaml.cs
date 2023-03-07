using Androsov.Desktop.Commands;
using Androsov.Desktop.Store;
using Androsov.Desktop.ViewModels;
using Androsov.Services.API;
using Androsov.Services.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Androsov.Desktop
{
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((ctx, services) =>
                {
                    services.ConfigureAPI(BasicApiClientAuthentication.FromAppSettings, ServiceLifetime.Singleton);

                    services.AddSingleton<ApiViewViewModel>();
                    services.AddSingleton<DesktopTextViewModel>();
                    services.AddSingleton<WebTextViewModel>();

                    services.AddSingleton<DesktopTextStore>();

                    services.AddSingleton<SetDesktopTextCommand>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<ApiViewViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();

            MainWindow window = host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.StopAsync();
            host.Dispose();

            base.OnExit(e);
        }
    }
}
