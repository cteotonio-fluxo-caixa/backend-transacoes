# Projeto Fluxo de Caixa - Serviço de Controle de Transações
Serviço dedicado ao controle de movimentação financeira

FORMATO: 1A
HOST-DEV: http://localhost:XXXX/v1
HOST-DOCKER: http://localhost:8080/v1


# EndPoints
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
  
## Error (object)
+ code: 500 (number) - Status code
+ message (string) - Mensagem do status
  
## Created (object)
+ Mensagem (string) - Mensagem de confirmação
+ transacao (object) - Transação adicionada

## Error400 (Object)
+ Mensagem (string) - Mensagem de erro
+ erro (string) - Lista de erros ocorridos
