namespace MoonMarsTravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int ID { get; set; }

        public int? Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ScheduleDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ArrivalDate { get; set; }

        public int? Seats { get; set; }

        [StringLength(50)]
        public string From { get; set; }

        [StringLength(50)]
        public string To { get; set; }
    }
}
