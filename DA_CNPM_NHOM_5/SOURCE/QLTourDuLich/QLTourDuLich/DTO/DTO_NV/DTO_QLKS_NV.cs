//dto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_NV
{
    public class DTO_QLKS_NV
    {

        private string maKS;
        private string tenKS;
        private string diaChi;
        private string sDT;
        public string MaKS
        {
            get
            {
                return maKS;
            }

            set
            {
                maKS = value;
            }
        }

        public string TenKS
        {
            get
            {
                return tenKS;
            }

            set
            {
                tenKS = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string SDT
        {
            get
            {
                return sDT;
            }

            set
            {
                sDT = value;
            }
        }
        public DTO_QLKS_NV()
        {
            maKS = tenKS = diaChi = sDT = "";
        }
        public DTO_QLKS_NV(string maks, string tenks, string diachi, string sdt)
        {
            this.maKS = maks;
            this.tenKS = tenks;
            this.diaChi = diachi;
            this.sDT = sdt;
        }
    }

}
