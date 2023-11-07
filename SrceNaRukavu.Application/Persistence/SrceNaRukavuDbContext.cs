using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SrceNaRukavu.Application.Persistence.Configurations;
using SrceNaRukavu.Domain;

namespace SrceNaRukavu.Application.Persistence
{
    public class SrceNaRukavuDbContext : DbContext
    {
        public DbSet<Person>? Persons { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet <Reservation>? Reservations { get; set; } 
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Section>? Sections { get; set; }
    
    
        public SrceNaRukavuDbContext(DbContextOptions options ) : base(options) {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoleSeeders(modelBuilder);
            SectionSeeder(modelBuilder);
            CategorySeeders(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReservationConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleConfiguration).Assembly);
        }
        private static void RoleSeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role()
                    {
                        Id = 1,
                        Name = "System admin",
                        Code = "SYSADM"
                    },
                    new Role()
                    {
                        Id = 2,
                        Name = "Owner",
                        Code = "OWN"
                    },
                    new Role()
                    {
                        Id = 3,
                        Name = "Manager",
                        Code = "MAN"
                    },
                    new Role()
                    {
                        Id = 4,
                        Name = "Customer",
                        Code = "CUS"
                    }
                    ) ;
        }

        private static void SectionSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>().HasData(

                new Section()
                {
                    Id = 1,
                    Name = "Anin odjel"
                },
                new Section()
                {
                    Id = 2,
                    Name = "Prijateljev odjel"
                }

                );
        }

        private static void CategorySeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category()
                {
                    Id = 1,
                    Name = "Majica",
                    Code = "TSHIRT"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Hlaće",
                    Code = "PANTS"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Košulja",
                    Code = "SHIRT"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Dugi rukavi",
                    Code = "LONGSLEEVE"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Jaketa",
                    Code = "JACKETS"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Obuća",
                    Code = "FOOTWEAR"
                },
                 new Category()
                 {
                     Id = 7,
                     Name = "Ostalo",
                     Code = "OTHER"
                 }
                );
        }

    }
}
