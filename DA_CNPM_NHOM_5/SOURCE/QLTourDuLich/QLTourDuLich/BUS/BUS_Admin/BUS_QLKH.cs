using QLTourDuLich.DTO.DTO_Admin;
using QLTourDuLich.Xuly_Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLTourDuLich.BUS.BUS_Admin
{
    public class BUS_QLKH
    {
        xuLyQLKH xl = new xuLyQLKH();
        public bool KT_Email(string email)
        {

            Regex kt = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
            if (kt.IsMatch(email))
                return true;
            else
                return false;
        }
        public DataTable getloadDataKH()
        {
            return xl.loadDataKH();
        }
        public DataTable getloadDiaChi()
        {
            return xl.loadcbbDC();
        }
        public bool themKH(DTO_QLKH kh)
        {
            return xl.ThemKH(kh);
        }
        public bool xoaKH(DTO_QLKH kh)
        {
            return xl.XoaKH(kh);
        }
        public bool suaKH(DTO_QLKH kh)
        {
            return xl.SuaKH(kh);
        }
        public DataTable TimKH(string kh)
        {
            return xl.TimKH(kh);
        }
        public void resetDataTable()
        {
            xl.ResetDataTable();
        }
        public bool KTRong_pass(string pass)
        {
            if (pass == string.Empty) { return false; }
            else { return true; }
        }
        public bool KTRong_tenKH(string tenkh)
        {
            if (tenkh == string.Empty) { return false; }
            else { return true; }
        }
        public bool KTRong_SDT(string sdt)
        {
            if (sdt == string.Empty) { return false; }
            else { return true; }
        }
        public bool KTsokytu_SDT(string sdt)
        {
            if (sdt.Length != 10) { return false; }
            else { return true; }
        }
        public bool ThemUser(string username)
        {
            return xl.themUser(username);
        }
        public bool XoaUser(string username)
        {
            return xl.xoaUser(username);
        }
        public bool KT_user(string user)
        {
            return xl.testUser(user);
        }
        public bool KT_khoaNgoaiKH(string email)
        {
            return xl.ktkhoaNgoai(email);
        }
    }
}