using EstateFlow.Server.Domain;
using Microsoft.EntityFrameworkCore;
namespace EstateFlow.Server.Data;

public class EstateFlowDbContext : DbContext
{
    public DbSet<City> Cities => Set<City>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();
    public DbSet<Meter> Meters => Set<Meter>();
    public EstateFlowDbContext(DbContextOptions<EstateFlowDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>()
                    .HasIndex(p => p.Code)
                    .IsUnique();
        
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Budapest" },
            new City { Id = 2, Name = "Debrecen" },
            new City { Id = 3, Name = "Szeged" },
            new City { Id = 4, Name = "Kecskemét" }
        );
        modelBuilder.Entity<Property>().HasData(
            new Property
            {
                Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                Code = "BPSZK",
                Name = "Szondi utcai lakás",
                Address = "1068 Budapest, Szondi utca 45.",
                SquareMeters = 54,
                AdvertisementText = "Világos, felújított másfél szobás lakás a VI. kerület szív",
                CityId = 1
            },
            new Property
            {
                Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                Code = "BPFKR",
                Name = "Ferenc körúti lakás",
                Address = "1092 Budapest, Ferenc körút 12.",
                SquareMeters = 68,
                AdvertisementText = null,
                CityId = 1
            },
            new Property
            {
                Id = new Guid("9b1deb4d-3b7d-4bad-9bdd-2b0d7b3dcb6d"),
                Code = "DEEGY",
                Name = "Egyetem sugárúti lakás",
                Address = "4026 Debrecen, Egyetem sugárút 8.",
                SquareMeters = 47,
                AdvertisementText = "Hangulatos, erkélyes lakás a Nagyerdő közelében, egyetemis",
                CityId = 2
            }
        );
        modelBuilder.Entity<PropertyImage>().HasData(
            new PropertyImage
            {
                Id = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                Name = "Nappali",
                FilePath = "uploads/properties/bpszk-nappali.jpg",
                UploadedAt = new DateTime(2026, 1, 15, 10, 30, 0, DateTimeKind.Utc),
                PropertyId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")
            },
            new PropertyImage
            {
                Id = new Guid("6ec0bd7f-11c0-43da-975e-2a8ad9ebae0b"),
                Name = "Hálószoba",
                FilePath = "uploads/properties/bpszk-haloszoba.jpg",
                UploadedAt = new DateTime(2026, 1, 15, 10, 32, 0, DateTimeKind.Utc),
                PropertyId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")
            },
            new PropertyImage
            {
                Id = new Guid("f9168c5e-ceb2-4faa-b6bf-329bf39fa1e4"),
                Name = "Utcai homlokzat",
                FilePath = "uploads/properties/bpfkr-homlokzat.jpg",
                UploadedAt = new DateTime(2026, 2, 3, 14, 0, 0, DateTimeKind.Utc),
                PropertyId = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7")
            },
            new PropertyImage
            {
                Id = new Guid("d2719b1e-1c3b-4e5f-9a6d-8b7c6d5e4f3a"),
                Name = "Konyha",
                FilePath = "uploads/properties/deegy-konyha.jpg",
                UploadedAt = new DateTime(2026, 2, 10, 9, 15, 0, DateTimeKind.Utc),
                PropertyId = new Guid("9b1deb4d-3b7d-4bad-9bdd-2b0d7b3dcb6d")
            }
        );
    }
}

