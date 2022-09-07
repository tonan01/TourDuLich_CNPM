//Bus
using QLTourDuLich.DTO.DTO_NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_NV
{
    public class BUS_QLKS_NV
    {
        XuLy_NV.xuLyQLKS_NV xl = new XuLy_NV.xuLyQLKS_NV();
        public DataTable getloadDataKS()
        {
            return xl.loadDataKS();
        }
        public DataTable getloadDiaChi()
        {
            return xl.loadcbbDC();
        }
        public bool themKS(DTO_QLKS_NV ks)
        {
            return xl.ThemKS(ks);
        }
        public bool xoaKS(DTO_QLKS_NV ks)
        {
            return xl.XoaKS(ks);
        }
        public bool suaKS(DTO_QLKS_NV ks)
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
        public bool KT_KS(string maKS)
        {
            return xl.Kt_KS(maKS);
        }
        public bool KT_KhoaNgoaiKS(string maKS)
        {
            return xl.ktkhoaNgoai(maKS);
        }
    }
}