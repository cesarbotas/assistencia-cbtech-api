using CBTech.Domain.Entities.Auth.Usuarios;
using CBTech.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CBTech.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db, IPasswordHasher hasher)
    {
        await db.Database.MigrateAsync();

        if (!await db.Usuarios.AnyAsync())
        {
            var admin = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = "Admin",
                Email = "admin@cbtech.com",
                SenhaHash = hasher.Hash("Admin@123"),
                Ativo = true,
                CriadoEm = DateTime.UtcNow
            };
            db.Usuarios.Add(admin);
            await db.SaveChangesAsync();

            // Vincula o Admin inicial à role Admin (semeada pela migration, que roda
            // antes deste ponto via MigrateAsync acima).
            var roleAdmin = await db.Roles.FirstOrDefaultAsync(r => r.Nome == "Admin");
            if (roleAdmin is not null &&
                !await db.UsuarioRoles.AnyAsync(ur => ur.UsuarioId == admin.Id && ur.RoleId == roleAdmin.Id))
            {
                db.UsuarioRoles.Add(new UsuarioRole { UsuarioId = admin.Id, RoleId = roleAdmin.Id });
                await db.SaveChangesAsync();
            }
        }
    }
}