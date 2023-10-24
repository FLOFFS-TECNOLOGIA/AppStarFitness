﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class Mensalidade
    {
        public string id { get; set; }
        public string invoice_date { get; set; } // data de ingresso na academia
        public string due_date { get; set; } // data do proximo pagamento
        public string payment_date { get; set; } // data que pagou (ou nao)
        public string id_gym_member { get; set; }
        /*public int active { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }*/
    }

    public class Root
    {
        public string success_message { get; set; }
        public Mensalidade data { get; set; }
    }
}