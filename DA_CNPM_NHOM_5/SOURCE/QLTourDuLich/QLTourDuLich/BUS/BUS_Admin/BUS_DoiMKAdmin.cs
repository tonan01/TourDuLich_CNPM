using QLTourDuLich.Xuly_Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_Admin
{
    public class BUS_DoiMKAdmin
    {
        xuLyDoiMKAdmin dt = new xuLyDoiMKAdmin();
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