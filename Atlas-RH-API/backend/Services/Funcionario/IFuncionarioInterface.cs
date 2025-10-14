using backend.Dto.Funcionario;
using backend.Models;

namespace backend.Services.Funcionario
{
    public interface IFuncionarioInterface
    {
        Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionarios();
        Task<ResponseModel<FuncionarioModel>> BuscarFuncionarioPorId(int id);
        Task<ResponseModel<FuncionarioModel>> RemoverFuncionario(int id);
        Task<ResponseModel<FuncionarioModel>> RegistrarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto);
        Task<ResponseModel<FuncionarioModel>> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto);
        
    }
}
