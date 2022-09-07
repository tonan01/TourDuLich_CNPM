using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_DN_DK
{
    public class DTO_DangKy
    {
        private string userName;
        private string pass;
        private int maQuyen;

        public int MaQuyen { get => maQuyen; set => maQuyen = value; }
        public string Pass { get => pass; set => pass = value; }
        public string UserName { get => userName; set => userName = value; }

        public DTO_DangKy() { }

        public DTO_DangKy(string userName, string pass, int maQuyen)
        {
            UserName = userName;
            Pass = pass;
            MaQuyen = maQuyen;
        }
    }
}