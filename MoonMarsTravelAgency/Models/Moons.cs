using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;


namespace MoonMarsTravelAgency.Models
{
    public class Moons 
    {
        [Key]
        public string crater { get; set; }
        public int locationX { get; set; }
        public int locationY { get; set; }
        public int radius { get; set; }

        
    }
}