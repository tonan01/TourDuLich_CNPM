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
    public class BUS_QLVe
    {
        xuLyQLVe daoxlnv = new xuLyQLVe();
        public DataTable getVe()
        {
            return daoxlnv.getVe();
        }
        public DataTable load_maTour()
        {
            return daoxlnv.load_maTour();
        }
        public DataTable load_maDL()
        {
            return daoxlnv.load_maDL();
        }
        public DataTable load_maKS()
        {
            return daoxlnv.load_maKS();
        }
        public DataTable load_maPT()
        {
            return daoxlnv.load_maPT();
        }
        public void themVe(DTO_QLVe ve)
        {
            daoxlnv.themVe(ve);
        }

        public void suaVe(DTO_QLVe ve)
        {
            daoxlnv.suaVe(ve);
        }

        public void xoaVe(string maVe)
        {
            daoxlnv.xoaVe(maVe);
        }
        public DataTable TimVe(string tim)
        {
            return daoxlnv.timVe(tim);
        }
    }
}