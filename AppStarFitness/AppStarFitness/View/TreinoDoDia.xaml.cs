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
	public partial class TreinoDoDia : ContentPage
	{
		string id_ficha;
		string dia_da_semana;
		public TreinoDoDia (string dia, string id_treino)
		{
			InitializeComponent ();
			dia_da_semana = dia;
			id_ficha = id_treino;
		}

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];

                List<AssocTreinoList> arr_assoc = await DataServiceAluno.PuxarAssocFichaExercicio(dia_da_semana, id_ficha, token); 
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

			Navigation.PushAsync(new ExercicioDetalhado());
        }
    }
}