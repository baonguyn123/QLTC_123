using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp16.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillInfo> BillInfo { get; set; }
        public virtual DbSet<BoardingInfo> BoardingInfo { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.TotalPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.BillInfo)
                .WithOptional(e => e.Bill)
                .HasForeignKey(e => e.IdBill);

            modelBuilder.Entity<BillInfo>()
                .Property(e => e.TotalPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<BillInfo>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.BillInfo)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Employee)
                .WithOptional(e => e.UserRole)
                .HasForeignKey(e => e.IdRole);
        }
    }
}
