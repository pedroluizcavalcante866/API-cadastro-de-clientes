# 🚀 Sistema de Cadastro Único de Clientes

Este é um projeto de um ecossistema completo de cadastro (CRUD) desenvolvido para demonstrar boas práticas de arquitetura, separação de responsabilidades e segurança no ecossistema .NET. O projeto conta com um backend robusto em formato de Web API e uma interface frontend limpa e responsiva.

## 🛠️ Tecnologias Utilizadas

- **Backend:** C# com ASP.NET Core Web API (.NET 6)
- **Banco de Dados:** SQL Server
- **Persistência de Dados:** ADO.NET (`SqlConnection`, `SqlCommand`) utilizando **Stored Procedures** para máxima performance e segurança contra SQL Injection.
- **Frontend:** HTML5, CSS3, Bootstrap 3 (via CDN) e jQuery/AJAX para consumo assíncrono da API.
- **Documentação:** Swagger UI

## 🏗️ Melhorias de Arquitetura Aplicadas

O projeto foi refatorado para seguir os padrões exigidos pelo mercado:
- **Padrão Repository:** Isolamento total da lógica de acesso ao banco de dados, deixando as Controllers limpas e focadas apenas nas requisições HTTP.
- **Injeção de Dependência:** Utilização do container nativo do .NET para injetar os repositórios nas controllers, facilitando testes e manutenção.
- **Segurança de Credenciais:** Remoção de strings de conexão fixas (hardcoded) no código. Agora o sistema gerencia as credenciais de forma segura através do `appsettings.json` e do ambiente de desenvolvimento (`Development`).
- **Configuração de CORS:** Implementado para permitir que o frontend HTML consuma a API localmente de forma segura e sem bloqueios do navegador.

## 🚀 Como Executar o Projeto

### 1. Configuração do Banco de Dados
1. Execute o script SQL contido na pasta `/BancoDados` (ou execute o script de criação da tabela e das Stored Procedures `Instrucoes_Filtro` e `Manutencao_Clientes`).

### 2. Configuração do Backend
1. Na raiz do projeto, localize o arquivo `appsettings.Example.json`.
2. Duplique o arquivo e renomeie a cópia para `appsettings.json` (ou `appsettings.Development.json`).
3. Ajuste a propriedade `ConnString` com as credenciais do seu servidor SQL Server local:
   ```json
   "ConnectionStrings": {
     "ConnString": "Server=SEU_SERVIDOR;Database=Nome_Do_Banco;Trusted_Connection=True;"
   }
