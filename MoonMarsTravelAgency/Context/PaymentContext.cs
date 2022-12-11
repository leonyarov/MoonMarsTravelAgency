using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoonMarsTravelAgency.Models
{
    public partial class PaymentContext : DbContext
    {
        public PaymentContext()
            : base("name=PaymentContext")
        {
        }

        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(e => e.CreditCard)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .Property(e => e.CCV)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .IsFixedLength();
        }
    }
}
