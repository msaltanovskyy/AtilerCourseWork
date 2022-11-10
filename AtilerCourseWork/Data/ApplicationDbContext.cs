using AtilerCourseWork.Configuration;
using AtilerCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtilerCourseWork.Data
{
    public class ApplicationDbContext : IdentityDbContext<Worker, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Worker> workers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Measure> measures { get; set; }
        public DbSet<Fitting> fittings { get; set; }
        public DbSet<Material> materials { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductMaterial> productMaterials { get; set; }
        public DbSet<InvoiceMaterial> invoiceMaterials { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Worker>().ToTable("workers");
            modelBuilder.Entity<IdentityRole>().ToTable("positions");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("worker_position");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("worker_token");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("position_claim");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("worker_claim");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("worker_login");

            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerPositionConfiguration());

            modelBuilder.Entity<Client>()
                        .HasOne(m => m.Measure)
                        .WithOne(c => c.Client)
                        .HasForeignKey<Measure>(fk => fk.MeasureId);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Product)
                .WithOne(o => o.Order)
                .HasForeignKey<Product>(fk => fk.OrderId);

        
        }

    }
}