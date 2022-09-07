using QLTourDuLich.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.XuLy_DN_DK
{
    public class xuLyDangKy
    {
        // Kết nối sql server ---------------------------------------------------------------
        SqlConnection con = XuLyKetNoi.getConnection();

        // Kiểm tra rỗng --------------------------------------------------------------------
        public bool testEmpty(string userName, string pass, string retypePass)
        {
            if (userName.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (pass.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (retypePass.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Nhập lại mật khẩu!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true; // Nhập đầy đủ
        }

        // Kiểm tra tài khoản tồn tại -------------------------------------------------------
        public bool testUser(string userName)
        {
            try
            {
                con.Open();

                // Truy vấn
                string sql = "select count(*) from TAIKHOAN where userName='" + userName + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                // Thực thi câu truy vấn
                int kq = (int)cmd.ExecuteScalar(); // Trả về 1 dữ liệu đơn

                con.Close();

                if (kq >= 1) // Trùng khóa chính (User name đã tồn tại)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        // Đăng ký tài khoản ----------------------------------------------------------------
        public bool dangKy(string userName, string password, string retypePassword)
        {
            if (testEmpty(userName, password, retypePassword)) // thoả mãn điều kiện
            {
                try
                {
                    con.Open();

                    string sql = "exec dkTaiKhoan '"+userName+"', '"+password+"'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery(); // Thực thi câu lệnh insert                   

                    con.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}