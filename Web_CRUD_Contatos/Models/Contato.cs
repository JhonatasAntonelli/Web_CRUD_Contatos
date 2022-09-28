using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Web_CRUD_Contatos.Models
{
    [Table("Contato")]
    public class Contato
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int id { get; set; }

        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Column("datanascimento")]
        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }
    }
}
