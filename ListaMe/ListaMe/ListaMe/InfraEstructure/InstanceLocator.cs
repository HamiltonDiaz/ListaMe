using ListaMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaMe.InfraEstructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
