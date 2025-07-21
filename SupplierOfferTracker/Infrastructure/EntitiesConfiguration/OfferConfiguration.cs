using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("Offers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Brand).IsRequired();
        builder.Property(x => x.Model).IsRequired();
        builder.Property(x => x.RegistrationDate).IsRequired();
        builder.Property(x => x.SupplierId).IsRequired();
        builder
            .HasOne(x => x.Supplier)
            .WithMany(x => x.Offers)
            .HasForeignKey(x => x.SupplierId)
            .HasConstraintName("FK_Offers_Suppliers_SupplierId");
        
        SeedData(builder);
    }

    private void SeedData(EntityTypeBuilder<Offer> builder)
    {
        builder.HasData(
            new Offer { Id = 1, Brand = "Toyota", Model = "Corolla", RegistrationDate = new DateTime(2021, 1, 10), SupplierId = 1 },
            new Offer { Id = 2, Brand = "BMW", Model = "X5", RegistrationDate = new DateTime(2022, 3, 5), SupplierId = 2 },
            new Offer { Id = 3, Brand = "Tesla", Model = "Model 3", RegistrationDate = new DateTime(2022, 8, 15), SupplierId = 3 },
            new Offer { Id = 4, Brand = "Audi", Model = "A4", RegistrationDate = new DateTime(2020, 11, 20), SupplierId = 4 },
            new Offer { Id = 5, Brand = "Honda", Model = "Civic", RegistrationDate = new DateTime(2019, 5, 30), SupplierId = 5 },
            new Offer { Id = 6, Brand = "Ford", Model = "Focus", RegistrationDate = new DateTime(2018, 7, 12), SupplierId = 1 },
            new Offer { Id = 7, Brand = "Mercedes", Model = "C-Class", RegistrationDate = new DateTime(2023, 1, 25), SupplierId = 2 },
            new Offer { Id = 8, Brand = "Volkswagen", Model = "Passat", RegistrationDate = new DateTime(2021, 6, 18), SupplierId = 3 },
            new Offer { Id = 9, Brand = "Hyundai", Model = "Elantra", RegistrationDate = new DateTime(2020, 9, 9), SupplierId = 4 },
            new Offer { Id = 10, Brand = "Kia", Model = "Ceed", RegistrationDate = new DateTime(2022, 10, 10), SupplierId = 5 },
            new Offer { Id = 11, Brand = "Nissan", Model = "Altima", RegistrationDate = new DateTime(2019, 2, 15), SupplierId = 1 },
            new Offer { Id = 12, Brand = "Chevrolet", Model = "Cruze", RegistrationDate = new DateTime(2018, 3, 17), SupplierId = 2 },
            new Offer { Id = 13, Brand = "Mazda", Model = "3", RegistrationDate = new DateTime(2023, 5, 5), SupplierId = 3 },
            new Offer { Id = 14, Brand = "Skoda", Model = "Octavia", RegistrationDate = new DateTime(2020, 12, 1), SupplierId = 4 },
            new Offer { Id = 15, Brand = "Renault", Model = "Megane", RegistrationDate = new DateTime(2021, 4, 22), SupplierId = 5 }
        );
    }
}