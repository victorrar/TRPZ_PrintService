using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRPZ_PrintService.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TRPZ_PrintService.Areas.Identity.Data;

namespace TRPZ_PrintService.Data
{
    public class TRPZ_PrintServiceContext : IdentityDbContext<TRPZ_PrintServiceUser>
    {
        
        public DbSet<Client> Clients { get; set; }
        // public DbSet<Manager> Managers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model3D> Models3D { get; set; }
        public DbSet<ModelInOrder> ModelsInOrders { get; set; }
        public DbSet<ModelSettings> ModelsSettings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PostProcessing> PostProcessings { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        
        public TRPZ_PrintServiceContext(DbContextOptions<TRPZ_PrintServiceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModelInOrder>().Property(mio => mio.Scale).HasDefaultValue(1);
        }
    }
}
