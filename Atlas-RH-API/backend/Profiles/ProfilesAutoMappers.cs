using AutoMapper;
using backend.Dto.Funcionario;
using backend.Dto.Usuario;
using backend.Models;

namespace backend.Profiles
{
    public class ProfilesAutoMappers : Profile
    {
        public ProfilesAutoMappers()
        {
            CreateMap<UsuarioCriacaoDto, UsuarioModel>().ReverseMap();
            CreateMap<FuncionarioCriacaoDto, FuncionarioModel>().ReverseMap();
        }
    }
}
