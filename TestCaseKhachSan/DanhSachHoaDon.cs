using BLL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseKhachSan
{
    public partial class DanhSachHoaDon : Form
    {
        Database db = new Database();

        private BLL_DanhSachHoaDon hoaDonBLL;
        public DanhSachHoaDon()
        {
            InitializeComponent();

            hoaDonBLL = new BLL_DanhSachHoaDon(new Database().GetDatabase());

            LoadHoaDon();
        }

        public void LoadHoaDon()
        {
            data_hoaDon.DataSource = hoaDonBLL.getDataHoaDon();
        }
        private void btn_LoadTongTien_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (data_hoaDon.CurrentRow != null)
                {
                    DataGridViewRow selectedRow = data_hoaDon.CurrentRow;

                    // Lấy thông tin hóa đơn
                    string maHD = selectedRow.Cells["MaHoaDon"].Value?.ToString() ?? "N/A";
                    string ngayLapHoaDon = selectedRow.Cells["NgayLapHoaDon"].Value?.ToString() ?? "N/A";
                    string tenPhong = selectedRow.Cells["TenPhong"].Value?.ToString() ?? "N/A";
                    string ngayNhanPhong = selectedRow.Cells["NgayNhanPhong"].Value?.ToString() ?? "N/A";
                    string ngayTraPhong = selectedRow.Cells["NgayTraPhong"].Value?.ToString() ?? "N/A";
                    int soNguoiO = Convert.ToInt32(selectedRow.Cells["SoNguoiO"].Value ?? 0);
                    decimal tienCoc = Convert.ToDecimal(selectedRow.Cells["TienCoc"].Value ?? 0);
                    string tenDichVu = selectedRow.Cells["TenDichVu"].Value?.ToString() ?? "Không sử dụng";
                    decimal giaDichVu = Convert.ToDecimal(selectedRow.Cells["GiaDichVu"].Value ?? 0);
                    decimal tongTienPhong = Convert.ToDecimal(selectedRow.Cells["TongTienPhong"].Value ?? 0);
                    decimal tongTienDichVu = Convert.ToDecimal(selectedRow.Cells["TongTienDichVu"].Value ?? 0);
                    decimal tongTienThanhToan = Convert.ToDecimal(selectedRow.Cells["TongTienThanhToan"].Value ?? 0);
                    string phuongThucThanhToan = selectedRow.Cells["PhuongThucThanhToan"].Value?.ToString() ?? "Chưa xác định";
                    string trangThai = selectedRow.Cells["TrangThai"].Value?.ToString() ?? "Chưa thanh toán";
                    string tenNhanVien = selectedRow.Cells["TenNhanVien"].Value?.ToString() ?? "N/A";

                    // Định dạng số tiền
                    string FormatCurrency(decimal amount) => amount.ToString("N0") + " VNĐ";

                    // Tạo nội dung hóa đơn
                    string invoiceContent = $@"
HÓA ĐƠN THANH TOÁN
--------------------------------------
Mã Hóa Đơn       : {maHD}
Ngày Lập Hóa Đơn : {ngayLapHoaDon}
Nhân Viên Lập    : {tenNhanVien}

Thông tin phòng:
{"Phòng:",-20} {tenPhong}
{"Ngày Nhận:",-20} {ngayNhanPhong}
{"Ngày Trả:",-20} {ngayTraPhong}
{"Số Người Ở:",-20} {soNguoiO}
{"Tiền Cọc:",-20} {FormatCurrency(tienCoc)}

Dịch vụ sử dụng:
{"Dịch Vụ:",-20} {tenDichVu}
{"Giá Dịch Vụ:",-20} {FormatCurrency(giaDichVu)}

Chi tiết thanh toán:
{"Tổng Tiền Phòng:",-20} {FormatCurrency(tongTienPhong)}
{"Tổng Tiền Dịch Vụ:",-20} {FormatCurrency(tongTienDichVu)}
{"Phương Thức TT:",-20} {phuongThucThanhToan}
{"Trạng Thái:",-20} {trangThai}
--------------------------------------
{"TỔNG THANH TOÁN:",-20} {FormatCurrency(tongTienThanhToan)}
--------------------------------------
Cảm ơn quý khách đã sử dụng dịch vụ!";

                    // In hóa đơn
                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += (s, ev) =>
                    {
                        System.Drawing.Font printFont = new System.Drawing.Font("Arial", 12);
                        ev.Graphics.DrawString(invoiceContent, printFont, Brushes.Black, new Point(50, 50));
                    };

                    PrintPreviewDialog previewDialog = new PrintPreviewDialog
                    {
                        Document = printDocument
                    };
                    previewDialog.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void data_hoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = data_hoaDon.Columns[e.ColumnIndex].Name;

            // Kiểm tra nếu cột là một trong các cột tiền tệ
            if ((columnName == "TienCoc" || columnName == "GiaDichVu" || columnName == "TongTienPhong" ||
                 columnName == "TongTienDichVu" || columnName == "TongTienThanhToan") && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal soTien))
                {
                    e.Value = string.Format("{0:N0} VND", soTien);
                    e.FormattingApplied = true;
                }
            }
        }

    }
}
