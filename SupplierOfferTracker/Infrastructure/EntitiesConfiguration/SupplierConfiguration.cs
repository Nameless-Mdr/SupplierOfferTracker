using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.CreatedDate).IsRequired();
        
        SeedData(builder);
    }

    private void SeedData(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasData(
            new Supplier { Id = 1, Name = "Supplier A", CreatedDate = new DateTime(2023, 1, 1) },
            new Supplier { Id = 2, Name = "Supplier B", CreatedDate = new DateTime(2023, 2, 1) },
            new Supplier { Id = 3, Name = "Supplier C", CreatedDate = new DateTime(2023, 3, 1) },
            new Supplier { Id = 4, Name = "Supplier D", CreatedDate = new DateTime(2023, 4, 1) },
            new Supplier { Id = 5, Name = "Supplier E", CreatedDate = new DateTime(2023, 5, 1) }
        );
    }
}