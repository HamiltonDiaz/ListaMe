using ListaMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaMe.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewModels ViewModel;
        public HomePage()
        {
            BindingContext = ViewModel = new HomeViewModels();
            InitializeComponent();

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroPage());
        }

        private void btnConferencias_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConferenciasPage());
        }
    }
}