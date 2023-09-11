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
        public  AreaDoUsuario()
        {
            InitializeComponent();

            btnimg_fotoperfil.Source = ImageSource.FromResource("AppStarFitness.Imagens.default.jpg");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string cpf_aluno = (string)Application.Current.Properties["usuario_logado"];
            string senha_aluno = (string)Application.Current.Properties["usuario_senha"];

            Aluno a = await DataServiceAluno.AutenticarAluno(new Aluno
            {
                cpf = cpf_aluno,
                senha = senha_aluno
            });

            lbl_nome.Text = a.nome.Split(' ')[0];
        }

        private void btnimg_fotoperfil_Clicked(object sender, EventArgs e)
        {
            // AGUARDANDO FINALIZAÇÃO DA API
        }

        private void btn_ficha_Clicked(object sender, EventArgs e)
        {

        }


        private void bnt_dieta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPageDietas());
        }

        private void btn_informacoes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPageInformacoes());
        }

        private void btn_evolucao_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Evolucao());
        }
    }
}