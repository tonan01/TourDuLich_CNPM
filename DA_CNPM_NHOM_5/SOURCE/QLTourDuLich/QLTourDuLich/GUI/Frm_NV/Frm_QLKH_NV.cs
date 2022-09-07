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
    public partial class Frm_QLKH_NV : Form
    {
        public Frm_QLKH_NV()
        {
            InitializeComponent();
            dataGridView1.DataSource = xl.getloadDataKH();
            cbbDiaChi.DataSource = xl.getloadDiaChi();
            cbbDiaChi.DisplayMember = "maTinh";
            cbbDiaChi.ValueMember = "maTinh";
            dataGridView1.ReadOnly = true;
            dtpNgaySinh.Value = DateTime.Now;
        }
        BUS_QLKH_NV xl = new BUS_QLKH_NV();
        // Quay về trang chủ ---------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeNV hnv = new Frm_HomeNV();
            hnv.Show();
        }
        public string chonGioiTinh()
        {
            if (rdbNam.Checked == true)
            {
                return "Nam";
            }
            else
            {
                return "Nữ";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (rdbNam.Checked == false && rdbNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (xl.KT_Email(txtEmail.Text) == false)
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
                return;
            }
            if (xl.KTRong_tenKH(txtHoTen.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbHoTen.Text);
                txtHoTen.Focus();
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
                MessageBox.Show("SDT không hợp lệ! Phải có 10 số");
                txtSDT.Focus();
                return;
            }

            DTO_QLKH_NV kh = new DTO_QLKH_NV(txtEmail.Text, txtHoTen.Text, cbbDiaChi.Text.ToString(), chonGioiTinh(), this.dtpNgaySinh.Text, txtSDT.Text);
            if (MessageBox.Show("Bạn có muốn thêm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //thêm tk

                if (xl.ThemUser(txtEmail.Text) == true)
                {
                    if (xl.themKH(kh) == true)
                        dataGridView1.DataSource = xl.getloadDataKH();
                    MessageBox.Show("Thêm thành công", "Thông Báo");
                    return;
                }

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            xl.resetDataTable();
            dataGridView1.DataSource = xl.TimKH(txtTimKiem.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lbEmail.Text);
                txtEmail.Focus();
                return;
            }

            if (rdbNam.Checked == false && rdbNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (xl.KT_Email(txtEmail.Text) == false)
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
                return;
            }
            if (xl.KTRong_tenKH(txtHoTen.Text) == false)
            {
                MessageBox.Show("Bạn phải nhập " + lbHoTen.Text);
                txtHoTen.Focus();
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
                MessageBox.Show("SDT không hợp lệ!");
                txtSDT.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DTO_QLKH_NV kh = new DTO_QLKH_NV(txtEmail.Text, txtHoTen.Text, cbbDiaChi.Text.ToString(), chonGioiTinh(), this.dtpNgaySinh.Text, txtSDT.Text);
                //sửa
                if (xl.suaKH(kh))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKH();
                    return;
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lbEmail.Text);
                txtEmail.Focus();
                return;
            }
            if (xl.KT_khoaNgoaiKH(txtEmail.Text) == false)
            {
                MessageBox.Show("Tài khoản đang được sử dụng không thể xóa");
                txtEmail.Focus();
                return;
            }
            DTO_QLKH_NV kh = new DTO_QLKH_NV(txtEmail.Text, txtHoTen.Text, cbbDiaChi.Text.ToString(), chonGioiTinh(), this.dtpNgaySinh.Text, txtSDT.Text);
            if (MessageBox.Show("Bạn có muốn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (xl.xoaKH(kh) == xl.XoaUser(txtEmail.Text) == true)//Xóa bảng KHACHHANG                     
                {
                    // if (xl.XoaUser(txtEmail.Text) == true)// xóa user bảng Tài Khoản

                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = xl.getloadDataKH();
                    return;

                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtHoTen.Text = "";

            txtSDT.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            cbbDiaChi.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Today;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtEmail.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else
                {
                    rdbNu.Checked = true;
                }

                dtpNgaySinh.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
