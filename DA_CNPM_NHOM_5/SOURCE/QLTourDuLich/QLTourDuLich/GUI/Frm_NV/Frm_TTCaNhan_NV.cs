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
    public partial class Frm_TTCaNhan_NV : Form
    {
        BUS_TTCaNhan_NV dt = new BUS_TTCaNhan_NV();
        // Biến động tenDN hiển thị tên người dùng đang đăng nhập
        public static string tenDN = "";
        public Frm_TTCaNhan_NV()
        {
            InitializeComponent();
        }

        // Xóa textbox
        private void xoatextbox()
        {
            txtHoTen.Text = "";
            txtEmail.Text = " ";
            txtSDT.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
        }


        // Quay về trang chủ ---------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeNV hnv = new Frm_HomeNV();
            hnv.Show();
        }
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            //tạo DTO
            DTO_TTCaNhan_NV nv = new DTO_TTCaNhan_NV(txtManv.Text, txtHoTen.Text, cbbCV.SelectedValue.ToString(), txtEmail.Text, cbbDiaChi.SelectedValue.ToString(), chonGioiT(), dtpNgaySinh.Value, txtSDT.Text);

            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn sửa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //sửa
                if (dt.Sua(nv))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = dt.getThongTinCaNhan_NV(tenDN);
                    xoatextbox();
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
            xoatextbox();
        }

        private void Frm_TTCaNhan_NV_Load(object sender, EventArgs e)
        {
            //load dữ liệu griv của người đăng nhập
            dataGridView1.DataSource = dt.getThongTinCaNhan_NV(tenDN);
            //load dữ liệu vào combobox địa chỉ
            cbbDiaChi.DataSource = dt.getloadDiaChi();
            cbbDiaChi.DisplayMember = "tenTinh";//hiển thị
            cbbDiaChi.ValueMember = "maTinh";//lấy giá trị
                                             //load dữ liệu vào combobox công việc
            cbbCV.DataSource = dt.getloadcv();
            cbbCV.DisplayMember = "tenCV";//hiển thị
            cbbCV.ValueMember = "maCV";//lấy giá trị
            //vô hiệu hóa 
            txtManv.Enabled = false;
            //hiển thị email của khách hàng đăng đăng nhập
            txtManv.Text = tenDN;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtManv.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbbCV.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
                //xử lý hiển thị lên rdo buttun
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Nam")
                {
                    rdbNam.Checked = true;//chon nam
                }
                else
                {
                    rdbNu.Checked = true;//chọn nữ
                }
                dtpNgaySinh.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
        }
    }
}
