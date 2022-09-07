using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTourDuLich.DAO
{
    public class XuLyKetNoi
    {

     
        
        

        public static string con = @"Data Source = DESKTOP-K7BRREB; " +
           "Initial Catalog = QLTourDuLich; User ID = sa; Password = 123";

        // Lớp kết nối ----------------------------------------------------------------------
        public static SqlConnection getConnection()
        {
            return new SqlConnection(con);
        }
       
    }
}