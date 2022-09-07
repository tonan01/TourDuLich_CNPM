using QLTourDuLich.Frm_KH;
using QLTourDuLich.XuLy_DN_DK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.Frm_DN_DK
{
    public partial class Frm_DangKy : Form
    {
        public Frm_DangKy()
        {
            InitializeComponent();
        }

        xuLyDangKy xldk = new xuLyDangKy();

        // Biến động tenDN hiển thị tên người dùng đang đăng nhập
        public static string tenDN = "";

        // Đăng ký -------------------------------------------------------------------------
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng ký?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Tài khoản đã tồn tại
                if (xldk.testUser(txtUserName.Text) == false)
                {
                    MessageBox.Show("Đăng ký không thành công!\nTài khoản đã tồn tại, " +
                            "quý khách vui lòng chọn user name khác!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu mật khẩu và nhập lại mật khẩu trùng khớp
                if (txtMK.Text == txtNhapLaiMK.Text)
                {
                    // Đăng ký tài khoản
                    if (xldk.dangKy(txtUserName.Text, txtMK.Text, txtNhapLaiMK.Text) == true)
                    {
                        MessageBox.Show("Chúc mừng quý khách!\nĐăng ký tài khoản thành công!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Frm_DangNhap dn = new Frm_DangNhap();
                        this.Hide();
                        dn.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký tài khoản thất bại!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Mật khẩu và nhập lại mật khẩu không khớp
                else
                {
                    MessageBox.Show("Đăng ký thất bại\nNhập lại mật khẩu không khớp!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
            }
        }

        // Đăng ký tài khoản ---------------------------------------------------------------
        private void lblDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_DangNhap dn = new Frm_DangNhap();
            dn.Show();
        }

        // Reset ---------------------------------------------------------------------------
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn nhập lại?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                txtUserName.Text = "";
                txtMK.Text = "";
                txtNhapLaiMK.Text = "";
                txtUserName.Focus();
            }
        }

        // Khởi tạo ngày giờ hệ thống ------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
        }

        // Ẩn mật khẩu ---------------------------------------------------------------------
        private void picHide_Click(object sender, EventArgs e)
        {
            if (txtMK.PasswordChar == '*')
            {
                picShow.BringToFront(); // Hiện lên phía trước
                txtMK.PasswordChar = '\0'; // Hiện ký tự thường
            }
        }
        
        // Hiện mật khẩu -------------------------------------------------------------------
        private void picShow_Click(object sender, EventArgs e)
        {
            if (txtMK.PasswordChar == '\0')
            {
                picHide.BringToFront(); // Hiện lên phía trước
                txtMK.PasswordChar = '*';
            }
        }

        // Ẩn mật khẩu ---------------------------------------------------------------------
        private void picHide2_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMK.PasswordChar == '*')
            {
                picShow2.BringToFront(); // Hiện lên phía trước
                txtNhapLaiMK.PasswordChar = '\0'; // Hiện ký tự thường
            }
        }

        // Hiện mật khẩu -------------------------------------------------------------------
        private void picShow2_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMK.PasswordChar == '\0')
            {
                picHide2.BringToFront(); // Hiện lên phía trước
                txtNhapLaiMK.PasswordChar = '*';
            }
        }

        // Load form -----------------------------------------------------------------------
        private void Frm_DangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
