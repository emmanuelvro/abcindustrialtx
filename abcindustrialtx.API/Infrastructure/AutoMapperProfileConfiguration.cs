using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;

namespace abcindustrialtx.API.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Usuarios, UsuarioDto>();
            CreateMap<UsuarioDto, Usuarios>();

            CreateMap<UsuarioLoginDTO, Usuarios>();
            CreateMap<Usuarios, UsuarioLoginDTO>();

            CreateMap<CatColores, CatColoresDTO>();
            CreateMap<CatCalibre, CatCalibreDTO>();
            CreateMap<CatMaterial, CatMaterialesDTO>();

            CreateMap<CatPresentacion, CatPresentacionDTO>();
        }
    }
}
