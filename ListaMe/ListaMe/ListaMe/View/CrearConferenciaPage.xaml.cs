using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ListaMe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaMe.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearConferenciaPage : ContentPage
    {
        CrearConferenciaViewModel ViewModel;
        public CrearConferenciaPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new CrearConferenciaViewModel();
        }

        private void Volver_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ConferenciasPage());//Esto es para regresar al home
        }
    }
}