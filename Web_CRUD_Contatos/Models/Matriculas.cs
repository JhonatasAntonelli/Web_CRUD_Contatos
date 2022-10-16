using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Web_CRUD_Contatos.Models
{
    
    public class Matriculas
    {       
        public int id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome do Aluno")]
        public string Nome { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF do Aluno")]
        public string CPF { get; set; }
        
        [Column("NomeCurso")]
        [Display(Name = "Nome do Curso")]
        public string NomeCurso { get; set; }

        
        [NotMapped]
        public List<SelectListItem>? ContatosSelectListNome { get; set; }

        [NotMapped]
        public List<SelectListItem>? ContatosSelectListCPF { get; set; }

        [NotMapped]
        public List<SelectListItem>? ContatosSelectListCurso { get; set; }
    }
    
}
