using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppStarFitness.DataService
{
    public class DataServiceAluno : DataService
    {
        // Envia dados preenchidos do aluno para autenticar ele pela nossa API | POST
        public static async Task<Aluno> AutenticarAluno(Aluno a)
        {
            var json_a_enviar = JsonConvert.SerializeObject(a);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/aluno/autenticar");

            if (json == "false")
                return null;

            Aluno aluno = JsonConvert.DeserializeObject<Aluno>(json);

            return aluno;
        }

        /*public static async Task<Aluno> BuscarDados(string cpf)
        {
            string json = await DataService.GetDataFromService("/aluno/dados?cpf=" + cpf);

            Aluno aluno_dados = JsonConvert.DeserializeObject<Aluno>(json);

            return aluno_dados;
        }*/
    }
}
