using QLTourDuLich.DAO;
using QLTourDuLich.DTO.DTO_Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTourDuLich.Xuly_Admin
{
    public class xuLyQLNV
    {
        //kết nối sql
        SqlConnection con = XuLyKetNoi.getConnection();
        //tạo dataset
        DataSet ds_KH = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;

        public xuLyQLNV()
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
        public bool KTRong(string manv, string email,string hoten,string sdt)
        {
            if (manv.Length == 0)//rỗng
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Thông Báo");
                return false;
            }
            if (email.Length == 0)//rỗng
            {
                MessageBox.Show("Email không được để trống", "Thông Báo");
                return false;
            }
            if (hoten.Length == 0)//rỗng
            {
                MessageBox.Show("Họ tên không được để trống", "Thông Báo");
                return false;
            }
            if (sdt.Length == 0)//rỗng
            {
                MessageBox.Show("Số điện thoại Không Để trống", "Thông Báo");
                return false;
            }
            return true;//đã nhập tất cả
        }

        //load combobox chức vụ
        public DataTable loadcbbChucVu()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from CHUCVU", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "CHUCVU");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["CHUCVU"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["CHUCVU"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_KH.Tables["CHUCVU"];
        }

        //kiểm tra khóa chính
        public bool ktkhoaC(string pvalue)
        {
            da = new SqlDataAdapter("select * from NHANVIEN", con);
            DataRow row = ds_KH.Tables["NHANVIEN"].Rows.Find(pvalue);//tim khoa chinh
            if (row != null)//trung khoa chinh
            {
                return false;
            }
            return true;//không tồn tại khóa chính
        }

        //load combobox địa chỉ
        public DataTable loadccbDiaChi()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from DIACHI", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "DIACHI");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["DIACHI"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["DIACHI"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_KH.Tables["DIACHI"];
        }

        //load thông tin của nhân viên
        public DataTable loadTTNV()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select NHANVIEN.* from NHANVIEN,TAIKHOAN where NHANVIEN.maNV=TAIKHOAN.userName and maQuyen !=1", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "NHANVIEN");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["NHANVIEN"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["NHANVIEN"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_KH.Tables["NHANVIEN"];
        }
        //thêm nhân viên
        public bool them(DTO_QLNV nv)
        {
            try
            {

                //tao dong du lieu moi
                da = new SqlDataAdapter("select * from NHANVIEN", con);
                DataRow rowData = ds_KH.Tables["NHANVIEN"].NewRow();
                //gan gia tri vao rowdata
                rowData["maNV"] = nv.MaNV;
                rowData["TenNV"] = nv.TenNV;
                rowData["maCV"] = nv.MaCV;
                rowData["email"] = nv.Email;
                rowData["diaChi"] = nv.DiaChi;
                rowData["gioiTinh"] = nv.GioiTinh;
                rowData["ngaySinh"] = nv.NgaySinh;
                rowData["sDT"] = nv.SDT;
                //chen vao dataset
                ds_KH.Tables["NHANVIEN"].Rows.Add(rowData);
                //update vao database
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                //update vao du lieu sql
                da.Update(ds_KH, "NHANVIEN");
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }

        }

        //Sửa thông tin khách hàng
        public bool Sua(DTO_QLNV nv)
        {
                try
                {
                    da = new SqlDataAdapter("select * from NHANVIEN", con);
                    //tìm dòng dữ liệu cần sửa
                    DataRow rowData = ds_KH.Tables["NHANVIEN"].Rows.Find(nv.MaNV);//Find chi co tac dung khi co khac chinh    
                    rowData["TenNV"] = nv.TenNV;
                    rowData["maCV"] = nv.MaCV;
                    rowData["email"] = nv.Email;
                    rowData["diaChi"] = nv.DiaChi;
                    rowData["gioiTinh"] = nv.GioiTinh;
                    rowData["ngaySinh"] = nv.NgaySinh;
                    rowData["sDT"] = nv.SDT;
                    //update vao database giup buld cau lanh them xoa sua vao bang khoa
                    SqlCommandBuilder build = new SqlCommandBuilder(da);//đánh đấu trạng thái
                                                                        //update vào db
                    da.Update(ds_KH, "NHANVIEN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                                                         //thành công
                    return true;
                }
                catch
                {
                    return false;//thất bại
                }
            
        }
        //Xoa
        public bool Xoa(string manv)
        {
            try
            {
                da = new SqlDataAdapter("select * from NHANVIEN", con);
                //1. Tim dong du lieu can xoa 
                DataRow rowData = ds_KH.Tables["NHANVIEN"].Rows.Find(manv);//Find chi co tac dung khi co khac chinh
                //2. xoa dong ra khoi table khoa tren dataset
                rowData.Delete();
                //3. update vao database giup buld cau lanh them xoa sua vao bang khoa
                SqlCommandBuilder build = new SqlCommandBuilder(da);//danh dau trang trang thai
                //update vao DB
                da.Update(ds_KH, "NHANVIEN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
        //them tai khoan
        public bool themtk(string tk)
        {
            try
            {
                openConnection();//mở kết nối
                string sql = "insert into TAIKHOAN values('"+tk+"','123','2')";
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
        //xoa tk
        public bool xoatk(string tk)
        {
            try
            {
                openConnection();//mở kết nối
                string sql = "delete TAIKHOAN where userName='"+tk+"'";
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
