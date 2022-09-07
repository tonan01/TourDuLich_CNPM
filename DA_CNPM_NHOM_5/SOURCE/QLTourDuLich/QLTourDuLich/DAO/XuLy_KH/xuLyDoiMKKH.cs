using QLTourDuLich.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.XuLy_KH
{
    public class xuLyDoiMKKH
    {
        //lấy dữ liệu tên đăng nhập
        public static string tenDN = "";
        //kết nối sql
        SqlConnection con = XuLyKetNoi.getConnection();
        // Open connection ------------------------------------------------------------
        public void openConnection()
        {
            // Mở kết nối đến CSDL
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        // Close connection -----------------------------------------------------------
        public void closeConnection()
        {
            // Kiểm tra kết nối và Đóng CSDL
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public xuLyDoiMKKH()
        {
        }

        //kiểm tra rỗng
        public bool KTRong(string username, string pass, string nhaplaipass)
        {
            if (username != tenDN)//email nhập không phải email của tài khoảng
            {
                MessageBox.Show("Nhập sai email của tài khoản", "Thông Báo");
                return false;
            }
            if (username.Length == 0)//rỗng
            {
                MessageBox.Show("Email không được để trống", "Thông Báo");
                return false;
            }
            if (pass.Length == 0)//rỗng
            {
                MessageBox.Show("Mật khẩu không Để trống", "Thông Báo");
                return false;
            }
            if (nhaplaipass.Length == 0)//rỗng
            {
                MessageBox.Show("Nhập lại mật khẩu không Để trống", "Thông Báo");
                return false;
            }
            if (pass != nhaplaipass)//mật khẩu Nhập lại không giống nhau
            {
                MessageBox.Show("Mật khẩu không Để trống", "Thông Báo");
                return false;
            }

            return true;//đã nhập tất cả
        }

        //Sửa mật khẩu
        public bool Sua(string username, string pass)
        {
            try
            {
                openConnection();//mở kết nối
                string sql = "update TAIKHOAN set pass='" + pass + "' where userName='" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();//thực thi câu lệnh insert update delete
                closeConnection();//đóng kết nối
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }
        }
    }
}
