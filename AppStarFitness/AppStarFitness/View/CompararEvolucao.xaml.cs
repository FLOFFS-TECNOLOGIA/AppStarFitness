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
	public partial class CompararEvolucao : ContentPage
	{
		string evolucao_selecionada1;
		string evolucao_selecionada2;

		public CompararEvolucao (string evolucao1,string evolucao2)
		{
			InitializeComponent();

			evolucao_selecionada1 = evolucao1;
			evolucao_selecionada2 = evolucao2;
        }

        protected override async void OnAppearing()
		{
			string token = (string)Application.Current.Properties["token"];

            Medidas m1 = await DataServiceAluno.PuxarMedidas(token, evolucao_selecionada1);

			lbl_chest1.Text = m1.ToString();

            Medidas m2 = await DataServiceAluno.PuxarMedidas(token, evolucao_selecionada2);

			lbl_chest2.Text = m2.ToString();
        }
    }
}