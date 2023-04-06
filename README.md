# Fluxo de Caixa - Carrefour
Lançamentos de Fluxo de Caixa

## Pré-requisitos

1. Instale o .NET SDK 7.0 ou posterior: https://dotnet.microsoft.com/download/dotnet/7.0
2. Instale o Visual Studio 2022 ou Visual Studio Code com a extensão C# (Omnisharp) para facilitar o desenvolvimento.
3. Instale o SQL Server ou modifique o projeto para usar outro banco de dados suportado pelo Entity Framework Core.

## Passos para executar o projeto localmente

1. Clone o repositório do projeto para sua máquina local usando o comando `git clone` ou baixe e extraia o arquivo ZIP do projeto.

2. Abra o projeto no Visual Studio 2022 ou no Visual Studio Code.

3. Atualize a string de conexão do banco de dados no arquivo `appsettings.json` na raiz do projeto, substituindo-a pela string de conexão do seu banco de dados local.

   ```
   json
   ```

1. ```
   {
       "ConnectionStrings": {
           "DefaultConnection": "suaconnectionstringaqui"
       },
       // Outras configurações
   }
   ```

2. Abra o terminal integrado no Visual Studio Code ou o terminal de desenvolvedor no Visual Studio e navegue até a pasta do projeto.

3. Execute o comando `dotnet ef database update` para aplicar as migrações e criar o banco de dados. Caso esteja utilizando o Visual Studio o comando pode ser `Update-Database`.

4. Execute o comando `dotnet run` para iniciar o servidor de desenvolvimento local. O servidor estará disponível no endereço `https://localhost:5001`.

5. Abra seu navegador e acesse `https://localhost:5001` para visualizar e interagir com a aplicação.

## Dicas adicionais

- Caso encontre problemas relacionados a SSL ao executar o projeto localmente, siga as instruções de desenvolvimento do ASP.NET Core para resolver problemas de certificado SSL: https://docs.microsoft.com/pt-br/aspnet/core/security/enforcing-ssl?view=aspnetcore-6.0&tabs=visual-studio

  

Essa descrição fornece informações sobre os pré-requisitos necessários e as etapas para executar o projeto localmente. Sinta-se à vontade para adaptá-la conforme necessário para o seu projeto específico.
