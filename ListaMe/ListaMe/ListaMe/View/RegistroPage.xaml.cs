
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ListaMe.ViewModels;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaMe.View
{
    
    public partial class RegistroPage : ContentPage
    {
        RegistroViewModel ViewModel;
        public RegistroPage()
        {
            BindingContext = ViewModel= new RegistroViewModel();
            InitializeComponent();
        }

        private void Volver_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new HomePage());//Esto es para regresar al home
        }
    }
}