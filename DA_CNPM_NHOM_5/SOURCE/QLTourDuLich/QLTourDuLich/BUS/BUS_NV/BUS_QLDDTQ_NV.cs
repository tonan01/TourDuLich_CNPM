using QLTourDuLich.DTO.DTO_NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_NV
{
    public class BUS_QLDDTQ_NV
    {
        XuLy_NV.xuLyQLDDTQ_NV xl = new XuLy_NV.xuLyQLDDTQ_NV();
        public DataTable getloadDataDDTQ()
        {
            return xl.loadDataDD();
        }
        public DataTable getloadDiaChi()
        {
            return xl.loadcbbDC();
        }
        public bool themDDTQ(DTO_QLDDTQ_NV dd)
        {
            return xl.ThemDD(dd);
        }
        public bool xoaDDTQ(DTO_QLDDTQ_NV dd)
        {
            return xl.XoaDD(dd);
        }
        public bool suaDDTQ(DTO_QLDDTQ_NV dd)
        {
            return xl.SuaDD(dd);
        }
        public DataTable TimDDTQ(string dd)
        {
            return xl.TimDiaDiem(dd);
        }
        public void resetDataTable()
        {
            xl.ResetDataTable();
        }
        public bool KTRong_maDD(string madd)
        {
            if (madd == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool KTRong_tenDD(string tendd)
        {
            if (tendd == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool KT_KhoaChinh(string madd)
        {
            return xl.Kt_DD(madd);
        }
        public bool KT_KhoaNgoaiDD(string maDD)
        {
            return xl.ktkhoaNgoai(maDD);
        }
    }
}