using System;
using System.Collections.Generic;
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
        //public List<string> getMoons()
        //{
        //    List<string> crater = new List<string>();
        //    List<string> locationX = new List<string>();
        //    List<string> locationY = new List<string>();
        //    List<string> Radius = new List<string>();
        //    using (var reader = new StreamReader(Server.MapPath("~/App_Data/filename"))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var values = line.Split(',');

        //            crater.Add(values[0]);
        //            locationX.Add(values[1]);
        //            locationY.Add(values[2]);
        //            Radius.Add(values[3]);
        //        }
        //    }
        //    return crater;
        //}

//        public void validateMoons()
//        {
//            services.AddDbContext<CatalogContext>(options => options.UseSqlServer
//(Configuration.GetConnectionString("DefaultConnection")));
//        }

        public List<string> getMoons()
        {
            var moons = new List<string>();
            string query = "select * from moon";
            SqlDataReader reader;
            SqlCommand command;
            SqlConnection sql = new SqlConnection(
                    "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                    //"AttachDbFilename=C:\\Users\\leon\\source\\repos\\MoonMarsTravelAgency\\MoonMarsTravelAgency\\App_Data\\Database.mdf;" +
                    "AttachDbFilename=|DataDirectory|\\Database.mdf;" + 
                    "Integrated Security=True"
                );
            try
            {

                //Open database connection
                sql.Open();

                command = new SqlCommand(query, sql);
                reader = command.ExecuteReader();

                while (reader.Read())
                    moons.Add(reader.GetString(0));

                //Close connection
                sql.Close();

            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
                moons.Add("No moons found!");
            }

            return moons;
        }
    }
}