using backend.Data;
using backend.Dto.Departamento;
using backend.Models;

namespace backend.Services.Departamento
{
    public class DepartamentoService : IDepartamentoInterface
    {
        private readonly AppDbContext _context;
        public DepartamentoService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<DepartamentoModel>> BuscarDepartamentoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<DepartamentoModel>> EditarDepartamento(DepartamentoEdicaoDto departamentoEdicaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<DepartamentoModel>>> ListarDepartamentos()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionariosPorDepartamento(int departamentoId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<DepartamentoModel>> RegistrarDepartamento(DepartamentoCriacaoDto departamentoCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<DepartamentoModel>> RemoverDepartamento(int id)
        {
            throw new NotImplementedException();
        }
    }
}
