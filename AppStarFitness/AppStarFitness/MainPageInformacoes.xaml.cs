using System;
using System.Collections.Generic;
using System.Linq;
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
            // ==================== Cálculo IMC ==========================
            double peso = double.Parse(txt_peso.Text);
            double altura = double.Parse(txt_altura.Text);

            altura = altura / 100;

            double imc = peso / (altura * altura);

            txt_imc.Text = imc.ToString();
        }
    }
}