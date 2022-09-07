using QLTourDuLich.BUS.BUS_KH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.Frm_KH
{
    public partial class Frm_DoiMKKH : Form
    {
        public Frm_DoiMKKH()
        {
            InitializeComponent();
        }
        BUS_DoiMKKH dt = new BUS_DoiMKKH();
        // Quay lại trang chủ --------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeKH hkh = new Frm_HomeKH();
            hkh.Show();
        }

        private void Frm_DoiMKKH_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (dt.KTRong(txtEmail.Text, txtMK.Text, txtNhapLaiMK.Text) == false)//rỗng or không thỏa dk đúng email or nhập không giống pass
            {
                return;
            }
            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn đổi mật khẩu không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dt.Sua(txtEmail.Text, txtMK.Text))//thành công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    //làm mới
                    Resetmk();
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
                    return;
                }
            }
        }

        //làm mới
        public void Resetmk()
        {
            //làm mới
            txtEmail.Clear();
            txtMK.Clear();
            txtNhapLaiMK.Clear();
            //di chuyển con trỏ chuột
            txtEmail.Focus();
        }
        //reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            Resetmk();
        }
    }
}
