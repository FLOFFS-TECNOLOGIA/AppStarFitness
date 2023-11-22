using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class FichaExercicioAssoc
    {
        public string id_workout_routine { get; set; }
        public string id_exercise { get; set; }
        public string week_day { get; set; }
        public string sets { get; set; }
        public string repetitions { get; set; }
        public string rest_seconds { get; set; }
        public string observation { get; set; }
        public string exercise_name { get; set; }
    }

    public class Root_FichaExercicioAssoc 
    {
        public string success_message {  get; set; }
        public FichaExercicioAssoc data {  get; set; }
    }

    // ================================================

    public class AssocTreinoList
    {
        public string id_workout_routine { get; set; }
        public string id_exercise { get; set; }
        public string week_day { get; set; }
        public string sets { get; set; }
        public string repetitions { get; set; }
        public string rest_seconds { get; set; }
        public string observation { get; set; }
        public string exercise_name { get; set; }
    }

    public class Root_AssocTreinoList
    {
        public string success_message { get; set; }
        public List<FichaExercicioAssoc> data { get; set; }
    }
}
