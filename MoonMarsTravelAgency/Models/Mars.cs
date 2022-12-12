
namespace MoonMarsTravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mars")]
    public partial class Mars
    {
        [Key]
        [StringLength(50)]
        public string Crater { get; set; }

        [StringLength(10)]
        public string LocationX { get; set; }

        [StringLength(10)]
        public string LocationY { get; set; }

        [StringLength(10)]
        public string Radius { get; set; }
    }
}
