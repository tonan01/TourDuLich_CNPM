using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLTourDuLich.XuLy_KH;
using QLTourDuLich.DTO.DTO_KH;

namespace QLTourDuLich.BUS.BUS_KH
{
    public class BUS_DatTour
    {
        xuLyDatTour dt = new xuLyDatTour();
        //load combobox địa chỉ
        public DataTable getccbDiaChi()
        {
            return dt.loadccbDiaChi();
        }

        //load combobox đại lý
        public DataTable getcbbDaiLy()
        {
            return dt.loadcbbDaiLY();
        }

        //load combobox khách sạn
        public DataTable getcbbKhachSan()
        {
            return dt.loadcbbKhachSan();
        }

        //load combobox phương tiện
        public DataTable getcbbPhuongTien()
        {
            return dt.loadcbbPhuongTien();
        }

        //load combobox địa điểm tham quan
        public DataTable getccbDDThamQuan()
        {
            return dt.loadccbDDThamQuan();
        }

        //load danh sách đặt tourr
        public DataTable getDSTour()
        {
            return dt.loadTour();
        }

        //load danh sách vé
        public DataTable getDSVe()
        {
            return dt.loadVe();
        }

        //kiểm tra rỗng
        public bool KTRong(string mave,string sl)
        {
            return dt.KTRong(mave,sl);
        }

        //tìm kiếm
        public DataTable searchDatVe(string timkiem)
        {
            return dt.timKiemVe(timkiem);
        }

        //làm mới tìm kiếm
        public void lamMoiSearchVe()
        {
            dt.lamMoiTimKiemVe();
        }

        //tìm kiếm
        public DataTable searchDatTour(string timkiem)
        {
            return dt.timKiemTour(timkiem);
        }

        //load ds ct_hd của hóa đơn
        public DataTable getDSCTHD(string mahd)
        {
            return dt.loadDSChiTietHD(mahd);
        }

        //làm mới chi tiết hd
        public void lamMoiDSCTHD()
        {
            dt.lamMoiDSCTHD();
        }

        //làm mới tìm kiếm
        public void lamMoiSearch()
        {
            dt.lamMoiTimKiem();
        }

        //tạo mã hd tự động
        public int maTuDong()
        {
            return dt.taomahdtudong();
        }

        //đặt tour
        public bool DatTour(DTO_DatTour hd)
        {
            return dt.DatTour(hd);
        }
        //đặt tour Thêm
        public bool DatTourThem(DTO_DatTour hd)
        {
            return dt.DatTourThem(hd);
        }
    }
}