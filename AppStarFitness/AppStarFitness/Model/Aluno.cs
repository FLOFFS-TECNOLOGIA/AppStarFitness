using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarFitness.Model
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string data_nascimento { get; set; }
        public string sexo { get; set; }
        public string altura_cm { get; set; }
        public string peso_kg { get; set; }
        public string foto { get; set; }
        public string observacao { get; set; }
        public int id_endereco { get; set; }
        public int id_registrado_por { get; set; }
        public int ativo { get; set; }
    }
}
