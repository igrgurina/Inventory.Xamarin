using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.ViewModels;
using Inventory.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Inventory
{
    public partial class App
    {
        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
            // Register Syncfusion license
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDk3NDIwQDMxMzkyZTMyMmUzMGUrSW9paEo0bkE2VTdrZW5aY1psWmM5Q0tEZDQ2NDJmOVRxQk1iY0lMV0U9");

            //InitializeComponent();

            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDk3NDIwQDMxMzkyZTMyMmUzMGUrSW9paEo0bkE2VTdrZW5aY1psWmM5Q0tEZDQ2NDJmOVRxQk1iY0lMV0U9");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
