using AutoMapper;
using backend.Data;
using backend.Dto.Login;
using backend.Dto.Usuario;
using backend.Models;
using backend.Services.Senha;
using backend.Services.Usuario;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        private readonly IMapper _mapper;
        public UsuarioService(AppDbContext context, ISenhaInterface senhaInterface, IMapper mapper)
        {
            _context = context;
            _senhaInterface = senhaInterface;
            _mapper = mapper;

        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            ResponseModel<UsuarioModel> response = new();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if(usuario == null)
                {
                    response.Mensagem = "Usuário não localizado";
                    return response;
                }
                response.Dados = usuario;
                response.Mensagem = "Usuário localizado";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            ResponseModel<UsuarioModel> response = new();

            try
            {
                UsuarioModel usuarioBanco = await _context.Usuarios.FindAsync(usuarioEdicaoDto.Id);

                if(usuarioBanco == null)
                {
                    response.Mensagem = "Usuário não localizado";
                    return response;
                }

                usuarioBanco.Nome = usuarioEdicaoDto.Nome;
                usuarioBanco.UsuarioLogin = usuarioEdicaoDto.UsuarioLogin;

                if (!string.IsNullOrEmpty(usuarioEdicaoDto.NovaSenha))
                {
                    _senhaInterface.CriarSenhaHash(usuarioEdicaoDto.NovaSenha, out byte[] senhaHash, out byte[] senhaSalt);
                    usuarioBanco.SenhaHash = senhaHash;
                    usuarioBanco.SenhaSalt = senhaSalt;
                }

                _context.Update(usuarioBanco);
                await _context.SaveChangesAsync();

                response.Mensagem = $"Usuário {usuarioBanco.Nome} editado com sucesso";
                response.Dados = usuarioBanco;
                return response;

            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new();

            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                if (usuarios.Count() == 0)
                {                   
                    response.Mensagem = "Nenhum usuário cadastrado";
                    return response;
                }

                response.Dados = usuarios;
                response.Mensagem = "Usuários localizados com sucesso";
                return response;

            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDto usuarioLoginDto)
        {
            ResponseModel<UsuarioModel> response = new();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(userBanco => userBanco.UsuarioLogin == usuarioLoginDto.UsuarioLogin);

                if(usuario == null)
                {
                    response.Mensagem = "Credenciais inválidas";
                    return response;
                }


                if (!_senhaInterface.VerificaSenhaHash(usuarioLoginDto.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    response.Mensagem = "Credenciais inválidas";
                    return response;
                }

                var token = _senhaInterface.CriarToken(usuario);

                usuario.Token = token;

                _context.Update(usuario);
                await _context.SaveChangesAsync();

                response.Dados = usuario;
                response.Mensagem = "Usuário logado com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<UsuarioModel> response = new();

            try
            {
                if (!VerificaSeExisteNomeOuUsuarioLoginRepetidos(usuarioCriacaoDto))
                {
                    response.Mensagem = "Usuário já cadastrado!";
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioCriacaoDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                UsuarioModel usuario = _mapper.Map<UsuarioModel>(usuarioCriacaoDto);

                usuario.SenhaHash = senhaHash;
                usuario.SenhaSalt = senhaSalt;

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário cadastrado com sucesso";
                response.Dados = usuario;

                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> RemoverUsuario(int id)
        {
            ResponseModel<UsuarioModel> response = new();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if(usuario == null)
                {
                    response.Mensagem = "Usuário não localizado";
                    return response;
                }

                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                response.Dados = usuario;
                response.Mensagem = $"Usuário {usuario.Nome} removido com sucesso";
                return response;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }
        private bool VerificaSeExisteNomeOuUsuarioLoginRepetidos(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(item => item.Nome == usuarioCriacaoDto.Nome || item.UsuarioLogin == usuarioCriacaoDto.UsuarioLogin);

            if(usuario != null)
            {
                return false;
            }
            return true;
        }
    }
}
