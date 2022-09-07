
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
    public class BUS_QLTour_NV
    {
        xuLyQLTour_NV daoxlnv = new xuLyQLTour_NV();
        public DataTable getCT_Tour()
        {
            return daoxlnv.getCT_Tour();
        }
        public int getKT(string maTour, string maDD)
        {
            return daoxlnv.getKT(maTour, maDD);
        }
        public DataTable load_maDD()
        {
            return daoxlnv.load_maDD();
        }
        public DataTable load_maTour()
        {
            return daoxlnv.load_maTour();
        }
        public DataTable load_DiaChi()
        {
            return daoxlnv.load_DiaChi();
        }
        public void themCT_Tour(DTO_QLTour ct)
        {
            daoxlnv.themCT_Tour(ct);
        }

        public void suaCT_Tour(DTO_QLTour ct)
        {
            daoxlnv.suaCT_TOUR(ct);
        }

        public void xoaCT_Tour(DTO_QLTour ct)
        {
            daoxlnv.xoaCT_Tour(ct);
        }
    }
}