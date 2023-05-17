using AppStarFitness.DataService;
using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaDoUsuario : ContentPage
    {
        public AreaDoUsuario()
        {
            InitializeComponent();

            btnimg_fotoperfil.Source = ImageSource.FromResource("AppStarFitness.Imagens.default.jpg");
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            Aluno a = BindingContext as Aluno;

            lbl_nome.Text = a.nome.Split(' ')[0];
        }

        private void btnimg_fotoperfil_Clicked(object sender, EventArgs e)
        {
        }

        private void pck_ficha_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker disparador = sender as Picker;
        }

        private void pck_dieta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker disparador = sender as Picker;
        }

        private void pck_info_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker disparador = sender as Picker;
        }
    }
}