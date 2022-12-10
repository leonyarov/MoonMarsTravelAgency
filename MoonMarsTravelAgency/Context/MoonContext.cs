using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoonMarsTravelAgency.Models
{
    public partial class MoonContext : DbContext
    {
        public MoonContext()
            : base("name=Database")
        {
        }

        public virtual DbSet<Moon> Moon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moon>()
                .Property(e => e.Crater)
                .IsUnicode(false);
        }
    }
}
