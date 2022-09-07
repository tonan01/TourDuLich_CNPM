using QLTourDuLich.DTO.DTO_NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_NV
{
    public class BUS_TTCaNhan_NV
    {
        XuLy_NV.xuLyTTCaNhan_NV dt = new XuLy_NV.xuLyTTCaNhan_NV();
        //load thông tin cá nhân của khách hàng đang đăng nhập
        public DataTable getThongTinCaNhan_NV(string email)
        {
            return dt.loadTTCaNhan_NV(email);
        }
        //load combobox địa chỉ
        public DataTable getloadDiaChi()
        {
            return dt.loadccbDiaChi();
        }
        //load combobox công việc
        public DataTable getloadcv()
        {
            return dt.loadccbCV();
        }
        //sửa khách hàng
        public bool Sua(DTO_TTCaNhan_NV kh)
        {
            return dt.Sua(kh);
        }
    }
}