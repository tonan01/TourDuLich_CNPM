using QLTourDuLich.BUS.BUS_Admin;
using QLTourDuLich.DTO.DTO_Admin;
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
    public partial class Frm_QLKS : Form
    {
        public Frm_QLKS()
        {
            InitializeComponent();
            dataGridView1.DataSource = xl.getloadDataKS();
            cbbDiaChi.DataSource = xl.getloadDiaChi();

            cbbDiaChi.DisplayMember = "maTinh";
            cbbDiaChi.ValueMember = "maTinh";
            dataGridView1.ReadOnly = true;
        }
        BUS_QLKS xl = new BUS_QLKS();

        // Quay lại trang chủ --------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeAdmin ha = new Frm_HomeAdmin();
            ha.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_QLKS ks = new DTO_QLKS(txtMaKS.Text, txtTenKS.Text, cbbDiaChi.Text.ToString(), txtSDT.Text);
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
            if (MessageBox.Show("Bạn có muốn thêm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm
                if (xl.themKS(ks))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKS(); ;
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
                    return;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            xl.resetDataTable();
            dataGridView1.DataSource = xl.TimKS(txtTimKiem.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xl.KTRong_maKS(txtMaKS.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaKS.Text);
                txtMaKS.Focus();
                return;
            }
            DTO_QLKS ks = new DTO_QLKS(txtMaKS.Text, txtTenKS.Text, cbbDiaChi.Text.ToString(), txtSDT.Text);
            if (MessageBox.Show("Bạn có muốn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm
                if (xl.xoaKS(ks))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKS(); ;
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
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
                MessageBox.Show("SDT không hợp lệ");
                txtSDT.Focus();
                return;
            }
            DTO_QLKS ks = new DTO_QLKS(txtMaKS.Text, txtTenKS.Text, cbbDiaChi.Text.ToString(), txtSDT.Text);
            if (MessageBox.Show("Bạn có muốn Sửa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm
                if (xl.suaKS(ks))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKS(); ;
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
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
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)//không chon
            {
                txtMaKS.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenKS.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Frm_QLKS_Load(object sender, EventArgs e)
        {

        }
    }
}
