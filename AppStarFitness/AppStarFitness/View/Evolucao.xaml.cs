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
	public partial class Evolucao : ContentPage
	{
		public Evolucao ()
		{
			InitializeComponent ();
		}

        private void btn_add_evolucao_Clicked(object sender, EventArgs e)
        {

        }

        private void pck_data_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_abrir_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_comparar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompararEvolucao());
        }
    }
}