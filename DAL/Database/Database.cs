using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class Database
    {
        string connectionString = @"Data Source=LAPTOP-DOCKI20T;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public string GetDatabase()
        {
            return connectionString;    
        }
    }
}
