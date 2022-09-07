using QLTourDuLich.GUI.Frm_NV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.Frm_NV
{
    public partial class Frm_HomeNV : Form
    {
        public Frm_HomeNV()
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
            Frm_DoiMKNV dmk = new Frm_DoiMKNV();
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

        // QLVe ----------------------------------------------------------------------------
        private void véToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLVe_NV v = new Frm_QLVe_NV();
            v.Show();
        }

        // QLKH ----------------------------------------------------------------------------
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLKH_NV kh = new Frm_QLKH_NV();
            kh.Show();
        }

        // QLTour --------------------------------------------------------------------------
        private void tourToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLTour_NV t = new Frm_QLTour_NV();
            t.Show();
        }

        // QLPT ----------------------------------------------------------------------------
        private void phươngTiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLPT_NV pt = new Frm_QLPT_NV();
            pt.Show();
        }

        // QLDDTQ --------------------------------------------------------------------------
        private void địaĐiểmThamQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLDDTQ_NV ddtq = new Frm_QLDDTQ_NV();
            ddtq.Show();
        }

        // QLKS ----------------------------------------------------------------------------
        private void kháchSạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_QLKS_NV ks = new Frm_QLKS_NV();
            ks.Show();
        }

        // Thông tin cá nhân ---------------------------------------------------------------
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_TTCaNhan_NV ttcn = new Frm_TTCaNhan_NV();
            ttcn.Show();
        }

        // Load form -----------------------------------------------------------------------
        private void Frm_HomeNV_Load(object sender, EventArgs e)
        {
            // Hiển thị tên User Name đang đăng nhập
            lblTenNV.Text = "Xin chào Nhân viên: " + tenDN;
        }
    }
}
