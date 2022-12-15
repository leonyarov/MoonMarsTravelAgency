namespace MoonMarsTravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flights
    {
        [Required]
        [StringLength(50)]
        public string From { get; set; }

        [StringLength(50)]
        public string To { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public double? Price { get; set; }

        public int? Seats { get; set; }

        public DateTime? Scheduled { get; set; }

        public int? Popularity { get; set; }
    }
}
