using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_NV
{
    public class DTO_QLKH_NV
    {
        private string email;
        private string tenKH;
        private string diaChi;
        private string gioiTinh;
        private string ngaySinh;
        private string sDT;
        private string userName;
        private string pass;
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }


        public string TenKH
        {
            get
            {
                return tenKH;
            }

            set
            {
                tenKH = value;
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

        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
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

        public string UserName { get => userName; set => userName = value; }
        public string Pass { get => pass; set => pass = value; }

        public DTO_QLKH_NV()
        {
            email = tenKH = diaChi = gioiTinh = ngaySinh = sDT = "";
        }
        public DTO_QLKH_NV(string Email, string tenkh, string diachi, string gioitinh, string ngaysinh, string sdt)
        {
            this.email = Email;

            this.tenKH = tenkh;
            this.diaChi = diachi;
            this.gioiTinh = gioitinh;
            this.ngaySinh = ngaysinh;
            this.sDT = sdt;
        }

    }
}