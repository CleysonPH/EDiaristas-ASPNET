# E-Diaristas

Implementação em ASP.NET Core da aplicação E-Diaristas desenvolvida na imersão Multi-stack da TreinaWeb.

## Executando o projeto

1. Clone o repositório e entre na pasta do projeto.

```sh
git clone https://github.com/CleysonPH/EDiaristas-ASPNET.git
cd EDiaristas-ASPNET
```

2. Instale as dependências do projeto.

```sh
dotnet restore
```

3. Execute as migrações do banco de dados.

```sh
dotnet ef database update
```

4. Execute o projeto

```sh
dotnet run
```

Na primeira execução do projeto é criado o usuário inicial que possui as seguintes credenciais:

- Login: admin@mail.com
- Senha: senha@123

## Rotas do Admin

| Rota                                 | Funcionalidade                                | Reque autenticação? | Tipo Usuário |
| ------------------------------------ | --------------------------------------------- | ------------------- | ------------ |
| /admin/login                         | Realizar login na aplicação administrativa    | Não                 | -            |
| /admin/logout                        | Realizar o logout na aplicação administrativa | Sim                 | Admin        |
| /admin/servicos                      | Listar todos os serviços cadastrados          | Sim                 | Admin        |
| /admin/servicos/cadastrar            | Cadastrar novo serviço                        | Sim                 | Admin        |
| /admin/servicos/{id}/editar          | Editar os dados de um serviço                 | Sim                 | Admin        |
| /admin/servicos/{id}/excluir         | Excluir um serviço                            | Sim                 | Admin        |
| /admin/usuarios                      | Listar todos os usuários cadastrados          | Sim                 | Admin        |
| /admin/usuarios/cadastrar            | Cadastrar um novo usuário com o perfil ADMIN  | Sim                 | Admin        |
| /admin/usuarios/{id}/editar          | Editar os dados de um usuário                 | Sim                 | Admin        |
| /admin/usuarios/{id}/excluir         | Excluir um usuário                            | Sim                 | Admin        |
| /admin/usuarios/alterar-senha        | Alterar a senha do usuário logado             | Sim                 | Admin        |
| /admin/diarias                       | Lista as diárias                              | Sim                 | Admin        |
| /admin/diarias/{diariaId}/transferir | Muda o status da diária para transferido      | Sim                 | Admin        |

## Rotas da API

| Verbo | Rota                                      | Funcionalidade                                               | Requer Autenticação? | Tipo Usuário      |
| ----- | ----------------------------------------- | ------------------------------------------------------------ | -------------------- | ----------------- |
| GET   | /api                                      | Lista os links iniciais da api                               | Não                  | -                 |
| GET   | /api/servicos                             | Listar serviços cadastrados                                  | Não                  | -                 |
| GET   | /api/enderecos                            | Buscar endereço por cep                                      | Não                  | -                 |
| GET   | /api/diaristas/localidades                | Listar diaristas que atendem um determinado cep              | Não                  | -                 |
| GET   | /api/diaristas/disponibilidade            | Verifica a disponibilidade de atendimento por cep            | Não                  | -                 |
| POST  | /api/usuarios                             | Realiza o cadastro de um novo usuário                        | Não                  | -                 |
| POST  | /auth/token                               | Autentica usuários através das credenciais                   | Não                  | -                 |
| POST  | /auth/refresh                             | Autentica usuários através do refresh token                  | Não                  | -                 |
| POST  | /auth/logout                              | Invalida o refresh token                                     | Não                  | -                 |
| GET   | /api/me                                   | Exibe os dados do usuário autenticado                        | Sim                  | Diarista, Cliente |
| POST  | /api/diarias                              | Cadastra uma nova diária                                     | Sim                  | Cliente           |
| POST  | /api/diarias/{id}/pagar                   | Pagar uma diária                                             | Sim                  | Cliente           |
| GET   | /api/diarias/                             | Lista as diários do usuário autenticado                      | Sim                  | Diarista, Cliente |
| GET   | /api/diarias/{id}                         | Detalha a diária                                             | Sim                  | Diarista, Cliente |
| GET   | /api/usuarios/endereco                    | Exibe os detalhes do endereço do usuário cadastrado          | Sim                  | Diarista          |
| PUT   | /api/usuarios/endereco                    | Altera o endereço do usuário cadastrado                      | Sim                  | Diarista          |
| GET   | /api/usuarios/cidades-atendidas           | Lista as cidades atendidas pelo usuário logado               | Sim                  | Diarista          |
| PUT   | /api/usuarios/cidades-atendidas           | Atualiza a lista as cidades atendidas pelo usuário logado    | Sim                  | Diarista          |
| GET   | /api/oportunidades                        | Lista as diarias em que o diarista logado pode se candidatar | Sim                  | Diarista          |
| POST  | /api/diaria/{diariaId}/candidatar         | Realiza a candidatura do usuário logado em uma diária        | Sim                  | Diarista          |
| PATCH | /api/diaria/{diariaId}/confirmar-presenca | Confirma a presença do diárista na diária                    | Sim                  | Cliente           |
| PATCH | /api/diaria/{diariaId}/avaliacao          | Avalia a diária                                              | Sim                  | Diarista, Cliente |
| POST  | /api/diaria/{diariaId}/cancelar           | Cancelar a diária                                            | Sim                  | Diarista, Cliente |

## TODO

- [x] Sistema Administrativo parte 1
  - [x] Cadastro de Serviços
  - [x] Listagem de Serviços
  - [x] Exclusão de Serviços
  - [x] Edição de Serviços
- [x] Sistema Administrativo parte 2
  - [x] Cadastro de Usuários
  - [x] Listagem de Usuários
  - [x] Exclusão de Usuários
  - [x] Edição de Usuários
  - [x] Login
  - [x] Logout
  - [x] Alteração de senha
  - [x] Reset de senha
- [x] Buscar diaristas que atendem um cep
  - [x] Listar diaristas que atendem um cep
- [x] Contratação de Diarista (Detalhes do Serviço)
  - [x] Verificação de disponibilidade por CEP
  - [x] Busca de endereço por CEP
  - [x] Listagem de Serviços
  - [x] Implementar HATEOAS
- [x] Contratação de Diarista (Dados do Cliente)
  - [x] Rotas de cadastro de usuário
  - [x] Calculo da media de reputação
  - [x] Envio de e-mail de boas vindas
  - [x] Upload de foto documento
  - [x] Rota de autenticação via credenciais
  - [x] Rota de autenticação via refresh token
  - [x] Rota de logout
  - [x] Rota de exibição dos dados do usuário logado
- [x] Contratação de Diarista (Cadastro de diária)
  - [x] Rota de cadastro de Diária
  - [x] Adicionar HATEOAS com link de cadastro de Diária
- [x] Contratação de Diarista (Pagamento Fake)
  - [x] Rota de pagamento de diária
  - [x] Adicionar HATEOAS com link de pagamento de Diária
- [x] Lista de Diárias e Detalhe da Diária
  - [x] Rota de listagem de diárias
  - [x] Rota de detalhes de diária
  - [x] Adicionar HATEOAS com link de listagem de Diárias
  - [x] Adicionar HATEOAS com link de detalhes de Diária
- [x] Cadastro de Diarista
  - [x] Criar o modelo de EnderecoDiarista
  - [x] Criar a rota de atualização de endereço de diarista
  - [x] Criar a rota de detalhes do endereço de diarista
  - [x] Criar o serviço de consulta de cidade por codigo IBGE
  - [x] Criar a rota de listagem de cidades atendidas
  - [x] Criar a rota de alteração de cidades atendidas
- [x] Lista de Oportunidades e Candidatar-se a uma Diária
  - [x] Rota de listagem de oportunidades
  - [x] Rota de candidatar-se a uma diária
- [x] Confirmação de presença
  - [x] Task de seleção de diaristas
  - [x] Rota de confirmação de presença
- [x] Avaliação da Diária
  - [x] Rota de avaliação da diária
  - [x] Adicionar HATEOAS com link de avaliação da diária
- [x] Integração com gateway de pagamento
  - [x] Criar model de Pagamento
  - [x] Criar repository de pagamento
  - [x] Criar service de integração com gateway de pagamento Pagar.me
  - [x] Utilizar service de integração com gateway de pagamento Pagar.me na rota de pagar diária
- [x] Reembolso automático de pagamento
  - [x] Criar método busca de diária aptas para cancelamento
  - [x] Criar método de reembolso de diária
  - [x] Criar task de cancelamento de diária
- [x] Cancelar diária
  - [x] Criar funcionalidade de estorno parcial no servico de comunicação com gateway de pagamento
  - [x] Criar validação de cancelamento de diária
  - [x] Criar permission para realizar cancelamento de diária
  - [x] Criar rota de cancelamento de diária
  - [x] Adicionar link de cancelamento de diária no HATEOAS
- [x] Aviso de pagamento Admin
  - [x] Página de listagem de diárias
  - [x] Botão para marcar a diária como transferida
  - [x] Filtros de diárias
- [x] Lista de pagamentos de diaristas
  - [x] Rota de listagem de pagamentos de diaristas
- [x] Alteração dos dados do usuário
  - [x] Rota de alteração de foto de perfil
  - [x] Rota de alteração de dados pessoais
- [x] Recuperação de senha
- [ ] Deploy da aplicação
