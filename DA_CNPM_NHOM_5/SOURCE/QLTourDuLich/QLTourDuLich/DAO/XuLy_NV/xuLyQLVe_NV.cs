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
    public class xuLyQLVe_NV
    {
        SqlConnection sqlCon = XuLyKetNoi.getConnection();

        public DataTable getVe()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VE", sqlCon);
            DataTable dtVe = new DataTable();
            da.Fill(dtVe);
            return dtVe;
        }
        public DataTable load_maTour()
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string sql = "select maTour,tenTour from TOUR";
            SqlCommand com = new SqlCommand(sql, sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        public DataTable load_maDL()
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string sql = "select maDL,tenDL from DAILY";
            SqlCommand com = new SqlCommand(sql, sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        public DataTable load_maKS()
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string sql = "select maKS,tenKS from KHACHSAN";
            SqlCommand com = new SqlCommand(sql, sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        public DataTable load_maPT()
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string sql = "select maPT,tenPT from PHUONGTIEN";
            SqlCommand com = new SqlCommand(sql, sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        public void themVe(DTO_QLVe ve)
        {
            // Ket noi
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert_VE";
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maVe", ve.MaVe));
            cmd.Parameters.Add(new SqlParameter("@maTour", ve.MaTour));
            cmd.Parameters.Add(new SqlParameter("@maDL", ve.MaDL));
            cmd.Parameters.Add(new SqlParameter("@maKS", ve.MaKS));
            cmd.Parameters.Add(new SqlParameter("@maPT", ve.MaPT));
            cmd.Parameters.Add(new SqlParameter("@gia", ve.Gia));
            cmd.Parameters.Add(new SqlParameter("@ngayBD", ve.NgayBD));
            cmd.Parameters.Add(new SqlParameter("@ngayKT", ve.NgayKT));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        //Sửa phương tiện
        public void suaVe(DTO_QLVe ve)
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update_VE";
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maVe", ve.MaVe));
            cmd.Parameters.Add(new SqlParameter("@maTour", ve.MaTour));
            cmd.Parameters.Add(new SqlParameter("@maDL", ve.MaDL));
            cmd.Parameters.Add(new SqlParameter("@maKS", ve.MaKS));
            cmd.Parameters.Add(new SqlParameter("@maPT", ve.MaPT));
            cmd.Parameters.Add(new SqlParameter("@gia", ve.Gia));
            cmd.Parameters.Add(new SqlParameter("@ngayBD", ve.NgayBD));
            cmd.Parameters.Add(new SqlParameter("@ngayKT", ve.NgayKT));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

        }
        // Xóa Phương Tiện
        public void xoaVe(string maVe)
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete_VE";
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maVe", maVe));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        public DataTable timVe(string tim)
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string stim = string.Format("select * from VE where maVe like N'%' +@maVe+ '%' ");
            SqlCommand cmd = new SqlCommand(stim, sqlCon);
            cmd.Parameters.AddWithValue("maVe", tim);
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
