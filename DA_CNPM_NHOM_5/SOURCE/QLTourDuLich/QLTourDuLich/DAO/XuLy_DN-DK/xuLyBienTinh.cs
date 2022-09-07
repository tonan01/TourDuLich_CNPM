using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.XuLy_DN_DK
{
    public class xuLyBienTinh
    {
        // KẾT NỐI =============================================================================
        // Tạo đối tượng kết nối CSDL
        SqlConnection con = new SqlConnection("Data Source = LAPTOP-PEPM7OTH;" +
            " Initial Catalog = QLTourDuLich; User ID = sa; Password = giabao04");

        // Open connection ---------------------------------------------------------------------
        public void openConnection()
        {
            // Mở kết nối đến CSDL
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        // Close connection --------------------------------------------------------------------
        public void closeConnection()
        {
            // Kiểm tra kết nối và Đóng CSDL
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        // Lấy mã nhân viên từ user name -------------------------------------------------------
        public void showMaNV(string userName)
        {
            //string sql = @"select maNV from NHANVIEN where userName = '" + userName + "' ";
            //SqlDataAdapter da = new SqlDataAdapter(sql, con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    Salary_User.maNV = dt.Rows[0]["maNV"].ToString(); // Form lương nhân viên
            //    Reward_Discipline_User.maNV = dt.Rows[0]["maNV"].ToString(); // Form khen thưởng kỷ luật
            //}
        }
    }
}
