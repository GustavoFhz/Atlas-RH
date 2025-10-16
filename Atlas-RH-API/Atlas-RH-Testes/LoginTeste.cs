using backend.Data;
using backend.Models;
using backend.Services.Senha;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Atlas_RH_Testes
{
    public class LoginTeste : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly SenhaService _senhaService;

        public LoginTeste()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureCreated();

            _senhaService = new SenhaService(null); // Passa null, já que não vamos criar token real
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task Deve_Registrar_E_Logar_Usuario()
        {
            // Arrange - criar usuário
            string senha = "123456";

            CriarSenhaHash(senha, out byte[] senhaHash, out byte[] senhaSalt);

            var usuario = new UsuarioModel
            {
                Nome = "Gustavo",
                UsuarioLogin = "gustavoxd3",
                SenhaHash = senhaHash,
                SenhaSalt = senhaSalt
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Act - login
            var usuarioBanco = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioLogin == "gustavoxd3");
            bool senhaValida = _senhaService.VerificaSenhaHash(senha, usuarioBanco!.SenhaHash, usuarioBanco.SenhaSalt);

            // Assert - verificar
            usuarioBanco.Should().NotBeNull();
            usuarioBanco!.UsuarioLogin.Should().Be("gustavoxd3");
            senhaValida.Should().BeTrue();
        }

        // Helper para criar hash e salt
        private void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using var hmac = new HMACSHA512();
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }
    }
}
