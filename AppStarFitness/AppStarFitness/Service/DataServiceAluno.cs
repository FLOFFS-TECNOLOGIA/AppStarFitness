using AppStarFitness.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppStarFitness.DataService
{
    public class DataServiceAluno : DataService
    {
        // Envia dados preenchidos do aluno para autenticar ele pela nossa API | POST
        public static async Task<Aluno> AutenticarAluno(Aluno a)
        {
            var json_a_enviar = JsonConvert.SerializeObject(a);
            string json = await DataService.PostDataToService(json_a_enviar, "/aluno/autenticar");
            Aluno aluno = JsonConvert.DeserializeObject<Aluno>(json);

            return aluno;
        }

    }
}
