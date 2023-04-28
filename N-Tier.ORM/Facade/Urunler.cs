using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.ORM.Facade
{
    internal class Urunler
    {
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Urunler", Tools.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}
