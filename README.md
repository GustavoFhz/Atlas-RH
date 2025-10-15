# 📘 Atlas RH API

## 🏗️ Sobre o projeto

O **Atlas RH API** é uma aplicação **backend** desenvolvida em **.NET 9**, voltada para **gestão de recursos humanos** — permitindo o gerenciamento de **departamentos, cargos e funcionários**.

O projeto segue boas práticas de arquitetura, como:
- 🧱 Separação por camadas (**Controllers**, **Services**, **DTOs**, **Data**);
- 🔁 Retornos padronizados via **ResponseModel**;
- 🔐 Autenticação **JWT**;
- 📘 Documentação automática com **Swagger**.

---

## ⚙️ Tecnologias utilizadas

- 🧩 **.NET 9 / ASP.NET Core Web API**
- 🗄️ **Entity Framework Core**
- 💾 **SQL Server**
- 📜 **Swagger (Swashbuckle)**
- 🔄 **AutoMapper**
- 🔐 **JWT Authentication**

---

## 📂 Estrutura principal

backend/
 ├── Controllers/
 │   ├── CargoController.cs
 │   ├── DepartamentoController.cs
 │   ├── FuncionarioController.cs
 │   ├── LoginController.cs
 │   └── UsuarioController.cs
 │
 ├── Services/
 │   ├── Cargo/
 │   ├── Departamento/
 │   └── Funcionario/
 │
 ├── Dto/
 │   ├── Cargo/
 │   ├── Departamento/
 │   ├── Funcionario/
 │   ├── Senha/
 │   └── Usuario/
 │
 ├── Data/
 │   └── AppDbContext.cs
 │
 ├── Config/
 │   └── SwaggerConfig.cs
 │
 └── Program.cs

🚀 Como executar o projeto

Clone o repositório:
git clone https://github.com/GustavoFhz/Atlas-RH.git

Acesse a pasta do backend:
cd Atlas-RH/Atlas-RH-API/backend

Restaure as dependências:
dotnet restore

Configure a conexão com o banco de dados:

No arquivo .env, atualize a string de conexão.
dotnet ef database update

Rode a aplicação:
dotnet run

Acesse a documentação:
https://localhost:7070/swagger

📋 Endpoints principais

| Método | Endpoint                               | Descrição                           |
| :----: | :------------------------------------- | :---------------------------------- |
|   GET  | `/api/departamentos`                   | Lista todos os departamentos        |
|  POST  | `/api/departamentos`                   | Cadastra um novo departamento       |
|   GET  | `/api/departamentos/{id}/funcionarios` | Lista funcionários por departamento |
|   GET  | `/api/cargos`                          | Lista todos os cargos               |
|  POST  | `/api/cargos`                          | Registra um cargo                   |
|   PUT  | `/api/cargos`                          | Edita um cargo                      |
| DELETE | `/api/cargos/{id}`                     | Remove um cargo                     |

🧠 Padrão de resposta
{
  "status": true,
  "mensagem": "Operação realizada com sucesso",
  "dados": { }
}

👨‍💻 Autor
Gustavo Fhz
📧 gustavojesus79@gmail.com

💼 github.com/GustavoFhz
