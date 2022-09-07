using QLTourDuLich.DTO.DTO_NV;
using QLTourDuLich.XuLy_NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_NV
{
    public class BUS_QLPT_NV
    {
        xuLyQLPT_NV daoxlnv = new xuLyQLPT_NV();
        public DataTable getPhuongTien()
        {
            return daoxlnv.getPhuongTien();
        }
        public void themPhuongTien(DTO_QLPT_NV pt)
        {
            daoxlnv.themPhuongTien(pt);
        }

        public void suaPhuongTien(DTO_QLPT_NV pt)
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