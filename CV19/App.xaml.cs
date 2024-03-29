﻿using CV19.Services.Interfaces.Registration;
using CV19.ViewModels.Registration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CV19
{
    public partial class App
    {
        public static bool IsDesignMode { get; private set; } = true;

        public static string CurrentDirectory => IsDesignMode 
            ? Path.GetDirectoryName(GetSourceCodePath()) 
            : Environment.CurrentDirectory;

        private static IHost _host;

        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment
            .GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            IHost host = Host;
            base.OnStartup(e);

            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            IHost host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, 
            IServiceCollection services) => services
            .RegisterServices()
            .RegisterViewModels();

        private static string GetSourceCodePath([CallerFilePath] string path = null) => path;
    }
}
