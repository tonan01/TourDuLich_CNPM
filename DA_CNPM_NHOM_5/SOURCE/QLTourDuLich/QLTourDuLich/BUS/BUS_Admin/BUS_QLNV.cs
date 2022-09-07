using QLTourDuLich.Xuly_Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLTourDuLich.DTO.DTO_Admin;

namespace QLTourDuLich.BUS.BUS_Admin
{
    public class BUS_QLNV
    {
        xuLyQLNV dt = new xuLyQLNV();
        //load cbb dia chi
        public DataTable getcbbDiaChi()
        {
            return dt.loadccbDiaChi();
        }
        //load cbb chức vụ
        public DataTable getcbbChucVu()
        {
            return dt.loadcbbChucVu();
        }
        //load dữ liệu nhân vien
        public DataTable getloadNV()
        {
            return dt.loadTTNV();
        }
        //kiểm tra rỗng
        public bool KTrong(string manv, string email, string hoten, string sdt)
        {
            return dt.KTRong(manv,email,hoten,sdt);
        }
        //kiểm tra trùng khóa chính
        public bool KTKhoaC(string pvalue)
        {
            return dt.ktkhoaC(pvalue);
        }
        //thêm
        public bool them(DTO_QLNV nv)
        {
            return dt.them(nv);
        }
        //xoa
        public bool xoa(string manv)
        {
            return dt.Xoa(manv);
        }
        //sửa
        public bool sua(DTO_QLNV nv)
        {
            return dt.Sua(nv);
        }
        //thêm tk
        public bool themtk(string tk)
        {
            return dt.themtk(tk);
        }
        //xoa tk
        public bool xoatk(string tk)
        {
            return dt.xoatk(tk);
        }
    }
}