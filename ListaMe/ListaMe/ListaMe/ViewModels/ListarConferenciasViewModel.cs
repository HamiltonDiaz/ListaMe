using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ListaMe.View;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ListaMe.ViewModels
{
    public class ListarConferenciasViewModel : BaseViewModels
    {
        HttpClient cliente = new HttpClient();
        private ObservableCollection<RegistroModel> conferencia;
        public ObservableCollection<RegistroModel> Conferencia
        {
            get { return this.conferencia; }
            set { this.SetValue(ref this.conferencia, value); }
        }

        public int idConfe=0;
        
        public RegistroModel Confe { get; set; }

        //Esto es para tomar el valor picker
        private RegistroModel _selectedRegistro { get; set; }
        public RegistroModel SelectedRegistro
        {
            get { return _selectedRegistro; }
            set
            {
                if (_selectedRegistro != value)
                {
                    _selectedRegistro = value;
                    idConfe = _selectedRegistro.id_conferencia;
                    //this.Conferencia[idConfe-1] = _selectedRegistro.conferencia;
                }
            }
        }


        public ListarConferenciasViewModel()
        {
            this.Confe = new RegistroModel();
            ListarConferencias();
        }
        
        private async void ListarConferencias()
        {
            
            var respuesta = await cliente.GetStringAsync("http://localhost:4000/lmconferencias/listar");
            var conferencias = JsonConvert.DeserializeObject<List<RegistroModel>>(respuesta);
            this.Conferencia = new ObservableCollection<RegistroModel>(conferencias);
        }

        public ICommand ModificarCommand
        {
            get
            {
                return new RelayCommand(Editar);
            }
        }

        public ICommand EliminarCommand
        {
            get
            {
                return new RelayCommand(Eliminar);
            }
        }

        private async void Editar()
        {
            
            var contenido = new StringContent(JsonConvert.SerializeObject(Confe), Encoding.UTF8, "application/json");
            var respuesta = await cliente.PutAsync($"http://localhost:4000/lmconferencias/editar/{idConfe}", contenido);
            if (respuesta.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Correcto",
                    "Actualizado Exitosamente",
                    "Aceptar"
                );
                await Application.Current.MainPage.Navigation.PushAsync(new ListarConferenciasPage());
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

        private async void Eliminar()
        {

           var confirmacion= await Application.Current.MainPage.DisplayAlert(
           "Confirmación",
           "¿Está seguro de eliminar la conferencia?",
           "Si",
           "No");

            if (confirmacion)
            {
                var respuesta = await cliente.DeleteAsync($"http://localhost:4000/lmconferencias/eliminar/{idConfe}");
                if (respuesta.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Conferencia Elminada",
                        "Aceptar"
                    );
                    await Application.Current.MainPage.Navigation.PushAsync(new ListarConferenciasPage());
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
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ListarConferenciasPage());
            }

            
        }

      
    }
}
