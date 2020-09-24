using System;
using System.ComponentModel.DataAnnotations;

namespace MedGrupo.API.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime? DataNascimento { get; set; }

        public int Idade {get;set;}

        public bool Ativo {get;set;}


    }
}