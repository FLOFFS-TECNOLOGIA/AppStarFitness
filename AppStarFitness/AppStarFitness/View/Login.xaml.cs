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
            logo.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
        }

        private void btn_entrar_Clicked(object sender, EventArgs e)
        {
            string[] cpf_pontuado = usuario.Text.Split('.', '-');
            string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];
            string senha_digitada = senha.Text;

            // CPF CADASTRADO NO BANCO
            string cpf_cadastrado = "12345678910";
            string senha_cadastrada = "teste";

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
            App.Current.MainPage = new NavigationPage(new View.EsqueciSenha());
        }
    }
}