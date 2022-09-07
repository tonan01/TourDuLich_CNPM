using QLTourDuLich.DAO;
using QLTourDuLich.DTO.DTO_KH;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.XuLy_KH
{
    public class xuLyDatTour
    {
        //kết nối sql
        SqlConnection con = XuLyKetNoi.getConnection();
        //tạo dataset
        DataSet ds_TOUR = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;

        public xuLyDatTour()
        {
        }

        // Open connection ------------------------------------------------------------
        public void openConnection()
        {
            // Mở kết nối đến CSDL
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        // Close connection -----------------------------------------------------------
        public void closeConnection()
        {
            // Kiểm tra kết nối và Đóng CSDL
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        //kiểm tra rỗng
        public bool KTRong(string mave,string sl)
        {
            if (mave.Length == 0)//rỗng
            {
                MessageBox.Show("Chưa chọn vé để đặt", "Thông Báo");
                return false;
            }
            
            if (sl.Length == 0)//rỗng
            {
                MessageBox.Show("Chưa nhập số lượng vé", "Thông Báo");
                return false;
            }

            if (int.Parse(sl) == 0)//nếu bằng 0
            {
                MessageBox.Show("Số lượng vé phải lớn hơn 0", "Thông Báo");
                return false;
            }
            return true;//đã nhập tất cả
        }

        //load combobox địa chỉ
        public DataTable loadccbDiaChi()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from DIACHI", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "DIACHI");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["DIACHI"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["DIACHI"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_TOUR.Tables["DIACHI"];
        }

        //load combobox địa điểm tham quan
        public DataTable loadccbDDThamQuan()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from DDTHAMQUAN", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "DDTHAMQUAN");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["DDTHAMQUAN"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["DDTHAMQUAN"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_TOUR.Tables["DDTHAMQUAN"];
        }

        //load combobox đại lý
        public DataTable loadcbbDaiLY()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from DAILY", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "DAILY");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["DAILY"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["DAILY"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_TOUR.Tables["DAILY"];
        }

        //load combobox khách sạn
        public DataTable loadcbbKhachSan()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from KHACHSAN", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "KHACHSAN");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["KHACHSAN"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["KHACHSAN"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_TOUR.Tables["KHACHSAN"];
        }

        //load combobox phương tiện
        public DataTable loadcbbPhuongTien()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from PHUONGTIEN", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "PHUONGTIEN");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["PHUONGTIEN"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["PHUONGTIEN"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_TOUR.Tables["PHUONGTIEN"];
        }

        //load thông tin của tour
        public DataTable loadTour()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec hienthitourdatkhachhang", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "TOUR_CTTOUR_DDTHAMQUAN");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["TOUR_CTTOUR_DDTHAMQUAN"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["TOUR_CTTOUR_DDTHAMQUAN"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_TOUR.Tables["TOUR_CTTOUR_DDTHAMQUAN"];
        }

        //load thông tin của vé
        public DataTable loadVe()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec hienthivedatkhachhang", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "VE_T_KS_DL_PT");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["VE_T_KS_DL_PT"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["VE_T_KS_DL_PT"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_TOUR.Tables["VE_T_KS_DL_PT"];
        }

        //load thông tin của tìm kiếm vé
        public DataTable timKiemVe(string timkiem)
        {

            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec TimKiemvedatkhachhang N'%" + timkiem + "%'", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "VE_T_KS_DL_PT_FIND");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["VE_T_KS_DL_PT_FIND"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["VE_T_KS_DL_PT_FIND"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_TOUR.Tables["VE_T_KS_DL_PT_FIND"];
        }

        //làm mới tìm kiếm ve
        public void lamMoiTimKiemVe()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec hienthivedatkhachhang", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "VE_T_KS_DL_PT_FIND");
            //xóa dữ liệu cũ
            ds_TOUR.Tables["VE_T_KS_DL_PT_FIND"].Clear();
        }

        //load thông tin của tìm kiếm tour của vé
        public DataTable timKiemTour(string timkiem)
        {
            
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec TimKiemtourdatkhachhang '"+timkiem+"'", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "TOUR_CTTOUR_DDTHAMQUAN_FIND");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_TOUR.Tables["TOUR_CTTOUR_DDTHAMQUAN_FIND"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["TOUR_CTTOUR_DDTHAMQUAN_FIND"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_TOUR.Tables["TOUR_CTTOUR_DDTHAMQUAN_FIND"];
        }

        //load thông tin chi tiết hóa đơn của hóa đơn
        public DataTable loadDSChiTietHD(string mahd)
        {

            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from CT_HOADON where maHD='"+mahd+"'", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "CT_HOADON_HD");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[2];
            key[0] = ds_TOUR.Tables["CT_HOADON_HD"].Columns[0];//chọn columns 0
            key[0] = ds_TOUR.Tables["CT_HOADON_HD"].Columns[1];//chọn columns 0
            //đặt làm khóa chính
            ds_TOUR.Tables["CT_HOADON_HD"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_TOUR.Tables["CT_HOADON_HD"];
        }

        //làm mới chi tiết hd
        public void lamMoiDSCTHD()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from CT_HOADON", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "CT_HOADON_HD");
            //xóa dữ liệu cũ
            ds_TOUR.Tables["CT_HOADON_HD"].Clear();
        }

        //làm mới tìm kiếm
        public void lamMoiTimKiem()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec hienthitourdatkhachhang", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_TOUR, "TOUR_CTTOUR_DDTHAMQUAN_FIND");
            //xóa dữ liệu cũ
            ds_TOUR.Tables["TOUR_CTTOUR_DDTHAMQUAN_FIND"].Clear();
        }

        //kiểm mã hóa đơn tránh bị trùng
        public bool KTmaHDtrung(int sl)
        {
            try
            {
                openConnection();//mở kết nối
                string sql = "select count(*) from HOADON where maHD='"+sl+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int k = (int)cmd.ExecuteScalar();//thực thi câu lệnh trả về 1 số
                closeConnection();//đóng kết nối
                if(k>0)//có tồn tại mã hóa đơn
                {
                    return true;
                }
                else//chưa có mã hóa đơn
                {
                    return false;
                }

            }
            catch
            {
                return false;//thất bại
            }
        }
        //tao ma hoa don tu dung
        public int taomahdtudong()
        {
            try
            {
                openConnection();//mở kết nối
                string sql = "select count(*) from HOADON";
                SqlCommand cmd = new SqlCommand(sql, con);
                int k = (int)cmd.ExecuteScalar();//thực thi câu lệnh trả về 1 số
                closeConnection();//đóng kết nối
                if(KTmaHDtrung(k))//trùng mã hóa đơn
                {
                    return k + 1;
                }
                else//không trùng mã hóa đơn
                {
                    return k;
                }
                
            }
            catch
            {
                return 0;
            }
        }

        //Đặt tour
        public bool DatTour(DTO_DatTour hd)
        {
            try
            {
                openConnection();//mở kết nối
                string sql = "exec DatVe '"+hd.MaDH+"','"+hd.Email+"','"+hd.SL+"','"+hd.MaVe+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();//thực thi câu lệnh insert update delete
                closeConnection();//đóng kết nối
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }
        }
        //Đặt tour tiếp
        public bool DatTourThem(DTO_DatTour hd)
        {
            try
            {
                openConnection();//mở kết nối
                string sql = "exec DatVeCoHD '" + hd.MaDH + "','" + hd.Email + "','" + hd.SL + "','" + hd.MaVe + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();//thực thi câu lệnh insert update delete
                closeConnection();//đóng kết nối
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }
        }
    }
}
