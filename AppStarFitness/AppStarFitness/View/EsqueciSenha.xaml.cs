using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EsqueciSenha : ContentPage
    {
        public EsqueciSenha()
        {
            InitializeComponent();
            logo.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btn_enviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                DisplayAlert("a", "a", "a");
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private void btn_voltar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new Login());              
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private void btn_voltarLogin_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new View.Login());
        }
    }
}