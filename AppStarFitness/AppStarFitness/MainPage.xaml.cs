using AppStarFitness.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppStarFitness
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(AreaDoUsuario)));

            NavigationPage.SetHasNavigationBar(this, false);

            logo.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");

        }

        private async void btn_logout_Clicked(object sender, EventArgs e)
        {
            bool confirmar = await DisplayAlert("Sair", "Tem certeza que quer sair?", "Sim", "Não");

            if (confirmar)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }
        }

        private void btn_inicio_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}
