using AppStarFitness.DataService;
using AppStarFitness.Model;
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
    public partial class AdicionarEvolucao : ContentPage
    {
        public AdicionarEvolucao()
        {
            InitializeComponent();

            txt_torax.Text = string.Empty;
            txt_gluteo.Text = string.Empty;
            txt_cintura.Text = string.Empty;
            txt_braco_esquerdo.Text = string.Empty;
            txt_braco_direito.Text = string.Empty;
            txt_panturrilha_esquerda.Text = string.Empty;
            txt_panturrilha_direita.Text = string.Empty;
            txt_antebraco_esquerdo.Text = string.Empty;
            txt_antebraco_direito.Text = string.Empty;
            txt_quadriceps_esquerdo.Text = string.Empty;
            txt_quadriceps_esquerdo.Text = string.Empty;
        }

        /*protected override async void OnAppearing()
        {
            try
            {
                string cpf_aluno = (string)Application.Current.Properties["usuario_logado"];
                string senha_aluno = (string)Application.Current.Properties["usuario_senha"];

                Usuario u = await DataServicePessoa.AutenticarPessoa(new Pessoa
                {
                    document = cpf_aluno,
                    password = senha_aluno
                });

                Pessoa p = u.user;

                string id_aluno = p.gymMember.id;

                EvolucaoAluno e = await DataServiceAluno.NovaEvolucao(new EvolucaoAluno
                {
                    complete_date = DateTime.Today,
                    id_gym_member = id_aluno,
                    
                }, new Usuario
                {
                    token = u.token
                });
            }
            catch (Exception ex) 
            {
                DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }*/

        private async void btn_salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string cpf_aluno = (string)Application.Current.Properties["usuario_logado"];
                string senha_aluno = (string)Application.Current.Properties["usuario_senha"];

                Usuario u = await DataServicePessoa.AutenticarPessoa(new Pessoa
                {
                    document = cpf_aluno,
                    password = senha_aluno
                });

                Pessoa p = u.user;

                string id_aluno = p.gymMember.id;

                EvolucaoAluno ev = await DataServiceAluno.NovaEvolucao(new EvolucaoAluno
                {
                    complete_date = DateTime.Today,
                    id_gym_member = id_aluno,

                }, new Usuario
                {
                    token = u.token
                });

                string id_evolucao = ev.id;

                Medidas m = await DataServiceAluno.MedidasAluno(new Medidas
                {
                    chest = txt_torax.Text,
                    glute = txt_gluteo.Text,
                    left_arm = txt_braco_esquerdo.Text,
                    right_arm = txt_braco_direito.Text,
                    left_calf = txt_panturrilha_esquerda.Text,
                    right_calf = txt_panturrilha_direita.Text,
                    left_forearm = txt_antebraco_esquerdo.Text,
                    right_forearm = txt_antebraco_direito.Text,
                    left_quadriceps = txt_quadriceps_esquerdo.Text,
                    right_quadriceps = txt_quadriceps_direito.Text,
                    id_evolution = id_evolucao

                }, new Usuario
                {
                    token = u.token
                });

                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }
    }
}