using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4.DAL
{  
    public class DALTinTuc:DBConnect
    {
        public static List<Models.TinTuc> getTin()
        {
            
            if (con != null && con.State == ConnectionState.Closed) con.Open();// mở kết nối
            List<Models.TinTuc> l = new List<Models.TinTuc>();
            SqlCommand cmd = new SqlCommand("Select * from TinTuc", con);


            //aaaaaaa
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read() && rd != null)
            {
                Models.TinTuc tin = new Models.TinTuc();
                tin.Id1 = rd.GetInt32(0);
                tin.TieuDe1 = rd.GetString(1);
                tin.Tag1 = rd.GetString(2);
                tin.NoiDung1 = rd.GetString(3);
                l.Add(tin);
            }

            
            rd.Close(); // <- too easy to forget
            rd.Dispose(); // <- too easy to forget
            con.Close();
            return l;
        }

        public static void insert(Models.TinTuc it)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into sanPham(img,ten) values('" + it.Id1 + "','" + it.TieuDe1 + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void update(Models.TinTuc it)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update sanPham set img = '" + it.Id1 + "' , ten = '" + it.TieuDe1 + "' where id = '" + it.Id1 + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Hienthi theo Hot
        public static void HienThiHot(Models.TinTuc tin)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_selectHot1_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TieuDe", tin.TieuDe1.Trim());
            cmd.Parameters.AddWithValue("@Tag", XuLiChuoi.xoaKhoangTrang(tin.Tag1.Trim()));
            cmd.Parameters.AddWithValue("@NoiDung", tin.NoiDung1.Trim());
            cmd.Parameters.AddWithValue("@TuKhoa", XuLiChuoi.xoaKhoangTrang(tin.TuKhoa1.Trim()));
            cmd.Parameters.AddWithValue("@Anh", tin.Anh1.Trim());
            cmd.Parameters.AddWithValue("@MetaTitle", XuLiChuoi.xoaKhoangTrang(tin.TieuDe1.Trim()));
            cmd.Parameters.AddWithValue("@Id", tin.Id1);
            cmd.Parameters.AddWithValue("@DanhMuc", tin.DanhMuc1);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void HienThi(Models.TinTuc tin)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_selectHienThi1_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TieuDe", tin.TieuDe1.Trim());
            cmd.Parameters.AddWithValue("@Tag", XuLiChuoi.xoaKhoangTrang(tin.Tag1.Trim()));
            cmd.Parameters.AddWithValue("@NoiDung", tin.NoiDung1.Trim());
            cmd.Parameters.AddWithValue("@TuKhoa", XuLiChuoi.xoaKhoangTrang(tin.TuKhoa1.Trim()));
            cmd.Parameters.AddWithValue("@Anh", tin.Anh1.Trim());
            cmd.Parameters.AddWithValue("@MetaTitle", XuLiChuoi.xoaKhoangTrang(tin.TieuDe1.Trim()));
            cmd.Parameters.AddWithValue("@Id", tin.Id1);
            cmd.Parameters.AddWithValue("@DanhMuc", tin.DanhMuc1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}