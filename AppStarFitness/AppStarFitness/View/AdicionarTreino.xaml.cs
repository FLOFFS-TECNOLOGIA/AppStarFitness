using AppStarFitness.DataService;
using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarTreino : ContentPage
    {
        ObservableCollection<ExerciciosList> lista_exercicios = new ObservableCollection<ExerciciosList>();
        ObservableCollection<string> lista_assoc = new ObservableCollection<string>();
        string dia_da_semana;
        string id_exercicio;
        string id_ficha;

        public AdicionarTreino(string dia, string id_treino)
        {
            InitializeComponent();
            pck_treino.ItemsSource = lista_exercicios;

            lbl_aviso.IsVisible = false;

            dia_da_semana = dia;
            id_ficha=  id_treino;
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

                if (exercicio_selecionado.id != null)
                {
                    id_exercicio = exercicio_selecionado.id;
                    lbl_nome_exercicio.Text = exercicio_selecionado.name;
                    img_gif.Source = exercicio_selecionado.exercise_gif;
                    img_maquina.Source = exercicio_selecionado.equipment_gym_photo;
                    lbl_grupo_muscular.Text = exercicio_selecionado.muscle_groups;
                }
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
                string token = (string)Application.Current.Properties["token"];
                string observacao;

                if (txt_obs.Text != null)
                {
                    observacao = txt_obs.Text;
                }
                else
                {
                    observacao = null;
                }

                string descanso = txt_descanso.Text;
                string[] array = descanso.Split(':');

                string tempo_em_seg = String.Concat(array[0], array[1]);

                Console.WriteLine("===========================");
                Console.WriteLine(tempo_em_seg);
                Console.WriteLine("===========================");

                FichaExercicioAssoc assoc = await DataServiceAluno.CriarAssocFichaExercicio(new FichaExercicioAssoc
                {
                    id_workout_routine = id_ficha,
                    id_exercise = id_exercicio,
                    week_day = dia_da_semana,
                    sets = txt_series.Text,
                    repetitions = txt_reps.Text,
                    rest_seconds = tempo_em_seg,
                    observation = observacao
                }, token);

                lbl_aviso.IsVisible = true;

                txt_series.Text = string.Empty;
                txt_reps.Text = string.Empty;
                txt_descanso.Text = string.Empty;
                txt_obs.Text = string.Empty;
            }
            catch(Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

    }
}