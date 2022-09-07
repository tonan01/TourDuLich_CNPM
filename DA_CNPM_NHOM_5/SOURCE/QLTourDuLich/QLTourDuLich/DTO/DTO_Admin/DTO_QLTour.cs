using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_Admin
{
    public class DTO_QLTour
    {
        private string maTour;
        private string maDD;
        private string diaChi;
        public DTO_QLTour() { }

        public DTO_QLTour(string maTour, string maDD)
        {
            this.maTour = maTour;
            this.maDD = maDD;
        }

        public DTO_QLTour(string maTour, string maDD, string diaChi)
        {
            this.MaTour = maTour;
            this.MaDD = maDD;
            this.DiaChi = diaChi;
        }

        public string MaTour { get => maTour; set => maTour = value; }
        public string MaDD { get => maDD; set => maDD = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}