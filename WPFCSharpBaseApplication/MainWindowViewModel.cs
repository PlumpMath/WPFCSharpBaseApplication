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
        private IService Service { get; set; }

        public MainWindowViewModel(IService service)
        {
            this.Service = service;    
        }
    }
}
