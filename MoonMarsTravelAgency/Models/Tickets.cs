namespace MoonMarsTravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tickets
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_ID { get; set; }

        [Key, Column(Order = 1)]
        public int? Flight_ID { get; set; }

        [Key, Column(Order = 2)]
        public int? Seat_ID { get; set; }
    }
}
