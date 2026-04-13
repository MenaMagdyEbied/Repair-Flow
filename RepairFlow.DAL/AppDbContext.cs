using Microsoft.EntityFrameworkCore;
using RepairFlow.Models;

namespace RepairFlow.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<SparePart>  SpareParts { get; set; }
        public DbSet<DeviceSparePart> DeviceSpareParts { get; set; }
        public DbSet<StatusHistory> StatusHistories { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=RepairFlowDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Name).IsRequired().HasMaxLength(100);
                e.Property(c => c.Phone).IsRequired().HasMaxLength(20);
                e.HasIndex(c => c.Phone).IsUnique();
            });

           
            modelBuilder.Entity<Device>(e =>
            {
                e.HasKey(d => d.Id);
                e.Property(d => d.ReceiptNumber).IsRequired().HasMaxLength(30);
                e.HasIndex(d => d.ReceiptNumber).IsUnique();
                e.Property(d => d.DeviceName).IsRequired().HasMaxLength(80);
                e.Property(d => d.Model).HasMaxLength(80);
                e.Property(d => d.Fault).HasMaxLength(300);
                e.Property(d => d.Accessories).HasMaxLength(300);
                e.Property(d => d.RepairCost).HasColumnType("decimal(18,2)");
                e.Property(d => d.PaidAmount).HasColumnType("decimal(18,2)");
                e.Property(d => d.Status).HasConversion<int>();
                e.Property(d => d.WarrantyMonths).HasDefaultValue(0);

                e.HasOne(d => d.Customer)
                 .WithMany(c => c.Devices)
                 .HasForeignKey(d => d.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(u => u.Username)
                      .IsUnique();

                entity.Property(u => u.PhoneNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(u => u.PasswordHash)
                      .IsRequired()
                      .HasMaxLength(64);

                entity.Ignore(u => u.Password);
            });

            modelBuilder.Entity<SparePart>(e =>
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.Code).IsRequired().HasMaxLength(30);
                e.HasIndex(s => s.Code).IsUnique();
                e.Property(s => s.Name).IsRequired().HasMaxLength(150);
                e.Property(s => s.Type).HasMaxLength(100);
                e.Property(s => s.PurchasePrice).HasColumnType("decimal(18,2)");
                e.Property(s => s.SellingPrice).HasColumnType("decimal(18,2)");
                e.Property(s => s.AlertThreshold).HasDefaultValue(15);
                
                e.Ignore(s => s.ProfitPerUnit);
                e.Ignore(s => s.TotalStockValue);
                e.Ignore(s => s.StockStatus);
            });

            modelBuilder.Entity<DeviceSparePart>(e =>
            {
                e.HasKey(ds => ds.Id);
                e.Property(ds => ds.UnitPrice).HasColumnType("decimal(18,2)");

                e.HasOne(ds => ds.Device)
                 .WithMany(d => d.DeviceSpareParts)
                 .HasForeignKey(ds => ds.DeviceId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(ds => ds.SparePart)
                 .WithMany(s => s.DeviceSpareParts)
                 .HasForeignKey(ds => ds.SparePartId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StatusHistory>(e =>
            {
                e.HasKey(sh => sh.Id);
                e.Property(sh => sh.OldStatus).HasConversion<int>();
                e.Property(sh => sh.NewStatus).HasConversion<int>();
                e.Property(sh => sh.Note).HasMaxLength(500);

                e.HasOne(sh => sh.Device)
                 .WithMany(d => d.StatusHistories)
                 .HasForeignKey(sh => sh.DeviceId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // AppUser mapping is defined above. The previous duplicate mapping was removed
            // to avoid referencing properties that do not exist on the AppUser class.

            base.OnModelCreating(modelBuilder);
        }
    }
}
