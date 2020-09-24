using System;

namespace MedGrupo.Business.Models
{
    public class Contato : Entity
    {  
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade {get;set;}
        public bool Ativo {get;set;}
    }
}