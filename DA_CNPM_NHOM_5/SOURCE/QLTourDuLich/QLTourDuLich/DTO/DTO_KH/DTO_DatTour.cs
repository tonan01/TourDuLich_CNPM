using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_KH
{
    public class DTO_DatTour
    {
        private string maDH;
        private string email;
        private int sL;
        private string maVe;

        public string MaDH { get => maDH; set => maDH = value; }
        public string Email { get => email; set => email = value; }
        public int SL { get => sL; set => sL = value; }
        public string MaVe { get => maVe; set => maVe = value; }

        public DTO_DatTour()
        { }

        public DTO_DatTour(string maDH, string email, int sL, string maVe)
        {
            MaDH = maDH;
            Email = email;
            SL = sL;
            MaVe = maVe;
        }
    }

}