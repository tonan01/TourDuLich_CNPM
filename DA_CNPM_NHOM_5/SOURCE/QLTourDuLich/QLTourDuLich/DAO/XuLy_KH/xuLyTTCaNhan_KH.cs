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
    public class xuLyTTCaNhan_KH
    {
        //kết nối sql
        SqlConnection con = XuLyKetNoi.getConnection();
        //tạo dataset
        DataSet ds_KH = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;

        public xuLyTTCaNhan_KH()
        {
        }

        //kiểm tra rỗng
        public bool KTRong(string ten, string sdt)
        {
            if (ten.Length == 0)//rỗng
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

        //load thông tin của khách hàng
        public DataTable loadTTCaNhan_KH(string email)
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from KHACHHANG where email='" + email + "'", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "KHACHHANG_CANHAN");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["KHACHHANG_CANHAN"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["KHACHHANG_CANHAN"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_KH.Tables["KHACHHANG_CANHAN"];
        }

        //Sửa thông tin khách hàng
        public bool Sua(DTO_TTCaNhanKH kh)
        {
            if (KTRong(kh.TenKH, kh.SDT))// không rỗng
            {
                try
                {
                    da = new SqlDataAdapter("select * from KHACHHANG where email='" + kh.Email + "'", con);
                    //tìm dòng dữ liệu cần sửa
                    DataRow rowData = ds_KH.Tables["KHACHHANG_CANHAN"].Rows.Find(kh.Email);//Find chi co tac dung khi co khac chinh    
                    rowData["tenKH"] = kh.TenKH;
                    rowData["diaChi"] = kh.DiaChi;
                    rowData["gioiTinh"] = kh.GioiTinh;
                    rowData["ngaySinh"] = kh.NgaySinh;
                    rowData["sDT"] = kh.SDT;
                    //update vao database giup buld cau lanh them xoa sua vao bang khoa
                    SqlCommandBuilder build = new SqlCommandBuilder(da);//đánh đấu trạng thái
                                                                        //update vào db
                    da.Update(ds_KH, "KHACHHANG_CANHAN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                                                         //thành công
                    return true;
                }
                catch
                {
                    return false;//thất bại
                }
            }
            else//rỗng
            {
                return false;
            }
        }
    }
}
