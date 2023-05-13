using System;
using Microsoft.EntityFrameworkCore;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Repository
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Auto> _Autos { get; set; }
        public DbSet<Brand> _AutoProperties { get; set; }
        public DbSet<Owner> _OwnerInfos { get; set; }

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
                .WithOne(t => t.Owner)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Brand>()
                .HasOne(t => t.Auto)
                .WithMany(t => t.AutoInfos)
                .HasForeignKey(t => t.AutoId)
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
            }) ;

            modelBuilder.Entity<Auto>().HasData(new Auto[]
            {
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
                new Auto("Kia", "Carens", 2008, 8, 111),
            }) ;
            //base.OnModelCreating(modelBuilder);
        }
    }
}
