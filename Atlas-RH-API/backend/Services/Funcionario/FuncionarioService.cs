using AutoMapper;
using backend.Data;
using backend.Dto.Funcionario;
using backend.Models;
using backend.Services.Cep;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICepInterface _cepInterface;

        public FuncionarioService(AppDbContext context, IMapper mapper, ICepInterface cepInterface)
        {
            _context = context;
            _mapper = mapper;
            _cepInterface = cepInterface;
        }
        public async Task<ResponseModel<FuncionarioModel>> BuscarFuncionarioPorId(int id)
        {
            ResponseModel<FuncionarioModel> response = new();

            try
            {
                var funcionario = await _context.Funcionarios.FindAsync(id);

                if(funcionario == null)
                {
                    response.Mensagem = "Funcionário não encontrado!";
                    return response;
                }
                response.Dados = funcionario;
                response.Mensagem = "Funcionário localizado com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<FuncionarioModel>> EditarFuncionario(FuncionarioEdicaoDto funcionarioEdicaoDto)
        {
            ResponseModel<FuncionarioModel> response = new();

            try
            {
                var funcionarioBanco = await _context.Funcionarios.FindAsync(funcionarioEdicaoDto.Id);

                if (funcionarioBanco == null)
                {
                    response.Mensagem = "Funcionário não encontrado";
                    return response;
                }

                // Atualiza os campos básicos via AutoMapper
                _mapper.Map(funcionarioEdicaoDto, funcionarioBanco);

                // Atualiza endereço APENAS se CEP for diferente e não nulo
                if (!string.IsNullOrEmpty(funcionarioEdicaoDto.Cep) &&
                    funcionarioEdicaoDto.Cep != funcionarioBanco.Cep)
                {
                    var enderecoResponse = await _cepInterface.EnderecoPorCep(funcionarioEdicaoDto.Cep);

                    if (enderecoResponse != null)
                    {
                        _mapper.Map(enderecoResponse, funcionarioBanco);
                    }
                }

                _context.Update(funcionarioBanco);
                await _context.SaveChangesAsync();

                response.Dados = funcionarioBanco;
                response.Mensagem = $"Funcionário {funcionarioBanco.Nome} editado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }


        public async Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionarios()
        {
            ResponseModel<List<FuncionarioModel>> response = new();

            try
            {
                var funcionarios = await _context.Funcionarios.ToListAsync();

                if(funcionarios.Count == 0)
                {
                    response.Mensagem = "Nenhum funcionário encontrado";
                    return response;
                }

                response.Dados = funcionarios;
                response.Mensagem = "Funcionários localizados com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<FuncionarioModel>> RegistrarFuncionario(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            ResponseModel<FuncionarioModel> response = new();

            try
            {              
                if (!VerificaSeExisteCpfRepetidos(funcionarioCriacaoDto))
                {
                    response.Mensagem = "Funcionário já cadastrado";
                    return response;
                }

                // Mapeia os campos básicos do DTO para o Model
                FuncionarioModel funcionario = _mapper.Map<FuncionarioModel>(funcionarioCriacaoDto);

                // Consulta CEP se informado
                if (!string.IsNullOrEmpty(funcionarioCriacaoDto.Cep))
                {
                    var enderecoResponse = await _cepInterface.EnderecoPorCep(funcionarioCriacaoDto.Cep);

                    if (enderecoResponse != null)
                    {
                        _mapper.Map(enderecoResponse, funcionario);
                    }
                }
              
                _context.Add(funcionario);
                await _context.SaveChangesAsync();

                response.Dados = funcionario;
                response.Mensagem = "Funcionário cadastrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }


        public async Task<ResponseModel<FuncionarioModel>> RemoverFuncionario(int id)
        {
            ResponseModel<FuncionarioModel> response = new();

            try
            {
                var funcionario = await _context.Funcionarios.FindAsync(id);

                if(funcionario == null)
                {
                    response.Mensagem = "Funcionário não encontrado";
                    return response;
                }

                _context.Remove(funcionario);
                await _context.SaveChangesAsync();

                
                response.Mensagem = $"Funcionário {funcionario.Nome} removido com sucesso";
                response.Dados = funcionario;
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        private bool VerificaSeExisteCpfRepetidos(FuncionarioCriacaoDto funcionarioCriacaoDto)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(item => item.Cpf == funcionarioCriacaoDto.Cpf);

            if(funcionario != null)
            {
                return false;
            }
            return true;
        }
    }
}
