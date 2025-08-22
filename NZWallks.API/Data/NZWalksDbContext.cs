using Microsoft.EntityFrameworkCore;
using NZWallks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data for Difficulty
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("f660183c-2740-43e7-bc14-d181581a9cc2"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("4ac5cbcb-c5d0-4dd5-b7e5-476cddab9746"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("96c9f1fd-4241-4b67-af7c-890c90795eed"),
                    Name = "Hard"
                }
            };

            // Seed difficulties to the Database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed Data for Region
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("65c77947-4986-416c-8c4d-d77ffac47922"),
                    Name = "Tehran",
                    Code = "TEH",
                    RegionImageUrl = "Some-Images-URL.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("3b146646-6a25-42de-961c-3095257625f1"),
                    Name = "Karaj",
                    Code = "KRJ",
                    RegionImageUrl = "Some-Images-URL.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("7a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4c5d"),
                    Name = "Shiraz",
                    Code = "SHZ",
                    RegionImageUrl = "some-shiraz-image-url.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("9b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e"),
                    Name = "Isfahan",
                    Code = "ISF",
                    RegionImageUrl = "some-isfahan-image-url.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("1c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"),
                    Name = "Mashhad",
                    Code = "MHD",
                    RegionImageUrl = "some-mashhad-image-url.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("2d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"),
                    Name = "Tabriz",
                    Code = "TBZ",
                    RegionImageUrl = "some-tabriz-image-url.jpg"
                },

            };

            // Seed regions to the Database
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}