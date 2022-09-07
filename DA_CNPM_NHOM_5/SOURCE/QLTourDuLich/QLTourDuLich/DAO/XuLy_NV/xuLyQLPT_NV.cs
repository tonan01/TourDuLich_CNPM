using QLTourDuLich.DAO;
using QLTourDuLich.DTO.DTO_NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.XuLy_NV
{
    public class xuLyQLPT_NV
    {
        SqlConnection sqlCon = XuLyKetNoi.getConnection();

        public DataTable getPhuongTien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHUONGTIEN", sqlCon);
            DataTable dtPhuongTien = new DataTable();
            da.Fill(dtPhuongTien);
            return dtPhuongTien;
        }
        //Thêm Phương Tiện
        public void themPhuongTien(DTO_QLPT_NV pt)
        {
            // Ket noi
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert_PHUONGTIEN";
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maPT", pt.MaPT));
            cmd.Parameters.Add(new SqlParameter("@tenPT", pt.TenPT));
            cmd.Parameters.Add(new SqlParameter("@hienTrang", pt.HienTrang));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }
        //Sửa phương tiện
        public void suaPhuongTien(DTO_QLPT_NV pt)
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update_PHUONGTIEN";
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maPT", pt.MaPT));
            cmd.Parameters.Add(new SqlParameter("@tenPT", pt.TenPT));
            cmd.Parameters.Add(new SqlParameter("@hienTrang", pt.HienTrang));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();

        }
        // Xóa Phương Tiện
        public void xoaPhuongTien(string maPT)
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete_PHUONGTIEN";
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maPT", maPT));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }
        public DataTable timPhuongTien(string tim)
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string stim = string.Format("select * from PHUONGTIEN where tenPT like N'%' +@tenPT+ '%' ");
            SqlCommand cmd = new SqlCommand(stim, sqlCon);
            cmd.Parameters.AddWithValue("tenPT", tim);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }
    }
}
