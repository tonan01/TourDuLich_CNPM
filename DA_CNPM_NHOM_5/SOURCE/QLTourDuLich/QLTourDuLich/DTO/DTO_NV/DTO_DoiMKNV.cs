using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_NV
{
    public class DTO_DoiMKNV
    {
        private string userName;
        private string pass;
        private string pass_hientai;
        public DTO_DoiMKNV()
        {
            userName = Pass = pass_hientai = "";
        }
        public DTO_DoiMKNV(string username, string mk, string pass_Hientai)
        {
            this.userName = username;
            this.Pass = mk;
            this.pass_hientai = pass_Hientai;
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        public string Pass_hientai
        {
            get
            {
                return pass_hientai;
            }

            set
            {
                pass_hientai = value;
            }
        }
    }
}