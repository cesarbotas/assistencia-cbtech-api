namespace CBTech.Infrastructure.Data.Configurations.Auth;

public sealed class TenantConfiguration /*: IEntityTypeConfiguration<Tenant>*/
{
    // public void Configure(EntityTypeBuilder<Tenant> builder)
    // {
    //     builder.ToTable("tenants");
    //     builder.HasKey(t => t.Id);
    //     builder.Property(t => t.Name).IsRequired().HasMaxLength(200);
    //     builder.Property(t => t.Cnpj).HasMaxLength(18);
    //     builder.Property(t => t.Phone).HasMaxLength(20);
    //     builder.Property(t => t.Address).HasMaxLength(500);
    //     builder.Property(t => t.Plan).HasMaxLength(50).HasDefaultValue("basic");
    //     builder.Property(t => t.IsSubscriptionActive).HasDefaultValue(true);
    //     builder.Property(t => t.WorkOrderSequence).HasDefaultValue(0);
    // }
}
