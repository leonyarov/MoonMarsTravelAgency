namespace MoonMarsTravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        [Required(ErrorMessage = "ID number is required")]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "ID number must contain 4 digits")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must have at least 2 character. The maximum length is 50 character")]
        public string Name { get; set; }
        
        [Column("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must have at least 2 character. The maximum length is 50 character")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username must have at least 2 character. The maximum length is 50 character")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Password must have at least 2 character. The maximum length is 50 character")]
        public string Password { get; set; }
    }
}
