using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class ExerciciosList
    {
        public string id {  get; set; }
        public string name { get; set; }
        public string exercise_gif { get; set; }
        public string equipment_gym_photo { get; set; }
        public string muscle_groups { get; set; }
    }

    public class Root_ExerciciosList
    {
        public string success_message { get; set; }
        public List<ExerciciosList> data { get; set; }
    }
}
