using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DanhSachHoaDon
    {
        private string connectionSring;

        public DAL_DanhSachHoaDon(string Dbconnection)
        {
            connectionSring = Dbconnection; 
        }

        public DataTable LoadDataHoaDon()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSring))
            {
                connection.Open();
                string query = @"
            SELECT 
                hd.MaHoaDon,
                hd.NgayLapHoaDon,
                p.TenPhong,
                pdp.NgayNhanPhong,
                pdp.NgayTraPhong,
                pdp.SoNguoiO,
                pdp.TienCoc,
                dv.TenDichVu,
                dv.GiaDichVu,
                hd.TongTienPhong,
                hd.TongTienDichVu,
                hd.TongTienThanhToan,
                hd.PhuongThucThanhToan,
                hd.TrangThai,
                nv.HoTen AS TenNhanVien
            FROM HOA_DON hd
            INNER JOIN PHIEU_DAT_PHONG pdp ON hd.MaLapPhieu = pdp.MaLapPhieu
            INNER JOIN PHONG p ON pdp.MaPhong = p.MaPhong
            LEFT JOIN DICH_VU dv ON pdp.MaDichVu = dv.MaDichVu
            LEFT JOIN NHAN_VIEN nv ON pdp.ID_NHANVIEN = nv.ID_NHANVIEN";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
