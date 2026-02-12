```text
# 📘 Atlas RH

![Status do Projeto](https://img.shields.io/badge/Status-Em_Desenvolvimento-blue?style=for-the-badge)
![.NET Version](https://img.shields.io/badge/.NET-9.0-purple?style=for-the-badge&logo=dotnet)
![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white)

## 🏗️ Sobre o Projeto

O **Atlas RH** é uma solução full-stack robusta para a gestão estratégica de recursos humanos. Desenvolvida com as tecnologias mais recentes do ecossistema .NET, a aplicação foca em escalabilidade, segurança e testabilidade.

A plataforma permite o gerenciamento completo de departamentos, cargos e funcionários, integrando um sistema de autenticação segura e documentação automatizada para facilitar o consumo da API.

### 🌟 Principais Características

* 🧱 **Arquitetura Limpa:** Organização estruturada em camadas (Controllers, Services, DTOs, Data).
* 🔐 **Segurança:** Autenticação e autorização via JWT (JSON Web Token).
* 🧪 **Qualidade de Código:** Cobertura de testes unitários no backend.
* 📘 **API Ready:** Documentação interativa e automática via Swagger.
* ⚡ **Modernidade:** Preparado para integração com frameworks frontend de última geração.

---

## ⚙️ Tecnologias Utilizadas

### **Backend**
* **Framework:** .NET 9 / ASP.NET Core Web API
* **ORM:** Entity Framework Core (SQL Server)
* **Documentação:** Swagger (Swashbuckle)
* **Mapeamento:** AutoMapper
* **Testes:** xUnit & Moq
* **Segurança:** JWT Authentication

### **Frontend**
* **Framework:** Angular 
* **Estilização:** Bootstrap 

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

```

---

## 🚀 Como Executar o Projeto

1. **Clone o repositório**
```bash
git clone [https://github.com/GustavoFhz/Atlas-RH.git](https://github.com/GustavoFhz/Atlas-RH.git)

```


2. **Acesse a pasta do backend**
```bash
cd Atlas-RH/Atlas-RH-API/backend

```


3. **Restaure as dependências**
```bash
dotnet restore

```


4. **Configuração do Banco de Dados**
* Atualize o arquivo `appsettings.json` com sua Connection String.
* Execute as migrations:


```bash
dotnet ef database update

```


5. **Rode a aplicação**
```bash
dotnet run

```


> 🌐 Acesse a documentação em: `https://localhost:7070/swagger`



### 🧪 Testes Unitários

Para rodar a suíte de testes automatizados, execute:

```bash
dotnet test

```

---

## 📋 Endpoints Principais

| Método | Endpoint | Descrição |
| --- | --- | --- |
| **GET** | `/api/departamentos` | Lista todos os departamentos |
| **POST** | `/api/departamentos` | Cadastra um novo departamento |
| **GET** | `/api/departamentos/{id}/funcionarios` | Lista funcionários por departamento |
| **GET** | `/api/cargos` | Lista todos os cargos |
| **POST** | `/api/cargos` | Registra um novo cargo |
| **PUT** | `/api/cargos` | Edita um cargo existente |
| **DELETE** | `/api/cargos/{id}` | Remove um cargo do sistema |

### **Padrão de Resposta**

Todas as requisições retornam um objeto padronizado:

```json
{
  "status": true,
  "mensagem": "Operação realizada com sucesso",
  "dados": { }
}

```

---

## 👨‍💻 Autor

**Gustavo Fhz** 📫 [gustavojesus79@gmail.com](mailto:gustavojesus79@gmail.com)

💼 [Meu Perfil no GitHub](https://www.google.com/search?q=https://github.com/GustavoFhz)

```

Algo mais que eu possa ajustar para você?

```
