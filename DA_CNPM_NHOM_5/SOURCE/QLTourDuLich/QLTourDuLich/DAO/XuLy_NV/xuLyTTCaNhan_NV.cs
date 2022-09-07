using QLTourDuLich.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTourDuLich.DTO.DTO_NV;
using System.Windows.Forms;

namespace QLTourDuLich.XuLy_NV
{
    public class xuLyTTCaNhan_NV
    {
        //kết nối sql
        SqlConnection con = XuLyKetNoi.getConnection();
        //tạo dataset
        DataSet ds_NV = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;

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
            da.Fill(ds_NV, "DIACHI");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NV.Tables["DIACHI"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_NV.Tables["DIACHI"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_NV.Tables["DIACHI"];
        }
        public DataTable loadccbCV()
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from CHUCVU", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_NV, "CHUCVU");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NV.Tables["CHUCVU"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_NV.Tables["CHUCVU"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_NV.Tables["CHUCVU"];
        }

        //load thông tin của khách hàng
        public DataTable loadTTCaNhan_NV(string manv)
        {
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from NHANVIEN where maNV='" + manv + "'", con);
            da.Fill(ds_NV, "NV_CANHAN");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NV.Tables["NV_CANHAN"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_NV.Tables["NV_CANHAN"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_NV.Tables["NV_CANHAN"];
        }

        //Sửa thông tin khách hàng
        public bool Sua(DTO_TTCaNhan_NV nv)
        {
            if (KTRong(nv.TenNV, nv.SDT))// không rỗng
            {
                try
                {
                    da = new SqlDataAdapter("select * from NHANVIEN where maNV='" + nv.MaNV + "'", con);
                    //tìm dòng dữ liệu cần sửa
                    DataRow rowData = ds_NV.Tables["NV_CANHAN"].Rows.Find(nv.MaNV);//Find chi co tac dung khi co khac chinh    
                    rowData["tenNV"] = nv.TenNV;
                    rowData["maCV"] = nv.MaCV;
                    rowData["email"] = nv.Email;
                    rowData["diaChi"] = nv.DiaChi;
                    rowData["gioiTinh"] = nv.GioiTinh;
                    rowData["ngaySinh"] = nv.NgaySinh;
                    rowData["sDT"] = nv.SDT;
                    //update vao database giup buld cau lanh them xoa sua vao bang khoa
                    SqlCommandBuilder build = new SqlCommandBuilder(da);//đánh đấu trạng thái
                                                                        //update vào db
                    da.Update(ds_NV, "NV_CANHAN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
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
