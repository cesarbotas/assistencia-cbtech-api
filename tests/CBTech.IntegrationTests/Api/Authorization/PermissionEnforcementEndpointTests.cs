using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using CBTech.IntegrationTests.Factory;
using Xunit;

namespace CBTech.IntegrationTests.Api.Authorization;

/// <summary>
/// Teste end-to-end da autorização por permissão (pointer da Task 10 / Task 11):
/// uma rota administrativa protegida por <c>RequirePermission("produtos:escrever")</c>
/// deve devolver 401 para anônimo, 403 para um usuário autenticado sem a permissão
/// (Cliente) e 201 para quem tem a permissão (Admin, com todas as 12 do seed).
/// </summary>
[Collection("Integration")]
public class PermissionEnforcementEndpointTests
{
    private readonly CustomWebApplicationFactory _factory;

    public PermissionEnforcementEndpointTests(CustomWebApplicationFactory factory) => _factory = factory;
}
