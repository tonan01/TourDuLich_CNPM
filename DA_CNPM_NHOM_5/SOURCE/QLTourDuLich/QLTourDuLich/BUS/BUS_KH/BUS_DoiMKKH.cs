using QLTourDuLich.XuLy_KH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_KH
{
    public class BUS_DoiMKKH
    {
        xuLyDoiMKKH dt = new xuLyDoiMKKH();
        //kiểm tra rỗng
        public bool KTRong(string username, string pass, string nhaplaipass)
        {
            return dt.KTRong(username, pass, nhaplaipass);
        }
        //đổi mật khẩu
        public bool Sua(string username, string pass)
        {
            return dt.Sua(username, pass);
        }
    }
}