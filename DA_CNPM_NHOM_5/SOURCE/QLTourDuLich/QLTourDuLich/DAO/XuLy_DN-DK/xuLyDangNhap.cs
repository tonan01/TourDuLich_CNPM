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
    public class xuLyDangNhap
    {
        // Kết nối sql server ---------------------------------------------------------------
        SqlConnection con = XuLyKetNoi.getConnection();

        // Kiểm tra rỗng --------------------------------------------------------------------
        public bool testEmpty(string userName, string pass)
        {
            // Nếu user name đễ trống
            if (userName.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập user name!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Trống
            }
            // Nếu mật khẩu để trống
            if (pass.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Trống
            }
            return true; // Nhập đầy đủ
        }

        // Lấy quyền đăng nhập --------------------------------------------------------------
        public int layQuyenDN(string userName)
        {
            try
            {
                // Mở kết nối
                con.Open();

                // Truy vấn
                string q = "Select maQuyen from TAIKHOAN where userName = " +
                    "'"+userName+"'";
                SqlCommand cmd = new SqlCommand(q, con);

                // Thực thi câu lệnh ExecuteScalar là trả về 1 số
                int k = (int)cmd.ExecuteScalar(); // trả về 1 số    

                // đóng kết nối
                con.Close();

                if (k > 0) // Nếu thành công
                    return k;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        // Đăng nhập ------------------------------------------------------------------------
        public bool login(string userName, string pass)
        {
            if (testEmpty(userName, pass)) // Nếu không rỗng
            {
                try
                {
                    con.Open(); // mở kết nối

                    string sql = "select count(*) from TAIKHOAN where userName = '" 
                        + userName + "' and pass = '" + pass + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    // Thực thi câu lệnh ExecuteScalar là trả về 1 số
                    int k = (int)cmd.ExecuteScalar(); // trả về 1 số    

                    con.Close(); // đóng kết nối

                    if (k > 0) // Nếu đăng nhập thành công
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            else // Rỗng
                return false;
        }
    }
}