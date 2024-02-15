# Projeto Fluxo de Caixa - Serviço de Controle de Transações
Serviço dedicado ao controle de movimentação financeira

*******
Tabelas de conteúdo 
 1. [EndPoints](#endipoints)
      * [Transação](#transa-o-api-transacao)
      * [Método de Pagamento](#metododepagamento)
      * [Categoria da Transação](#categoriadatransacao)
 3. [Cobertura de Teste](#coberturadetestes)
*******

<div id='endipoints'/>  

# EndPoints
    
FORMATO: 1A
HOST-DEV: http://localhost:XXXX/v1
HOST-DOCKER: http://localhost:8080/v1

<div id='transa-o-api-transacao'/> 

## Transação [/api/Transacao]
### Criar uma Transacao [/] [POST]
+ Request Criar uma transacao 
    + Headers
            Accept: application/json
            Content-Type: application/json
    + Attributes (TransacaoRequest)
+ Response 200 (application/json)
    + Attributes (Created)
+ Response 400 (application/json)
    + Attributes (Error400)
+ Response 500 (application/json)
    + Attributes (Error)
#### body
```json
{
  "valor": 0,
  "dataTransacao": "2024-02-14T13:12:12.870Z",
  "isCredito": true,
  "descricao": "string",
  "criadoPorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "criadoEm": "2024-02-14T13:12:12.870Z",
  "excluido": true,
  "categoriaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "metodoPagamentoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```
#### Curl
```curl -X 'POST' \
  'http://host:port/api/Transacao' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d 'body'
```
#### Request URL
```
http://host:port/api/Transacao
```
<div id='metododepagamento'/> 
 
## Método de Pagamento [/api/MetodoPagamento]
### Criar um Método de Pagameto [/] [POST]
+ Request Criar um método de pagamento 
    + Headers
            Accept: application/json
            Content-Type: application/json
    + Attributes (MetodoPagamentoRequest)
+ Response 200 (application/json)
    + Attributes (MetodoPagamentoResponse)
+ Response 400 (application/json)
    + Attributes (Error400)
+ Response 500 (application/json)
    + Attributes (Error)
#### body
```json
{
  "nome": "Nome do metodo de pagamento",
  "descricao": "Decrição do método de pagamento"
}
```
#### Curl
```curl -X 'POST' \
  'http://host:port/api/MetodoPagamento' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d 'body'
```
#### Request URL
```
http://host:port/api/MetodoPagamento
```

### Listar Métodos de Pagameto [/listartodos] [GET]
+ Listar todos os métodos de pagamento 
    + Headers
            Accept: application/json
            Content-Type: application/json
+ Response 200 (application/json)
    + Attributes (Lista MetodoPagamentoResponse)
+ Response 400 (application/json)
    + Attributes (Error400)
+ Response 500 (application/json)
    + Attributes (Error)
      
#### Curl
```curl -X 'GET' \
  'http://host:port/api/MetodoPagamento/listartodos' \
  -H 'accept: text/plain' \
```
#### Request URL
```
http://host:port/api/MetodoPagamento/listartodos
```
<div id='categoriadatransacao'/> 
 
## Categoria da Transação [/api/MetodoPagamento]
### Criar uma Categoria da Transação [/] [POST]
+ Request Criar categoria da transação 
    + Headers
            Accept: application/json
            Content-Type: application/json
    + Attributes (CategoriaTransacaoRequest)
+ Response 200 (application/json)
    + Attributes (CategoriaTransacaoResponse)
+ Response 400 (application/json)
    + Attributes (Error400)
+ Response 500 (application/json)
    + Attributes (Error)
#### body
```json
{
  "nome": "Nome da categoria da transacao",
  "descricao": "Decrição da categoria da transacao"
}
```
#### Curl
```curl -X 'POST' \
  'http://host:port/api/CategoriaTransacao' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d 'body'
```
#### Request URL
```
http://host:port/api/CategoriaTransacao
```

### Listar CategoriaTransacao [/listartodos] [GET]
+ Listar todas as categorias de transação 
    + Headers
            Accept: application/json
            Content-Type: application/json
+ Response 200 (application/json)
    + Attributes (Lista CategoriaTransacaoResponse)
+ Response 400 (application/json)
    + Attributes (Error400)
+ Response 500 (application/json)
    + Attributes (Error)
      
#### Curl
```curl -X 'GET' \
  'http://host:port/api/CategoriaTransacao/listartodos' \
  -H 'accept: text/plain' \
```
#### Request URL
```
http://host:port/api/CategoriaTransacao/listartodos
```

# Estrutura de Dados
## TransacaoRequest (object)
+ valor (number) - Valor da transação
+ dataTransacao (string) - Data da Transação
+ isCredito (boolean) - Indica se a operação é Crédito ou Débito
+ descricao (string) - Descrição da transação
+ criadoPorId string($uuid) - Id do Usuário que criou o registro
+ criadoEm string($date-time) - Data de criação do registro
+ excluido (boolean) - Indica se o registro foi excluído
+ categoriaId (string($uuid)) - Código da Categoria
+ metodoPagamentoId (string($uuid)) - Código do Método de Pagamento

## MetodoPagamentoRequest (object)
+ nome (string) - Nome do método de pagamento
+ descrição (string) - Descrição do método de pagamento

## MetodoPagamentoResponse (object)
+ id (string($uuid)) - Código do Método de Pagamento
+ nome (string) - Nome do método de pagamento
+ descrição (string) - Descrição do método de pagamento

## CategoriaTransacaoRequest (object)
+ nome (string) - Nome da categoria da transação
+ descrição (string) - Descrição da categoria da transação

## CategoriaTransacaoResponse (object)
+ id (string($uuid)) - Código da categoria da transação
+ nome (string) - Nome da categoria da transação
+ descrição (string) - Descrição da categoria da transação
  
## Error (object)
+ code: 500 (number) - Status code
+ message (string) - Mensagem do status
  
## Created (object)
+ Mensagem (string) - Mensagem de confirmação
+ transacao (object) - Transação adicionada

## Error400 (Object)
+ Mensagem (string) - Mensagem de erro
+ erro (string) - Lista de erros ocorridos

*******

<div id='coberturadetestes'/>  

# Cobertura de testes
Como sabemos ter uma boa cobertura de testes é muito importante para evitarmos problemas antes da disponibilização do projeto em produção.
Para este projeto foi utilizado [Coverlet](https://github.com/coverlet-coverage/coverlet), uma alternativa de software livre de coletor interno.
Nas versões mais recentes do visual studio você já conta com ele.
O Coverlet irá gerar um arquivos XML com as informações dos testes, mas precisamos visualizar isto de uma maneira mais amigável e, para resolver testa tarefa podemos utiliza o [ReportGenerator](https://www.nuget.org/packages/dotnet-reportgenerator-globaltool), abaixo segue os passos para configurar e gerar o relatório.

Configure o ReportGenerator como um ferramenta global do .NET

```
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.2.1
```

Execute a ferramenta de teste no diretório onde se ecnontra a solução do projeto

```
dotnet test --collect:"XPlat Code Coverage"
```

Após a execução do teste será apresentado o **Anexo** normalmente localizado **TestResults** do seu projeto de testes.
A cada execução dos teste é gerado uma nova pasta GUID da utlima execução, você irá precisar desta informação para o próximo passo.
Ex.: Diretório completo da saolução\TestResults\**a7ad81f8-f6b6-4542-a3b5-c69d305e6b36**\coverage.cobertura.xml

Agora vamos gerar o relatório
Ainda na pasta da solução do projeto digite o seguinte commando

```
reportgenerator -reports:C:\Caminho Completo\backend-transacoes\src\SlnTransacoes\Transacoes.Testes\TestResults\a7ad81f8-f6b6-4542-a3b5-c69d305e6b36\coverage.cobertura.xml -targetdir:"coveragereport" -reporttypes:Html
```

Ao final da execução deste comando será criada uma pasta na solução do projeto chamada coveragereport, nesta conterá o conteúdo do relatório no formato HTML.
Clique no arquivo index.html e veja as informações de cobertura por vários níveis, Projeto, Classe e Métodos
Exemplo do relatório gerado.



