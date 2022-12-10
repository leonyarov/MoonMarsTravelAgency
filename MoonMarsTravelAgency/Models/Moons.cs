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

        //public List<string> getMoons()
        //{
        //    var moons = new List<string>();
        //    string query = "select * from moon";
        //    SqlDataReader reader;
        //    SqlCommand command;
        //    SqlConnection sql = new SqlConnection(
        //            "Data Source=(LocalDB)\\MSSQLLocalDB;" +
        //            //"AttachDbFilename=C:\\Users\\leon\\source\\repos\\MoonMarsTravelAgency\\MoonMarsTravelAgency\\App_Data\\Database.mdf;" +
        //            "AttachDbFilename=|DataDirectory|\\Database.mdf;" + 
        //            "Integrated Security=True"
        //        );
        //    try
        //    {

        //        //Open database connection
        //        sql.Open();

        //        command = new SqlCommand(query, sql);
        //        reader = command.ExecuteReader();

        //        while (reader.Read())
        //            moons.Add(reader.GetString(0));

        //        //Close connection
        //        sql.Close();

        //    }
        //    catch (Exception e) {
        //        Debug.WriteLine(e.Message);
        //        moons.Add("No moons found!");
        //    }

        //    return moons;
        //}
    }
}