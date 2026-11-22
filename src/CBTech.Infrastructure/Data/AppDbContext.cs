using Microsoft.EntityFrameworkCore;
using CBTech.Domain.Entities.Auth;
using CBTech.Domain.Entities.Auth.Usuarios;
using Microsoft.EntityFrameworkCore.Design;
using CBTech.Infrastructure.Data.Configurations.Auth;
using CBTech.Domain.Entities.Clientes;
using CBTech.Domain.Entities.Enderecos;
using CBTech.Domain.Entities.Marcas;
using CBTech.Infrastructure.Data.Configurations.Clientes;
using CBTech.Infrastructure.Data.Configurations.Marcas;

namespace CBTech.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<UsuarioRole> UsuarioRoles => Set<UsuarioRole>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Endereco> Enderecos => Set<Endereco>();

    public DbSet<Marca> Marcas => Set<Marca>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioRoleConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());

        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new EnderecoConfiguration());

        modelBuilder.ApplyConfiguration(new MarcaConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql();

        return new AppDbContext(optionsBuilder.Options);
    }
}
