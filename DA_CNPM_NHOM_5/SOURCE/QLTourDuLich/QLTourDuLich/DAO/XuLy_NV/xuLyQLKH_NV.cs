using QLTourDuLich.DAO;
using QLTourDuLich.DTO.DTO_DN_DK;
using QLTourDuLich.DTO.DTO_NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.XuLy_NV
{
    public class xuLyQLKH_NV
    {
        SqlConnection con = XuLyKetNoi.getConnection();
        DataSet ds_KH = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;
        public xuLyQLKH_NV()
        {

        }
        public DataTable loadDataKH()
        {
            da = new SqlDataAdapter("select * from KHACHHANG", con);
            da.Fill(ds_KH, "KHACHHANG");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["KHACHHANG"].Columns[0];
            ds_KH.Tables["KHACHHANG"].PrimaryKey = key;
            return ds_KH.Tables["KHACHHANG"];

        }
        public DataTable loadcbbDC()
        {
            da = new SqlDataAdapter("select * from DIACHI", con);
            da.Fill(ds_KH, "DIACHI");
            //khoa chinh
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["DIACHI"].Columns[0];
            ds_KH.Tables["DIACHI"].PrimaryKey = key;
            return ds_KH.Tables["DIACHI"];
        }
        public bool ThemKH(DTO_QLKH_NV kh)//thêm thông tin bảng KHACHHANG
        {
            try
            {
                //tao dong du lieu moi
                da = new SqlDataAdapter("select * from KHACHHANG", con);

                DataRow rowData = ds_KH.Tables["KHACHHANG"].NewRow();
                //gan gia tri vao rowdata
                rowData["email"] = kh.Email;
                rowData["tenKH"] = kh.TenKH;
                rowData["diaChi"] = kh.DiaChi;
                rowData["gioiTinh"] = kh.GioiTinh;
                rowData["ngaySinh"] = kh.NgaySinh;
                rowData["sDT"] = kh.SDT;

                //chen vao dataset
                ds_KH.Tables["KHACHHANG"].Rows.Add(rowData);
                //update vao database
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                //update vao du lieu sql
                da.Update(ds_KH, "KHACHHANG");
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }
        }
        public bool XoaKH(DTO_QLKH_NV kh)
        {
            try
            {
                da = new SqlDataAdapter("select * from KHACHHANG", con);
                //1. Tim dong du lieu can xoa 
                DataRow rowData = ds_KH.Tables["KHACHHANG"].Rows.Find(kh.Email);//Find chi co tac dung khi co khac chinh
                //2. xoa dong ra khoi table khoa tren dataset
                rowData.Delete();
                //3. update vao database giup buld cau lanh them xoa sua vao bang khoa
                SqlCommandBuilder build = new SqlCommandBuilder(da);//danh dau trang trang thai
                //update vao DB
                da.Update(ds_KH, "KHACHHANG");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
        public bool SuaKH(DTO_QLKH_NV kh)
        {
            try
            {
                da = new SqlDataAdapter("select * from KHACHHANG", con);
                //1. Tim dong du lieu can sua 
                DataRow rowData = ds_KH.Tables["KHACHHANG"].Rows.Find(kh.Email);//Find chi co tac dung khi co khac chinh                                                      //2. sua dong  table khoa tren dataset
                rowData["email"] = kh.Email;
                rowData["tenKH"] = kh.TenKH;
                rowData["diaChi"] = kh.DiaChi;
                rowData["gioiTinh"] = kh.GioiTinh;
                rowData["ngaySinh"] = kh.NgaySinh;
                rowData["sDT"] = kh.SDT;
                //3. update vao database giup buld cau lanh them xoa sua vao bang khoa
                SqlCommandBuilder build = new SqlCommandBuilder(da);//danh dau trang trang thai
                                                                    //update vao DB
                da.Update(ds_KH, "KHACHHANG");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
        public DataTable TimKH(string giatritimkiem)
        {

            da = new SqlDataAdapter("select * from KHACHHANG where concat(email,tenKH,gioiTinh,ngaySinh,diaChi,sDT) like N'%" + giatritimkiem + "%'", con);
            da.Fill(ds_KH, "KHACHHANG_FIND");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["KHACHHANG_FIND"].Columns[0];
            ds_KH.Tables["KHACHHANG_FIND"].PrimaryKey = key;
            return ds_KH.Tables["KHACHHANG_FIND"];
        }
        public void ResetDataTable()
        {
            da = new SqlDataAdapter("select * from KHACHHANG ", con);
            da.Fill(ds_KH, "KHACHHANG_FIND");
            ds_KH.Tables["KHACHHANG_FIND"].Clear();
        }
        public bool themUser(string userName)//thêm user  bảng TAIKHOAN 
        {
            try
            {
                con.Open();

                string sql = "insert into TAIKHOAN values( '" + userName + "', '123','3')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return true;//thanh cong

            }
            catch
            {
                return false;
            }
        }
        public bool xoaUser(string userName)//xóa user  bảng TAIKHOAN 
        {
            try
            {
                con.Open();

                string sql = "delete TAIKHOAN where userName= '" + userName + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();

                return true;//thanh cong


            }
            catch
            {
                return false;
            }
        }
        //KT tài khoản tồn tại
        public bool testUser(string userName)
        {
            try
            {
                con.Open();

                // Truy vấn
                string sql = "select count(*) from TAIKHOAN where userName='" + userName + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                // Thực thi câu truy vấn
                int kq = (int)cmd.ExecuteScalar(); // Trả về 1 dữ liệu đơn

                con.Close();

                if (kq >= 1) // Trùng khóa chính (User name đã tồn tại)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktkhoaNgoai(string pvalue)
        {
            try
            {
                //mo csdl
                if (con.State == ConnectionState.Closed)//nếu nó đang đóng
                {
                    con.Open();//mở kết nối
                }
                //cau truy van
                string sql = "select count(*) from HOADON where email='" + pvalue + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                //thuc thi cau truy van
                int kq = (int)cmd.ExecuteScalar();//ho tro tra tra ve 1 du lieu don
                //dong csld
                if (con.State == ConnectionState.Open)//nếu nó đang mở
                {
                    con.Close();//Đóng kết nối
                }
                if (kq >= 1)//Co khóa ngoai
                {
                    return false;
                }
                else//Không có khóa ngoại
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }



    }
}
