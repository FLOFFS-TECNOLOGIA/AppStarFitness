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
            logo_2.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
            logo_3.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
			
        }

        protected override async void OnAppearing()
        {


            /*Aluno a = BindingContext as Aluno;

            Console.WriteLine("=======================");
            Console.WriteLine(a);
            Console.WriteLine("=======================");*/

            string cpf_aluno = (string)Application.Current.Properties["usuario_logado"];
            string senha_aluno = (string)Application.Current.Properties["usuario_senha"];

            /*Pessoa p = await DataServicePessoa.AutenticarAluno(new Pessoa
            {
                document = cpf_aluno,
                password = senha_aluno
            });

            lbl_altura.Text = p.altura_cm;
            lbl_peso.Text = p.peso_kg;


            double peso = Convert.ToDouble(p.peso_kg);
            double altura = Convert.ToDouble(p.altura_cm);

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
            string sexo = p.sexo;

            DateTime data_nasc = Convert.ToDateTime(a.data_nascimento);
            TimeSpan diferenca = DateTime.Now - data_nasc;

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
            }*/

        }
    }
}