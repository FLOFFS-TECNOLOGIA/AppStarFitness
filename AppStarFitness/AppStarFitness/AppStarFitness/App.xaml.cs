using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness
{
    public partial class App : Application
    {
        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            InitializeComponent();

            if (Properties.ContainsKey("usuario_logado"))
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new View.Login();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
