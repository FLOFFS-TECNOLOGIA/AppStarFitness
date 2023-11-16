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
	public partial class OutroTreino : ContentPage
	{
        string treino;
        bool criar_ficha;
		public OutroTreino (string treino_selecionado, bool criar_nova_ficha)
		{
			InitializeComponent ();

            treino = treino_selecionado;
            criar_ficha = criar_nova_ficha;
		}

        protected override async void OnAppearing()
        {
            try
            {
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_segunda_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (criar_ficha == false)
                {
                    await Navigation.PushAsync(new TreinoDoDia());
                }
                else
                {
                    string dia = "Segunda";
                    //await Navigation.PushAsync(new AdicionarTreino(dia));
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_terca_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (criar_ficha == false)
                {
                    await Navigation.PushAsync(new TreinoDoDia());
                }
                else
                {
                    string dia = "Terça";
                    //await Navigation.PushAsync(new AdicionarTreino(dia));
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_quarta_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (criar_ficha == false)
                {
                    await Navigation.PushAsync(new TreinoDoDia());
                }
                else
                {
                    string dia = "Quarta";
                    //await Navigation.PushAsync(new AdicionarTreino(dia));
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_quinta_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (criar_ficha == false)
                {
                    await Navigation.PushAsync(new TreinoDoDia());
                }
                else
                {
                    string dia = "Quinta";
                    //await Navigation.PushAsync(new AdicionarTreino(dia));
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_sexta_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (criar_ficha == false)
                {
                    await Navigation.PushAsync(new TreinoDoDia());
                }
                else
                {
                    string dia = "Sexta";
                    //await Navigation.PushAsync(new AdicionarTreino(dia));
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_sabado_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (criar_ficha == false)
                {
                    await Navigation.PushAsync(new TreinoDoDia());
                }
                else
                {
                    string dia = "Sábado";
                    //await Navigation.PushAsync(new AdicionarTreino(dia));
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_domingo_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (criar_ficha == false)
                {
                    await Navigation.PushAsync(new TreinoDoDia());
                }
                else
                {
                    string dia = "Domingo";
                    //await Navigation.PushAsync(new AdicionarTreino(dia));
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }
    }
}