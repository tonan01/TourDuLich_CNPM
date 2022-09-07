using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_Admin
{
    public class DTO_QLKS
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
        public DTO_QLKS()
        {
            maKS = tenKS = diaChi = sDT = "";
        }
        public DTO_QLKS(string maks, string tenks, string diachi, string sdt)
        {
            this.maKS = maks;
            this.tenKS = tenks;
            this.diaChi = diachi;
            this.sDT = sdt;
        }
    }
}