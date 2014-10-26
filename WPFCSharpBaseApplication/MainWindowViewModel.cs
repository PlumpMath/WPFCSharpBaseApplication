using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCSharpBaseApplication.Services;

namespace WPFCSharpBaseApplication
{
    class MainWindowViewModel : BindableBase
    {
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
            }
        }

        private IService Service { get; set; }

        public MainWindowViewModel(IService service)
        {
            this.Service = service;    
        }
    }
}
