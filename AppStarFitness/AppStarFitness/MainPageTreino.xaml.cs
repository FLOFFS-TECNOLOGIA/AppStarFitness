using AppStarFitness.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageTreino : TabbedPage
    {
        public MainPageTreino()
        {
            InitializeComponent();
        }

        private void btn_abrir1_Clicked(object sender, EventArgs e)
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

        private void btn_abrir2_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new OutroTreino());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_segunda_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch(Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_terca_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_quarta_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_quinta_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_sexta_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_sabado_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_domingo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new TreinoDoDia());
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private void pck_treino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}