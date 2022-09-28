using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Web_CRUD_Contatos.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Contato> Contato { get; set; }
    }
}
