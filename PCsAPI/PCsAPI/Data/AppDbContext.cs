using Microsoft.EntityFrameworkCore;
using PCsAPI.Entities;

namespace PCsAPI.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PC>().HasData(new List<PC>()
        {
            new PC
            {
                Id = 1, Name = "Gaming PC", Weight = 12.5f, Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5
            },
            new PC
            {
                Id = 2, Name = "Office PC", Weight = 4.2f, Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12
            },
            new PC
            {
                Id = 3, Name = "Home PC", Weight = 6.8f, Warranty = 24,
                CreatedAt = new DateTime(2026, 5, 10, 10, 0, 0), Stock = 3
            }
        });

        modelBuilder.Entity<Component>().HasData(new List<Component>()
        {
            new Component
            {
                Code = "INT-I9", Name = "Intel Core i9-14900K", Description = "Intel processor",
                ComponentManufacturersId = 1, ComponentTypesId = 1
            },
            new Component
            {
                Code = "AMD-R9", Name = "AMD Ryzen 9 7950X", Description = "AMD processor",
                ComponentManufacturersId = 2, ComponentTypesId = 1
            },
            new Component
            {
                Code = "ASU-4090", Name = "ASUS ROG Strix RTX 4090", Description = "Nvidia graphics card",
                ComponentManufacturersId = 3, ComponentTypesId = 2
            }
        });

        modelBuilder.Entity<ComponentType>().HasData(new List<ComponentType>()
        {
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "MOBO", Name = "Motherboard" }
        });

        modelBuilder.Entity<ComponentManufacturer>().HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer
            {
                Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation",
                FoundationDate = new DateOnly(1968, 7, 18)
            },
            new ComponentManufacturer
            {
                Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices, Inc.",
                FoundationDate = new DateOnly(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 3, Abbreviation = "ASUS", FullName = "ASUSTeK Computer Inc.",
                FoundationDate = new DateOnly(1989, 4, 2)
            }
        });

        modelBuilder.Entity<PCComponent>().HasData(new List<PCComponent>()
        {
            new PCComponent { PCId = 1, ComponentCode = "INT-I9", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "ASU-4090", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "AMD-R9", Amount = 1 }
        });
        
        base.OnModelCreating(modelBuilder);
    }

}