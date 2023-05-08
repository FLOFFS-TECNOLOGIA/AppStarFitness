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
    public partial class AreaDoUsuario : ContentPage
    {
        public AreaDoUsuario()
        {
            InitializeComponent();

            foto_perfil.Source = ImageSource.FromResource("AppStarFitness.Imagens.default.jpg");
        }
    }
}