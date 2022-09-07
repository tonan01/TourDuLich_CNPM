using QLTourDuLich.DAO;
using QLTourDuLich.DTO.DTO_Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.Xuly_Admin
{
    public class xuLyQLDDTQ
    {
        SqlConnection con = XuLyKetNoi.getConnection();
        DataSet ds_DDTQ = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;
        public xuLyQLDDTQ()
        {

        }
        public DataTable loadDataDD()
        {
            da = new SqlDataAdapter("select * from DDTHAMQUAN", con);
            da.Fill(ds_DDTQ, "DDTHAMQUAN");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_DDTQ.Tables["DDTHAMQUAN"].Columns[0];
            ds_DDTQ.Tables["DDTHAMQUAN"].PrimaryKey = key;
            return ds_DDTQ.Tables["DDTHAMQUAN"];

        }
        public DataTable loadcbbDC()
        {
            da = new SqlDataAdapter("select * from DIACHI", con);
            da.Fill(ds_DDTQ, "DIACHI");
            //khoa chinh
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_DDTQ.Tables["DIACHI"].Columns[0];
            ds_DDTQ.Tables["DIACHI"].PrimaryKey = key;
            return ds_DDTQ.Tables["DIACHI"];
        }
        public bool ThemDD(DTO_QLDDTQ dd)
        {
            try
            {

                //tao dong du lieu moi
                da = new SqlDataAdapter("select * from DDTHAMQUAN", con);
                DataRow rowData = ds_DDTQ.Tables["DDTHAMQUAN"].NewRow();
                //gan gia tri vao rowdata
                rowData["maDD"] = dd.MaDD;
                rowData["tenDD"] = dd.TenDD;
                rowData["diaChi"] = dd.DiaChi;

                //chen vao dataset
                ds_DDTQ.Tables["DDTHAMQUAN"].Rows.Add(rowData);
                //update vao database
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                //update vao du lieu sql
                da.Update(ds_DDTQ, "DDTHAMQUAN");
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }
        }
        public bool XoaDD(DTO_QLDDTQ dd)
        {
            try
            {
                da = new SqlDataAdapter("select * from DDTHAMQUAN", con);
                //1. Tim dong du lieu can xoa 
                DataRow rowData = ds_DDTQ.Tables["DDTHAMQUAN"].Rows.Find(dd.MaDD);//Find chi co tac dung khi co khac chinh
                //2. xoa dong ra khoi table khoa tren dataset
                rowData.Delete();
                //3. update vao database giup buld cau lanh them xoa sua vao bang khoa
                SqlCommandBuilder build = new SqlCommandBuilder(da);//danh dau trang trang thai
                //update vao DB
                da.Update(ds_DDTQ, "DDTHAMQUAN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
        public bool SuaDD(DTO_QLDDTQ dd)
        {
            try
            {
                da = new SqlDataAdapter("select * from DDTHAMQUAN", con);
                //1. Tim dong du lieu can sua 
                DataRow rowData = ds_DDTQ.Tables["DDTHAMQUAN"].Rows.Find(dd.MaDD);//Find chi co tac dung khi co khac chinh                                                      //2. sua dong  table khoa tren dataset
                rowData["maDD"] = dd.MaDD;
                rowData["tenDD"] = dd.TenDD;
                rowData["diaChi"] = dd.DiaChi;
                //3. update vao database giup buld cau lanh them xoa sua vao bang khoa
                SqlCommandBuilder build = new SqlCommandBuilder(da);//danh dau trang trang thai
                                                                    //update vao DB
                da.Update(ds_DDTQ, "DDTHAMQUAN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
        public DataTable TimDiaDiem(string giatritimkiem)
        {

            da = new SqlDataAdapter("select * from DDTHAMQUAN where concat(maDD,tenDD,diaChi) like N'%" + giatritimkiem + "%'", con);
            da.Fill(ds_DDTQ, "DDTHAMQUAN_FIND");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_DDTQ.Tables["DDTHAMQUAN_FIND"].Columns[0];
            ds_DDTQ.Tables["DDTHAMQUAN_FIND"].PrimaryKey = key;
            return ds_DDTQ.Tables["DDTHAMQUAN_FIND"];
        }
        public void ResetDataTable()
        {
            da = new SqlDataAdapter("select * from DDTHAMQUAN ", con);
            da.Fill(ds_DDTQ, "DDTHAMQUAN_FIND");
            ds_DDTQ.Tables["DDTHAMQUAN_FIND"].Clear();
        }
        // Kiểm tra Địa điểm tồn tại -------------------------------------------------------
        public bool Kt_DD(string maDD)
        {
            try
            {
                con.Open();

                // Truy vấn
                string sql = "select count(*) from DDTHAMQUAN where maDD='" + maDD + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                // Thực thi câu truy vấn
                int kq = (int)cmd.ExecuteScalar(); // Trả về 1 dữ liệu đơn

                con.Close();

                if (kq >= 1) // Trùng khóa chính
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktkhoaNgoai(string maDD)
        {
            try
            {
                //mo csdl
                if (con.State == ConnectionState.Closed)//nếu nó đang đóng
                {
                    con.Open();//mở kết nối
                }
                //cau truy van
                string sql = "select count(*) from CT_TOUR where maDD='" + maDD + "'";
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
