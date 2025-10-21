using AutoMapper;
using backend.Dto.Cep;
using backend.Dto.Funcionario;
using backend.Dto.Usuario;
using backend.Dto.Cargo;
using backend.Dto.Departamento;
using backend.Models;



namespace backend.Profiles
{
    public class ProfilesAutoMappers : Profile
    {
        public ProfilesAutoMappers()
        {
            // Usuário
            CreateMap<UsuarioCriacaoDto, UsuarioModel>().ReverseMap();

            // Funcionário
            CreateMap<FuncionarioCriacaoDto, FuncionarioModel>().ReverseMap();
            CreateMap<FuncionarioEdicaoDto, FuncionarioModel>().ReverseMap();
            CreateMap<CepResponse, FuncionarioModel>()
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Localidade))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf));                

            // Cargo
            CreateMap<CargoCriacaoDto, CargoModel>().ReverseMap();

            // Departamento
            CreateMap<DepartamentoCriacaoDto, DepartamentoModel>().ReverseMap();
        }
    }
}
