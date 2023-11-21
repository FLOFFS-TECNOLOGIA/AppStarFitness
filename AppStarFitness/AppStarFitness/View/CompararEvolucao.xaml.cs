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

            lbl_chest_atual.IsVisible = false;
            lbl_glute_atual.IsVisible = false;
            lbl_left_arm_atual.IsVisible = false;
            lbl_right_arm_atual.IsVisible = false;
            lbl_left_calf_atual.IsVisible = false;
            lbl_right_calf_atual.IsVisible = false;
            lbl_left_forearm_atual.IsVisible = false;
            lbl_right_forearm_atual.IsVisible = false;
            lbl_left_quadriceps_atual.IsVisible = false;
            lbl_right_quadriceps_atual.IsVisible = false;
        }

        protected override async void OnAppearing()
		{
			try
			{
				string token = (string)Application.Current.Properties["token"];

				Medidas m1 = await DataServiceAluno.PuxarMedidas(token, evolucao_selecionada1);

				lbl_chest1.Text = m1.chest;
				lbl_glute1.Text = m1.glute;
				lbl_left_arm1.Text = m1.left_arm;
				lbl_right_arm1.Text = m1.right_arm;
				lbl_left_calf1.Text = m1.left_calf;
				lbl_right_calf1.Text = m1.right_calf;
				lbl_left_forearm1.Text = m1.left_forearm;
				lbl_right_forearm1.Text = m1.right_forearm;
				lbl_left_quadriceps1.Text = m1.left_quadriceps;
				lbl_right_quadriceps1.Text = m1.right_quadriceps;

				if (evolucao_selecionada2 != null)
				{
					Medidas m2 = await DataServiceAluno.PuxarMedidas(token, evolucao_selecionada2);

					lbl_chest_antiga.Text = "Data 1: ";
                    lbl_glute_antiga.Text = "Data 1: ";
                    lbl_left_arm_antiga.Text = "Data 1: ";
                    lbl_right_arm_antiga.Text = "Data 1: ";
                    lbl_left_calf_antiga.Text = "Data 1: ";
                    lbl_right_calf_antiga.Text = "Data 1: ";
                    lbl_left_forearm_antiga.Text = "Data 1: ";
                    lbl_right_forearm_antiga.Text = "Data 1: ";
                    lbl_left_quadriceps_antiga.Text = "Data 1: ";
                    lbl_right_quadriceps_antiga.Text = "Data 1: ";

                    lbl_chest_atual.IsVisible = true;
                    lbl_glute_atual.IsVisible = true;
                    lbl_left_arm_atual.IsVisible = true;
                    lbl_right_arm_atual.IsVisible = true;
                    lbl_left_calf_atual.IsVisible = true;
                    lbl_right_calf_atual.IsVisible = true;
                    lbl_left_forearm_atual.IsVisible = true;
                    lbl_right_forearm_atual.IsVisible = true;
                    lbl_left_quadriceps_atual.IsVisible = true;
                    lbl_right_quadriceps_atual.IsVisible = true;

                    lbl_chest2.Text = m2.chest;
					lbl_glute2.Text = m2.glute;
					lbl_left_arm2.Text = m2.left_arm;
					lbl_right_arm2.Text = m2.right_arm;
					lbl_left_calf2.Text = m2.left_calf;
					lbl_right_calf2.Text = m2.right_calf;
					lbl_left_forearm2.Text = m2.left_forearm;
					lbl_right_forearm2.Text = m2.right_forearm;
					lbl_left_quadriceps2.Text = m2.left_quadriceps;
					lbl_right_quadriceps2.Text = m2.right_quadriceps;
				}
			}
			catch(Exception ex) 
			{
				await DisplayAlert(ex.Message, ex.StackTrace, "OK");
			}
        }
    }
}