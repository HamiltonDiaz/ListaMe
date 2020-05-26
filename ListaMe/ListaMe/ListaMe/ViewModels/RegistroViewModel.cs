using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ListaMe.View;
using Newtonsoft.Json;
using Xamarin.Forms;



namespace ListaMe.ViewModels
{
    public class RegistroViewModel : BaseViewModels
    {
        #region Atributos

        
        private ObservableCollection<RegistroModel> conferencia;
        public ObservableCollection<RegistroModel> Conferencia
        {
            get { return this.conferencia; }
            set { this.SetValue(ref this.conferencia, value); }
        }

        
        public RegistroModel Confe{ get; set; }
        public Listados Listarme { get; set; }

        //Esto es para tomar el valor picker
        private RegistroModel _selectedRegistro { get; set; }
        public RegistroModel SelectedRegistro
        {
            get { return _selectedRegistro; }
            set
            {
                if (_selectedRegistro!= value)
                {
                    _selectedRegistro = value;

                    Listarme.conferencia = _selectedRegistro.conferencia;
                }
            }
        }
        //fin valor picker

        HttpClient cliente = new HttpClient();


        #endregion

        #region propiedades
        private async void ListarConferencias()
        {
            var respuesta = await cliente.GetStringAsync("http://localhost:4000/lmconferencias/listar");
            var conferencias = JsonConvert.DeserializeObject<List<RegistroModel>>(respuesta);            
            this.Conferencia= new ObservableCollection<RegistroModel>(conferencias);
        }

        private async void AgregarParticipante()
        {
            var contenido= new StringContent(JsonConvert.SerializeObject(Listarme),Encoding.UTF8,"application/json");
            var respuesta = await cliente.PostAsync("http://localhost:4000/lmlistas/crear", contenido);
            if (respuesta.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Correcto",
                    "Registrado Exitosamente",
                    "Aceptar"
                );
                await Application.Current.MainPage.Navigation.PushAsync(new HomePage());//Esto es para regresar al home
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
        
      

        #endregion

        #region contructor
        public RegistroViewModel()
        {
            ListarConferencias();
            this.Confe = new RegistroModel();
            this.Listarme = new Listados();
        }
        #endregion


        #region comandos
        public ICommand RegistroCommand
        {
            get
            {
                return new RelayCommand(Registro);
            }
        }


        public async void Registro()
        {


            if (string.IsNullOrEmpty(Listarme.conferencia))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Selecione una conferencia",
                        "Aceptar"
                    );
                this.Listarme.conferencia = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(this.Listarme.num_doc))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese el número de documento",
                        "Aceptar"
                    );
                this.Listarme.num_doc = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(this.Listarme.nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su nombre",
                        "Aceptar"
                    );
                this.Listarme.nombre = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(this.Listarme.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su email",
                        "Aceptar"
                    );
                this.Listarme.email = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(this.Listarme.telefono))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese un telefono",
                        "Aceptar"
                    );
                this.Listarme.telefono = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(this.Listarme.empresa))
            {
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese empresa",
                        "Aceptar"
                    );
                this.Listarme.empresa = string.Empty;
                return;
            }

            //si cumpel todas las condiciones entonces registar
            AgregarParticipante();
        }

        #endregion



    }
}

