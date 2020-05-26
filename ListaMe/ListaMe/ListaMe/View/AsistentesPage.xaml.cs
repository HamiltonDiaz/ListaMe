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
    public partial class AsistentesPage : ContentPage
    {
        AsistenteViewModel ViewModel;
        public AsistentesPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new AsistenteViewModel();
        }
    }
}