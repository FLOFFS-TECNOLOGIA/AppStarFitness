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
	public partial class CompararEvolucao : ContentPage
	{
		public CompararEvolucao ()
		{
			InitializeComponent();

            string evolucao1 = (string)Application.Current.Properties["evolucao_selecionada1"];
            string evolucao2 = (string)Application.Current.Properties["evolucao_selecionada1"];

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("EVOLUCAO COMPARAR EVOLUCAO");
            Console.WriteLine(evolucao1);
            Console.WriteLine(evolucao2);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");
        }
    }
}