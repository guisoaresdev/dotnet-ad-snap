# Web API Anuncios

## Sobre o projeto

Esse projeto disponibiliza uma aplicação Web para cadastrar anuncios, persistindo os dados através de uma REST API utilizando .NET Core e o Entity Framework.
---

## Tecnologias utilizadas

- **.NET LTS Version 8.0**
- **C#**
- **React**
- **Entity Framework Core** (para persistência de dados)
- **Swagger** (para documentação e testes da API)
- **SQL Server** (banco de dados)
---

## Rodando o projeto

### Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (ou SQL Server Express) instalado. Se você não tem o SQL Server instalado, você pode usar o SQL Server Express.
- SSMS (SQL Server Management Studio) ou uma ferramenta similar para gerenciar seu banco de dados.

### Configuração do ambiente

1. Clone o repositório para sua máquina:
```
git clone https://github.com/guisoaresdev/dotnet-webapi-anuncios.git
```
2. Navegue até o diretório do projeto:

```
cd dotnet-webapi-anuncios
```

3. Configure o banco de dados:

Abra o SSMS (ou outra ferramenta de sua preferência para SQL Server).
Crie um novo banco de dados chamado "anuncios" (ou o nome de sua preferência).

4. Rode as migrations:
```
dotnet ef database update
```

5. Restaure as dependências do projeto:

```
dotnet restore
```

6. Inicie o servidor de desenvolvimento:

```
dotnet watch run
```
