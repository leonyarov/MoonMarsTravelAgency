namespace MoonMarsTravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mars
    {
        [Key]
        [StringLength(50)]
        public string Crater { get; set; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }

        public int Radius { get; set; }
    }
}
