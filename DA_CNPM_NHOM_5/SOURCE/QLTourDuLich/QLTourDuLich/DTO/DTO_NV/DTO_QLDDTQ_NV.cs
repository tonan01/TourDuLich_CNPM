using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_NV
{
    public class DTO_QLDDTQ_NV
    {
        private string maDD;
        private string tenDD;
        private string diaChi;

        public string MaDD
        {
            get
            {
                return maDD;
            }

            set
            {
                maDD = value;
            }
        }

        public string TenDD
        {
            get
            {
                return tenDD;
            }

            set
            {
                tenDD = value;
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

        public DTO_QLDDTQ_NV()
        {
            MaDD = TenDD = DiaChi = "";
        }
        public DTO_QLDDTQ_NV(string madd, string tendd, string diachi)
        {
            this.MaDD = madd;
            this.TenDD = tendd;
            this.DiaChi = diachi;
        }
    }
}