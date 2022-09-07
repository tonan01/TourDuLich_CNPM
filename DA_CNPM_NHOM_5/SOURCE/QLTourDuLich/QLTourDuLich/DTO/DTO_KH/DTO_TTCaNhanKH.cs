using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_KH
{
    public class DTO_TTCaNhanKH
    {
        private string email;
        private string tenKH;
        private string diaChi;
        private string gioiTinh;
        private string ngaySinh;
        private string sDT;
        
        public string Email { get => email; set => email = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SDT { get => sDT; set => sDT = value; }


        public DTO_TTCaNhanKH()
        { }

        public DTO_TTCaNhanKH(string email, string tenKH, string diaChi, string gioiTinh, string ngaySinh, string sDT)
        {
            Email = email;
            TenKH = tenKH;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SDT = sDT;
        }

    }
}