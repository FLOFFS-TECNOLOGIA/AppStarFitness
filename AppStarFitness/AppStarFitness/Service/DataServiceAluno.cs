using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppStarFitness.DataService
{
    public class DataServiceAluno : DataService
    {
        public static async Task<Mensalidade> MensalidadeAluno(Usuario usuario)
        {
            string token = usuario.token;
            string id_aluno = usuario.user.gymMember.id;

            string json = await DataService.GetDataFromService("/billing/" + id_aluno, token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("MENSALIDADE ALUNO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root root = JsonConvert.DeserializeObject<Root>(json);

            return root.data;
        }

        /*public static async Task<Aluno> MedidasAluno(Aluno a)
        {
            
        }*/
    }
}
