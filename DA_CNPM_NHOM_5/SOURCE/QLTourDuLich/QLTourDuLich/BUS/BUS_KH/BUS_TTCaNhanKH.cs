using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLTourDuLich.DTO.DTO_KH;

namespace QLTourDuLich.BUS.BUS_KH
{
    public class BUS_TTCaNhanKH
    {
        XuLy_KH.xuLyTTCaNhan_KH dt = new XuLy_KH.xuLyTTCaNhan_KH();
        //load thông tin cá nhân của khách hàng đang đăng nhập
        public DataTable getThongTinCaNhan_KH(string email)
        {
            return dt.loadTTCaNhan_KH(email);
        }
        //load combobox địa chỉ
        public DataTable getloadDiaChi()
        {
            return dt.loadccbDiaChi();
        }
        //sửa khách hàng
        public bool Sua(DTO_TTCaNhanKH kh)
        {
            return dt.Sua(kh);
        }



    }
}