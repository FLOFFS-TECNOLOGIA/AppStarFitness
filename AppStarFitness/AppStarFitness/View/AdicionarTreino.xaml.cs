using AppStarFitness.DataService;
using AppStarFitness.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarTreino : ContentPage
    {
        ObservableCollection<ExerciciosList> lista_exercicios = new ObservableCollection<ExerciciosList>();

        string dia_da_semana;

        public AdicionarTreino(string dia)
        {
            InitializeComponent();
            pck_treino.ItemsSource = lista_exercicios;

            lbl_aviso.IsVisible = false;

            dia_da_semana = dia;
        }

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];

                List<ExerciciosList> arr_exercicios = await DataServiceAluno.PuxarExercicios(token);

                lista_exercicios.Clear();

                arr_exercicios.ForEach(i => lista_exercicios.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void pck_treino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_aviso.IsVisible = false;

                Picker disparador = sender as Picker;

                ExerciciosList exercicio_selecionado = disparador.SelectedItem as ExerciciosList;

                lbl_nome_exercicio.Text = exercicio_selecionado.name;
                img_gif.Source = exercicio_selecionado.exercise_gif;
                img_maquina.Source = exercicio_selecionado.equipment_gym_photo;
                lbl_grupo_muscular.Text = exercicio_selecionado.muscle_groups;
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Esperando a rota de associacao de fichas e treinos

                lbl_aviso.IsVisible = true;
            }
            catch(Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }
    }
}