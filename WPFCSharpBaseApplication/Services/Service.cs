using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCSharpBaseApplication.Services
{
    class Service : IService
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
