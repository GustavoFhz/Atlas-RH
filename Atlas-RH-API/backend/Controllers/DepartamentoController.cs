using backend.Dto.Departamento;
using backend.Services.Departamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoInterface _departamentoInterface;
        public DepartamentoController(IDepartamentoInterface departamentoInterface)
        {
            _departamentoInterface = departamentoInterface;
        }
        /// <summary>
        /// Lista todos os departamentos
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> ListarDepartamentos()
        {
            var departamentos = await _departamentoInterface.ListarDepartamentos();
            return Ok(departamentos);
        }
        /// <summary>
        /// Busca os departamentos pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarDepartamentoPorId(int id)
        {
            var departamento = await _departamentoInterface.BuscarDepartamentoPorId(id);
            return Ok(departamento);
        }

        /// <summary>
        /// Remove um departamento pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverDepartamento(int id)
        {
            var departamento = await _departamentoInterface.RemoverDepartamento(id);
            return Ok(departamento);
        }
        /// <summary>
        /// Registra um departamento
        /// </summary>
        /// <param name="departamentoCriacaoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegistrarDepartamento(DepartamentoCriacaoDto departamentoCriacaoDto)
        {
            var departamento = await _departamentoInterface.RegistrarDepartamento(departamentoCriacaoDto);
            return Ok(departamento);
        }
        /// <summary>
        /// Lista funcionários por departamento
        /// </summary>
        /// <param name="departamentoId"></param>
        /// <returns></returns>
        [HttpGet("{departamentoId}/funcionarios")]
        public async Task<IActionResult> ListarFuncionariosPorDepartamento(int departamentoId)
        {
            var funcionarios = await _departamentoInterface.ListarFuncionariosPorDepartamento(departamentoId);
            return Ok(funcionarios);
        }
        /// <summary>
        /// Edita um departamento 
        /// </summary>
        /// <param name="departamentoEdicaoDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarDepartamento(DepartamentoEdicaoDto departamentoEdicaoDto)
        {
            var departamento = await _departamentoInterface.EditarDepartamento(departamentoEdicaoDto);
            return Ok(departamento);
        }

    }
}
