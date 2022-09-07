using QLTourDuLich.DTO.DTO_Admin;
using QLTourDuLich.Xuly_Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_Admin
{
    public class BUS_QLPT
    {
        xuLyQLPT daoxlnv = new xuLyQLPT();
        public DataTable getPhuongTien()
        {
            return daoxlnv.getPhuongTien();
        }
        public void themPhuongTien(DTO_QLPT pt)
        {
            daoxlnv.themPhuongTien(pt);
        }

        public void suaPhuongTien(DTO_QLPT pt)
        {
            daoxlnv.suaPhuongTien(pt);
        }

        public void xoaPhuongTien(string maPT)
        {
            daoxlnv.xoaPhuongTien(maPT);
        }
        public DataTable timPhuongTien(string tim)
        {
            return daoxlnv.timPhuongTien(tim);
        }
    }
}