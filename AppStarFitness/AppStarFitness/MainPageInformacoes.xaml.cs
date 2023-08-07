using AppStarFitness.DataService;
using AppStarFitness.Model;
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
			InitializeComponent ();

            logo.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");
			
        }

        protected override void OnAppearing()
        {
            Aluno a = BindingContext as Aluno;

            double peso = Convert.ToDouble(a.peso_kg);
            double altura = Convert.ToDouble(a.altura_cm);

            // ==================== Cálculo IMC ==========================
            double imc = peso / ((altura/100) * (altura/100));
            imc = Math.Round(imc, 1);

            txt_imc.Text = imc.ToString();

            if (imc <= 18.5)
            {
                txt_classificacao_imc.Text = " / Abaixo do peso";
            }
            else if (imc >= 18.6 && imc <= 24.9)
            {
                txt_classificacao_imc.Text = " / Peso ideal";
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                txt_classificacao_imc.Text = " / Acima do peso";
            }
            else if (imc >= 30 && imc <= 34.9)
            {
                txt_classificacao_imc.Text = " / Obesidade I";
            }
            else if (imc >= 35 && imc <= 39.9)
            {
                txt_classificacao_imc.Text = " / Obesidade II";
            }
            else
            {
                txt_classificacao_imc.Text = " / Obesidade III (mórbida)";
            }

            // ==================== Cálculo Idade ==========================
            string sexo = a.sexo;

            DateTime data_nasc = Convert.ToDateTime(a.data_nascimento);
            TimeSpan diferenca = DateTime.Now - data_nasc;

            double idade = diferenca.TotalDays / 365;
            idade = Math.Floor(idade);

            txt_idade.Text = idade.ToString();

            // ==================== Cálculo TMB ==========================
            if (sexo == "M")
            {
                double tmb = 88.362 + (13.397 * peso) + (4.779 * altura) - (5.677 * idade);
                txt_tmb.Text = tmb.ToString();
            }
            else
            {
                double tmb = 447.593 + (9.247 * peso) + (3.098 * altura) - (4.330 - idade);
                txt_tmb.Text = tmb.ToString();
            }

        }
    }
}