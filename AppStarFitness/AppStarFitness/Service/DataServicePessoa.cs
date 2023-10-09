using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

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

            // ===============================================================================================

            dynamic usuario = JsonConvert.DeserializeObject(json);

            Console.WriteLine("=============================================================================");
            Console.WriteLine("TESTE DADOS");
            Console.WriteLine(usuario["user"]["gymMember"]["height_cm"]);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            /*new Pessoa()
            {
                id = usuario["user"]["id"],
                name = usuario["user"]["name"],
                email = usuario["user"]["email"],
                document = usuario["user"]["document"],
                phone = usuario["user"]["phone"],
                birthday = usuario["user"]["birthday"],
                gender = usuario["user"]["gender"],
                photo_url = usuario["user"]["photo_url"],
                id_address = usuario["user"]["id_address"],
                gymMember = usuario["user"]["gymMember"]
            };

            new Aluno()
            {
                id = usuario["user"]["gymMember"]["id"],
                id_person = usuario["user"]["gymMember"]["id_person"],
                id_type_enrollment = usuario["user"]["gymMember"]["id_person"],
                height_cm = usuario["user"]["gymMember"]["height_cm"],
                weight_kg = usuario["user"]["gymMember"]["weight_kg"],
                observation = usuario["user"]["gymMember"]["observation"],
                created_at = usuario["user"]["gymMember"]["created_at"],
                updated_at = usuario["user"]["gymMember"]["updated_at"],
            };*/

            //JsonConvert.DeserializeObject<Pessoa>(usuario["user"]);
            //JsonConvert.DeserializeObject<Aluno>(usuario["user"]["gymMember"]);

            //return new Pessoa();
            return usuario;
        }
    }
}
