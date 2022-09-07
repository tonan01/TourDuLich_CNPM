using QLTourDuLich.BUS.BUS_NV;
using QLTourDuLich.DTO.DTO_NV;
using QLTourDuLich.Frm_NV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.GUI.Frm_NV
{
    public partial class Frm_DoiMKNV : Form
    {
        public Frm_DoiMKNV()
        {
            InitializeComponent();
        }
        BUS_DoiMKNV xl = new BUS_DoiMKNV();
        // Biến động tenDN hiển thị tên người dùng đang đăng nhập
        public static string tenDN = "";
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            DTO_DoiMKNV mk = new DTO_DoiMKNV(txtMaNV.Text, txtMK.Text, txtMK_hientai.Text);
            if (xl.KTRong_maNV(txtMaNV.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaNV.Text);
                txtMaNV.Focus();
                return;
            }
            if (xl.KTRong_MK(txtMK.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMatKhau.Text);
                txtMK.Focus();
                return;
            }
            if (xl.SoSanh(txtMK.Text, txtNhapLaiMK.Text) == false)
            {
                MessageBox.Show("Mật khẩu và nhập lại mật khẩu không giống nhau!");
                return;
            }
            if (MessageBox.Show("Bạn có muốn đổi mật khẩu?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (xl.setMK(mk) == true)
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công");
                }
                else
                    MessageBox.Show("Mật khẩu hiện tại không chính xác!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            txtMK.Text = "";
            txtNhapLaiMK.Text = "";
            txtMK_hientai.Text = "";
        }
        // Quay lại trang chủ --------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeNV hnv = new Frm_HomeNV();
            hnv.Show();
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            if (txtMK.PasswordChar == '*')
            { txtMK.PasswordChar = '\0'; }
            else
                txtMK.PasswordChar = '*';
        }

        private void picHide2_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMK.PasswordChar == '*')
            { txtNhapLaiMK.PasswordChar = '\0'; }
            else
                txtNhapLaiMK.PasswordChar = '*';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtMK_hientai.PasswordChar == '*')
            { txtMK_hientai.PasswordChar = '\0'; }
            else
                txtMK_hientai.PasswordChar = '*';
        }

        private void Frm_DoiMKNV_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            txtMaNV.Text = tenDN;
        }
    }
}
