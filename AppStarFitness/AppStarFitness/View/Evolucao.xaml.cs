using AppStarFitness.DataService;
using AppStarFitness.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Evolucao : ContentPage
	{
        ObservableCollection<EvolucaoAlunoList> lista_evolucoes = new ObservableCollection<EvolucaoAlunoList>();

        string string_selecionada;
        string string_selecionada1;
        string string_selecionada2;
        public Evolucao ()
		{
			InitializeComponent ();
            pck_data.ItemsSource = lista_evolucoes;
            pck_data1.ItemsSource = lista_evolucoes;
            pck_data2.ItemsSource = lista_evolucoes;
        }

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];

                List<EvolucaoAlunoList> arr_evolucoes = await DataServiceAluno.PuxarEvolucoes(new Usuario
                {
                    token = token
                });

                lista_evolucoes.Clear();

                arr_evolucoes.ForEach(i => lista_evolucoes.Add(i));
            }
            catch (Exception ex) 
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private void btn_add_evolucao_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new AdicionarEvolucao());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void pck_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                EvolucaoAlunoList evolucao_selecionada = disparador.SelectedItem as EvolucaoAlunoList;

                if (evolucao_selecionada != null)
                {
                    string_selecionada = evolucao_selecionada.id;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_abrir_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new CompararEvolucao(string_selecionada, null));
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void pck_data1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                EvolucaoAlunoList evolucao_selecionada1 = disparador.SelectedItem as EvolucaoAlunoList;

                if (evolucao_selecionada1 != null)
                {
                    string_selecionada1 = evolucao_selecionada1.id;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void pck_data2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                EvolucaoAlunoList evolucao_selecionada2 = disparador.SelectedItem as EvolucaoAlunoList;

                if (evolucao_selecionada2 != null)
                {
                    string_selecionada2 = evolucao_selecionada2.id;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_comparar_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new CompararEvolucao(string_selecionada1,string_selecionada2));
            }
            catch (Exception err)
            {
               await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }
    }
}