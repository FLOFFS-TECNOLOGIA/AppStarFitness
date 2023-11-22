using AppStarFitness.DataService;
using AppStarFitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercicioDetalhado : ContentPage
	{
        double descanso_seg;
        double tempo_de_descanso;
        string id_exercicio;
        bool condicao = true;

        public ExercicioDetalhado(string exercicio, string descanso)
		{
			InitializeComponent();
            tempo_de_descanso = 0;

            id_exercicio = exercicio;
            string[] array = descanso.Split(':');
            string tempo_em_seg = array[1].Remove(0, 1) + array[2];
            descanso_seg = Convert.ToDouble(tempo_em_seg);
            descanso_seg = (descanso_seg / 100) * 60;
            tempo_de_descanso = descanso_seg;

            lbl_timer_descanso.Text = tempo_de_descanso.ToString();
        }

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];

                Exercicios e = await DataServiceAluno.ExercicioById(id_exercicio, token);

                lbl_nome.Text = e.name;
                img_gif.Source = e.exercise_gif;
                img_maquina.Source = e.equipment_gym_photo;
                lbl_grupo_muscular.Text = e.muscle_groups;
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private void btn_timer_Clicked(object sender, EventArgs e)
        {
            condicao = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if(tempo_de_descanso == 0)
                {
                    Parar();
                    tempo_de_descanso = descanso_seg;
                }

                if (condicao == true)
                {
                    tempo_de_descanso -= 1;

                    lbl_timer_descanso.Text = tempo_de_descanso.ToString();

                    return true;
                }
                else
                {
                    return false;
                }
            });

            btn_timer.IsEnabled = false;
        }

        void Parar()
        {
            condicao = false;
            btn_timer.IsEnabled = true;
        }

        private void btn_parar_Clicked(object sender, EventArgs e)
        {
            Parar();
        }
    }
}