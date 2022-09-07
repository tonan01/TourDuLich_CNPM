using QLTourDuLich.BUS.BUS_Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.Frm_Admin
{
    public partial class Frm_DoiMKAdmin : Form
    {
        public Frm_DoiMKAdmin()
        {
            InitializeComponent();
        }
        BUS_DoiMKAdmin dt = new BUS_DoiMKAdmin();
        // Reset ---------------------------------------------------------------------------
        private void btnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn nhập lại?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                txtUserName.Text = "";
                txtMK.Text = "";
                txtNhapLaiMK.Text = "";
                txtUserName.Focus();
            }
        }

        // Đổi mật khẩu --------------------------------------------------------------------
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (dt.KTRong(txtUserName.Text, txtMK.Text, txtNhapLaiMK.Text) == false)//rỗng or không thỏa dk đúng email or nhập không giống pass
            {
                return;
            }
            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn đổi mật khẩu không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dt.Sua(txtUserName.Text, txtMK.Text))//thành công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    //làm mới
                    txtUserName.Text = "";
                    txtMK.Text = "";
                    txtNhapLaiMK.Text = "";
                    txtUserName.Focus();
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
                    return;
                }
            }
        }

        // Quay lại trang chủ --------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeAdmin ha = new Frm_HomeAdmin();
            ha.Show();
        }

        private void Frm_DoiMKAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
