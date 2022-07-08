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

| Rota                          | Funcionalidade                                | Reque autenticação? |
| ----------------------------- | --------------------------------------------- | ------------------- |
| /admin/login                  | Realizar login na aplicação administrativa    | Não                 |
| /admin/logout                 | Realizar o logout na aplicação administrativa | Sim                 |
| /admin/servicos               | Listar todos os serviços cadastrados          | Sim                 |
| /admin/servicos/cadastrar     | Cadastrar novo serviço                        | Sim                 |
| /admin/servicos/{id}/editar   | Editar os dados de um serviço                 | Sim                 |
| /admin/servicos/{id}/excluir  | Excluir um serviço                            | Sim                 |
| /admin/usuarios               | Listar todos os usuários cadastrados          | Sim                 |
| /admin/usuarios/cadastrar     | Cadastrar um novo usuário com o perfil ADMIN  | Sim                 |
| /admin/usuarios/{id}/editar   | Editar os dados de um usuário                 | Sim                 |
| /admin/usuarios/{id}/excluir  | Excluir um usuário                            | Sim                 |
| /admin/usuarios/alterar-senha | Alterar a senha do usuário logado             | Sim                 |

## Rotas da API

| Verbo | Rota                           | Funcionalidade                                    | Requer Autenticação? |
| ----- | ------------------------------ | ------------------------------------------------- | -------------------- |
| GET   | /api                           | Lista os links iniciais da api                    | Não                  |
| GET   | /api/servicos                  | Listar serviços cadastrados                       | Não                  |
| GET   | /api/enderecos                 | Buscar endereço por cep                           | Não                  |
| GET   | /api/diaristas/localidades     | Listar diaristas que atendem um determinado cep   | Não                  |
| GET   | /api/diaristas/disponibilidade | Verifica a disponibildiade de atendimento por cep | Não                  |

## TODO

- [x] Sistema Administrativo parte 1
  - [x] Cadastro de Serviços
  - [x] Listagem de Serviços
  - [x] Exclusão de Serviços
  - [x] Edição de Serviços
- [ ] Sistema Administrativo parte 2
  - [x] Cadastro de Usuários
  - [x] Listagem de Usuários
  - [x] Exclusão de Usuários
  - [x] Edição de Usuários
  - [x] Login
  - [x] Logout
  - [x] Alteração de senha
  - [ ] Reset de senha
- [x] Buscar diaristas que atendem um cep
  - [x] Listar diaristas que atendem um cep
- [x] Contratação de Diarista (Detalhes do Serviço)
  - [x] Verificação de disponibilidade por CEP
  - [x] Busca de endereço por CEP
  - [x] Listagem de Serviços
  - [x] Implementar HATEOAS
- [ ] Contratação de Diarista (Dados do Cliente)
- [ ] Contratação de Diarista (Cadastro de diária)
- [ ] Contratação de Diarista (Pagamento Fake)
- [ ] Lista de Diárias e Detalhe da Diária
- [ ] Cadastro de Diarista
- [ ] Lista de Oportunidades e Candidatar-se a uma Diária
- [ ] Confirmação de presença
- [ ] Avaliação da Diária
- [ ] Integração com gateway de pagamento
- [ ] Reembolso automático de pagamento
- [ ] Cancelar diária
- [ ] Aviso de pagamento Admin
- [ ] Lista de pagamentos de diaristas
- [ ] Alteração dos dados do usuário
- [ ] Recuperação de senha
- [ ] Deploy da aplicação
