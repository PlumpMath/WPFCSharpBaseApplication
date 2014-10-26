using System.Windows;

namespace WPFCSharpBaseApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var applicationBootstrapper = new ApplicationBootstrapper();
            applicationBootstrapper.Run();
        }
    }
}
