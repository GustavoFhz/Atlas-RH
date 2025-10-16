using backend.Data;
using backend.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Atlas_RH_Testes;

public class UsuarioTeste : IDisposable
{
    private readonly AppDbContext _context;

    public UsuarioTeste()
    {
        // Configura o banco em mem�ria para testes, isolado por teste
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        // Limpa e fecha o banco de dados ap�s cada teste
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Fact]
    public async Task Deve_Adicionar_Usuario()
    {
        // Arrange - preparar o usu�rio
        var usuario = new UsuarioModel
        {
            Nome = "Gustavo",
            UsuarioLogin = "gustavoxd",
            SenhaHash = new byte[] { 1, 2, 3 }, // Exemplo simples
            SenhaSalt = new byte[] { 4, 5, 6 }
        };

        // Act - adicionar no banco
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        // Assert - verificar se o usu�rio foi adicionado corretamente
        var resultado = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioLogin == "gustavoxd");
        resultado.Should().NotBeNull();
        resultado!.Nome.Should().Be("Gustavo");
        resultado.UsuarioLogin.Should().Be("gustavoxd");
    }

    [Fact]
    public async Task Deve_Listar_Usuarios()
    {
        // Arrange - adicionar m�ltiplos usu�rios
        _context.Usuarios.AddRange(
            new UsuarioModel { Nome = "Gustavo", UsuarioLogin = "gustavoxd", SenhaHash = new byte[] { 1 }, SenhaSalt = new byte[] { 2 } },
            new UsuarioModel { Nome = "Lucas", UsuarioLogin = "lucasxd", SenhaHash = new byte[] { 3 }, SenhaSalt = new byte[] { 4 } }
        );
        await _context.SaveChangesAsync();

        // Act - listar todos os usu�rios do banco
        var usuarios = await _context.Usuarios.ToListAsync();

        // Assert - verificar se os usu�rios foram listados corretamente
        usuarios.Should().HaveCount(2);
        usuarios.Should().Contain(u => u.UsuarioLogin == "gustavoxd");
        usuarios.Should().Contain(u => u.UsuarioLogin == "lucasxd");
    }

    [Fact]
    public async Task Deve_Atualizar_Usuario()
    {
        // Arrange - criar e adicionar um usu�rio
        var usuario = new UsuarioModel
        {
            Nome = "Gustavo",
            UsuarioLogin = "gustavoxd",
            SenhaHash = new byte[] { 1 },
            SenhaSalt = new byte[] { 2 }
        };
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        // Act - atualizar informa��es do usu�rio
        usuario.Nome = "Gustavo Silva";
        usuario.UsuarioLogin = "gustavo123";
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();

        // Assert - verificar se a atualiza��o foi aplicada
        var resultado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);
        resultado.Should().NotBeNull();
        resultado!.Nome.Should().Be("Gustavo Silva");
        resultado.UsuarioLogin.Should().Be("gustavo123");
    }

    [Fact]
    public async Task Deve_Remover_Usuario()
    {
        // Arrange - criar e adicionar usu�rio
        var usuario = new UsuarioModel
        {
            Nome = "Gustavo",
            UsuarioLogin = "gustavoxd",
            SenhaHash = new byte[] { 1 },
            SenhaSalt = new byte[] { 2 }
        };
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        // Act - remover usu�rio
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        // Assert - verificar se o usu�rio foi removido
        var resultado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);
        resultado.Should().BeNull();
    }
}
