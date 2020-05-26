using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

namespace ListaMe.ViewModels
{

    public class LoginViewModel
    {
        public string Usuario { get; set; }
        public string Contra { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public async void Login()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese el usuario",
                        "Aceptar"
                    );
                this.Usuario = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(this.Contra))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese la contraseña",
                        "Aceptar"
                    );
                this.Contra = string.Empty;
                return;
            }

        }

    }
}
