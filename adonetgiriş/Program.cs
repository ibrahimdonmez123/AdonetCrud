using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdonetCrud
{
    public class Program
    {
        private static SqlConnection con = new SqlConnection("data source=DESKTOP-JI1JKUA\\SQLEXPRESS; initial catalog=Ogrenci ; integrated security=true");

        static void Main(string[] args)
        {
            kayitlarigetir();
            //kayitekle(1333, "ibrahim", "dönmez", 21, "izmir");
            //kayıtlarıgüncelle("ibrahimmmm", 1333);
            kayıtsil(1333);
        }

        public static void kayitlarigetir()
        {
            List<ogrenci> ogrencilist = new List<ogrenci>();

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ogrenci", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ogrenci ogr = new ogrenci();
                ogr.id = int.Parse(dr["id"].ToString());
                ogr.isim = dr["isim"].ToString();
                ogr.soyisim = dr["soyisim"].ToString();
                ogr.yas = int.Parse(dr["yas"].ToString());
                ogr.memleket = dr["memleket"].ToString();
                ogrencilist.Add(ogr);
            }
            con.Close();
            foreach (ogrenci ogr in ogrencilist)
            {
                Console.WriteLine("Öğrenci id :" + ogr.id + " ogrenci isim:" + ogr.isim + " ogrenci soyisim : " + ogr.soyisim + " ogrenci yas : " + ogr.yas + "ogrenci memleket :" + ogr.memleket);
            }
            Console.ReadLine();
        }

        public static void kayitekle(int id, string isim, string soyisim, int yas, string memleket)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ogrenci ( id , isim ,  soyisim , yas , memleket) values(@id, @isim, @soyisim, @yas, @memleket)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@isim", isim);
            cmd.Parameters.AddWithValue("@soyisim", soyisim);
            cmd.Parameters.AddWithValue("@yas", yas);
            cmd.Parameters.AddWithValue("@memleket", memleket);
            int donendeger = cmd.ExecuteNonQuery();
            if (donendeger == 1)
            {
                Console.WriteLine("Başarılı...");
            }
            else
            {
                Console.WriteLine("Başarısız...");
            }
            con.Close();
        }

        public static void kayıtlarıgüncelle(string isim, int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update ogrenci set isim = @isim where id=@id", con);
            cmd.Parameters.AddWithValue("@isim", isim);
            cmd.Parameters.AddWithValue("@id", id);
            int donendeger = cmd.ExecuteNonQuery();

            if (donendeger == 1)
            {
                Console.WriteLine("Başarılı...");
            }
            else
            {
                Console.WriteLine("Başarısız...");
            }
            con.Close();
        }

        public static void kayıtsil(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from ogrenci where id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int donendeger = cmd.ExecuteNonQuery();
            if (donendeger == 1)
            {
                Console.WriteLine("Başarılı...");
            }
            else
            {
                Console.WriteLine("Başarısız...");
            }
            con.Close();
        }
    }
}
