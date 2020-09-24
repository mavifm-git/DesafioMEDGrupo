using MedGrupo.API.ViewModels;
using MedGrupo.Business.Models;
using AutoMapper;

namespace MedGrupo.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();

        }
    }
}