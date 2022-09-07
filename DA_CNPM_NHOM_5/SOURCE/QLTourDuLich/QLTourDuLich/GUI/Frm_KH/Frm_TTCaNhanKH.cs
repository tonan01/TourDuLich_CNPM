using QLTourDuLich.BUS.BUS_KH;
using QLTourDuLich.DTO.DTO_KH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.Frm_KH
{
    public partial class Frm_TTCaNhanKH : Form
    {
        public Frm_TTCaNhanKH()
        {
            InitializeComponent();
        }
        BUS_TTCaNhanKH dt = new BUS_TTCaNhanKH();
        // Biến động tenDN hiển thị tên người dùng đang đăng nhập
        public static string tenDN = "";

        // Quay về trang chủ ---------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeKH hkh = new Frm_HomeKH();
            hkh.Show();
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

        private void Frm_TTCaNhanKH_Load(object sender, EventArgs e)
        {
            //load dữ liệu vào combobox địa chỉ
            cbbDiaChi.DataSource = dt.getloadDiaChi();
            cbbDiaChi.DisplayMember = "tenTinh";//hiển thị
            cbbDiaChi.ValueMember = "maTinh";//lấy giá trị
            //load dữ liệu griv của người đăng nhập
            dataGridView1.DataSource = dt.getThongTinCaNhan_KH(tenDN);
            //vô hiệu hóa 
            txtemail.Enabled = false;
            //hiển thị email của khách hàng đăng đăng nhập
            txtemail.Text = tenDN;
        }

        private void grbTTCT_Enter(object sender, EventArgs e)
        {

        }

        //sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            //tạo DTO
            DTO_TTCaNhanKH kh = new DTO_TTCaNhanKH(txtemail.Text, txtHoTen.Text, cbbDiaChi.SelectedValue.ToString(), chonGioiT(), dtpNgaySinh.Value.ToShortDateString(), txtSDT.Text);
            
            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn sửa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //sửa
                if (dt.Sua(kh))//thành  công
                {
                    MessageBox.Show("Thành công", "Thông Báo");
                    dataGridView1.DataSource = dt.getThongTinCaNhan_KH(tenDN);
                    return;
                }
                else//thất bại
                {
                    MessageBox.Show("Thất Bại", "Thông Báo");
                    return;
                }
            }
        }

        
        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        //nhập lại
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            cbbDiaChi.SelectedIndex = 0;//chuyển comboboox về địa chỉ đầu tiên
        }

        //hiển thị lên txtbox
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtemail.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                //xử lý hiển thị lên rdo buttun
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Nam")
                {
                    rdbNam.Checked = true;//chon nam
                }
                else
                {
                    rdbNu.Checked = true;//chọn nữ
                }
                dtpNgaySinh.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')//không phải là số và không nhập dấu trừ
            {
                e.Handled = true;
            }
        }
    }
}
