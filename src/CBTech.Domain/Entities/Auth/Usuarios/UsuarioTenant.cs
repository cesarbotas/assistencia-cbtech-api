namespace CBTech.Domain.Entities.Auth.Usuarios;

public class UsuarioTenant
{
    public int IdUsuario { get; set; }
    public int TenantId { get; set; }
    public bool IsActive { get; set; }
    public bool AssinaturaAtiva { get; set; }
}