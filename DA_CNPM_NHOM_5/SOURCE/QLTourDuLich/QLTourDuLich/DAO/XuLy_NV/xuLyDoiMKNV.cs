using QLTourDuLich.DAO;
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
    public class xuLyDoiMKNV
    {
        SqlConnection con = XuLyKetNoi.getConnection();

        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;
        public xuLyDoiMKNV()
        {

        }
        public bool DoiMKNV(DTO_DoiMKNV mk)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //Xac dinh chuoi truy van
                string updatestring;
                updatestring = "update TAIKHOAN set pass='" + mk.Pass + "' where userName='" + mk.UserName + "' and pass='" + mk.Pass_hientai + "'";

                //Khai bao commamnd moi
                SqlCommand cmd = new SqlCommand(updatestring, con);
                //Goi ExecuteNonQuery de gui command
                cmd.ExecuteNonQuery();
                //Kiem tra ket noi truoc khi dong
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return true;//thanh cong
            }
            catch
            {

                return false;//that bai
            }
        }
    }
}
