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
    public partial class ListarConferenciasPage : ContentPage
    {
        ListarConferenciasViewModel ViewModel;
        public ListarConferenciasPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ListarConferenciasViewModel();
            ListaConfe.ItemSelected += ListaConfe_ItemSelected;
        }

        private void ListaConfe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem!=null)
            {
                var element = e.SelectedItem as RegistroModel;
                nomConfe.Text = element.conferencia;
            }
        }
    }
}