using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppStarFitness.View;
using AppStarFitness.Model;
using AppStarFitness.DataService;
using System.Collections.ObjectModel;

namespace AppStarFitness
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDietas : TabbedPage
    {
        ObservableCollection<DietasList> lista_dietas = new ObservableCollection<DietasList>();

        string string_selecionada;
        public MainPageDietas()
        {
            InitializeComponent();

            pck_dieta.ItemsSource = lista_dietas;
        }

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];
                string id_aluno = (string)Application.Current.Properties["id_aluno"];

                List<DietasList> arr_dietas = await DataServiceAluno.PuxarDietas(id_aluno, token);

                lista_dietas.Clear();

                arr_dietas.ForEach(i => lista_dietas.Add(i));
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void pck_dieta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                DietasList dieta_selecionada = disparador.SelectedItem as DietasList;

                /*if (dieta_selecionada != null)
                {
                    string_selecionada = treino_selecionado.id;
                }*/
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_dieta_Clicked(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_criar_dieta_Clicked(object sender, EventArgs e)
        {
            string token = (string)Application.Current.Properties["token"];
            string id_aluno = (string)Application.Current.Properties["id_aluno"];

            try
            {
                Dietas d = await DataServiceAluno.CriarDieta(new Dietas
                {
                    name = txt_nome.Text,
                    id_gym_member = id_aluno
                }, token);

                await Navigation.PushAsync(new AdicionarRefeicao());
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }
    }
}