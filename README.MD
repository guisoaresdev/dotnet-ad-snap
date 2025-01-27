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

4. Altere a Connection String no arquivo appsetings.Development.json dentro da pasta api:

4.1. Você deve selecionar com o botão direito no banco de dados "anuncios" no SSMS e verificar em propriedades o propriétario do banco e substituir na string de conexão
```
(Nas propriedades do BD)
Proprietário: Makarov\gui_c

...
"ConnectionStrings": {
"DefaultConnection": "Data Source=Makarov\\SQLEXPRESS;Initial Catalog=anuncios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
},
...
```

Neste trecho, logo após Data Source:
```
"DefaultConnection": "Data Source=Makarov\\SQLEXPRESS;
````

5. Entre na pasta api e rode as migrations:
```
dotnet ef database update
```

6. Restaure as dependências do projeto:

```
dotnet restore
```

7. Dentro da pasta do frontend, copie o .env.example para um novo arquivo .env:
```
cp .env.example .env
```

8. Substitua a URL da API para que o front consiga realizar as requisições: 
```
REACT_APP_API_URL="http://localhost:5254/api"
```

9. Instale as dependências do front:
```
npm install
```

10. Execute a aplicação através do comando:
```
npm run start:all
```
Isso irá levantar tanto a API Web usando .NET, quanto o frontend em React.

### Outros comandos

Rodar a API:
```
npm run start:api
```
