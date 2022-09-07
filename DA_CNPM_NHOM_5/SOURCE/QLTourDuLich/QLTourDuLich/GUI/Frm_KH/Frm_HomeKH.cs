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
    public partial class Frm_HomeKH : Form
    {
        public Frm_HomeKH()
        {
            InitializeComponent();
        }

        // Biến động tenDN hiển thị tên người dùng đang đăng nhập
        public static string tenDN = "";

        // Đổi mật khẩu --------------------------------------------------------------------
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_DoiMKKH dmk = new Frm_DoiMKKH();
            dmk.Show();
        }

        // Đăng xuất -----------------------------------------------------------------------
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                tenDN = "";
                this.Hide();
                Frm_DangNhap dn = new Frm_DangNhap();
                dn.Show();
            }
        }

        // Thông tin cá nhân ---------------------------------------------------------------
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_TTCaNhanKH ttcn = new Frm_TTCaNhanKH();
            ttcn.Show();
        }

        // Tour ----------------------------------------------------------------------------
        private void tourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_DatTour dt = new Frm_DatTour();
            dt.Show();
        }

        // Load form -----------------------------------------------------------------------
        private void Frm_HomeKH_Load(object sender, EventArgs e)
        {
                // Hiển thị tên User Name đang đăng nhập
                lblTenKH.Text = "Xin chào Quý khách: " + tenDN;
        }
    }
}