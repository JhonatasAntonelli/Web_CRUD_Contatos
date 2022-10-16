using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_CRUD_Contatos.Models
{
    [Table("Curso")]
    public class Curso
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int id { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do Curso")]
        public string Nome { get; set; }

        [Column("cpf")]
        [Display(Name = "Carga Horária")]
        public string CPF { get; set; }

        [Column("datanascimento")]
        [Display(Name = "Descrição do Curso")]
        public string DataNascimento { get; set; }

    }
}
