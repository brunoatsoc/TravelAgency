# Projeto de Simulação de Compra de Pacotes de Viagem

Desenvolvido por:

- Bruno Santos Costa
- Breno Gonçalves Piropo
- Valcírico Francisco de Souza Vanderlei Silva Terceiro
- Edinaldo De Oliveira Junior

Este projeto simula a compra de pacotes de viagem em uma agência de viagens. Utilizamos a linguagem C#, o framework .NET e o banco de dados SQLite para o desenvolvimento.

## Pré-requisitos

- .NET SDK
- EntityFramework

## Instruções para Execução

1. Certifique-se de ter o .NET e o EntityFramework instalados no seu computador.
2. Instale as dependências usando:
    ```bash
    dotnet restore
    ```
3. Atualize o banco de dados usando:
    ```bash
    dotnet ef database update
    ```
4. Execute o programa usando:
    ```bash
    dotnet run
    ```

## Instruções para Criar o Projeto do Zero

1. Instale o .NET e verifique a versão com os comandos:
    ```bash
    dotnet --version
    dotnet --info
    ```
2. Instale o EntityFramework:
    ```bash
    dotnet tool install --global dotnet-ef
    ```
    Verifique a instalação com:
    ```bash
    dotnet ef
    ```
3. Crie a Minimal API com o comando:
    ```bash
    dotnet new webapi --name nomeProjeto -minimal
    ```
4. Para rodar no terminal use o comando:
    ```bash
    dotnet run
    ```
5. Instale o EntityFrameworkCore dentro da pasta do projeto:
    ```bash
    dotnet add package Microsoft.EntityFrameworkCore
    ```
6. Instale as dependências do SQLite:
    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    ```
7. Instale o EntityFrameworkCore.Design:
    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
8. Instale o FluentValidation.AspNetCore:
    ```bash
    dotnet add package FluentValidation.AspNetCore
    ```
9. Instale o Microsoft.AspNetCore.Identity.EntityFrameworkCore:
    ```bash
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    ```
10. Instale o System.IdentityModel.Tokens.Jwt:
    ```bash
    dotnet add package System.IdentityModel.Tokens.Jwt
    ```
11. Para criar uma migration use:
    ```bash
    dotnet ef migrations add migrationName
    ```
    Depois, atualize o banco de dados usando:
    ```bash
    dotnet ef database update
    ```
