using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class Aluno
    {
        public string id { get; set; }
        public string id_person { get; set; }
        public string id_type_enrollment { get; set; }
        public string height_cm { get; set; }
        public string weight_kg { get; set; }
        public string observation {  get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set;}
    }
}
