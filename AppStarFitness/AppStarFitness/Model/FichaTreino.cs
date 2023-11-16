using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class FichaTreino
    {
        public string name { get; set; }
        public string id_gym_member { get; set; }
        public string id {  get; set; }
    }

    public class Root_FichaTreino
    {
        public string success_message { get; set; }
        public FichaTreino data { get; set; }
    }

    // ===============================================

    public class FichaTreinoList
    {
        public string id { get; set; }
        public string name { get; set; }
        public string id_gym_member { get; set; }
    }

    public class Root_FichaTreinoList
    {
        public string success_message { get; set; }
        public List<FichaTreinoList> data { get; set; }
    }
}
