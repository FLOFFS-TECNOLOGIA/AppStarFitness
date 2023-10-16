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

            //btnimg_fotoperfil.Source = ImageSource.FromResource("AppStarFitness.Imagens.default.jpg");
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                string cpf_aluno = (string)Application.Current.Properties["usuario_logado"];
                string senha_aluno = (string)Application.Current.Properties["usuario_senha"];

                Pessoa p = await DataServicePessoa.AutenticarPessoa(new Pessoa
                {
                    document = cpf_aluno,
                    password = senha_aluno
                });

                lbl_nome.Text = p.name.Split(' ')[0];
                btnimg_fotoperfil.Source = p.photo_url;
            }
            catch(Exception err) 
            {
                await DisplayAlert("Erro", err.Message, "OK");
            }
        }

        private void btnimg_fotoperfil_Clicked(object sender, EventArgs e)
        {
           
        }

        private void btn_ficha_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPageTreino());
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