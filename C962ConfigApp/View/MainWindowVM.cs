using C962ConfigApp.C962;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C962ConfigApp.View
{
    internal class MainWindowVM
    {
        public C962ConfigModel C962 { get; set; } = new C962ConfigModel();
    }
}
