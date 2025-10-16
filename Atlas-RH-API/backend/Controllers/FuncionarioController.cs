using backend.Dto.Funcionario;
using backend.Services.Funcionario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }
        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListarFuncionarios()
        {
            var funcionarios = await _funcionarioInterface.ListarFuncionarios();
            return Ok(funcionarios);
        }
        /// <summary>
        /// Busca um funcionário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarFuncionarioPorId(int id)
        {
            var funcionario = await _funcionarioInterface.BuscarFuncionarioPorId(id);
            return Ok(funcionario);
        }
        /// <summary>
        /// Remove um funcionário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverFuncionario(int id)
        {
            var funcionario = await _funcionarioInterface.RemoverFuncionario(id);
            return Ok(funcionario);
        }
        /// <summary>
        /// Registra um funcionário
        /// </summary>
        /// <param name="funcionarioCriacaoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegistrarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            var funcionario = await _funcionarioInterface.RegistrarFuncionario(funcionarioCriacaoDto);
            return Ok(funcionario);
        }
        /// <summary>
        /// Edita um funcionário
        /// </summary>
        /// <param name="funcionarioEdicaoDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            var funcionario = await _funcionarioInterface.EditarFuncionario(funcionarioEdicaoDto);
            return Ok(funcionario);
        }
    }
}
