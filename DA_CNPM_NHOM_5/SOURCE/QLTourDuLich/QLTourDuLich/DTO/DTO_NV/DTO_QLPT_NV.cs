using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_NV
{
    public class DTO_QLPT_NV
    {
        private string maPT;
        private string tenPT;
        private string hienTrang;

        public string MaPT
        {
            get { return maPT; }
            set { maPT = value; }
        }
        public string TenPT
        {
            get { return tenPT; }
            set { tenPT = value; }
        }
        public string HienTrang
        {
            get { return hienTrang; }
            set { hienTrang = value; }
        }
        public DTO_QLPT_NV()
        {

        }
        public DTO_QLPT_NV(string maPT, string tenPT, string hienTrang)
        {
            this.maPT = maPT;
            this.tenPT = tenPT;
            this.hienTrang = hienTrang;
        }
    }
}