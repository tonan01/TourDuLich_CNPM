using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_KH
{
    public class DTO_DoiMKKH
    {
        private string userName;
        private string pass;
        private int maQuyen;

        public int MaQuyen { get => maQuyen; set => maQuyen = value; }
        public string Pass { get => pass; set => pass = value; }
        public string UserName { get => userName; set => userName = value; }

        public DTO_DoiMKKH() { }

        public DTO_DoiMKKH(string userName, string pass, int maQuyen)
        {
            UserName = userName;
            Pass = pass;
            MaQuyen = maQuyen;
        }
    }
}