using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTourDuLich.DAO;
using QLTourDuLich.DTO.DTO_NV;
namespace QLTourDuLich.XuLy_NV
{
    public class xuLyQLTour_NV
    {
        SqlConnection sqlCon = XuLyKetNoi.getConnection();

        public DataTable getCT_Tour()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CT_Tour", sqlCon);
            DataTable dtPhuongTien = new DataTable();
            da.Fill(dtPhuongTien);
            return dtPhuongTien;
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
        public DataTable load_maDD()
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string sql = "select maDD,tenDD from DDTHAMQUAN";
            SqlCommand com = new SqlCommand(sql, sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        public DataTable load_DiaChi()
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string sql = "select maTinh,tenTinh from DIACHI";
            SqlCommand com = new SqlCommand(sql, sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
        // kiểm tra tồn tại khóa chính
        public int getKT(string MaTour, string maDD)
        {

            string kt = string.Format("select count(*) from CT_TOUR where maTour= @maTour and maDD =@maDD");
            SqlCommand cmd = new SqlCommand(kt, sqlCon);
            cmd.Parameters.Add(new SqlParameter("@maTour", MaTour));
            cmd.Parameters.Add(new SqlParameter("@maDD", maDD));
            int a = (int)cmd.ExecuteScalar();
            return a;

        }
        //Thêm CT TOUR
        public void themCT_Tour(DTO_QLTour ct)
        {
            // Ket noi
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string delete = string.Format("insert into CT_TOUR VALUES(@maTour,@maDD,@diaChi)");
            SqlCommand cmd = new SqlCommand(delete, sqlCon);
            cmd.Parameters.Add(new SqlParameter("@maTour", ct.MaTour));
            cmd.Parameters.Add(new SqlParameter("@maDD", ct.MaDD));
            cmd.Parameters.Add(new SqlParameter("@diaChi", ct.DiaChi));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

        }
        //Sửa ct_tour
        public void suaCT_TOUR(DTO_QLTour ct)
        {
            // Ket noi
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string delete = string.Format("update CT_TOUR SET maTour=@maTour,maDD=@maDD,diaChi=@diaChi WHERE maTour=@maTour and maDD=@maDD");
            SqlCommand cmd = new SqlCommand(delete, sqlCon);
            cmd.Parameters.Add(new SqlParameter("@maTour", ct.MaTour));
            cmd.Parameters.Add(new SqlParameter("@maDD", ct.MaDD));
            cmd.Parameters.Add(new SqlParameter("@diaChi", ct.DiaChi));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

        }
        // Xóa CT_TOUR
        public void xoaCT_Tour(DTO_QLTour ct)
        {
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            string delete = string.Format("DELETE FROM  CT_TOUR where maTour = @maTour and maDD = @maDD");
            SqlCommand cmd = new SqlCommand(delete, sqlCon);
            cmd.Parameters.Add(new SqlParameter("@maTour", ct.MaTour));
            cmd.Parameters.Add(new SqlParameter("@maDD", ct.MaDD));
            cmd.ExecuteNonQuery();
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }
    }
}
