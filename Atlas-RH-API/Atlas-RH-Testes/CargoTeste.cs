using backend.Data;
using backend.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Atlas_RH_Testes
{
    public class CargoTeste : IDisposable
    {
        private readonly AppDbContext _context;

        public CargoTeste()
        {
            // Banco em memória (sem SQL Server)
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // cria um DB isolado pra cada teste
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task Deve_Adicionar_Cargo()
        {
            //Arrange - Preparar o cenário
            var cargo = new CargoModel
            {
                Nome = "Desenvolvedor",
                Descricao = "Responsável por desenvolver sistemas"
            };

            //Act - Executar a ação
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();

            //Assert - Verificar o resultado
            var resultado = await _context.Cargos.FirstOrDefaultAsync(c => c.Nome == cargo.Nome);
            resultado.Should().NotBeNull();
            resultado!.Nome.Should().Be(cargo.Nome);
            resultado.Descricao.Should().Be(cargo.Descricao);
        }

        [Fact]
        public async Task Deve_Listar_Cargos()
        {
            // Arrange - Preparar o cenário
            _context.Cargos.AddRange(
                new CargoModel { Nome = "Analista", Descricao = "Analisa requisitos" },
                new CargoModel { Nome = "Tester", Descricao = "Executa testes de software" }
            );
            await _context.SaveChangesAsync();

            // Act - Executar a ação
            var cargos = await _context.Cargos.ToListAsync();

            //Assert - Verificar o resultado
            cargos.Should().HaveCount(2);
            cargos.Should().Contain(c => c.Nome == "Analista");
            cargos.Should().Contain(c => c.Nome == "Tester");
        }

        [Fact]
        public async Task Deve_Atualizar_Cargo()
        {
            // Arrange - Preparar o cenário
            var cargo = new CargoModel
            {
                Nome = "Junior",
                Descricao = "Cargo inicial"
            };
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();

            // Act - Executar a ação
            cargo.Nome = "Pleno";
            cargo.Descricao = "Cargo intermediário";
            _context.Cargos.Update(cargo);
            await _context.SaveChangesAsync();

            //Assert - Verificar o resultado
            var resultado = await _context.Cargos.FirstOrDefaultAsync(c => c.Id == cargo.Id);
            resultado.Should().NotBeNull();
            resultado!.Nome.Should().Be("Pleno");
            resultado.Descricao.Should().Be("Cargo intermediário");
        }

        [Fact]
        public async Task Deve_Remover_Cargo()
        {
            // Arrange - Preparar o cenário
            var cargo = new CargoModel
            {
                Nome = "Temporário",
                Descricao = "Cargo por tempo determinado"
            };
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();

            // Act - Executar a ação
            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();

            //Assert - Verificar o resultado
            var resultado = await _context.Cargos.FirstOrDefaultAsync(c => c.Id == cargo.Id);
            resultado.Should().BeNull();
        }
    }
}
