using AutoMapper;
using backend.Data;
using backend.Dto.Departamento;
using backend.Dto.Funcionario;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Departamento
{
    public class DepartamentoService : IDepartamentoInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DepartamentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<DepartamentoModel>> BuscarDepartamentoPorId(int id)
        {
            ResponseModel<DepartamentoModel> response = new();

            try
            {
                var departamento = await _context.Departamentos.FindAsync(id);

                if(departamento == null)
                {
                    response.Mensagem = "Nenhum departamento localizado";
                    return response;
                }
                response.Dados = departamento;
                response.Mensagem = "Departamento localizado com sucesso";
                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<DepartamentoModel>> EditarDepartamento(DepartamentoEdicaoDto departamentoEdicaoDto)
        {
            ResponseModel<DepartamentoModel> response = new();

            try
            {
                var departamentoBanco = await _context.Departamentos.FindAsync(departamentoEdicaoDto.Id);

                if(departamentoBanco == null)
                {
                    response.Mensagem = "Nenhum departamento localizado";
                    return response;
                }

                departamentoBanco.Nome = departamentoEdicaoDto.Nome;
                departamentoBanco.Descricao = departamentoEdicaoDto.Descricao;

                _context.Update(departamentoBanco);
                await _context.SaveChangesAsync();

                response.Dados = departamentoBanco;
                response.Mensagem = $"Departamento {departamentoBanco.Nome} editado com sucesso";
                return response;

            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<DepartamentoModel>>> ListarDepartamentos()
        {
            ResponseModel<List<DepartamentoModel>> response = new();

            try
            {
                var departamentos = await _context.Departamentos.ToListAsync();

                if(departamentos.Count == 0)
                {
                    response.Mensagem = "Nenhum departamento encontrado";
                    return response;
                }
                response.Dados = departamentos;
                response.Mensagem = "Departamentos localizados";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<FuncionarioModel>>> ListarFuncionariosPorDepartamento(int departamentoId)
        {
            ResponseModel<List<FuncionarioModel>> response = new();

            try
            {
                var funcionarios = await _context.Funcionarios
                    .Where(f => f.DepartamentoId == departamentoId)
                    .ToListAsync();

                if (funcionarios.Count == 0)
                {
                    response.Mensagem = "Nenhum funcionário encontrado para este departamento";
                    return response;
                }

                response.Dados = funcionarios;
                response.Mensagem = "Funcionários localizados";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<DepartamentoModel>> RegistrarDepartamento(DepartamentoCriacaoDto departamentoCriacaoDto)
        {
            ResponseModel<DepartamentoModel> response = new();

            try
            {
                if (!VerificaSeExisteDepartamentoRepetido(departamentoCriacaoDto)){

                    response.Mensagem = "Departamento já cadastrado";
                    return response;
                }
                DepartamentoModel departamento = _mapper.Map<DepartamentoModel>(departamentoCriacaoDto);

                _context.Add(departamento);
                await _context.SaveChangesAsync();

                response.Dados = departamento;
                response.Mensagem = "Departamento cadastrado com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<DepartamentoModel>> RemoverDepartamento(int id)
        {
            ResponseModel<DepartamentoModel> response = new();

            try
            {
                var departamento = await _context.Departamentos.FindAsync(id);

                if(departamento == null)
                {
                    response.Mensagem = "Nenhum departamento localizado";
                    return response;
                }
                _context.Remove(departamento);
                await _context.SaveChangesAsync();

                response.Dados = departamento;
                response.Mensagem = $"Departamento {departamento.Nome} removido com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        private bool VerificaSeExisteDepartamentoRepetido(DepartamentoCriacaoDto departamentoCriacaoDto)
        {
            var departamento = _context.Departamentos.FirstOrDefault(item => item.Nome == departamentoCriacaoDto.Nome);
            
            if(departamento != null)
            {
                return false;
            }
            return false;
        }
    }
}
