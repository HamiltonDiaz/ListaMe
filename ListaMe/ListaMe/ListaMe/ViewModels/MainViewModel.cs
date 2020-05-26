using System;
using System.Collections.Generic;
using System.Text;

namespace ListaMe.ViewModels
{
    public class MainViewModel
    {
        //Se manejan todas las vistas - la parte lógica
        //Se crea una clase por cada vidsta y esta clase las reune
        public LoginViewModel Login { get; set; }
        public RegistroViewModel Registro { get; set; }
        public HomeViewModels Home { get; set; }
        public MainViewModel()
        {
            this.Home = new HomeViewModels();
            this.Registro = new RegistroViewModel();
            this.Login = new LoginViewModel();
        }
    }
}
