using backend.Data;
using backend.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;


namespace Atlas_RH_Testes
{
    public class DepartamentoTeste : IDisposable
    {
        private readonly AppDbContext _context;
        public DepartamentoTeste()
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
        public async Task Deve_Adicionar_Departamento()
        {
            //Arrange - Preparar o cenário
            var departamento = new DepartamentoModel {
                Nome = "Tecnologia da Informação",
                Descricao = "Responsável pela infraestrutura e desenvolvimento de sistemas da empresa"
            };

            //Act - Executar a ação
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            //Assert - Verificar o resultado
            var resultado = await _context.Departamentos.FirstOrDefaultAsync(d => d.Nome == departamento.Nome);
            resultado.Should().NotBeNull();
            resultado!.Nome.Should().Be(departamento.Nome);
            resultado.Descricao.Should().Be(departamento.Descricao);
        }

        [Fact]
        public async Task Deve_Listar_Departamentos()
        {
            //Arrange - Preparar o cenário
            _context.Departamentos.AddRange(
            new DepartamentoModel { Nome = "Recursos Humanos", Descricao = "Gerencia contratações, benefícios e o bem-estar dos colaboradores" },
            new DepartamentoModel { Nome = "Tecnologia da Informação", Descricao = "Responsável pela infraestrutura e desenvolvimento de sistemas da empresa" }
            );
            await _context.SaveChangesAsync();

            //Act - Executar a ação
            var departamentos = await _context.Departamentos.ToListAsync();

            //Assert - Verificar o resultado
            departamentos.Should().HaveCount(2);
            departamentos.Should().Contain(d => d.Nome == "Recursos Humanos");
            departamentos.Should().Contain(d => d.Nome == "Tecnologia da Informação");
        }

        [Fact]
        public async Task Deve_Atualizar_Departamento()
        {
            //Arrange - Preparar o cenário
            var departamento = new DepartamentoModel
            {
                Nome = "Recursos Humanos",
                Descricao = "Gerencia contratações, benefícios e o bem-estar dos colaboradores"
            };
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            //Act - Executar a ação
            departamento.Nome = "Financeiro";
            departamento.Descricao = "Controla o fluxo de caixa, pagamentos, orçamentos e planejamento financeiro";
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();

            //Assert - Verificar o resultado
            var resultado = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == departamento.Id);
            resultado.Should().NotBeNull();
            resultado!.Nome.Should().Be("Financeiro");
            resultado.Descricao.Should().Be("Controla o fluxo de caixa, pagamentos, orçamentos e planejamento financeiro");
        }

        [Fact]
        public async Task Deve_Remover_Departamento()
        {
            //Arrange - Preparar o cenário
            var departamento = new DepartamentoModel
            {
                Nome = "Temporário",
                Descricao = "Departamento por tempo determinado"
            };
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();


            //Act - Executar a ação
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            //Assert - Verificar o resultado
            var resultado = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == departamento.Id);
            resultado.Should().BeNull();
        }

    }
}
