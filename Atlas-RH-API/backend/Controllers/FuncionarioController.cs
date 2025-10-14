using backend.Dto.Funcionario;
using backend.Services.Funcionario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> ListarFuncionarios()
        {
            var funcionarios = await _funcionarioInterface.ListarFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarFuncionarioPorId(int id)
        {
            var funcionario = await _funcionarioInterface.BuscarFuncionarioPorId(id);
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverFuncionario(int id)
        {
            var funcionario = await _funcionarioInterface.RemoverFuncionario(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            var funcionario = await _funcionarioInterface.RegistrarFuncionario(funcionarioCriacaoDto);
            return Ok(funcionario);
        }

        [HttpPut]
        public async Task<IActionResult> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            var funcionario = await _funcionarioInterface.EditarFuncionario(funcionarioEdicaoDto);
            return Ok(funcionario);
        }
    }
}
