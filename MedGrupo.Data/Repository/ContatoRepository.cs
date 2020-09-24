using System.Threading.Tasks;
using MedGrupo.Business.Interfaces;
using MedGrupo.Business.Models;
using MedGrupo.Data.Context;

namespace MedGrupo.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
 
        public ContatoRepository(MedGrupoDbContext context) : base(context)
        {
            
        }

        public async Task Inativar(Contato contato)
        {
            DbSet.Update(contato);
            await SaveChanges();
        }
       
    }
}
