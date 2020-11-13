using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;

namespace abcindustrialtx.API.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Usuarios, UsuarioGetDto>();

            CreateMap<UsuarioCreateDto, Usuarios>()
                .AfterMap((usuariodto, usuario) => usuario.PasswordHash = usuariodto.Password);

            CreateMap<UsuarioLoginDTO, Usuarios>()
                .AfterMap((usuariologindto, usuario) => usuario.PasswordHash = usuariologindto.Password);

            CreateMap<UsuarioUpdateDto, Usuarios>()
                .AfterMap((usuarioupdate, usuario) => usuario.PasswordHash = usuarioupdate.Password);

            CreateMap<Roles, RolesGetDto>();
            CreateMap<RolesCreateDto, Roles>();
            CreateMap<RolesUpdateDto, Roles>();

        }
    }
}
