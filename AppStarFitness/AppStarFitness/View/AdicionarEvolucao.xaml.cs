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
           
        }*/

        private async void btn_salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txt_torax.Text != null && txt_gluteo.Text != null && txt_braco_esquerdo.Text != null && txt_braco_direito.Text != null
                    && txt_panturrilha_esquerda.Text != null && txt_panturrilha_direita.Text != null && txt_antebraco_esquerdo.Text != null
                    && txt_antebraco_direito.Text != null && txt_quadriceps_esquerdo.Text != null && txt_quadriceps_direito.Text != null)
                {
                    string token = (string)Application.Current.Properties["token"];
                    string id_aluno = (string)Application.Current.Properties["id_aluno"];

                    string dia_hoje = DateTime.Today.ToString("yyyy-MM-dd");

                    EvolucaoAluno ev = await DataServiceAluno.NovaEvolucao(new EvolucaoAluno
                    {
                        complete_date = dia_hoje,
                        id_gym_member = id_aluno,

                    }, new Usuario
                    {
                        token = token
                    });

                    string id_evolucao = ev.id;

                    Application.Current.Properties.Add("id_medida_atual", id_evolucao);

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
                        token = token
                    });

                    Application.Current.Properties.Add("gordura", txt_gordura.Text);
                    Application.Current.Properties.Add("massa_magra", txt_massa_magra.Text);
                    Application.Current.Properties.Add("massa_gorda", txt_massa_gorda.Text);

                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }
    }
}