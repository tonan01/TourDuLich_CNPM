using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using QLTourDuLich.DTO.DTO_NV;
using QLTourDuLich.XuLy_NV;

namespace QLTourDuLich.BUS.BUS_NV
{
    public class BUS_QLVe_NV
    {
        xuLyQLVe_NV daoxlnv = new xuLyQLVe_NV();
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
        public void themVe(DTO.DTO_NV.DTO_QLVe ve)
        {
            daoxlnv.themVe(ve);
        }

        public void suaVe(DTO.DTO_NV.DTO_QLVe ve)
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