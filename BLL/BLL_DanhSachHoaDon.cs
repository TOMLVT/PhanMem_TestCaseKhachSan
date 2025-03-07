using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DanhSachHoaDon
    {
        public DAL_DanhSachHoaDon hoaDonDAL;

        public BLL_DanhSachHoaDon(string Dbconnection)
        {
            hoaDonDAL = new DAL_DanhSachHoaDon(Dbconnection);
        }
        public DataTable getDataHoaDon()
        {
            return hoaDonDAL.LoadDataHoaDon();
        }
    }
}
