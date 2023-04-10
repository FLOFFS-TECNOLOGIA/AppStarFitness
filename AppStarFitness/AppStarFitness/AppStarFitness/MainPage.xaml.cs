using AppStarFitness.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppStarFitness
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(AreaDoUsuario)));

            logo.Source = ImageSource.FromResource("AppStarFitness.View.logo.png");
        }
    }
}
