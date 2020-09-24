using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedGrupo.Business.DTO;
using MedGrupo.Business.Interfaces;
using MedGrupo.Business.Models;

namespace  MedGrupo.Business.Services
{

    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;
        
        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<RetornoDTO> Adicionar(Contato contato)
        {
            contato.Idade = contato.DataNascimento != null ? (DateTime.Today - contato.DataNascimento).Days/365 : 0 ;
            contato.Ativo = true;
            
            var retorno = new RetornoDTO();

            if(contato.Idade < 18){
                
                retorno.Sucess = false;
                retorno.Msg = "Contato deve ser maior de Idade";
                
            }
            else{
                await _contatoRepository.Adicionar(contato);

                retorno.Sucess = true;
                retorno.Msg = "Contato Inserido com Sucesso";

            }
                
                return retorno;
        }

        public async Task<RetornoDTO> Atualizar(Contato contato)
        {
            contato.Idade = contato.DataNascimento != null ? (DateTime.Today - contato.DataNascimento).Days/365 : 0 ;

            var retorno = new RetornoDTO();

            if(contato.Idade < 18)
            {
                retorno.Sucess = false;
                retorno.Msg = "Contato deve ser maior de Idade";
            }
            else
            {
                await _contatoRepository.Atualizar(contato);

                retorno.Sucess = true;
                retorno.Msg = "Contato Atualizado com Sucesso";
            }

            return retorno;
        }

        public async Task<Contato> BuscarPorID(int id)
        {
           return await _contatoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Contato>> BuscarTodos()
        {
           return await _contatoRepository.ObterTodos();
        }
        
        public async Task Remover(int id)
        {   
            await _contatoRepository.Remover(id);
        }

        public async Task Inativar(int id)
        { 
            var contato = await _contatoRepository.ObterPorId(id);  
            contato.Ativo = false;
            await _contatoRepository.Inativar(contato);
        }

        public void Dispose()
        {
            _contatoRepository.Dispose();
        }
    }


}