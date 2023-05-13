using System;
using Microsoft.EntityFrameworkCore;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Repository
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Auto> _Autos { get; set; }
        public DbSet<AutoProperties> _AutoProperties { get; set; }
        public DbSet<OwnerInfos> _OwnerInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string conn = @"";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
            //base.OnConfiguring(optionsBuilder);
        }

    }
}
