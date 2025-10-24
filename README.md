📘 Atlas RH
🏗️ Sobre o projeto

O Atlas RH é uma aplicação full-stack para gestão de recursos humanos, construída com .NET 9 no backend e tecnologias modernas no frontend.
Ela permite gerenciar departamentos, cargos e funcionários, garantindo autenticação segura, testes automatizados e documentação clara.

Principais características:

🧱 Arquitetura organizada por camadas (Controllers, Services, DTOs, Data)

🔐 Autenticação JWT para segurança

🧪 Testes unitários no backend para garantir qualidade

📘 Documentação automática com Swagger

⚡ Integração com frontend moderno

⚙️ Tecnologias utilizadas
Backend

🧩 .NET 9 / ASP.NET Core Web API

🗄️ Entity Framework Core (SQL Server)

📜 Swagger (Swashbuckle)

🔄 AutoMapper

🧪 xUnit / Moq (testes unitários)

🔐 JWT Authentication

Frontend

💻 Angular / React / Vue (colocar a que você usa)

🎨 Bootstrap / Tailwind CSS (estilização)

📂 Estrutura principal do backend
backend/
 ├── Controllers/
 │   ├── CargoController.cs
 │   ├── DepartamentoController.cs
 │   ├── FuncionarioController.cs
 │   ├── LoginController.cs
 │   └── UsuarioController.cs
 ├── Services/
 │   ├── Cargo/
 │   ├── Departamento/
 │   └── Funcionario/
 ├── Dto/
 │   ├── Cargo/
 │   ├── Departamento/
 │   ├── Funcionario/
 │   ├── Senha/
 │   └── Usuario/
 ├── Data/
 │   └── AppDbContext.cs
 ├── Config/
 │   └── SwaggerConfig.cs
 ├── Tests/
 │   └── UnitTests/
 └── Program.cs
 
🚀 Como executar o projeto

1. Clone o repositório
git clone https://github.com/GustavoFhz/Atlas-RH.git
2. Acesse a pasta do backend
cd Atlas-RH/Atlas-RH-API/backend
3. dotnet restore
4. Configure a conexão com o banco de dados
Atualize o arquivo .env com a string de conexão correta
dotnet ef database update
5. Execute a aplicação
dotnet run
6. Acesse a documentação
https://localhost:7070/swagger


🧪 Testes unitários

Para rodar os testes:
dotnet test

Todos os testes são implementados usando xUnit e Moq, garantindo que Services e Controllers funcionem corretamente.

📋 Endpoints principais
Método	Endpoint	Descrição
GET	/api/departamentos	Lista todos os departamentos
POST	/api/departamentos	Cadastra um novo departamento
GET	/api/departamentos/{id}/funcionarios	Lista funcionários por departamento
GET	/api/cargos	Lista todos os cargos
POST	/api/cargos	Registra um cargo
PUT	/api/cargos	Edita um cargo
DELETE	/api/cargos/{id}	Remove um cargo

Padrão de resposta
{
  "status": true,
  "mensagem": "Operação realizada com sucesso",
  "dados": { }
}

👨‍💻 Autor

Gustavo Fhz
📧 gustavojesus79@gmail.com

💼 GitHub
