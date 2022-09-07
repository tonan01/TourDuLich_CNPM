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
    public class BUS_QLKS
    {
        xuLyQLKS xl = new xuLyQLKS();
        public DataTable getloadDataKS()
        {
            return xl.loadDataKS();
        }
        public DataTable getloadDiaChi()
        {
            return xl.loadcbbDC();
        }
        public bool themKS(DTO_QLKS ks)
        {
            return xl.ThemKS(ks);
        }
        public bool xoaKS(DTO_QLKS ks)
        {
            return xl.XoaKS(ks);
        }
        public bool suaKS(DTO_QLKS ks)
        {
            return xl.SuaKS(ks);
        }
        public DataTable TimKS(string ks)
        {
            return xl.TimKS(ks);
        }
        public void resetDataTable()
        {
            xl.ResetDataTable();
        }
        public bool KTRong_SDT(string sdt)
        {
            if (sdt == string.Empty) { return false; }
            else { return true; }
        }
        public bool KTsokytu_SDT(string sdt)
        {
            if (sdt.Length != 10) { return false; }
            else { return true; }
        }
        public bool KTRong_maKS(string maks)
        {
            if (maks == string.Empty) { return false; }
            else { return true; }
        }
        public bool KTRong_tenKS(string tenKS)
        {
            if (tenKS == string.Empty) { return false; }
            else { return true; }
        }
    }
}