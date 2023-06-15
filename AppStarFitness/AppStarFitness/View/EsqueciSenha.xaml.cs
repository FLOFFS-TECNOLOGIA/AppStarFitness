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
    public partial class EsqueciSenha : ContentPage
    {
        public EsqueciSenha()
        {
            InitializeComponent();
            logo.Source = ImageSource.FromResource("AppStarFitness.View.logo.png");
        }

        private void btn_enviar_Clicked(object sender, EventArgs e)
        {

        }
    }
}