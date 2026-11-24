# CBTech API - Coleção Postman

Esta pasta contém os arquivos para importar a API CBTech no Postman.

## Arquivos

| Arquivo | Descrição |
|---------|-----------|
| `CBTech-API.postman_collection.json` | Coleção completa com todos os endpoints |
| `CBTech-API.postman_environment.json` | Environment com variáveis da API |

## Como Importar

### 1. Importar o Environment

1. Abra o Postman
2. Clique no ícone ⚙️ (Gear icon) no topo para abrir **Manage Environments**
3. Clique em **Import**
4. Selecione o arquivo `CBTech-API.postman_environment.json`
5. Selecione o environment **CBTech API Environments** na barra superior do Postman

### 2. Importar a Coleção

1. Clique em **Import** no Postman (botão no canto superior esquerdo)
2. Selecione o arquivo `CBTech-API.postman_collection.json`
3. A coleção **CBTech API** aparecerá na sidebar esquerda

## Variáveis da Coleção

| Variável | Descrição |
|----------|-----------|
| `baseUrl` | URL base da API (padrão: `http://localhost:5176`) |
| `accessToken` | Token JWT de acesso (preenchido automaticamente pelo Login) |
| `refreshToken` | Token de renovação (preenchido automaticamente pelo Login) |
| `clienteId` | ID do cliente criado (preenchido automaticamente) |
| `marcaId` | ID da marca criada (preenchido automaticamente) |
| `aparelhoId` | ID do aparelho criado (preenchido automaticamente) |

## Scripts Automáticos

A coleção possui scripts de **Test** que executam automaticamente após cada request:

### Login
- Salva `accessToken` e `refreshToken` nas variáveis da coleção
- Requests autenticados usam automaticamente o Bearer token

### Refresh Token
- Atualiza `accessToken` e `refreshToken` com os novos valores

### Logout / Logout All
- Limpa `accessToken` e `refreshToken` das variáveis

### Criar Cliente
- Salva o `clienteId` retornado para uso em outros requests

### Criar Marca
- Salva o `marcaId` retornado para uso em outros requests

### Criar Aparelho
- Salva o `aparelhoId` retornado para uso em outros requests

## Fluxo de Teste Recomendado

Siga esta ordem para testar a API completamente:

1. **Auth → Login** — Autentica e salva os tokens
2. **Marcas → Criar Marca** — Cria uma marca e salva o ID
3. **Clientes → Criar Cliente** — Cria um cliente e salva o ID
4. **Aparelhos → Criar Aparelho** — Cria um aparelho usando os IDs salvos
5. **Aparelhos → Listar Aparelhos por Cliente** — Lista os aparelhos do cliente
6. Teste os demais endpoints PUT/DELETE conforme necessário

## Endpoints Disponíveis

### Auth (6 endpoints)
- `POST /api/v1/auth/login` — Login
- `POST /api/v1/auth/register` — Registrar usuário
- `POST /api/v1/auth/refresh` — Renovar token
- `GET /api/v1/auth/me` — Dados do usuário logado
- `POST /api/v1/auth/logout` — Logout
- `POST /api/v1/auth/logout-all` — Logout de todas as sessões

### Roles (6 endpoints)
- `GET /api/v1/roles` — Listar roles
- `GET /api/v1/roles/{id}` — Consultar role
- `POST /api/v1/roles` — Criar role
- `PUT /api/v1/roles/{id}` — Atualizar role
- `DELETE /api/v1/roles/{id}` — Excluir role
- `PUT /api/v1/roles/{id}/permissions` — Definir permissões

### Permissions (5 endpoints)
- `GET /api/v1/permissions` — Listar permissões
- `GET /api/v1/permissions/{id}` — Consultar permissão
- `POST /api/v1/permissions` — Criar permissão
- `PUT /api/v1/permissions/{id}` — Atualizar permissão
- `DELETE /api/v1/permissions/{id}` — Excluir permissão

### Usuarios (6 endpoints)
- `GET /api/v1/usuarios` — Listar usuários
- `GET /api/v1/usuarios/{id}` — Consultar usuário
- `POST /api/v1/usuarios` — Criar usuário
- `PUT /api/v1/usuarios/{id}/roles` — Definir roles
- `PATCH /api/v1/usuarios/{id}/ativo` — Ativar/desativar
- `DELETE /api/v1/usuarios/{id}` — Excluir usuário

### Clientes (5 endpoints)
- `GET /api/v1/clientes` — Listar clientes (com paginação)
- `GET /api/v1/clientes/{id}` — Consultar cliente
- `POST /api/v1/clientes` — Criar cliente
- `PUT /api/v1/clientes/{id}` — Atualizar cliente
- `DELETE /api/v1/clientes/{id}` — Excluir cliente

### Marcas (5 endpoints)
- `GET /api/v1/marcas` — Listar marcas (com paginação)
- `GET /api/v1/marcas/{id}` — Consultar marca
- `POST /api/v1/marcas` — Criar marca
- `PUT /api/v1/marcas/{id}` — Atualizar marca
- `DELETE /api/v1/marcas/{id}` — Excluir marca

### Aparelhos (4 endpoints)
- `GET /api/v1/aparelhos?clienteId={id}` — Listar aparelhos por cliente
- `POST /api/v1/aparelhos` — Criar aparelho
- `PUT /api/v1/aparelhos/{id}` — Atualizar aparelho
- `DELETE /api/v1/aparelhos/{id}` — Excluir aparelho

### Enderecos (1 endpoint)
- `GET /api/v1/enderecos/cep/{cep}` — Buscar endereço por CEP (público)

## Credenciais Padrão

Para testes locais, use as credenciais configuradas no seed do banco:

- **Email:** `admin@cbtech.com`
- **Senha:** `Admin@123`

## Runner

Para executar todos os requests automaticamente via **Postman Runner**:

1. Clique na coleção **CBTech API** na sidebar
2. Clique em **...** → **Run collection**
3. Selecione o environment **CBTech API Environments**
4. Configure as iterações e delay entre requests
5. Clique em **Run**

> **Nota:** O Runner executa os requests na ordem definida. Certifique-se de que o Login é o primeiro request para que os tokens sejam salvos antes dos requests autenticados.
