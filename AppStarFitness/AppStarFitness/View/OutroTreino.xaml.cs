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
		public OutroTreino ()
		{
			InitializeComponent ();
		}

        private async void btn_segunda_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async  void btn_terca_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_quarta_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_quinta_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_sexta_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_sabado_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_domingo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }
    }
}