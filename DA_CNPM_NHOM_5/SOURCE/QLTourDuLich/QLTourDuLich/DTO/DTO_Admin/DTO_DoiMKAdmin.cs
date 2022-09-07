using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_Admin
{
    public class DTO_DoiMKAdmin
    {
        private string userName;
        private string pass;
        private int maQuyen;

        public int MaQuyen { get => maQuyen; set => maQuyen = value; }
        public string Pass { get => pass; set => pass = value; }
        public string UserName { get => userName; set => userName = value; }

        public DTO_DoiMKAdmin() { }

        public DTO_DoiMKAdmin(string userName, string pass, int maQuyen)
        {
            UserName = userName;
            Pass = pass;
            MaQuyen = maQuyen;
        }
    }
}