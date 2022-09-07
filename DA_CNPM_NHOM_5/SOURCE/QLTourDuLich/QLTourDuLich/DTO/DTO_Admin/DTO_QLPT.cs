using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_Admin
{
    public class DTO_QLPT
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
        public DTO_QLPT()
        {

        }
        public DTO_QLPT(string maPT, string tenPT, string hienTrang)
        {
            this.maPT = maPT;
            this.tenPT = tenPT;
            this.hienTrang = hienTrang;
        }
    }
}