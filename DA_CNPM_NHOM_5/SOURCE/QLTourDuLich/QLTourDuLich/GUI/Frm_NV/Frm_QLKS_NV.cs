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
    public partial class Frm_QLKS_NV : Form
    {
        public Frm_QLKS_NV()
        {
            InitializeComponent();
            dataGridView1.DataSource = xl.getloadDataKS();
            cbbDiaChi.DataSource = xl.getloadDiaChi();

            cbbDiaChi.DisplayMember = "maTinh";
            cbbDiaChi.ValueMember = "maTinh";
            dataGridView1.ReadOnly = true;
        }
        BUS_QLKS_NV xl = new BUS_QLKS_NV();

        // Quay lại trang chủ --------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeNV hnv = new Frm_HomeNV();
            hnv.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            xl.resetDataTable();
            dataGridView1.DataSource = xl.TimKS(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_QLKS_NV ks = new DTO_QLKS_NV(txtMaKS.Text, txtTenKS.Text, cbbDiaChi.Text.ToString(), txtSDT.Text);

            if (xl.KTRong_maKS(txtMaKS.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaKS.Text);
                txtMaKS.Focus();
                return;
            }
            if (xl.KTRong_tenKS(txtTenKS.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbTenKS.Text);
                txtTenKS.Focus();
                return;
            }
            if (xl.KTRong_SDT(txtSDT.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbSDT.Text);
                txtSDT.Focus();
                return;
            }
            if (xl.KTsokytu_SDT(txtSDT.Text) == false)
            {
                MessageBox.Show("SDT không hợp lệ");
                txtSDT.Focus();
                return;
            }
            if (xl.KT_KS(txtMaKS.Text) == false)
            {
                MessageBox.Show("Đã tồn tại mã khách sạn!");
                txtMaKS.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có muốn thêm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm
                if (xl.themKS(ks))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKS(); ;
                    return;
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xl.KTRong_maKS(txtMaKS.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaKS.Text);
                txtMaKS.Focus();
                return;
            }
            if (xl.KT_KhoaNgoaiKS(txtMaKS.Text) == false)
            {
                MessageBox.Show("Khách sạn đang được sử dụng không thể xóa!");
                txtMaKS.Focus();
                return;
            }
            DTO_QLKS_NV ks = new DTO_QLKS_NV(txtMaKS.Text, txtTenKS.Text, cbbDiaChi.Text.ToString(), txtSDT.Text);
            if (MessageBox.Show("Bạn có muốn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (xl.xoaKS(ks))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKS(); ;
                    return;
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (xl.KTRong_maKS(txtMaKS.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaKS.Text);
                txtMaKS.Focus();
                return;
            }
            if (xl.KTRong_tenKS(txtTenKS.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbTenKS.Text);
                txtTenKS.Focus();
                return;
            }
            if (xl.KTRong_SDT(txtSDT.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbSDT.Text);
                txtSDT.Focus();
                return;
            }
            if (xl.KTsokytu_SDT(txtSDT.Text) == false)
            {
                MessageBox.Show("SDT không hợp lệ, phải có 10 kí tự!");
                txtSDT.Focus();
                return;
            }
            if (xl.KT_KhoaNgoaiKS(txtMaKS.Text) == false)
            {
                MessageBox.Show("Khách sạn đang được sử dụng không thể sửa!");
                txtMaKS.Focus();
                return;
            }
            DTO_QLKS_NV ks = new DTO_QLKS_NV(txtMaKS.Text, txtTenKS.Text, cbbDiaChi.Text.ToString(), txtSDT.Text);
            if (MessageBox.Show("Bạn có muốn Sửa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm
                if (xl.suaKS(ks))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKS(); ;
                    return;
                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaKS.Text = "";
            txtTenKS.Text = "";
            txtSDT.Text = "";
            cbbDiaChi.SelectedIndex = 0;
            txtMaKS.Enabled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)//không chon
            {
                txtMaKS.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenKS.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtMaKS.Enabled = false;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Frm_QLKS_NV_Load(object sender, EventArgs e)
        {

        }
    }
}
