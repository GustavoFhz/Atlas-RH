using backend.Dto.Cargo;
using backend.Models;

namespace backend.Services.Cargo
{
    public interface ICargoInterface
    {
        Task<ResponseModel<List<CargoModel>>> ListarCargos();
        Task<ResponseModel<CargoModel>> BuscarCargoPorId(int id);
        Task<ResponseModel<CargoModel>> RemoverCargo(int id);
        Task<ResponseModel<CargoModel>> RegistrarCargo(CargoCriacaoDto cargoCriacaoDto);
        Task<ResponseModel<CargoModel>> EditarCargo(CargoEdicaoDto cargoEdicaoDto);
    }
}
