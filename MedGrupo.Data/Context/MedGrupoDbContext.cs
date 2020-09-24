using MedGrupo.Business.Models;
using Microsoft.EntityFrameworkCore;


namespace MedGrupo.Data.Context
{
    public class MedGrupoDbContext: DbContext
    {


        public MedGrupoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contato> Contato { get; set; }
       
        

    }
}