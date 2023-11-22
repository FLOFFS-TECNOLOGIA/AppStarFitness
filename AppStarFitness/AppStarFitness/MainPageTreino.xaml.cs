using AppStarFitness.DataService;
using AppStarFitness.Model;
using AppStarFitness.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<FichaTreinoList> lista_fichas = new ObservableCollection<FichaTreinoList>();
        string nome_ficha;
        bool picker_item;
        string string_selecionada;
        public MainPageTreino()
        {
            InitializeComponent();

            pck_treino.ItemsSource = lista_fichas;
            picker_item = false;
        }

        protected override async void OnAppearing()
        {
            try
            {
                string token = (string)Application.Current.Properties["token"];
                string id_aluno = (string)Application.Current.Properties["id_aluno"];

                List<FichaTreinoList> arr_fichas = await DataServiceAluno.PuxarFichas(token, id_aluno);

                lista_fichas.Clear();

                arr_fichas.ForEach(i => lista_fichas.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void btn_nova_ficha_Clicked(object sender, EventArgs e)
        {

            string token = (string)Application.Current.Properties["token"];
            string id_aluno = (string)Application.Current.Properties["id_aluno"];

            try
            {
                FichaTreino f = await DataServiceAluno.NovaFicha(new FichaTreino
                {
                    name = txt_nome_ficha.Text,
                    id_gym_member = id_aluno
                }, token);

                string id_ficha = f.id;

                await Navigation.PushAsync(new OutroTreino(id_ficha, true, txt_nome_ficha.Text));
            }
            catch(Exception ex) 
            {
                await DisplayAlert(ex.Message, ex.StackTrace, "OK");
            }
        }

        private async void pck_treino_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                FichaTreinoList treino_selecionado = disparador.SelectedItem as FichaTreinoList;

                if (treino_selecionado != null)
                {
                    string_selecionada = treino_selecionado.id;
                    nome_ficha = treino_selecionado.name;
                    picker_item = true;
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private async void btn_abrir_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (picker_item == true)
                {
                    await Navigation.PushAsync(new OutroTreino(string_selecionada, false, nome_ficha));
                    picker_item = false;
                }
                else
                {
                    await DisplayAlert("Erro", "Seleciona um treino!", "OK");
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new MainPageInformacoes());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }
    }
}