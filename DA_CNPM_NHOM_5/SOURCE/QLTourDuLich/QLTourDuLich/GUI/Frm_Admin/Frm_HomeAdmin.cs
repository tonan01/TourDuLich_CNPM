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
    public partial class Frm_HomeAdmin : Form
    {
        public Frm_HomeAdmin()
        {
            InitializeComponent();
        }

        // Biến động tenDN hiển thị tên người dùng đang đăng nhập
        public static string tenDN = ""; 

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
        }

        // Đổi mật khẩu --------------------------------------------------------------------
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_DoiMKAdmin dmk = new Frm_DoiMKAdmin();
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

        // QLKH ----------------------------------------------------------------------------
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLKH kh = new Frm_QLKH();
            kh.Show();
        }

        // QLNV ----------------------------------------------------------------------------
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLNV nv = new Frm_QLNV();
            nv.Show();
        }

        // QLTour --------------------------------------------------------------------------
        private void tourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLTour t = new Frm_QLTour();
            t.Show();
        }

        // Vé ------------------------------------------------------------------------------
        private void véToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
           Frm_QLVe v = new Frm_QLVe();
            v.Show();
        }

        // QLPT ----------------------------------------------------------------------------
        private void phươngTiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLPT pt = new Frm_QLPT();
            pt.Show();
        }

        // QLDDTQ --------------------------------------------------------------------------
        private void địaĐiểmThamQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLDDTQ ddtq = new Frm_QLDDTQ();
            ddtq.Show();
        }

        // QLKS ----------------------------------------------------------------------------
        private void kháchSạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLKS ks = new Frm_QLKS();
            ks.Show();
        }

        // Load form -----------------------------------------------------------------------
        private void Frm_HomeAdmin_Load(object sender, EventArgs e)
        {
            // Hiển thị tên User Name đang đăng nhập
            lblTenAdmin.Text = "Xin chào Quản lý: " + tenDN; 
        }
    }
}