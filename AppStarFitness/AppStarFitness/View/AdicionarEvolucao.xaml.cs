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
    public partial class AdicionarEvolucao : ContentPage
    {
        public AdicionarEvolucao()
        {
            InitializeComponent();
        }

        private void btn_salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                txt_torax.Text = string.Empty;
                txt_gluteo.Text = string.Empty;
                txt_cintura.Text = string.Empty;
                txt_braco_esquerdo.Text = string.Empty;
                txt_braco_direito.Text = string.Empty;
                txt_panturrilha_esquerda.Text = string.Empty;
                txt_panturrilha_direita.Text = string.Empty;
                txt_antebraco_esquerdo.Text = string.Empty;
                txt_antebraco_direito.Text = string.Empty;
                txt_quadriceps_esquerdo.Text = string.Empty;
                txt_quadriceps_esquerdo.Text = string.Empty;

                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }
    }
}