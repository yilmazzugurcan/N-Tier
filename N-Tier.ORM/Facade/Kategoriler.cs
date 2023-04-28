using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.ORM.Facade
{
    public class Kategoriler
    {
        //select metodu
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Kategoriler",Tools.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        //insert metodu
        public static bool Insert(Kategori k)
        {
            // SqlCommand komut = new SqlCommand("UrunEkle", baglanti);//sql de procedure olursa
            //komut.CommandType = CommandType.StoredProcedure;//sql de procedure olursa

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "insert kategoriler (KategoriAdi,Tanimi) values (@adi,@Tanimi)";
            komut.Parameters.AddWithValue("@adi", k.KategoriAdi);
            komut.Parameters.AddWithValue("@Tanimi", k.Tanimi);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);

        }

        public static bool Update(Kategori k)
        {
            
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "UPDATE kategoriler SET KategoriAdi = @adi, Tanimi = @Tanimi WHERE KategoriID = @id";
            komut.Parameters.AddWithValue("@adi", k.KategoriAdi);
            komut.Parameters.AddWithValue("@Tanimi", k.Tanimi);
            komut.Parameters.AddWithValue("@id", k.KategoriID);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);
        }
        
        public static bool Delete(Kategori k)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "DELETE kategoriler WHERE KategoriID = @id";
            komut.Parameters.AddWithValue("@id", k.KategoriID);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);
        }
    }
}
