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
    public partial class Frm_QLTour_NV : Form
    {
        BUS_QLTour_NV bus_tour = new BUS_QLTour_NV();
        public Frm_QLTour_NV()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            DataTable dt = bus_tour.getCT_Tour();
            dataGridView1.DataSource = dt;
        }
        private void load_cbbmaDD()
        {
            DataTable dt = bus_tour.load_maDD();
            cbbDDTQ.DisplayMember = "tenDD";
            cbbDDTQ.ValueMember = "maDD";
            cbbDDTQ.DataSource = dt;
        }
        private void load_cbbDiaChi()
        {
            DataTable dt = bus_tour.load_DiaChi();
            cbbDiaChi.DisplayMember = "tenTinh";
            cbbDiaChi.ValueMember = "maTinh";
            cbbDiaChi.DataSource = dt;
        }
        private void load_cbbMaTour()
        {
            DataTable dt = bus_tour.load_maTour();
            cbbMaTour.DisplayMember = "tenTour";
            cbbMaTour.ValueMember = "maTour";
            cbbMaTour.DataSource = dt;
        }
        public bool KTThongTin()
        {
            if (cbbMaTour.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã Tour", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaTour.Focus();
                return false;
            }
            if (cbbDDTQ.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Địa điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbDDTQ.Focus();
                return false;
            }
            if (cbbDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbDiaChi.Focus();
                return false;
            }

            return true;
        }
        public void XoaTextBox()
        {
            cbbMaTour.Enabled = false;
            cbbDDTQ.Enabled = false;
            load_cbbMaTour();
            load_cbbDiaChi();
            load_cbbmaDD();

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
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbbMaTour.Enabled = true;
            cbbDDTQ.Enabled = true;
            if (KTThongTin())
            {
                string maTour = cbbMaTour.SelectedValue.ToString();
                string maDD = cbbDDTQ.SelectedValue.ToString();
                string DiaChi = cbbDiaChi.SelectedValue.ToString();
                DTO_QLTour ct = new DTO_QLTour(maTour, maDD, DiaChi);
                int dt = bus_tour.getKT(maTour, maDD);
                // Them
                if (dt == 0)
                {
                    bus_tour.themCT_Tour(ct);
                    loadData();
                    XoaTextBox();
                    MessageBox.Show("Thêm thành công");
                }
                else if (dt == 1) MessageBox.Show("Tour và địa điểm đã tồn tại");
                else MessageBox.Show("Thêm không thành công");

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maTour = cbbMaTour.SelectedValue.ToString();
            string maDD = cbbDDTQ.SelectedValue.ToString();
            DTO_QLTour ct = new DTO_QLTour(maTour, maDD);
            try
            {
                bus_tour.xoaCT_Tour(ct);
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
                string maTour = cbbMaTour.SelectedValue.ToString();
                string maDD = cbbDDTQ.SelectedValue.ToString();
                string DiaChi = cbbDiaChi.SelectedValue.ToString();
                DTO_QLTour ct = new DTO_QLTour(maTour, maDD, DiaChi);
                //int dt = bus_tour.getKT(maTour, maDD);
                // Them
                try
                {
                    bus_tour.suaCT_Tour(ct);
                    loadData();
                    XoaTextBox();
                    MessageBox.Show("Sửa thành công");
                }
                catch
                {
                    //else if (dt == 1) MessageBox.Show("Tour và địa điểm đã tồn tại");
                    MessageBox.Show("Sửa không thành công");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            XoaTextBox();
        }

        private void Frm_QLTour_NV_Load(object sender, EventArgs e)
        {
            cbbMaTour.Enabled = false;
            cbbDDTQ.Enabled = false;
            loadData();
            load_cbbDiaChi();
            load_cbbmaDD();
            load_cbbMaTour();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)//không chon
            {
                cbbMaTour.SelectedValue = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbbDDTQ.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                cbbDiaChi.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            }
        }
    }
}
