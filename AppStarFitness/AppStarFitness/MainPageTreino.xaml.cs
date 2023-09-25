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

        private void pck_dia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btn_abrir1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Treino());
        }

        private void pck_treino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_abrir2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Treino());
        }
    }
}