using QLTourDuLich.BUS.BUS_NV;
using QLTourDuLich.DTO.DTO_NV;
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
    public partial class Frm_QLPT_NV : Form
    {
        BUS_QLPT_NV busPT = new BUS_QLPT_NV();

        public Frm_QLPT_NV()
        {
            InitializeComponent();
        }
        //Loa Du Lieu
        public void loadData()
        {
            DataTable dt = busPT.getPhuongTien();
            dataGridView1.DataSource = dt;
        }
        // Kiểm tra thông tin
        public bool KTThongTin()
        {
            if (txtMaPT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPT.Focus();
                return false;
            }
            if (txtTenPT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên phương tiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPT.Focus();
                return false;
            }
            if (txtTinhTrang.Text == "")
            {
                MessageBox.Show("Vui lòng nhập hiện trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTinhTrang.Focus();
                return false;
            }
            return true;
        }
        // Xóa textBox
        public void XoaTextBox()
        {
            txtMaPT.Text = "";
            txtTenPT.Text = "";
            txtTinhTrang.Text = "";
        }
        // Quay về trang chủ ---------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeNV hnv = new Frm_HomeNV();
            hnv.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                DataTable dt = busPT.timPhuongTien(txtTimKiem.Text);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên chuyến cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPT.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KTThongTin())
            {
                // Tạo DTo
                DTO_QLPT_NV pt = new DTO_QLPT_NV(txtMaPT.Text, txtTenPT.Text, txtTinhTrang.Text);

                // Them
                try
                {
                    busPT.themPhuongTien(pt);
                    loadData();
                    XoaTextBox();
                    MessageBox.Show("Thêm thành công");

                }
                catch
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                busPT.xoaPhuongTien(txtMaPT.Text);
                loadData();
                XoaTextBox();
                MessageBox.Show("Xóa thành công");

            }
            catch
            {
                MessageBox.Show("Xóa không thành công");

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KTThongTin())
            {
                DTO_QLPT_NV pt = new DTO_QLPT_NV(txtMaPT.Text, txtTenPT.Text, txtTinhTrang.Text);
                try
                {
                    busPT.suaPhuongTien(pt);
                    loadData();
                    XoaTextBox();
                    MessageBox.Show("Sửa thành công");

                }
                catch
                {
                    MessageBox.Show("Sửa không thành công");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            XoaTextBox();
        }

        private void Frm_QLPT_NV_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == " ") loadData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)//không chon
            {
                txtMaPT.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenPT.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtTinhTrang.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }
    }
}
