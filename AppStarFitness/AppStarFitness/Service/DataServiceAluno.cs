using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;

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

            Root_Mensalidade root = JsonConvert.DeserializeObject<Root_Mensalidade>(json);

            return root.data;
        }

        public static async Task<EvolucaoAluno> NovaEvolucao(EvolucaoAluno e, Usuario usuario)
        {
            string token = usuario.token;

            var json_a_enviar = JsonConvert.SerializeObject(e);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("NOVA EVOLUCAO - JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/evolution", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("NOVA EVOLUCAO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_Evolucao root =  JsonConvert.DeserializeObject<Root_Evolucao>(json);

            return root.data;
        }

        public static async Task<Medidas> MedidasAluno(Medidas m, Usuario usuario)
        {
            string token = usuario.token;

            var json_a_enviar = JsonConvert.SerializeObject(m);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("MEDIDAS ALUNO - JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/measurement", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("MEDIDAS ALUNO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return JsonConvert.DeserializeObject<Medidas>(json);
        }

        public static async Task<List<EvolucaoAlunoList>> PuxarEvolucoes(Usuario usuario)
        {
            string token = usuario.token;

            string json = await DataService.GetDataFromService("/evolution", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR EVOLUÇÕES - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_EvolucaoList root = JsonConvert.DeserializeObject<Root_EvolucaoList>(json);
            var dados = JsonConvert.SerializeObject(root.data);
            List<EvolucaoAlunoList> evolucoes = JsonConvert.DeserializeObject<List<EvolucaoAlunoList>>(dados);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR EVOLUÇÕES - ARRAY EVOLUCOES");
            foreach (var evolucao in evolucoes)
            {
                Console.WriteLine($"ID: {evolucao.id}");
                Console.WriteLine($"Complete Date: {evolucao.complete_date}");
                Console.WriteLine($"ID Gym Member: {evolucao.id_gym_member}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return evolucoes;
        }

        public static async Task<Medidas> PuxarMedidas(string token, string id_evolucao)
        {
            string json = await DataService.GetDataFromService("/measurement/evolution/" + id_evolucao, token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR MEDIDAS - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_Medidas root = JsonConvert.DeserializeObject<Root_Medidas>(json);

            return root.data;
        }

        public static async Task<FichaTreino> NovaFicha(FichaTreino f, string token)
        {
            var json_a_enviar = JsonConvert.SerializeObject(f);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("NOVA FICHA DE TREINO - JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/workout-routine", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("NOVA FICHA DE TREINO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_FichaTreino root = JsonConvert.DeserializeObject<Root_FichaTreino>(json);

            return root.data;
        }

        public static async Task<List<FichaTreinoList>> PuxarFichas(string token, string id_aluno)
        {
            string json = await DataService.GetDataFromService("/workout-routine/gym-member/" + id_aluno, token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR FICHAS DE TREINO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_FichaTreinoList root = JsonConvert.DeserializeObject<Root_FichaTreinoList>(json);
            var dados = JsonConvert.SerializeObject(root.data);
            List<FichaTreinoList> fichas = JsonConvert.DeserializeObject<List<FichaTreinoList>>(dados);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR FICHAS DE TREINO - ARRAY FICHAS");
            foreach (var ficha in fichas)
            {
                Console.WriteLine($"ID: {ficha.id}");
                Console.WriteLine($"Name: {ficha.name}");
                Console.WriteLine($"ID Gym Member: {ficha.id_gym_member}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return fichas;
        }

        public static async Task<List<ExerciciosList>> PuxarExercicios(string token)
        {
            string json = await DataService.GetDataFromService("/exercise", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR EXERCÍCIOS - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_ExerciciosList root = JsonConvert.DeserializeObject<Root_ExerciciosList>(json);
            var dados = JsonConvert.SerializeObject(root.data);
            List<ExerciciosList> exercicios = JsonConvert.DeserializeObject<List<ExerciciosList>>(dados);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR EXERCÍCIOS - ARRAY EXERCÍCIOS");
            foreach (var exercicio in exercicios)
            {
                Console.WriteLine($"ID: {exercicio.id}");
                Console.WriteLine($"Name: {exercicio.name}");
                Console.WriteLine($"Exercise GIF: {exercicio.exercise_gif}");
                Console.WriteLine($"Equipment Gym Photo: {exercicio.equipment_gym_photo}");
                Console.WriteLine($"Muscle Group: {exercicio.muscle_groups}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return exercicios;
        }
    }
}
