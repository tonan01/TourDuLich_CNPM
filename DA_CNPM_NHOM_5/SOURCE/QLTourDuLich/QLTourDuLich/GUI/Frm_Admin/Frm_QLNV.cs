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
    public partial class Frm_QLNV : Form
    {
        public Frm_QLNV()
        {
            InitializeComponent();
        }
        BUS_QLNV dt = new BUS_QLNV();
        // Quay lại trang chủ --------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeAdmin ha = new Frm_HomeAdmin();
            ha.Show();
        }
        //chọn giới tính
        public string chonGioiT()
        {
            if (rdbNam.Checked == true)//chọn nam
            {
                return "Nam";
            }
            else//chọn nữ
            {
                return "Nữ";
            }
        }
        private void Frm_QLNV_Load(object sender, EventArgs e)
        {
            //load dữ liệu vào combobox địa chỉ
            cbbDiaChi.DataSource = dt.getcbbDiaChi();
            cbbDiaChi.DisplayMember = "tenTinh";//hiển thị
            cbbDiaChi.ValueMember = "maTinh";//lấy giá trị

            //load dữ liệu vào combobox chức vụ
            cbbCV.DataSource = dt.getcbbChucVu();
            cbbCV.DisplayMember = "tenCV";//hiển thị
            cbbCV.ValueMember = "maCV";//lấy giá trị

            //load dữ liệu griv của người đăng nhập
            dataGridView1.DataSource = dt.getloadNV();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')//không phải là số và không nhập dấu trừ
            {
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //kiem tra rông
            if (dt.KTrong(txtMaNV.Text, txt_email.Text, txtHoTen.Text, txtSDT.Text) == false)//rỗng
            {
                return;
            }
            if (dt.KTKhoaC(txtMaNV.Text) == false)//tồn mại mã nhân viên
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thong bao");
                return;
            }
            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn Thêm", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //tạo DTO
                DTO_QLNV nv = new DTO_QLNV(txtMaNV.Text, txtHoTen.Text, cbbCV.SelectedValue.ToString(), txt_email.Text, cbbDiaChi.SelectedValue.ToString(), chonGioiT(), dtpNgaySinh.Value.ToShortDateString(), txtSDT.Text);
                //sửa
                if (dt.them(nv)==dt.themtk(txtMaNV.Text)==true)//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = dt.getloadNV();
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
                    return;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //kiem tra rông
            if (txtMaNV.Text=="")//rỗng
            {
                MessageBox.Show("Nhập mã nhân viên", "thong báo");
                return;
            }
            if (dt.KTKhoaC(txtMaNV.Text) == true)//không tồn tại mã này
            {
                MessageBox.Show("Mã nhân viên này không tồn tại", "Thong bao");
                return;
            }
            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //xóa
                if (dt.xoa(txtMaNV.Text)==dt.xoatk(txtMaNV.Text)==true)//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = dt.getloadNV();
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
            //kiem tra rông
            if(dt.KTrong(txtMaNV.Text,txt_email.Text,txtHoTen.Text,txtSDT.Text)==false)//rỗng
            {
                return;
            }
            if(dt.KTKhoaC(txtMaNV.Text)==true)//không tồn tại mã này
            {
                MessageBox.Show("Mã nhân viên này không tồn tại", "Thong bao");
                return;
            }
            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn sửa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //tạo DTO
                DTO_QLNV nv = new DTO_QLNV(txtMaNV.Text, txtHoTen.Text, cbbCV.SelectedValue.ToString(), txt_email.Text, cbbDiaChi.SelectedValue.ToString(), chonGioiT(), dtpNgaySinh.Value.ToShortDateString(), txtSDT.Text);
                //sửa
                if (dt.sua(nv))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = dt.getloadNV();
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
                    return;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtMaNV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbbCV.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_email.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else
                {
                    rdbNu.Checked = true;
                }

                dtpNgaySinh.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
        }
    }
}
