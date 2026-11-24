-- ============================================================================
-- Seed de roles, permissões e vínculos — RBAC CTech
-- ============================================================================
--
-- FONTE DA VERDADE: a migration EF `AuthRbacRefreshToken`
--   (src/CBTech.Infrastructure/Migrations/..._AuthRbacRefreshToken.cs).
-- A migration já executa este seed automaticamente no startup da API. Este
-- script é um ESPELHO idempotente, para conferência/execução manual (ex.: via
-- DBeaver por túnel SSH — ver docs/Banco/Tunel-SSH-DBeaver.md).
--
-- É seguro rodar múltiplas vezes: todos os INSERTs usam ON CONFLICT DO NOTHING.
-- Nomes de tabela/coluna seguem o padrão do EF/Npgsql: PascalCase com aspas
-- duplas (identificadores case-sensitive no PostgreSQL).
--
-- Conteúdo: 15 permissões, 3 roles de sistema, vínculos role→permissão
--   (Admin = todas as 15, Gerente = 12, Cliente = nenhuma).
-- ============================================================================

-- ----------------------------------------------------------------------------
-- 1) Permissões (formato recurso:acao)
-- ----------------------------------------------------------------------------
INSERT INTO "Permissions" ("Codigo", "Recurso", "Acao", "Descricao") VALUES
    ('usuarios:gerenciar','usuarios', 'gerenciar', 'Gerenciar usuarios'),
    ('roles:gerenciar',     'roles',      'gerenciar','Gerenciar roles'),
    ('permissoes:gerenciar','permissoes', 'gerenciar','Gerenciar permissoes'),
    ('clientes:ler',        'clientes',   'ler',      'Visualizar clientes'),
    ('clientes:escrever',   'clientes',   'escrever', 'Criar e editar clientes'),
    ('marcas:ler',        'marcas',   'ler',      'Visualizar marcas'),
    ('marcas:escrever',   'marcas',   'escrever', 'Criar e editar marcas'),
    ('aparelhos:ler',        'aparelhos',   'ler',      'Visualizar aparelhos'),
    ('aparelhos:escrever',   'aparelhos',   'escrever', 'Criar e editar aparelhos'),
    ('fornecedores:ler',        'fornecedores',   'ler',      'Visualizar fornecedores'),
    ('fornecedores:escrever',   'fornecedores',   'escrever', 'Criar e editar fornecedores'),
    ('categorias:ler',          'categorias',     'ler',      'Visualizar categorias'),
    ('categorias:escrever',     'categorias',     'escrever', 'Criar e editar categorias'),
    ('produtos:ler',            'produtos',      'ler',      'Visualizar produtos'),
    ('produtos:escrever',       'produtos',      'escrever', 'Criar e editar produtos')
ON CONFLICT ("Codigo") DO NOTHING;

-- ----------------------------------------------------------------------------
-- 2) Roles de sistema
--    Admin e Cliente são roles de sistema (Sistema=true): não podem ser
--    renomeadas, excluídas nem ter permissões alteradas via API.
--    Gerente é uma role comum (Sistema=false).
-- ----------------------------------------------------------------------------
INSERT INTO "Roles" ("Nome", "Descricao", "Sistema") VALUES
    ('Admin',   'Acesso total ao sistema', true),
    ('Cliente', 'Cliente final sem acesso administrativo', true),
    ('Gerente', 'Operacao de loja com acesso parcial', false)
ON CONFLICT ("Nome") DO NOTHING;

-- ----------------------------------------------------------------------------
-- 3) Vínculos role → permissão
-- ----------------------------------------------------------------------------

-- Admin recebe TODAS as 15 permissões (CROSS JOIN com o catálogo).
INSERT INTO "RolePermissions" ("RoleId", "PermissionId")
SELECT
    r."Id",
    p."Id"
FROM
    "Roles" r
        CROSS JOIN
    "Permissions" p
WHERE
    r."Nome" = 'Admin'
ON CONFLICT DO NOTHING;

-- Gerente recebe 12 permissões operacionais.
INSERT INTO "RolePermissions" ("RoleId", "PermissionId")
SELECT
    r."Id",
    p."Id"
FROM
    "Roles" r
JOIN
    "Permissions" p ON p."Codigo" IN
    (
        'clientes:ler',
        'clientes:escrever',
        'marcas:ler',
        'marcas:escrever',
        'aparelhos:ler',
        'aparelhos:escrever',
        'fornecedores:ler',
        'fornecedores:escrever',
        'categorias:ler',
        'categorias:escrever',
        'produtos:ler',
        'produtos:escrever'
    )
WHERE
    r."Nome" = 'Gerente'
ON CONFLICT DO NOTHING;

-- Cliente NÃO recebe nenhuma permissão (nenhum insert — intencional).

-- ============================================================================
-- Conferência (queries de verificação — opcionais)
-- ============================================================================
-- Total de permissões (esperado: 15):
--   SELECT COUNT(*) FROM "Permissions";
--
-- Permissões por role (esperado: Admin=15, Gerente=12, Cliente=0):
--   SELECT r."Nome", COUNT(rp."PermissionId") AS total
--   FROM "Roles" r
--   LEFT JOIN "RolePermissions" rp ON rp."RoleId" = r."Id"
--   GROUP BY r."Nome"
--   ORDER BY r."Nome";
-- ============================================================================
