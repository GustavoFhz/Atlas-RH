using backend.Data;
using backend.Enum;
using backend.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Atlas_RH_Testes;

public class FuncionarioTeste :IDisposable
{
    private readonly AppDbContext _context;
    public FuncionarioTeste()
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
    public async Task Deve_Adicionar_Funcionario()
    {
        //Arrange - Preparar o cenário
        var funcionario = new FuncionarioModel
        {
            Nome = "Gustavo",
            Cpf = "12345678",
            Email = "gustavo@gmail.com",
            Salario = 5000,
            DataAdmissao = DateTime.Now,
            Status = StatusFuncionario.Ativo,
            DepartamentoId = 1,
            CargoId = 1
        };

        //Act - Executar a ação
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();

        //Assert - Verificar o resultado
        var resultado = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Nome == funcionario.Nome);
        resultado.Should().NotBeNull();
        resultado!.Nome.Should().Be(funcionario.Nome);
        resultado.Cpf.Should().Be(funcionario.Cpf);
        resultado.Email.Should().Be(funcionario.Email);
        resultado.Salario.Should().Be(funcionario.Salario);
        resultado.DataAdmissao.Should().Be(funcionario.DataAdmissao);
        resultado.Status.Should().Be(funcionario.Status);
        resultado.DepartamentoId.Should().Be(funcionario.DepartamentoId);
        resultado.CargoId.Should().Be(funcionario.CargoId);
    }
    [Fact]
    public async Task Deve_Listar_Funcionarios()
    {
        //Arrange - Preparar o cenário
        _context.Funcionarios.AddRange(
        new FuncionarioModel { Nome = "Gustavo", Cpf = "12345678", Email = "gustavo@gmail.com", Salario = 5000, DataAdmissao=DateTime.Now,Status =StatusFuncionario.Ativo, DepartamentoId = 1, CargoId = 1 },
        new FuncionarioModel { Nome = "Lucas", Cpf = "87654321", Email = "lucas@gmail.com", Salario = 6000, DataAdmissao = DateTime.Now, Status = StatusFuncionario.Inativo, DepartamentoId = 2, CargoId = 2 }
        );
        await _context.SaveChangesAsync();

        //Act - Executar a ação
        var funcionarios = await _context.Funcionarios.ToListAsync();

        // Assert - Verificar o resultado
        funcionarios.Should().HaveCount(2);

        var funcionario1 = funcionarios.FirstOrDefault(f => f.Nome == "Gustavo");
        funcionario1.Should().NotBeNull();
        funcionario1!.Cpf.Should().Be("12345678");
        funcionario1.Email.Should().Be("gustavo@gmail.com");
        funcionario1.Salario.Should().Be(5000);
        funcionario1.Status.Should().Be(StatusFuncionario.Ativo);
        funcionario1.DepartamentoId.Should().Be(1);
        funcionario1.CargoId.Should().Be(1);

        var funcionario2 = funcionarios.FirstOrDefault(f => f.Nome == "Lucas");
        funcionario2.Should().NotBeNull();
        funcionario2!.Cpf.Should().Be("87654321");
        funcionario2.Email.Should().Be("lucas@gmail.com");
        funcionario2.Salario.Should().Be(6000);
        funcionario2.Status.Should().Be(StatusFuncionario.Inativo);
        funcionario2.DepartamentoId.Should().Be(2);
        funcionario2.CargoId.Should().Be(2);
    }

    [Fact]
    public async Task Deve_Atualizar_Funcionario() 
    {
        //Arrange - Preparar o cenário
        var funcionario = new FuncionarioModel
        {
            Nome = "Gustavo",
            Cpf = "12345678",
            Email = "gustavo@gmail.com",
            Salario = 5000,
            DataAdmissao = DateTime.Now,
            Status = StatusFuncionario.Ativo,
            DepartamentoId = 1,
            CargoId = 1
        };

        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();

        //Act - Executar a ação
        funcionario.Nome = "Gustavo";
        funcionario.Cpf = "12345678";
        funcionario.Email = "gustavo@gmail.com";
        funcionario.Salario = 5000;
        funcionario.DataAdmissao = DateTime.Now;
        funcionario.Status = StatusFuncionario.Ativo;
        funcionario.DepartamentoId = 1;
        funcionario.CargoId = 1;

        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();

        // Assert - Verificar o resultado
        var resultado = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == funcionario.Id);
        resultado.Should().NotBeNull();
        resultado!.Nome.Should().Be("Gustavo");
        resultado.Cpf.Should().Be("12345678");
        resultado.Email.Should().Be("gustavo@gmail.com");
        resultado.Salario.Should().Be(5000);
        resultado.DataAdmissao.Date.Should().Be(funcionario.DataAdmissao.Date); 
        resultado.Status.Should().Be(StatusFuncionario.Ativo);
        resultado.DepartamentoId.Should().Be(1);
        resultado.CargoId.Should().Be(1);
    }

    [Fact]
    public async Task Deve_Remover_Funcionario()
    {       
        //Arrange - Preparar o cenário
        var funcionario = new FuncionarioModel
        {

            Nome = "Gustavo",
            Cpf = "12345678",
            Email = "gustavo@gmail.com",
            Salario = 5000,
            DataAdmissao = DateTime.Now,
            Status = StatusFuncionario.Ativo,
            DepartamentoId = 1,
            CargoId = 1
        };
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();


        //Act - Executar a ação
        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();

        //Assert - Verificar o resultado
        var resultado = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == funcionario.Id);
        resultado.Should().BeNull(); 
    }
}


