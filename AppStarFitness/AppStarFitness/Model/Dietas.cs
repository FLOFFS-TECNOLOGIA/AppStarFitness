using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class Dietas
    {
        public string name {  get; set; }
        public string id_gym_member { get; set; }
        public string id { get; set; }
    }

    public class Root_Dietas
    {
        public string success_message { get; set; }
        public Dietas data { get; set; }
    }

    // =============================================

    public class DietasList
    {
        public string id { get; set; }
        public string name { get; set; }
        public string id_gym_member { get; set; }
    }

    public class Root_DietasList
    {
        public string success_message { get; set; }
        public List<DietasList> data { get; set;}
    }
}
