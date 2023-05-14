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

        public AutoDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\autos.mdf;Integrated Security=True;MultipleActiveResultSets=True";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
            //base.OnConfiguring(optionsBuilder);
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
                


            ////////   DbSeed   ////////
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
                new Owner("Szegedi Péter", "1980.07.10.", "Szombathely", 13)
            }) ;

            modelBuilder.Entity<Auto>().HasData(new Auto[]
            {
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("BMW", "M4", 2014, 4, 112),
                new Auto("Kia", "Ceed", 2013, 1, 113),
                new Auto("Opel", "Corsa", 2016, 1, 114),
                new Auto("Suzuki", "Swift", 2001, 2, 115),
                new Auto("Mercedes-Benz", "C36 AMG", 2011, 3, 116),
                new Auto("Audi", "A8", 2018, 3, 117),
                new Auto("Volkswagen", "Golf", 2008, 4, 118),
                new Auto("Toyota", "Avensis", 2007, 2, 119),
                new Auto("Peugeot", "306", 2004, 5, 120),
                new Auto("Renault", "Clio", 2015, 6, 121),
                new Auto("Fiat", "Bravo", 2009, 7, 122),
                new Auto("Toyota", "Corolla", 2017, 7, 123),
                new Auto("Mercedes-Benz", "C63 AMG", 2016, 8, 124),
                new Auto("Nissan", "Qashqai", 2010, 9, 125),
                new Auto("Ferrari", "Roma", 2021, 10, 126),
                new Auto("Mercedes-Benz", "G63 AMG", 2022, 10, 127),
                new Auto("Alfa Romeo", "Giulia", 2018, 9, 128),
                new Auto("Aston Martin", "DB9", 2005, 10, 129),
                new Auto("Ford", "Mustang", 2013, 11, 130),
                new Auto("Ford", "Kuga", 2014, 12, 131),
                new Auto("Nissan", "Micra", 2013, 13, 132),
                new Auto("Opel", "Insignia", 2013, 13, 133),
                new Auto("BMW", "I3", 2013, 12, 134),
                new Auto("Toyota", "Celica", 1992, 12, 135)
            }) ;

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand(01, "Kia", "South-Korea", 1944, true, false),
                new Brand(02, "Toyota", "Japan", 1936, false, false),
                new Brand(03, "Mercedes-Benz", "Germany", 1890, true, true),
                new Brand(04, "BMW", "Germany", 1916, true, false),
                new Brand(05, "Opel", "Germany", 1862, true, false),
                new Brand(06, "Suzuki", "Japan", 1909, false, false),
                new Brand(07, "Audi", "Germany", 1932, true, false),
                new Brand(08, "Volkswagen", "Germany", 1937, true, false),
                new Brand(09, "Peugeot", "France", 1810, true, false),
                new Brand(10, "Renault", "France", 1889, true, false),
                new Brand(11, "Fiat", "Italy", 1899, true, false),
                new Brand(12, "Nissan", "Japan", 1930, true, false),
                new Brand(13, "Ferrari", "Italy", 1947, false, true),
                new Brand(14, "Alfa Romeo", "Italy", 1910, false, true),
                new Brand(15, "Aston Martin", "England", 1913, false, true),
                new Brand(16, "Ford", "Germany", 1903, true, true),
            }) ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
