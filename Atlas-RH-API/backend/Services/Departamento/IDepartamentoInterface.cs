using backend.Dto.Departamento;
using backend.Models;

namespace backend.Services.Departamento
{
    public interface IDepartamentoInterface
    {
        Task<ResponseModel<List<DepartamentoModel>>> ListarDepartamentos();
        Task<ResponseModel<DepartamentoModel>> BuscarDepartamentoPorId(int id);
        Task<ResponseModel<DepartamentoModel>> RemoverDepartamento(int id);
        Task<ResponseModel<DepartamentoModel>> RegistrarDepartamento(DepartamentoCriacaoDto departamentoCriacaoDto);
        Task<ResponseModel<DepartamentoModel>> EditarDepartamento(DepartamentoEdicaoDto departamentoEdicaoDto);
        Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionariosPorDepartamento(int departamentoId);
    }
}
