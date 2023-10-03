using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppStarFitness.DataService
{
    public class DataServicePessoa : DataService
    {
        // Envia dados preenchidos do aluno para autenticar ele pela nossa API | POST
        public static async Task<Pessoa> AutenticarAluno(Pessoa p)
        {
            var json_a_enviar = JsonConvert.SerializeObject(p);

            Console.WriteLine("=============================================================================");
            Console.WriteLine("JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/login/gym-member");

            Console.WriteLine("=============================================================================");
            Console.WriteLine("JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            if (json == "false")
                return null;

            dynamic aluno = JsonConvert.DeserializeObject(json);

            Console.WriteLine(aluno["gym_member"]["email"]);

            //Pessoa pessoa = JsonConvert.DeserializeObject<Pessoa>(aluno.gym_member);

            return new Pessoa();
        }
    }
}
