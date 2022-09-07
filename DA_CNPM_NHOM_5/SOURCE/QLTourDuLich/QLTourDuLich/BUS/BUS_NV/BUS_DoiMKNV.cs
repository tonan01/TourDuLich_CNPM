using QLTourDuLich.DTO.DTO_NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_NV
{
    public class BUS_DoiMKNV
    {
        XuLy_NV.xuLyDoiMKNV xl = new XuLy_NV.xuLyDoiMKNV();
        public bool KTRong_maNV(string manv)
        {
            if (manv == string.Empty)
                return false;
            else
                return true;
        }
        public bool KTRong_MK(string mk)
        {
            if (mk == string.Empty)
                return false;
            else
                return true;
        }
        public bool SoSanh(string mk, string nhaplai_mk)
        {
            if (mk != nhaplai_mk)
                return false;
            else
                return true;
        }
        public bool setMK(DTO_DoiMKNV mk)
        {
            return xl.DoiMKNV(mk);
        }
    }
    }