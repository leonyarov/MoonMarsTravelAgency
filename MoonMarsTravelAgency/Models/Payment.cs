namespace MoonMarsTravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CreditCard { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CCV { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string ID { get; set; }


    }
}
