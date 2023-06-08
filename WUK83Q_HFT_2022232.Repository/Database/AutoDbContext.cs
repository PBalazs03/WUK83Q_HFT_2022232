using System;
using Microsoft.EntityFrameworkCore;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Repository
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Auto> AutosTable { get; set; }
        public DbSet<Brand> BrandsTable { get; set; }
        public DbSet<Owner> OwnersTable { get; set; }
        public DbSet<Concern> ConcernsTable { get; set; }

        public AutoDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase("AutoDatabase")
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasMany(t => t.Autos)
                .WithOne(t => t._Owner)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Brand>()
                .HasMany(t => t.Autos)
                .WithOne(t => t._Brand)
                .HasForeignKey(t => t.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Concern>()
                .HasMany(t => t.Brands)
                .WithOne(t => t._Concern)
                .HasForeignKey(t => t.ConcernId)
                .OnDelete(DeleteBehavior.Cascade);


            
            modelBuilder.Entity<Owner>().HasData(new Owner[]
            {
                new Owner("Kiss Pál", "1968.06.07.", "Budapest", 1),
                new Owner("Nagy András", "1963.09.01.", "Kaposvár", 2),
                new Owner("Lakatos József", "1974.03.21.", "Miskolcs", 3),
                new Owner("Veres Andor", "1993.10.10.", "Pécel", 4),
                new Owner("Kovács Júlia", "1973.01.30.", "Székesfehérvár", 5),
                new Owner("Kis Ferencné", "1962.05.01.", "Debrecen", 6),
                new Owner("Budai Ildikó", "1968.06.07.", "Veszprém", 7),
                new Owner("Pesti Balázs", "2001.12.04.", "Budapest", 8),
                new Owner("Kovács Károly", "1971.11.11.", "Szeged", 9),
                new Owner("Gazdag Imre", "1969.04.13.", "Szentendre", 10),
                new Owner("Papp Elek", "1992.12.13.", "Győr", 11),
                new Owner("Fekete József", "1970.01.04.", "Siófok", 12),
                new Owner("Szegedi Péter", "1980.07.10.", "Szombathely", 13),
                new Owner("Horváth Tamás", "1976.06.01.", "Piliscsaba", 14),
                new Owner("Gáspár József", "1970.09.09.", "Gyömrő", 15),


            });

            modelBuilder.Entity<Auto>().HasData(new Auto[]
            {
                new Auto("Kia", "Carens", 2008, 8, 111, 01),
                new Auto("BMW", "M4", 2014, 4, 112, 04),
                new Auto("Kia", "Ceed", 2013, 1, 113, 01),
                new Auto("Opel", "Corsa", 2016, 1, 114, 05),
                new Auto("Suzuki", "Swift", 2001, 2, 115, 06),
                new Auto("Mercedes-Benz", "C36 AMG", 2011, 3, 116, 03),
                new Auto("Audi", "A8", 2018, 3, 117, 07),
                new Auto("Volkswagen", "Golf", 2008, 4, 118, 08),
                new Auto("Toyota", "Avensis", 2007, 2, 119, 02),
                new Auto("Peugeot", "306", 2004, 5, 120, 09),
                new Auto("Renault", "Clio", 2015, 6, 121, 10),
                new Auto("Fiat", "Bravo", 2009, 7, 122, 11),
                new Auto("Toyota", "Corolla", 2017, 7, 123, 02),
                new Auto("Audi", "RS6", 2016, 8, 124, 03),
                new Auto("Nissan", "Qashqai", 2010, 9, 125, 12),
                new Auto("Ferrari", "Roma", 2021, 10, 126, 13),
                new Auto("Mercedes-Benz", "G63 AMG", 2022, 10, 127, 03),
                new Auto("Alfa Romeo", "Giulia", 2018, 9, 128, 14),
                new Auto("Aston Martin", "DB9", 2005, 10, 129, 15),
                new Auto("Ford", "Mustang", 2013, 11, 130, 16),
                new Auto("Ford", "Kuga", 2014, 12, 131, 16),
                new Auto("Nissan", "Micra", 2013, 13, 132, 12),
                new Auto("Opel", "Insignia", 2013, 13, 133, 05),
                new Auto("BMW", "I3", 2013, 12, 134, 04),
                new Auto("Toyota", "Celica", 1992, 12, 135, 02),
                new Auto("Tesla", "Model S", 2016, 14, 136, 17),
                new Auto("Volkswagen", "ID.3", 2022, 14, 137, 08),
                new Auto("Cadillac", "Escalade", 2013, 15, 138, 18)
            });

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand(01, "Kia", "South-Korea", 1944, true, false, 010),
                new Brand(02, "Toyota", "Japan", 1936, false, false, 003),
                new Brand(03, "Mercedes-Benz", "Germany", 1890, true, true, 004),
                new Brand(04, "BMW", "Germany", 1916, true, false, 006),
                new Brand(05, "Opel", "Germany", 1862, true, false, 001),
                new Brand(06, "Suzuki", "Japan", 1909, false, false, 013),
                new Brand(07, "Audi", "Germany", 1932, true, false, 002),
                new Brand(08, "Volkswagen", "Germany", 1937, true, false, 002),
                new Brand(09, "Peugeot", "France", 1810, true, false, 001),
                new Brand(10, "Renault", "France", 1889, true, false, 011),
                new Brand(11, "Fiat", "Italy", 1899, true, false, 001),
                new Brand(12, "Nissan", "Japan", 1930, true, false, 011),
                new Brand(13, "Ferrari", "Italy", 1947, false, true, 001),
                new Brand(14, "Alfa Romeo", "Italy", 1910, false, true, 001),
                new Brand(15, "Aston Martin", "England", 1913, false, true, 015),
                new Brand(16, "Ford", "Germany", 1903, true, false, 005),
                new Brand(17, "Tesla", "USA", 2003, true, false, 014),
                new Brand(18, "Cadillac", "USA", 1902, true, false, 008),
            });

            modelBuilder.Entity<Concern>().HasData(new Concern[]{
                new Concern(001, "Stellanois", 2021, "Netherland", 3),
                new Concern(002, "Volkswagen AG", 1937, "Germany", 1),
                new Concern(003, "Toyota", 1936, "Japan", 2),
                new Concern(004, "Mercedes-Benz Group", 1926, "Germany", 4),
                new Concern(005, "Ford Motor Company", 1903, "USA", 6),
                new Concern(006, "Bayerische Motoren Werke AG", 1916, "Germany", 7),
                new Concern(008, "General Motors", 1908, "USA", 9),
                new Concern(009, "SAIC Motor", 1997, "China", 10),
                new Concern(010, "Hyundai Motor Group", 1967, "South-Korea", 12),
                new Concern(011, "Renault-Nissan-Mitsubishi", 2017, "France-Japan", 5),
                new Concern(012, "Geely", 2017, "France-Japan", 13),
                new Concern(013, "Suzuki", 1909, "Japan", 22),
                new Concern(014, "Tesla", 2003, "USA", 19),
                new Concern(015, "Aston Martin", 1913, "England", 23),



            });
            base.OnModelCreating(modelBuilder);

        }
    }
}