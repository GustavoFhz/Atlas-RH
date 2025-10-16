using backend.Config;
using backend.Data;
using backend.Services;
using backend.Services.Cargo;
using backend.Services.Departamento;
using backend.Services.Funcionario;
using backend.Services.Senha;
using backend.Services.Usuario;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// Carrega o .env antes de criar o builder
Env.Load();

// Pegar chave do JWT
var tokenSecret = Environment.GetEnvironmentVariable("JWT_SECRET")
                  ?? throw new Exception("JWT_SECRET não encontrado.");

var builder = WebApplication.CreateBuilder(args);

// ----------------- Configuração do Banco -----------------
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"Server={dbHost};Database={dbName};User Id={dbUser};Password={dbPass};TrustServerCertificate=True;";

// Registrar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// ----------------- Serviços -----------------
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<ISenhaInterface, SenhaService>();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();
builder.Services.AddScoped<IDepartamentoInterface, DepartamentoService>();
builder.Services.AddScoped<ICargoInterface, CargoService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

// ----------------- Swagger -----------------
builder.Services.AddSwaggerConfig();

// ----------------- Autenticação JWT -----------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenSecret)),
            ValidateAudience = false,
            ValidateIssuer = false            
        };
    });

var app = builder.Build();



app.UseSwaggerConfig();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
