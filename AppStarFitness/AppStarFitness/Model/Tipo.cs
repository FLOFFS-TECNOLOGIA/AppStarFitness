using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class Tipo
    {
        public string name {  get; set; }
    }

    public class Root_Tipo
    {
        public string success_message { get; set; }   
        public Tipo data { get; set; }
    }
}
