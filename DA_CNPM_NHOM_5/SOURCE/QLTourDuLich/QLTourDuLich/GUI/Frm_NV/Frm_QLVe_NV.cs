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
    public partial class Frm_QLVe_NV : Form
    {
        BUS_QLVe_NV busVe = new BUS_QLVe_NV();
        public Frm_QLVe_NV()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            DataTable dt = busVe.getVe();
            dataGridView1.DataSource = dt;
        }
        private void load_cbbmaTour()
        {
            DataTable dt = busVe.load_maTour();
            cbbMaTour.DisplayMember = "tenTour";
            cbbMaTour.ValueMember = "maTour";
            cbbMaTour.DataSource = dt;
        }
        private void load_cbbmaDL()
        {
            DataTable dt = busVe.load_maDL();
            cbbMaDL.DisplayMember = "tenDL";
            cbbMaDL.ValueMember = "maDL";
            cbbMaDL.DataSource = dt;
        }
        private void load_cbbmaKS()
        {
            DataTable dt = busVe.load_maKS();
            cbbMaKS.DisplayMember = "tenKS";
            cbbMaKS.ValueMember = "maKS";
            cbbMaKS.DataSource = dt;
        }
        private void load_cbbmaPT()
        {
            DataTable dt = busVe.load_maPT();
            cbbMaPT.DisplayMember = "tenPT";
            cbbMaPT.ValueMember = "maPT";
            cbbMaPT.DataSource = dt;
        }
        // Quay về trang chủ ---------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeNV hnv = new Frm_HomeNV();
            hnv.Show();
        }
        private void Taomoi()
        {
            txtMaVe.Text = "";
            txtGia.Text = "";
            load_cbbmaTour();
            load_cbbmaDL();
            load_cbbmaKS();
            load_cbbmaPT();
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
        }
        private void Frm_QLVe_NV_Load(object sender, EventArgs e)
        {
            loadData();
            load_cbbmaTour();
            load_cbbmaDL();
            load_cbbmaKS();
            load_cbbmaPT();
        }
        // Kiểm tra thông tin
        public bool KTThongTin()
        {
            if (txtMaVe.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaVe.Focus();
                return false;
            }
            if (txtGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return false;
            }

            return true;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                DataTable dt = busVe.TimVe(txtTimKiem.Text);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã vé cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaVe.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KTThongTin())
            {
                // Tạo DTo
                DTO_QLVe ve = new DTO_QLVe(txtMaVe.Text, cbbMaTour.SelectedValue.ToString(), cbbMaDL.SelectedValue.ToString(),
                    cbbMaKS.SelectedValue.ToString(), cbbMaPT.SelectedValue.ToString(), double.Parse(txtGia.Text), dtpNgayBD.Value, dtpNgayKT.Value);

                // Them
                try
                {
                    busVe.themVe(ve);
                    loadData();
                    Taomoi();
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
                busVe.xoaVe(txtMaVe.Text);
                loadData();
                Taomoi();
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
                try
                {
                    DTO_QLVe ve = new DTO_QLVe(txtMaVe.Text, cbbMaTour.SelectedValue.ToString(), cbbMaDL.SelectedValue.ToString(), cbbMaKS.SelectedValue.ToString(),
                        cbbMaPT.SelectedValue.ToString(), double.Parse(txtGia.Text), dtpNgayBD.Value, dtpNgayKT.Value);
                    busVe.suaVe(ve);
                    loadData();
                    Taomoi();
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
            Taomoi();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "") loadData();
        }

        private void Frm_QLVe_NV_Load_1(object sender, EventArgs e)
        {
            loadData();
            load_cbbmaTour();
            load_cbbmaDL();
            load_cbbmaKS();
            load_cbbmaPT();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)//không chon
            {
                txtMaVe.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbbMaTour.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                cbbMaDL.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cbbMaKS.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cbbMaPT.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtGia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dtpNgayBD.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                dtpNgayKT.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }    
        }
    }
}
