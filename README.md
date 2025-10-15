🏗️ Sobre o projeto
O Atlas RH API é uma aplicação backend desenvolvida em .NET 9 voltada para gestão de recursos humanos, permitindo o gerenciamento de departamentos, cargos e funcionários. 
O projeto foi estruturado seguindo boas práticas de arquitetura, incluindo separação por camadas (Controllers, Services, DTOs e Data), retornos padronizados, autentificação e documentação via Swagger.

⚙️ Tecnologias utilizadas
- .NET 9 / ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- AutoMapper
- JWT Authentication 

📂 Estrutura principal
backend/
 ├── Controllers/
 │   ├── CargoController.cs
 │   ├── DepartamentoController.cs
 │   └── FuncionarioController.cs
 │   └── LoginController.cs
 |   └── UsuarioController.cs
 ├── Services/
 │   ├── Cargo/
 │   ├── Departamento/
 │   └── Funcionario/
 │  
 ├── Dto/
 │   ├── Cargo/
 │   ├── Departamento/
 │   └── Funcionario/
 |   └── Senha/
 |   └── Usuario/
 │
 ├── Data/
 │   └── AppDbContext.cs
 │
 ├── Config/
 │   └── SwaggerConfig.cs
 │
 └── Program.cs

🚀 Como executar o projeto
1. Clone o repositório:
   git clone https://github.com/GustavoFhz/Atlas-RH.git

2. Acesse a pasta do backend:
   cd Atlas-RH/Atlas-RH-API/backend

3. Restaure as dependências:
   dotnet restore

4. Configure a conexão com o banco de dados no arquivo:
   appsettings.json

5. Execute as migrações:
   dotnet ef database update

6. Rode a aplicação:
   dotnet run

7. Acesse a documentação no navegador:
   https://localhost:7070/swagger

📋 Endpoints principais
| Método | Endpoint | Descrição |
|--------|-----------|------------|
| GET | /api/departamentos | Lista todos os departamentos |
| POST | /api/departamentos | Cadastra um novo departamento |
| GET | /api/departamentos/{id}/funcionarios | Lista funcionários por departamento |
| GET | /api/cargos | Lista todos os cargos |
| POST | /api/cargos | Registra um cargo |
| PUT | /api/cargos | Edita um cargo |
| DELETE | /api/cargos/{id} | Remove um cargo |

🧠 Padrão de resposta
{
  "status": true,
  "mensagem": "Operação realizada com sucesso",
  "dados": { ... }
}

👨‍💻 Autor
Gustavo Fhz
📧 gustavojesus79@gmail.com
💼 GitHub - https://github.com/GustavoFhz
