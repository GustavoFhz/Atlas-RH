using backend.Dto.Funcionario;
using backend.Services.Cep;
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
        private readonly ICepInterface _cepInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface, ICepInterface cepInterface)
        {
            _funcionarioInterface = funcionarioInterface;
            _cepInterface = cepInterface;
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
        public async Task<IActionResult> RegistrarFuncionario([FromBody] FuncionarioCriacaoDto funcionarioCriacaoDto)
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
        public async Task<IActionResult> EditarFuncionario([FromBody] FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            var funcionario = await _funcionarioInterface.EditarFuncionario(funcionarioEdicaoDto);
            return Ok(funcionario);
        }

        /// <summary>
        /// Busca Cep
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpGet("cep/{cep}")]

        public async Task<IActionResult> BuscarCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return BadRequest("CEP inválido");

            // Remove hífen e espaços
            cep = new string(cep.Where(char.IsDigit).ToArray());

            var endereco = await _cepInterface.EnderecoPorCep(cep);

            if (endereco == null)
                return NotFound();

            return Ok(new
            {
                logradouro = endereco.Logradouro,
                bairro = endereco.Bairro,
                cidade = endereco.Localidade,
                uf = endereco.Uf
            });
        }

    }
}
