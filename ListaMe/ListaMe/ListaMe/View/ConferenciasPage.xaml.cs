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
    public partial class ConferenciasPage : ContentPage
    {
        ConferenciasViewModel ViewModel;
        public ConferenciasPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ConferenciasViewModel();
        }

        private void btnCrear_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CrearConferenciaPage());
        }

        private void btnConferencias_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListarConferenciasPage());
        }


        private void btnAsistentes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

    }
}