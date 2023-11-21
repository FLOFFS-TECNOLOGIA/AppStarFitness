using AppStarFitness.DataService;
using AppStarFitness.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TreinoDoDia : ContentPage
	{
        ObservableCollection<AssocTreinoList> lista_assoc = new ObservableCollection<AssocTreinoList>();
        string id_exercicio;
        string descanso;
        string id_ficha;
		string dia_da_semana;

		public TreinoDoDia (string dia, string id_treino)
		{
			InitializeComponent ();
			dia_da_semana = dia;
			id_ficha = id_treino;

            lst_assoc.ItemsSource = lista_assoc;
            lst_assoc.SelectionMode = ListViewSelectionMode.Single;
            lst_assoc.ItemSelected += OnItemSelected;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem != null)
                {
                    AssocTreinoList itemSelecionado = (AssocTreinoList)e.SelectedItem;

                    id_exercicio = itemSelecionado.id_exercise;
                    descanso = itemSelecionado.rest_seconds;

                    Console.WriteLine("=============================================================================");
                    Console.WriteLine(" ");
                    Console.WriteLine("TESTE DOS DADOS");
                    Console.WriteLine(id_exercicio);
                    Console.WriteLine(descanso);
                    Console.WriteLine(" ");
                    Console.WriteLine("=============================================================================");

                    lst_assoc.SeparatorColor = Color.Green;
                    
                    ((ListView)sender).SelectedItem = null;
                    lst_assoc.SeparatorColor = Color.Transparent;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];

                List<AssocTreinoList> arr_assoc = await DataServiceAluno.PuxarAssocFichaExercicio(dia_da_semana, id_ficha, token);

                lista_assoc.Clear();

                arr_assoc.ForEach(i => lista_assoc.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("=============================================================================");
                Console.WriteLine(" ");
                Console.WriteLine("TESTE DOS DADOS - BOTAO");
                Console.WriteLine(id_exercicio);
                Console.WriteLine(descanso);
                Console.WriteLine(" ");
                Console.WriteLine("=============================================================================");

                await Navigation.PushAsync(new ExercicioDetalhado(id_exercicio, descanso));
            }
            catch(Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }
    }
}