using QLTourDuLich.Frm_Admin;
using QLTourDuLich.Frm_DN_DK;
using QLTourDuLich.Frm_KH;
using QLTourDuLich.Frm_NV;

using QLTourDuLich.GUI.Frm_NV;
using QLTourDuLich.Xuly_Admin;
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

namespace QLTourDuLich
{
    public partial class Frm_DangNhap : Form
    {
        public Frm_DangNhap()
        {
            InitializeComponent();
        }

        xuLyDangNhap xldn = new xuLyDangNhap();
        xuLyBienTinh xlbt = new xuLyBienTinh();

        // Biến động tên đăng nhập hiển thị tên người dùng đang đăng nhập
        public static string tenDN = ""; 

        // Biến cục bộ ------------------------------------------------------------------------------------
        public void luuBienCucBo()
        {
            // Lưu tên đăng nhập của người dùng hiện tại
            Frm_HomeAdmin.tenDN = txtUserName.Text; 
            Frm_HomeNV.tenDN = txtUserName.Text;
            Frm_HomeKH.tenDN = txtUserName.Text;
            Frm_TTCaNhanKH.tenDN = txtUserName.Text;
            Frm_TTCaNhan_NV.tenDN = txtUserName.Text;
            Frm_DangKy.tenDN = txtUserName.Text;
            Frm_DatTour.tenDN = txtUserName.Text;
            Frm_DoiMKNV.tenDN = txtUserName.Text;
            Frm_TTCaNhan_NV.tenDN = txtUserName.Text;
            xuLyDoiMKAdmin.tenDN = txtUserName.Text;
            // Lấy mã nhân viên từ user name
            xlbt.showMaNV(txtUserName.Text);
        }

        // Khởi tạo ngày giờ hệ thống ------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text =  DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
        }

        // Đăng nhập -----------------------------------------------------------------------
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (xldn.login(txtUserName.Text, txtMK.Text))
            {
                // Lấy quyền đăng nhập
                int q = xldn.layQuyenDN(txtUserName.Text);

                // Quyền khách hàng
                if (q == 3)
                {
                    MessageBox.Show("Chào mừng quý khách\nQuý khách đã đăng nhập " +
                        "thành công!", "Thông báo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    luuBienCucBo(); // Lưu tên user name
                    Frm_HomeKH hkh = new Frm_HomeKH();
                    this.Hide();
                    hkh.Show();
                }
                // Quyền nhân viên
                else if (q == 2)
                {
                    MessageBox.Show("Chào mừng bạn\nBạn đã đăng nhập " +
                        "thành công!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    luuBienCucBo(); // Lưu tên user name
                    Frm_HomeNV hnv = new Frm_HomeNV();
                    this.Hide();
                    hnv.Show();
                }
                // Quyền quản lý
                else
                {
                    MessageBox.Show("Chào mừng bạn\nBạn đã đăng nhập " +
                        "thành công!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    luuBienCucBo(); // Lưu tên user name
                    Frm_HomeAdmin ha = new Frm_HomeAdmin();
                    this.Hide();
                    ha.Show();
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công\n" +
                    "Vui lòng kiểm tra lại User name hoặc Mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reset ---------------------------------------------------------------------------
        private void btnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn nhập lại?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                txtUserName.Text = "";
                txtMK.Text = "";
                txtUserName.Focus();
            }
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

        // Đăng ký tài khoản ---------------------------------------------------------------
        private void lblDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_DangKy dk = new Frm_DangKy();
            dk.Show();
        }

        // Load form -----------------------------------------------------------------------
        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_KetNoiSerVer_Click(object sender, EventArgs e)
        {
           
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
