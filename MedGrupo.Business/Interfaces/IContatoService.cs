using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedGrupo.Business.DTO;
using MedGrupo.Business.Models;

namespace MedGrupo.Business.Interfaces
{
    public interface IContatoService : IDisposable
    {
        Task<Contato> BuscarPorID(int id);
        Task<IEnumerable<Contato>> BuscarTodos();
        Task<RetornoDTO> Adicionar(Contato contato);
        Task<RetornoDTO> Atualizar(Contato contato);
        Task Remover(int id);
        Task Inativar(int id);
    }
}