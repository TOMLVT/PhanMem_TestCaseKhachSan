using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Phong
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string TinhTrang { get; set; }
        public int? MaLoaiPhong { get; set; } // Nullable vì có thể không có
        public int? MaTangLau { get; set; }   // Nullable vì có thể không có

        public Phong() { }

        public Phong(int maPhong, string tenPhong, string tinhTrang, int? maLoaiPhong, int? maTangLau)
        {
            MaPhong = maPhong;
            TenPhong = tenPhong;
            TinhTrang = tinhTrang;
            MaLoaiPhong = maLoaiPhong;
            MaTangLau = maTangLau;
        }
    }

}
