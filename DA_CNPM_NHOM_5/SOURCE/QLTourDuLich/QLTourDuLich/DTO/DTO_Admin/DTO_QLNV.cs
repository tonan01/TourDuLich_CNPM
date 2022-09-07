using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_Admin
{
    public class DTO_QLNV
    {
        private string maNV;
        private string tenNV;
        private string maCV;
        private string email;
        private string diaChi;
        private string gioiTinh;
        private string ngaySinh;
        private string sDT;

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string MaCV { get => maCV; set => maCV = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SDT { get => sDT; set => sDT = value; }

        public DTO_QLNV(string maNV, string tenNV, string maCV, string email, string diaChi, string gioiTinh, string ngaySinh, string sDT)
        {
            MaNV = maNV;
            TenNV = tenNV;
            MaCV = maCV;
            Email = email;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SDT = sDT;
        }
    }
}