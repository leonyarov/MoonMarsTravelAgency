using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoonMarsTravelAgency.Models
{
    public partial class MoonMarsContext : DbContext
    {
        public MoonMarsContext()
            : base("name=Database")
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
      
        public virtual DbSet<Mars> Mars { get; set; }
        public virtual DbSet<Moon> Moon { get; set; }
        //public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }

        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>()
       .Property(e => e.From)
       .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.To)
                .IsUnicode(false);

            modelBuilder.Entity<Flights>()
              .Property(e => e.FlightName)
              .IsUnicode(false);

            modelBuilder.Entity<Mars>()
                .Property(e => e.Crater)
                .IsUnicode(false);

            modelBuilder.Entity<Mars>()
                .Property(e => e.LocationX);

            modelBuilder.Entity<Mars>()
                .Property(e => e.LocationY);

            modelBuilder.Entity<Mars>()
                .Property(e => e.Radius);

            modelBuilder.Entity<Moon>()
                .Property(e => e.Crater)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
