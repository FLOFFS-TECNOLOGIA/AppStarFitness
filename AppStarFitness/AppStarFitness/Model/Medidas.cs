using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class Medidas
    {
        public string id { get; set; }
        public string chest { get; set; }
        public string glute { get; set; }
        public string left_arm { get; set; }
        public string right_arm { get; set; }
        public string left_calf { get; set; }
        public string right_calf { get; set; }
        public string left_forearm { get; set; }
        public string right_forearm { get; set; }
        public string left_quadriceps { get; set; }
        public string right_quadriceps { get; set; }
        public string id_evolution { get; set; }
        /*public int active { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }*/
    }

    public class Root_Medidas
    {
        public string success_message { get; set; }
        public Medidas data { get; set; }
    }
}
