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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            logo.Source = ImageSource.FromResource("AppStarFitness.View.logo.png");
        }

        private void btn_entrar_Clicked(object sender, EventArgs e)
        {
            string cpf_digitado = usuario.Text;
            string senha_digitada = senha.Text;

            string cpf_cadastrado = "83239889862";
            string senha_cadastrada = "ribamar";
            
            if (cpf_digitado == cpf_cadastrado && senha_digitada == senha_cadastrada)
            {
                App.Current.Properties.Add("usuario_logado", cpf_digitado);
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                DisplayAlert("Erro", "Dados incorretos!", "OK");
            }
        }

        private void btn_esqueci_Clicked(object sender, EventArgs e)
        {

        }
    }
}