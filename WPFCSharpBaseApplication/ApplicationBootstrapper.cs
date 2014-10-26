using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using WPFCSharpBaseApplication.Services;

namespace WPFCSharpBaseApplication
{
    class ApplicationBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypes();
            SetupViewModelProvider();
        }

        private void RegisterTypes()
        {
            // TODO Register types here.
            RegisterTypeIfMissing(typeof(IService), typeof(Service), false);
        }

        private void SetupViewModelProvider()
        {
            // Use Service Locator to resolve ViewModels.
            // Within views, when prism:ViewModelLocator.AutoWireViewModel is set to true, 
            // prism will use our service locator to get the required view models.
            ViewModelLocationProvider.SetDefaultViewModelFactory((type) =>
            {
                return ServiceLocator.Current.GetInstance(type);
            });

            // Prism uses a convention to resolve Views and ViewModels. Views need to be in the 
            // Views namespace while ViewModels need to be in the ViewModels namespace.
            // To change that convention, use this method.
            //
            // With this change, Views and ViewModels should be placed next to each other.
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) => 
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);
                return Type.GetType(viewModelName);
            });
        }
    }
}
