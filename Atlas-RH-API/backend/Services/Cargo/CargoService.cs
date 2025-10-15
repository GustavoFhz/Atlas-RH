using AutoMapper;
using backend.Data;
using backend.Dto.Cargo;
using backend.Dto.Funcionario;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Cargo
{
    public class CargoService : ICargoInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CargoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseModel<CargoModel>> BuscarCargoPorId(int id)
        {
            ResponseModel<CargoModel> response = new();

            try
            {
                var cargo = await _context.Cargos.FindAsync(id);

                if(cargo == null)
                {
                    response.Mensagem = "Cargo não localizado";
                    return response;
                }
                response.Dados = cargo;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<CargoModel>> EditarCargo(CargoEdicaoDto cargoEdicaoDto)
        {
            ResponseModel<CargoModel> response = new();

            try
            {
                var cargoBanco = await _context.Cargos.FindAsync(cargoEdicaoDto.Id);

                if(cargoBanco == null)
                {
                    response.Mensagem = "Cargo não localizado";
                    return response;
                }

                cargoBanco.Nome = cargoEdicaoDto.Nome;
                cargoBanco.Nivel = cargoEdicaoDto.Nivel;
                cargoBanco.Descricao = cargoEdicaoDto.Descricao;

                _context.Update(cargoBanco);
                await _context.SaveChangesAsync();

                response.Dados = cargoBanco;
                response.Mensagem = $"Cargo {cargoBanco.Nome} editado com sucesso";
                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<CargoModel>>> ListarCargos()
        {
            ResponseModel<List<CargoModel>> response = new();

            try
            {
                var cargos = await _context.Cargos.ToListAsync();
                if(cargos.Count() == 0)
                {
                    response.Mensagem = "Nenhum cargo encontrado";
                    return response;
                }
                response.Dados = cargos;
                response.Mensagem = "Cargos localizados com sucesso";
                return response;

            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<CargoModel>> RegistrarCargo(CargoCriacaoDto cargoCriacaoDto)
        {
            ResponseModel<CargoModel> response = new();

            try
            {
                if (!VerificaSeExisteCargoRepetido(cargoCriacaoDto))
                {
                    response.Mensagem = "Cargo já cadastrado";
                    return response;
                }
                CargoModel cargo = _mapper.Map<CargoModel>(cargoCriacaoDto);

                _context.Add(cargo);
                await _context.SaveChangesAsync();

                response.Dados = cargo;
                response.Mensagem = "Cargo cadastrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<CargoModel>> RemoverCargo(int id)
        {
            ResponseModel<CargoModel> response = new();

            try
            {
                var cargo = await _context.Cargos.FindAsync(id);
                if(cargo == null)
                {
                    response.Mensagem = "Nenhum cargo localizado";
                    return response;
                }
                _context.Remove(cargo);
                await _context.SaveChangesAsync();

                response.Dados = cargo;
                response.Mensagem = $"Cargo removido {cargo.Nome} com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        private bool VerificaSeExisteCargoRepetido(CargoCriacaoDto cargoCriacaoDto)
        {
            var cargo = _context.Cargos.FirstOrDefault(item => item.Nome == cargoCriacaoDto.Nome);

            if(cargo != null)
            {
                return false;
            }
            return true;
        }
    }
}
