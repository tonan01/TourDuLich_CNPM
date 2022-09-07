using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_NV
{
    public class DTO_TTCaNhan_NV
    {
        private string maNV;
        private string tenNV;
        private string maCV;
        private string email;
        private string diaChi;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string sDT;


        public string Email { get => email; set => email = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string MaCV { get => maCV; set => maCV = value; }
        public string MaNV { get => maNV; set => maNV = value; }

        public DTO_TTCaNhan_NV()
        { }

        public DTO_TTCaNhan_NV(string maNV, string tenNV, string maCV, string email, string diaChi, string gioiTinh, DateTime ngaySinh, string sDT)
        {
            this.maNV = maNV;
            this.email = email;
            this.tenNV = tenNV;
            this.maCV = maCV;
            this.diaChi = diaChi;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.sDT = sDT;
        }
    }
}