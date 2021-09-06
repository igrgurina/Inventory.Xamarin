using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Inventory
{
    public partial class App : Application
    {
        public App()
        {
            // Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDk3NDIwQDMxMzkyZTMyMmUzMGUrSW9paEo0bkE2VTdrZW5aY1psWmM5Q0tEZDQ2NDJmOVRxQk1iY0lMV0U9");

            InitializeComponent();

            MainPage = new Inventory.MainPage();
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
    }
}
