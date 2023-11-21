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
        int tempo_de_descanso;

        bool condicao = true;

        public ExercicioDetalhado()
		{
			InitializeComponent();

            lbl_timer_descanso.Text = tempo_de_descanso.ToString();
        }

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];
                // ID COLOCADO MANUALMENTE AFIM DE TESTES
                string id_exercicio = "ba8663d5-3cc4-4068-9cac-7153ee2db90e";

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
                    tempo_de_descanso = 11;
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