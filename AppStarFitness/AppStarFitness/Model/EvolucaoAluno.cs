using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class EvolucaoAluno
    {
        public string complete_date {  get; set; }
        public string id_gym_member { get; set; }
        public string id { get; set; }
    }
    public class Root_Evolucao
    {
        public string success_message { get; set; }
        public EvolucaoAluno data { get; set; }
    }

    // ===============================================

    public class EvolucaoAlunoList
    {
        public string id { get; set; }
        public string complete_date { get; set; }
        public string id_gym_member { get; set; }
        public string created_at {  get; set; }
    }

    public class Root_EvolucaoList
    {
        public string success_message { get; set; }
        public List<EvolucaoAlunoList> data { get; set; }
    }
}
