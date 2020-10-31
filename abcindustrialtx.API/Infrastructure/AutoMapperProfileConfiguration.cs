using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;

namespace abcindustrialtx.API.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<CatUsuario, UsuarioDto>();
            CreateMap<UsuarioDto, CatUsuario>();

            CreateMap<UsuarioLoginDTO, CatUsuario>();
            CreateMap<CatUsuario, UsuarioLoginDTO>();

            CreateMap<CatColores, CatColoresDTO>();
            CreateMap<CatCalibre, CatCalibreDTO>();
            CreateMap<CatHilosMateriales, CatMaterialesDTO>();
        }
    }
}
