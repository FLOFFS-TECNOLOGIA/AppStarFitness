using AppStarFitness.DataService;
using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
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

            //logo_1.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
            //logo_2.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
            logo_3.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");

            string gordura = (string)Application.Current.Properties["gordura"];
            string massa_magra = (string)Application.Current.Properties["massa_magra"];
            string massa_gorda = (string)Application.Current.Properties["massa_gorda"];

            if(gordura != null)
                lbl_gordura.Text = gordura;

            if(massa_magra != null)
                lbl_massa_magra.Text = massa_magra;

            if(massa_gorda != null)
                lbl_massa_gorda.Text = massa_gorda;
        }

        protected override async void OnAppearing()
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

                lbl_altura.Text = p.gymMember.height_cm;
                lbl_peso.Text = p.gymMember.weight_kg.Replace('.', ',');

                string peso_sem_ponto = p.gymMember.weight_kg.Replace('.', ',');
                double peso = Convert.ToDouble(peso_sem_ponto);
                double altura_cm = Convert.ToDouble(p.gymMember.height_cm);

                // ==================== Cálculo IMC ==========================

                double altura_metros = altura_cm / 100;

                double imc = peso / (altura_metros * altura_metros);
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

                DateTime data_nasc = Convert.ToDateTime(p.birthday);
                TimeSpan diferenca = DateTime.Today - data_nasc;

                // CONFERIR EM CASO DE ANO BISSEXTO 
                double idade = diferenca.TotalDays / 365;
                idade = Math.Floor(idade);

                lbl_idade.Text = idade.ToString();

                // ==================== Cálculo TMB ==========================
                string sexo = p.gender;


                if (sexo == "M")
                {
                    double tmb = 88.362 + (13.397 * peso) + (4.799 * altura_cm) - (5.677 * idade);
                    lbl_tmb.Text = tmb.ToString();
                }
                else
                {
                    double tmb = 447.593 + (9.247 * peso) + (3.098 * altura_cm) - (4.330 - idade);
                    lbl_tmb.Text = tmb.ToString();
                }

                // ============================================================

                // invoice_date -> data que o aluno ingressou na academia
                // due_date -> data do vencimento
                // payment_date -> data que o aluno pagou a mensalidade (valor pode ser nulo) 

                Mensalidade mensalidade = await DataServiceAluno.MensalidadeAluno(u);

                TimeSpan diferenca_mensalidade = mensalidade.due_date - DateTime.Today;

                lbl_ingressou.Text = mensalidade.invoice_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
                lbl_data_vencimento.Text = mensalidade.due_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);

                if (DateTime.Now >= mensalidade.due_date)
                {
                    lbl_status.Text = "Em Aberto";
                    lbl_status.TextColor = Color.Green;
                }
                else
                {
                    lbl_status.Text = "Em atraso";
                    lbl_status.TextColor = Color.Red;
                }

                // ======================================= MEDIDAS ATUAIS ==========================================
                string token = (string)Application.Current.Properties["token"];
                string id_medida_atual = (string)Application.Current.Properties["id_medida_atual"];



                if (id_medida_atual != null)
                {
                    Medidas m = await DataServiceAluno.PuxarMedidas(token, id_medida_atual);

                    lbl_torax.Text = m.chest;
                    lbl_gluteo.Text = m.glute;
                    lbl_braco_esquerdo.Text = m.left_arm;
                    lbl_braco_direito.Text = m.right_arm;
                    lbl_panturrilha_esquerda.Text = m.left_calf;
                    lbl_panturrilha_direita.Text = m.right_calf;
                    lbl_antebraco_esquerdo.Text = m.left_forearm;
                    lbl_antebraco_direito.Text = m.right_forearm;
                    lbl_quadriceps_esquerdo.Text = m.left_quadriceps;
                    lbl_quadriceps_direito.Text = m.right_quadriceps;
                }
            }
            catch (Exception ex) 
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }
    }
}