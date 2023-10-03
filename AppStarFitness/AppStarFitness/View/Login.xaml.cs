using AppStarFitness.DataService;
using AppStarFitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            logo.Source = ImageSource.FromResource("AppStarFitness.Imagens.logo.png");

            carregando.Color = Color.Blue;
        }

        private async void btn_login_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                string[] cpf_pontuado = usuario.Text.Split('.', '-');
                string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];
                string senha_digitada = senha.Text;

                // Codificando a senha digitada para SHA1 e comparando-a com a senha cadastrada em sha1 no banco para autenticação
                /*string senha_sha1;
                using (var sha1 = new SHA1Managed())
                {
                    senha_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(senha_digitada)));
                    senha_sha1 = string.Join("", senha_sha1.ToLower().Split('-'));
                }*/

                Pessoa p = await DataServicePessoa.AutenticarAluno(new Pessoa
                {
                    document = cpf_digitado,
                    password = senha_digitada
                });

                Console.WriteLine("================================");
                Console.WriteLine("TESTE");
                Console.WriteLine(p.name);
                Console.WriteLine("================================");


                if (p != null)
                {
                    Application.Current.Properties.Add("usuario_logado", cpf_digitado);
                    Application.Current.Properties.Add("usuario_senha", senha_digitada);
                    await Application.Current.SavePropertiesAsync();

                    Application.Current.MainPage = new NavigationPage(new MainPage()
                    {
                        BindingContext = p
                    });

                }
                else
                {
                    DisplayAlert("Erro", "Dados incorretos!", "OK");
                }

            } 
            catch (Exception err)
            {
                await DisplayAlert("Erro", err.Message, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
            }

        }

        private void btn_esqueci_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EsqueciSenha());
        }
    }
}