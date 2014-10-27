using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCSharpBaseApplication.Services;

namespace WPFCSharpBaseApplication
{
    class MainWindowViewModel : BindableBase
    {
        private IService Service { get; set; }

        private String _boundText;
        public String BoundText
        {
            get { return _boundText; }
            set 
            {
                // Use this inherited method to set properties. It triggers OnPropertyChanged 
                // of INotifyPropertyChanged.
                SetProperty<String>(ref _boundText, value, "BoundText");
                
                // This should write out to the console everything being typed in the bound textbox.
                Service.Send(_boundText);

                // Conditions of the command's CanExecute method have changed, test it again.
                BoundCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand<String> BoundCommand { get; private set; }
        
        public MainWindowViewModel(IService service)
        {
            this.Service = service;

            // Commands may have parameters. Specified with the CommandParameter attribute.
            this.BoundCommand = new DelegateCommand<String>(this.Execute, this.CanExecute);
        }

        private void Execute(String button)
        {
            Service.Send(String.Format("Executed Command on {0} with text {1}", button, BoundText));
        }

        private bool CanExecute(String button)
        {
            return !String.IsNullOrEmpty(BoundText);
        }
    }
}
