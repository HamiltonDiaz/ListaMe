using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaMe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
            ListarConferencias();
        }

        private async void ListarConferencias()
        {
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetStringAsync("http://localhost:4000/lmconferencias/listar");
            var conferencias = JsonConvert.DeserializeObject<List<Conferencias>>(respuesta);
            //fk_conferencias.ItemsSource = conferencias;
            foreach (var conferencia in conferencias)
            {
                fk_conferencias.Items.Add(conferencia.cod_conferencia + " - " +  conferencia.conferencia);
            }

        }




    }
}