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
        string nome_dieta;

        public MainPageDietas()
        {
            InitializeComponent();

            pck_dieta.ItemsSource = lista_dietas;

            lbl_pao.IsVisible = false;
            lbl_cafe.IsVisible = false;
            lbl_arroz.IsVisible = false;
            lbl_arroz2.IsVisible = false;
            lbl_feijao.IsVisible = false;
            lbl_feijao2.IsVisible = false;
            lbl_frango.IsVisible = false;
            lbl_frango2.IsVisible = false;
            lbl_maca.IsVisible = false;
            lbl_banana.IsVisible = false;
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

                if (dieta_selecionada != null)
                {
                    nome_dieta = dieta_selecionada.name;
                }
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
                lbl_dietaNome.Text = nome_dieta;

                lbl_pao.IsVisible = true;
                lbl_cafe.IsVisible = true;
                lbl_arroz.IsVisible = true;
                lbl_arroz2.IsVisible = true;
                lbl_feijao.IsVisible = true;
                lbl_feijao2.IsVisible = true;
                lbl_frango.IsVisible = true;
                lbl_frango2.IsVisible = true;
                lbl_maca.IsVisible = true;
                lbl_banana.IsVisible = true;

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