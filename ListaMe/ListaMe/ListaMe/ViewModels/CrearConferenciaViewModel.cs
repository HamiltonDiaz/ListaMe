using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ListaMe.View;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ListaMe.ViewModels
{
    public class CrearConferenciaViewModel
    {

        public string nombre { get; set; }
        HttpClient cliente = new HttpClient();

        RegistroModel Registro { get; set; }

        public CrearConferenciaViewModel()
        {
            this.Registro = new RegistroModel();
        }

        

        public ICommand CrearCommand
        {
            get
            {
                return new RelayCommand(Valida);
            }
        }

        
        private async void CrearConferencia()
        {
            
            var contenido = new StringContent(JsonConvert.SerializeObject(Registro), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PostAsync("http://localhost:4000/lmconferencias/crear", contenido);
            if (respuesta.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Correcto",
                    "Registrado Exitosamente",
                    "Aceptar"
                );
                await Application.Current.MainPage.Navigation.PushAsync(new ConferenciasPage());//Esto es para regresar al home
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error comuníquese con el administrador",
                    "Aceptar"
                );

            }

        }

        public async void Valida()
        {
            if (string.IsNullOrEmpty(this.nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese un nombre",
                        "Aceptar"
                    );
                this.nombre = string.Empty;
                return;
            }
            this.Registro.conferencia = this.nombre;
            CrearConferencia();
        }


    }
}
