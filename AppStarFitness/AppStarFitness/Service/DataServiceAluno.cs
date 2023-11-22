using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
using System.Security.Cryptography.X509Certificates;

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

            Root_Evolucao root = JsonConvert.DeserializeObject<Root_Evolucao>(json);

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
                Console.WriteLine($"Created_at: {evolucao.created_at}");
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

        public static async Task<Exercicios> ExercicioById(string id_exercicio, string token)
        {
            string json = await DataService.GetDataFromService("/exercise/" + id_exercicio, token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR EXERCICIO PELO ID - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_Exercicios root = JsonConvert.DeserializeObject<Root_Exercicios>(json);

            return root.data;
        }

        public static async Task<Dietas> CriarDieta(Dietas d, string token)
        {
            var json_a_enviar = JsonConvert.SerializeObject(d);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("CRIAR DIETA - JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/diet", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("CRIAR DIETA - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_Dietas root = JsonConvert.DeserializeObject<Root_Dietas>(json);

            return root.data;
        }

        public static async Task<List<DietasList>> PuxarDietas(string id_aluno, string token)
        {
            string json = await DataService.GetDataFromService("/diet/gym-member/" + id_aluno, token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR DIETAS - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_DietasList root = JsonConvert.DeserializeObject<Root_DietasList>(json);
            var dados = JsonConvert.SerializeObject(root.data);
            List<DietasList> dietas = JsonConvert.DeserializeObject<List<DietasList>>(dados);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("PUXAR DIETAS - ARRAY DIETAS");
            foreach (var dieta in dietas)
            {
                Console.WriteLine($"ID: {dieta.id}");
                Console.WriteLine($"Name: {dieta.name}");
                Console.WriteLine($"ID Gym_Member: {dieta.id_gym_member}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return dietas;
        }

        public static async Task<FichaExercicioAssoc> CriarAssocFichaExercicio(FichaExercicioAssoc f, string token)
        {
            var json_a_enviar = JsonConvert.SerializeObject(f);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("CRIAR ASSOC - JSON A ENVIAR");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/workout-routine/mobile", token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("CRIAR ASSOC - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_FichaExercicioAssoc root = JsonConvert.DeserializeObject<Root_FichaExercicioAssoc>(json);

            return root.data;
        }

        public static async Task<List<AssocTreinoList>> PuxarAssocFichaExercicio(string dia_semana, string id_ficha, string token)
        {

            string json = await DataService.GetDataFromService("/workout-routine/mobile/" + dia_semana + "/" + id_ficha, token);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("LISTAR ASSOC FICHA EXERCICIO - JSON");
            Console.WriteLine(json);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            Root_AssocTreinoList root = JsonConvert.DeserializeObject<Root_AssocTreinoList>(json);
            var dados = JsonConvert.SerializeObject(root.data);
            List<AssocTreinoList> array_assoc = JsonConvert.DeserializeObject<List<AssocTreinoList>>(dados);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("ASSOC FICHA EXERCICIO - ARRAY ASSOC");
            foreach (var assoc in array_assoc)
            {
                Console.WriteLine($"ID Workout Routine: {assoc.id_workout_routine}");
                Console.WriteLine($"ID Exercise: {assoc.id_exercise}");
                Console.WriteLine($"Week Day: {assoc.week_day}");
                Console.WriteLine($"Sets: {assoc.sets}");
                Console.WriteLine($"Repetitions: {assoc.repetitions}");
                Console.WriteLine($"Rest seconds: {assoc.rest_seconds}");
                Console.WriteLine($"Observation: {assoc.observation}");
                Console.WriteLine($"Execise Name: {assoc.exercise_name}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            return array_assoc;
        }
    }
}
