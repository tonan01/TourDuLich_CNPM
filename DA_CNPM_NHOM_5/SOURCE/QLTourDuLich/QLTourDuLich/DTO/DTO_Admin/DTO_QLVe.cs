using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DTO.DTO_Admin
{
    public class DTO_QLVe
    {
        private string maVe;
        private string maTour;
        private string maDL;
        private string maKS;
        private string maPT;
        private double gia;
        private DateTime ngayBD;
        private DateTime ngayKT;
        public string MaVe
        {
            get { return maVe; }
            set { maVe = value; }
        }

        public string MaTour
        {
            get { return maTour; }
            set { maTour = value; }
        }

        public string MaDL
        {
            get => maDL;
            set => maDL = value;
        }
        public string MaKS
        {
            get { return maKS; }
            set { maKS = value; }
        }
        public string MaPT
        {
            get { return maPT; }
            set { maPT = value; }
        }
        public double Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        public DateTime NgayBD
        {
            get { return ngayBD; }
            set { ngayBD = value; }
        }
        public DateTime NgayKT
        {
            get { return ngayKT; }
            set { ngayKT = value; }
        }
        public DTO_QLVe() { }
        public DTO_QLVe(string maVe, string maTour, string maDL, string maKS, string maPT, double gia, DateTime ngayBD, DateTime ngayKT)
        {
            this.maVe = maVe;
            this.maTour = maTour;
            this.maDL = maDL;
            this.maKS = maKS;
            this.maPT = maPT;
            this.gia = gia;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }

    }
}