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
    public class xuLyQLKS
    {
        SqlConnection con = XuLyKetNoi.getConnection();
        DataSet ds_KS = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;
        public xuLyQLKS()
        {

        }
        public DataTable loadDataKS()
        {
            da = new SqlDataAdapter("select * from KHACHSAN", con);
            da.Fill(ds_KS, "KHACHSAN");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KS.Tables["KHACHSAN"].Columns[0];
            ds_KS.Tables["KHACHSAN"].PrimaryKey = key;
            return ds_KS.Tables["KHACHSAN"];

        }
        public DataTable loadcbbDC()
        {
            da = new SqlDataAdapter("select * from DIACHI", con);
            da.Fill(ds_KS, "DIACHI");
            //khoa chinh
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KS.Tables["DIACHI"].Columns[0];
            ds_KS.Tables["DIACHI"].PrimaryKey = key;
            return ds_KS.Tables["DIACHI"];
        }
        public bool KT_KhoaChinh(string ma)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select * from KHACHSAN where maKS='" + ma + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Close();
                con.Close();
                return false;
            }
            else
            {
                rd.Close();
                con.Close();
                return true;
            }
        }
        public bool ThemKS(DTO_QLKS ks)
        {
            try
            {
                //tao dong du lieu moi
                da = new SqlDataAdapter("select * from KHACHSAN", con);
                DataRow rowData = ds_KS.Tables["KHACHSAN"].NewRow();
                //gan gia tri vao rowdata
                rowData["maKS"] = ks.MaKS;
                rowData["tenKS"] = ks.TenKS;
                rowData["diaChi"] = ks.DiaChi;
                rowData["sDT"] = ks.SDT;
                //chen vao dataset
                ds_KS.Tables["KHACHSAN"].Rows.Add(rowData);
                //update vao database
                SqlCommandBuilder buil = new SqlCommandBuilder(da);
                //update vao du lieu sql
                da.Update(ds_KS, "KHACHSAN");
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }
        }
        public bool XoaKS(DTO_QLKS ks)
        {
            try
            {
                da = new SqlDataAdapter("select * from KHACHSAN", con);
                //1. Tim dong du lieu can xoa 
                DataRow rowData = ds_KS.Tables["KHACHSAN"].Rows.Find(ks.MaKS);//Find chi co tac dung khi co khac chinh
                //2. xoa dong ra khoi table khoa tren dataset
                rowData.Delete();
                //3. update vao database giup buld cau lanh them xoa sua vao bang khoa
                SqlCommandBuilder build = new SqlCommandBuilder(da);//danh dau trang trang thai
                //update vao DB
                da.Update(ds_KS, "KHACHSAN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
        public bool SuaKS(DTO_QLKS ks)
        {
            try
            {
                da = new SqlDataAdapter("select * from KHACHSAN", con);
                //1. Tim dong du lieu can sua 
                DataRow rowData = ds_KS.Tables["KHACHSAN"].Rows.Find(ks.MaKS);//Find chi co tac dung khi co khac chinh                                                      

                //2. sua dong  table khoa tren dataset

                rowData["maKS"] = ks.MaKS;
                rowData["tenKS"] = ks.TenKS;
                rowData["diaChi"] = ks.DiaChi;
                rowData["sDT"] = ks.SDT;
                //3. update vao database giup buld cau lanh them xoa sua vao bang khoa
                SqlCommandBuilder build = new SqlCommandBuilder(da);//danh dau trang trang thai
                                                                    //update vao DB
                da.Update(ds_KS, "KHACHSAN");//khi thuc hien cau nay du lieu trong sql moi bi thay doi
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
        public DataTable TimKS(string giatri)
        {

            da = new SqlDataAdapter("select * from KHACHSAN where concat(maKS,tenKS,diaChi,sDT) like '%" + giatri + "%'", con);

            da.Fill(ds_KS, "KHACHSAN_FIND");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KS.Tables["KHACHSAN_FIND"].Columns[0];
            ds_KS.Tables["KHACHSAN_FIND"].PrimaryKey = key;
            return ds_KS.Tables["KHACHSAN_FIND"];
        }
        public void ResetDataTable()
        {
            da = new SqlDataAdapter("select * from KHACHSAN ", con);
            da.Fill(ds_KS, "KHACHSAN_FIND");
            ds_KS.Tables["KHACHSAN_FIND"].Clear();
        }
        // Kiểm tra Khách sạn tồn tại -------------------------------------------------------
        public bool Kt_KS(string maKS)
        {
            try
            {
                con.Open();

                // Truy vấn
                string sql = "select count(*) from KHACHSAN where maKS='" + maKS + "'";
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
                string sql = "select count(*) from VE where maKS='" + pvalue + "'";
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
