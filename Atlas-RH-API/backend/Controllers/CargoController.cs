using backend.Dto.Cargo;
using backend.Services.Cargo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CargoController : ControllerBase
    {
        private readonly ICargoInterface _cargo;
        public CargoController(ICargoInterface cargo)
        {
            _cargo = cargo;
        }
        /// <summary>
        /// Lista todos os cargos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListarCargos()
        {
            var cargos = await _cargo.ListarCargos();
            return Ok(cargos);
        }
        /// <summary>
        /// Buscar um cargo pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCargoPorId(int id)
        {
            var cargo = await _cargo.BuscarCargoPorId(id);
            return Ok(cargo);
        }

        /// <summary>
        /// Deleta um cargo pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCargo(int id)
        {
            var cargo = await _cargo.RemoverCargo(id);
            return Ok(cargo);
        }
        /// <summary>
        /// Registra um cargo
        /// </summary>
        /// <param name="cargoCriacaoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegistrarCargo(CargoCriacaoDto cargoCriacaoDto)
        {
            var cargo = await _cargo.RegistrarCargo(cargoCriacaoDto);
            return Ok(cargo);
        }
        /// <summary>
        /// Edita um cargo
        /// </summary>
        /// <param name="cargoEdicaoDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarCargo(CargoEdicaoDto cargoEdicaoDto)
        {
            var cargo = await _cargo.EditarCargo(cargoEdicaoDto);
            return Ok(cargo);
        }
    }
}
