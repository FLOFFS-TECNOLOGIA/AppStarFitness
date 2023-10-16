using AppStarFitness.DataService;
using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageInformacoes : TabbedPage
	{
		public MainPageInformacoes ()
		{
			InitializeComponent();

            logo_1.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
            //logo_2.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
            logo_3.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
        }

        protected override async void OnAppearing()
        {
            string cpf_aluno = (string)Application.Current.Properties["usuario_logado"];
            string senha_aluno = (string)Application.Current.Properties["usuario_senha"];

            Pessoa p = await DataServicePessoa.AutenticarPessoa(new Pessoa
            {
                document = cpf_aluno,
                password = senha_aluno
            });

            lbl_altura.Text = p.gymMember.height_cm;
            lbl_peso.Text = p.gymMember.weight_kg;

            double peso = Convert.ToDouble(p.gymMember.weight_kg);
            double altura = Convert.ToDouble(p.gymMember.height_cm);

            // ==================== Cálculo IMC ==========================
            double imc = peso / ((altura/100) * (altura/100));
            imc = Math.Round(imc, 1);

            lbl_imc.Text = imc.ToString();

            if (imc <= 18.5)
            {
                lbl_classificacao_imc.Text = " / Abaixo do peso";
            }
            else if (imc >= 18.6 && imc <= 24.9)
            {
                lbl_classificacao_imc.Text = " / Peso ideal";
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                lbl_classificacao_imc.Text = " / Acima do peso";
            }
            else if (imc >= 30 && imc <= 34.9)
            {
                lbl_classificacao_imc.Text = " / Obesidade I";
            }
            else if (imc >= 35 && imc <= 39.9)
            {
                lbl_classificacao_imc.Text = " / Obesidade II";
            }
            else
            {
                lbl_classificacao_imc.Text = " / Obesidade III (mórbida)";
            }

            // ==================== Cálculo Idade ==========================
            string sexo = p.gender;

            DateTime data_nasc = Convert.ToDateTime(p.birthday);
            TimeSpan diferenca = DateTime.Now - data_nasc;

            // CONFERIR EM CASO DE ANO BISSEXTO 
            double idade = diferenca.TotalDays / 365;
            idade = Math.Floor(idade);

            lbl_idade.Text = idade.ToString();

            // ==================== Cálculo TMB ==========================
            if (sexo == "M")
            {
                double tmb = 88.362 + (13.397 * peso) + (4.779 * altura) - (5.677 * idade);
                lbl_tmb.Text = tmb.ToString();
            }
            else
            {
                double tmb = 447.593 + (9.247 * peso) + (3.098 * altura) - (4.330 - idade);
                lbl_tmb.Text = tmb.ToString();
            }

            // ============================================================

            string id_aluno = p.gymMember.id.ToString();

            /*Aluno a = await DataServiceAluno.MedidasAluno(new Aluno
            {
                id = id_aluno
            });*/
        }

        private void btn_editar_Clicked(object sender, EventArgs e)
        {
            btn_salvar.IsEnabled = true;
            btn_editar.IsEnabled = false;

            txt_torax.IsEnabled = true;
            txt_gluteo.IsEnabled = true;
            txt_cintura.IsEnabled = true;
            txt_braco_esquerdo.IsEnabled = true;
            txt_braco_direito.IsEnabled = true;
            txt_panturrilha_esquerda.IsEnabled = true;
            txt_panturrilha_direita.IsEnabled = true;
            txt_antebraco_esquerdo.IsEnabled = true;
            txt_antebraco_direito.IsEnabled = true;
            txt_quadriceps_esquerdo.IsEnabled = true;
            txt_quadriceps_direito.IsEnabled = true;
        }

        private void btn_salvar_Clicked(object sender, EventArgs e)
        {
            // ---
            btn_editar.IsEnabled = true;
            btn_salvar.IsEnabled = false;

            txt_torax.IsEnabled = false;
            txt_gluteo.IsEnabled = false;
            txt_cintura.IsEnabled = false;
            txt_braco_esquerdo.IsEnabled = false;
            txt_braco_direito.IsEnabled = false;
            txt_panturrilha_esquerda.IsEnabled = false;
            txt_panturrilha_direita.IsEnabled = false;
            txt_antebraco_esquerdo.IsEnabled = false;
            txt_antebraco_direito.IsEnabled = false;
            txt_quadriceps_esquerdo.IsEnabled = false;
            txt_quadriceps_direito.IsEnabled = false;
        }
    }
}