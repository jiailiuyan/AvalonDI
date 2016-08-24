﻿using Ayx.AvalonDI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfSample.Infrastructure;
using WpfSample.Repository;
using WpfSample.ViewModels;
using WpfSample.Views;

namespace WpfSample
{
    public partial class App : Application
    {
        //DI container
        public static AvalonContainer VM;
        public static AyxContainer Container;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InitDependency();
            //show start window
            VM.GetView<MainWindow>().Show();
        }

        private void InitDependency()
        {
            //dependency
            Container = new AyxContainer();
            Container.Wire<ITestDataRepo, TestDataRepo>();
            Container.WireSingleton<ILogger, SimpleLogger>();
            VM = new AvalonContainer(new DefaultContainer(Container));

            //view and viewmodel
            VM.WireVM<MainWindow, MainWindowViewModel>();
            VM.WireVM<TestOneView, TestOneViewModel>();
        }
    }
}
