# 📘 Atlas RH

![Status do Projeto](https://img.shields.io/badge/Status-Em_Desenvolvimento-blue?style=for-the-badge)
![.NET Version](https://img.shields.io/badge/.NET-9.0-purple?style=for-the-badge&logo=dotnet)

## 🏗️ Sobre o Projeto

O **Atlas RH** é uma solução full-stack robusta para a gestão estratégica de recursos humanos. Desenvolvida com as tecnologias mais recentes do ecossistema .NET, a aplicação foca em escalabilidade, segurança e testabilidade.

Ela permite o gerenciamento completo de departamentos, cargos e funcionários, integrando um sistema de autenticação segura e documentação automatizada para facilitar o consumo da API.

### Principais Características

* 🧱 **Arquitetura Limpa:** Organização estruturada em camadas (Controllers, Services, DTOs, Data).
* 🔐 **Segurança:** Autenticação e autorização via JWT (JSON Web Token).
* 🧪 **Qualidade de Código:** Cobertura de testes unitários no backend.
* 📘 **API Ready:** Documentação interativa e automática via Swagger.
* ⚡ **Modernidade:** Preparado para integração com frameworks frontend de última geração.

---

## ⚙️ Tecnologias Utilizadas

### Backend
* **Framework:** .NET 9 / ASP.NET Core Web API
* **ORM:** Entity Framework Core (SQL Server)
* **Documentação:** Swagger (Swashbuckle)
* **Mapeamento:** AutoMapper
* **Testes:** xUnit & Moq
* **Segurança:** JWT Authentication

### Frontend
* **Framework:** Angular 
* **Estilização:**  Bootstrap 

---

## 📂 Estrutura de Pastas (Backend)



```text
backend/
 ├── Controllers/      # Pontos de entrada da API (REST)
 ├── Services/         # Lógica de negócio e regras de domínio
 ├── Dto/              # Objetos de transferência de dados
 ├── Data/             # Contexto do Banco de Dados (EF Core)
 ├── Config/           # Configurações de Middlewares (Swagger, etc)
 ├── Tests/            # Testes Unitários e Mocking
 └── Program.cs        # Inicialização da aplicação

---
🚀 Como Executar o ProjetoClone o repositórioBashgit clone [https://github.com/GustavoFhz/Atlas-RH.git](https://github.com/GustavoFhz/Atlas-RH.git)
Acesse a pasta do backendBashcd Atlas-RH/Atlas-RH-API/backend
Restaure as dependênciasBashdotnet restore
Configuração do Banco de DadosAtualize o arquivo .env (ou appsettings.json) com sua Connection String.Execute as migrations:Bashdotnet ef database update
Rode a aplicaçãoBashdotnet run
Acesse a documentaçãoAbra o navegador em: https://localhost:7070/swagger🧪 Testes UnitáriosA qualidade do Atlas RH é garantida por testes automatizados. Para rodar a suíte de testes, execute:Bashdotnet test

Nota: Utilizamos xUnit para estrutura de testes e Moq para isolar as dependências dos Services e Controllers.📋 Endpoints PrincipaisMétodoEndpointDescriçãoGET/api/departamentosLista todos os departamentosPOST/api/departamentosCadastra um novo departamentoGET/api/departamentos/{id}/funcionariosLista funcionários por departamentoGET/api/cargosLista todos os cargosPOST/api/cargosRegistra um novo cargoPUT/api/cargosEdita um cargo existenteDELETE/api/cargos/{id}Remove um cargo do sistemaPadrão de RespostaTodas as requisições retornam um objeto padronizado:JSON{
  "status": true,
  "mensagem": "Operação realizada com sucesso",
  "dados": { }
}
👨‍💻 AutorGustavo Fhz 📫 gustavojesus79@gmail.com💼 Meu Perfil no GitHub
