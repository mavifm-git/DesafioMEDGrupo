using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedGrupo.API.ViewModels;
using MedGrupo.Business.Interfaces;
using MedGrupo.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedGrupo.API.Controllers
{

    [ApiController]
    [Route("api/contato")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoController(IContatoService contatoService, IMapper mapper, IContatoRepository contatoRepository)
        {
            _contatoService = contatoService;
            _mapper = mapper;
            _contatoRepository = contatoRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoService.BuscarTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(int id)
        {
            var contatoViewModel = _mapper.Map<ContatoViewModel>(await _contatoService.BuscarPorID(id));

            if (contatoViewModel == null) return NotFound();

            return contatoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(ContatoViewModel contatoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var retorno = await _contatoService.Adicionar(_mapper.Map<Contato>(contatoViewModel));
                
                
                
                if(retorno.Sucess)
                {
                    return Ok(retorno.Msg);
                }
                else
                {
                    return BadRequest(retorno.Msg);
                }

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar(ContatoViewModel contatoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
           
            if (!_contatoRepository.Buscar(c => c.Id == contatoViewModel.Id).Result.Any())
            {
                return NotFound();
            }

            try
            {
               var retorno = await _contatoService.Atualizar(_mapper.Map<Contato>(contatoViewModel));
               
               if(retorno.Sucess)
                {
                    return Ok(retorno.Msg);
                }
                else
                {
                    return BadRequest(retorno.Msg);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (!_contatoRepository.Buscar(c => c.Id == id).Result.Any())
            {
                return NotFound();
            }
            
            try
            {
                await _contatoService.Remover(id);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Inativar(int id)
        {
            var contato = await _contatoRepository.Buscar(c => c.Id == id);

            if (!_contatoRepository.Buscar(c => c.Id == id).Result.Any())
            {
                return NotFound();
            }

            
            try
            {
                await _contatoService.Inativar(id);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }


}