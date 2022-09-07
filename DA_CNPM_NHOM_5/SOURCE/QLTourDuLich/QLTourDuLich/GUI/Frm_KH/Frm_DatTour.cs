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
    public partial class Frm_DatTour : Form
    {
        public Frm_DatTour()
        {
            InitializeComponent();
        }

        BUS_DatTour dt = new BUS_DatTour();

        // Biến động tenDN hiển thị tên người dùng đang đăng nhập
        public static string tenDN = "";

        // Quay về trang chủ ---------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_HomeKH hkh = new Frm_HomeKH();
            hkh.Show();
        }

        //load dữ liệu
        private void Frm_DatTour_Load(object sender, EventArgs e)
        {
            //load dữ liệu vé
            dataGridView2.DataSource = dt.getDSVe();

            //load dữ liệu của tour
            dataGridView1.DataSource = dt.getDSTour();

            //load dữ liệu vào combobox địa chỉ
            cbbDiaChi.DataSource = dt.getccbDiaChi();
            cbbDiaChi.DisplayMember = "tenTinh";//hiển thị
            cbbDiaChi.ValueMember = "maTinh";//lấy giá trị

            //load dữ liệu vào combobox địa điểm tham quan
            cbbDDTQ.DataSource = dt.getccbDDThamQuan();
            cbbDDTQ.DisplayMember = "tenDD";//hiển thị
            cbbDDTQ.ValueMember = "maDD";//lấy giá trị

            //load dữ liệu vào combobox đại lý
            cbb_daily.DataSource = dt.getcbbDaiLy();
            cbb_daily.DisplayMember = "tenDL";//hiển thị
            cbb_daily.ValueMember = "maDL";//lấy giá trị

            //load dữ liệu vào combobox khách sạn
            cbb_khachsan.DataSource = dt.getcbbKhachSan();
            cbb_khachsan.DisplayMember = "tenKS";//hiển thị
            cbb_khachsan.ValueMember = "maKS";//lấy giá trị

            //load dữ liệu vào combobox phương tiện
            cbb_phuongtien.DataSource = dt.getcbbPhuongTien();
            cbb_phuongtien.DisplayMember = "tenPT";//hiển thị
            cbb_phuongtien.ValueMember = "maPT";//lấy giá trị

            //vô hiệu hóa buttun
            txt_sohoadon.Enabled = txt_mave.Enabled = txtMaTour.Enabled = cbbDDTQ.Enabled = cbbDiaChi.Enabled = cbb_daily.Enabled = cbb_khachsan.Enabled = cbb_phuongtien.Enabled = false;
        }

        //hiển thj dữ liệu lên test box
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)//nếu chọn dữ liệu phía trông griview
            {
                txtMaTour.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbbDDTQ.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
        }

        //làm mới txt số lượng
        public void lamtxtbSoLuong()
        {
            txt_soluongve.Clear();
        }

        private void btnDatTour_Click(object sender, EventArgs e)
        {
           

            //kiểm tra chưa chọn vé
            if(dt.KTRong(txt_mave.Text,txt_soluongve.Text)==false)//chưa chọn vé or chưa nhập sluong
            {
                return;
            }

            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn đặt vé này không", "Thông Báo", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if(txt_sohoadon.Text.Length==0)//chưa tạo hóa đơn
                {
                    //tạo DTO
                    DTO_DatTour hd = new DTO_DatTour(dt.maTuDong().ToString(), tenDN, int.Parse(txt_soluongve.Text), txt_mave.Text);
                    //đặt tour
                    if (dt.DatTour(hd))//thành  công
                    {
                        
                        MessageBox.Show("Đặt vé thành công", "Thông Báo");
                        //hiển thị mã hd đơn của hóa đơn
                        int k = dt.maTuDong() - 1;//do khi thêm vào stt sẽ tăng 1
                        txt_sohoadon.Text = k.ToString();
                        //load ds chi tiết hóa đơn
                        dataGridView3.DataSource = dt.getDSCTHD(txt_sohoadon.Text);
                        //load lại dữ liệu vé
                        dataGridView2.DataSource = dt.getDSVe();
                        //làm mới
                        lamtxtbSoLuong();
                        return;
                    }
                    else//thất bại
                    {
                        MessageBox.Show("Đặt vé thất Bại", "Thông Báo");
                        return;
                    }
                }
                else//đã tạo hóa đơn
                {
                    //tạo DTO
                    DTO_DatTour hd = new DTO_DatTour(txt_sohoadon.Text, tenDN, int.Parse(txt_soluongve.Text), txt_mave.Text);
                    //đặt tour
                    if (dt.DatTourThem(hd))//thành  công đặt tour này thêm vào ct hóa đơn
                    {
                        MessageBox.Show("Đặt vé thành công", "Thông Báo");
                        //load ds chi tiết hóa đơn
                        dt.lamMoiDSCTHD();//làm mới ds
                        dataGridView3.DataSource = dt.getDSCTHD(txt_sohoadon.Text);
                        //load lại dữ liệu vé
                        dataGridView2.DataSource = dt.getDSVe();
                        //làm mới
                        lamtxtbSoLuong();
                        return;
                    }
                    else//thất bại
                    {
                        MessageBox.Show("Đặt vé thất Bại", "Thông Báo");
                        return;
                    }
                }
                
            }
        }

        //tìm kiếm vé
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //làm mới dữ liệu trước khi tìm
            dt.lamMoiSearchVe();
            //tìm kiếm
            dataGridView2.DataSource=dt.searchDatVe(txtTimKiem.Text);
            MessageBox.Show("Tìm kiếm thành công", "Tìm kiếm");
        }

        //hiến thị tour của vé
        public void cTTourcuarve(string matour)
        {
            //hiển thị ds tour của vé
            dt.lamMoiSearch();
            dataGridView1.DataSource = dt.searchDatTour(matour);//chọn mã tour
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)//nếu chọn dữ liệu phía trong griview
            {
                txt_mave.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                cbb_daily.SelectedValue = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                cbb_khachsan.SelectedValue = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                cbb_phuongtien.SelectedValue = dataGridView2.CurrentRow.Cells[7].Value.ToString();

                //hiển thị ds tour của vé
                cTTourcuarve(dataGridView2.CurrentRow.Cells[1].Value.ToString());
            }
            else//không chọn vào vé nào cả
            {
                cTTourcuarve("");//clean griview chi tiết tour
            }
        }

        private void txt_soluongve_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_soluongve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar!='-')//không phải là số và không nhập dấu trừ
            {
                e.Handled = true;
            }
        }
    }
}
