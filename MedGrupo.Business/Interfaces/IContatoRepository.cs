using System.Threading.Tasks;
using MedGrupo.Business.Models;


namespace MedGrupo.Business.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task Inativar(Contato contato);
    }
}