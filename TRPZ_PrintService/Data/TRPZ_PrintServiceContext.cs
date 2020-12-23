using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TRPZ_PrintService.Areas.Identity.Data;

namespace TRPZ_PrintService.Data
{
    public class TRPZ_PrintServiceContext : IdentityDbContext<TRPZ_PrintServiceUser>
    {
        public TRPZ_PrintServiceContext(DbContextOptions<TRPZ_PrintServiceContext> options)
            : base(options)
        {
        }

        // public DbSet<Client> Clients { get; set; }
        // public DbSet<Manager> Managers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model3D> Models3D { get; set; }
        public DbSet<ModelInOrder> ModelsInOrders { get; set; }
        public DbSet<ModelSettings> ModelsSettings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PostProcessing> PostProcessings { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModelInOrder>().Property(mio => mio.Scale).HasDefaultValue(1);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Models)
                .WithOne(p => p.Order)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ModelInOrder>()
                .HasOne(o => o.ModelSettings)
                .WithOne(settings => settings.ModelInOrder)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(settings => settings.Orders)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}