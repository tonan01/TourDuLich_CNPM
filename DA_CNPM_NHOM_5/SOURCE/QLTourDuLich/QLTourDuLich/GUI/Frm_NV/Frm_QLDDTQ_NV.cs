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
    public partial class Frm_QLDDTQ_NV : Form
    {
        public Frm_QLDDTQ_NV()
        {
            InitializeComponent();
            dataGridView1.DataSource = xl.getloadDataDDTQ();
            cbbDiaChi.DataSource = xl.getloadDiaChi();

            cbbDiaChi.DisplayMember = "maTinh";
            cbbDiaChi.ValueMember = "maTinh";
            dataGridView1.ReadOnly = true;
        }
        BUS.BUS_NV.BUS_QLDDTQ_NV xl = new BUS.BUS_NV.BUS_QLDDTQ_NV();

        // Quay lại trang chủ --------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeNV hnv = new Frm_HomeNV();
            hnv.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO.DTO_NV.DTO_QLDDTQ_NV dd = new DTO.DTO_NV.DTO_QLDDTQ_NV(txtMaDD.Text, txtTenDD.Text, cbbDiaChi.Text.ToString());
            if (xl.KTRong_maDD(txtMaDD.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaDD.Text);
                txtMaDD.Focus();
                return;
            }
            if (xl.KTRong_tenDD(txtTenDD.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbTenDD.Text);
                txtTenDD.Focus();
                return;
            }
            if (xl.KT_KhoaChinh(txtMaDD.Text) == false)
            {
                MessageBox.Show("Đã tồn tại mã địa điểm!");
                txtMaDD.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn thêm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm
                if (xl.themDDTQ(dd))//thành  công
                {
                    MessageBox.Show("Thêm Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataDDTQ();
                    return;
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xl.KTRong_maDD(txtMaDD.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaDD.Text);
                txtMaDD.Focus();
                return;
            }
            if (xl.KT_KhoaNgoaiDD(txtMaDD.Text) == false)
            {
                MessageBox.Show("Địa điểm đang được sử dụng không thể xóa!");
                txtMaDD.Focus();
                return;
            }
            DTO.DTO_NV.DTO_QLDDTQ_NV dd = new DTO.DTO_NV.DTO_QLDDTQ_NV(txtMaDD.Text, txtTenDD.Text, cbbDiaChi.Text.ToString());
            if (MessageBox.Show("Bạn có muốn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm
                if (xl.xoaDDTQ(dd))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataDDTQ();
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
            if (xl.KTRong_maDD(txtMaDD.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbMaDD.Text);
                txtMaDD.Focus();
                return;
            }
            if (xl.KTRong_tenDD(txtTenDD.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbTenDD.Text);
                txtTenDD.Focus();
                return;
            }
            if (xl.KT_KhoaNgoaiDD(txtMaDD.Text) == false)
            {
                MessageBox.Show("Địa điểm đang được sử dụng không thể xóa!");
                txtMaDD.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DTO.DTO_NV.DTO_QLDDTQ_NV dd = new DTO.DTO_NV.DTO_QLDDTQ_NV(txtMaDD.Text, txtTenDD.Text, cbbDiaChi.Text.ToString());
                //sửa
                if (xl.suaDDTQ(dd))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataDDTQ();
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Sửa thất bại", "Thông Báo");
                    return;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaDD.Text = "";
            txtTenDD.Text = "";
            cbbDiaChi.SelectedIndex = 0;
            txtMaDD.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            xl.resetDataTable();
            dataGridView1.DataSource = xl.TimDDTQ(txtTimKiem.Text);
        }

        private void Frm_QLDDTQ_NV_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtMaDD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenDD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtMaDD.Enabled = false;
            }
        }
    }
}
