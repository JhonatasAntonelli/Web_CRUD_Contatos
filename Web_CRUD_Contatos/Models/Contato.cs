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

        [Required(ErrorMessage = "Digite o nome do aluno")]
        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o CPF do aluno")]
        [Column("cpf")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento do aluno")]
        [Column("datanascimento")]
        [Display(Name = "Data de Nascimento")]

        public string DataNascimento { get; set; }
              
    }
    
}
