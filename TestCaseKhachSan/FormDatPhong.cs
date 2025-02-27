using DAL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Data.Helpers.FindSearchRichParser;

namespace TestCaseKhachSan
{
    public partial class FormDatPhong : Form
    {
        Database db = new Database();

        private Timer NhanVienTimer, DichVuTimer;

        private int maPhong;
        public FormDatPhong(int maPhong)
        {
            InitializeComponent();

            NhanVienTimer = new Timer();
            NhanVienTimer.Interval = 1000;
            NhanVienTimer.Tick += (s, e) => LoadDataChonNhanVien();
            NhanVienTimer.Start();


            DichVuTimer = new Timer();
            DichVuTimer.Interval = 1000;
            DichVuTimer.Tick += (s, e) => LoadDataChonDichVu();
            DichVuTimer.Start();

            this.maPhong = maPhong;
        }


        public void LoadDataChonNhanVien()
        {
            string connectionString = new Database().GetDatabase();
            string query = "SELECT ID_NHANVIEN, HOTEN FROM NHAN_VIEN";


            var selectedValue = cb_NhanVien.SelectedValue;

            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_NhanVien.DisplayMember = "HOTEN";
            cb_NhanVien.ValueMember = "ID_NHANVIEN";
            cb_NhanVien.DataSource = dt;


            if (selectedValue != null && dt.AsEnumerable().Any(row => row["ID_NHANVIEN"].ToString() == selectedValue.ToString()))
            {
                cb_NhanVien.SelectedValue = selectedValue;
            }
            else
            {

                cb_NhanVien.SelectedIndex = 0;
            }
        }

        public void LoadDataChonDichVu()
        {
            string connectionString = new Database().GetDatabase();
            string query = "SELECT MaDichVu, TenDichVu FROM DICH_VU";


            var selectedValue = cb_DichVu.SelectedValue;

            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_DichVu.DisplayMember = "TenDichVu";
            cb_DichVu.ValueMember = "MaDichVu";
            cb_DichVu.DataSource = dt;


            if (selectedValue != null && dt.AsEnumerable().Any(row => row["MaDichVu"].ToString() == selectedValue.ToString()))
            {
                cb_DichVu.SelectedValue = selectedValue;
            }
            else
            {

                cb_DichVu.SelectedIndex = 0;
            }
        }

        private void btn_DatPhong_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = date_NgaySinh.Value;
            string gioiTinh = cb_GioiTinh.SelectedItem.ToString();
            string sdt = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            string cccd = txtCCCD.Text;
            DateTime ngayNhan = date_NhanPhong.Value;
            DateTime ngayTra = date_TraPhong.Value;
            int soNguoi = int.Parse(txtSonguoi.Text);
            decimal tienCoc = decimal.Parse(txtTienCoc.Text);
            DateTime ngayDat = DateTime.Now;
            string trangThaiPhieuDat = cb_TrangThaiPhieuDat.Text;
            

            using (SqlConnection conn = new SqlConnection(db.GetDatabase()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {

                    int maKH;
                   
                    string checkKhachHangQuery = "SELECT MaKhachHang FROM KHACH_HANG WHERE SDT = @SoDienThoai AND HoTen = @HoTen";
                    using (SqlCommand cmdCheckKH = new SqlCommand(checkKhachHangQuery, conn, transaction))
                    {
                        cmdCheckKH.Parameters.AddWithValue("@SoDienThoai", sdt);
                        cmdCheckKH.Parameters.AddWithValue("@HoTen", hoTen);
                        var result = cmdCheckKH.ExecuteScalar();
                        maKH = result != null ? Convert.ToInt32(result) : 0;
                    }


                    // Lưu thông tin khách hàng
                    if (maKH == 0)
                    {
                        string insertKhachHang = @"
                    INSERT INTO KHACH_HANG (HoTen, NgaySinh, GioiTinh, SDT, DiaChi, CCCD) 
                    VALUES (@HoTen, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @CCCD);
                    SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmdInsertKH = new SqlCommand(insertKhachHang, conn, transaction))
                        {
                            cmdInsertKH.Parameters.AddWithValue("@HoTen", hoTen);
                            cmdInsertKH.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            cmdInsertKH.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            cmdInsertKH.Parameters.AddWithValue("@SDT", sdt);
                            cmdInsertKH.Parameters.AddWithValue("@DiaChi", diaChi);
                            cmdInsertKH.Parameters.AddWithValue("@CCCD", cccd);

                            maKH = Convert.ToInt32(cmdInsertKH.ExecuteScalar());
                        }
                    }

                  


                    // Lưu thông tin phiếu đặt phòng
                    string insertPhieuDat = @"INSERT INTO PHIEU_DAT_PHONG 
    (NgayNhanPhong, NgayTraPhong, SoNguoiO, TrangThaiPhieuDat, TienCoc, NgayDat, MaPhong , MaDichVu , ID_NHANVIEN) 
    VALUES (@NgayNhan, @NgayTra, @SoNguoiO, @TrangThai, @TienCoc, @NgayDat, @MaPhong, @MaDichVu , @MaNhanVien);";

                    SqlCommand cmdPhieuDat = new SqlCommand(insertPhieuDat, conn, transaction);
                    cmdPhieuDat.Parameters.AddWithValue("@NgayNhan", ngayNhan);
                    cmdPhieuDat.Parameters.AddWithValue("@NgayTra", ngayTra);
                    cmdPhieuDat.Parameters.AddWithValue("@SoNguoiO", soNguoi);
                    cmdPhieuDat.Parameters.AddWithValue("@TrangThai", trangThaiPhieuDat);
                    cmdPhieuDat.Parameters.AddWithValue("@TienCoc", tienCoc);
                    cmdPhieuDat.Parameters.AddWithValue("@NgayDat", ngayDat);
                    cmdPhieuDat.Parameters.AddWithValue("@MaNhanVien", 7);
                    cmdPhieuDat.Parameters.AddWithValue("@MaDichVu", cb_DichVu.SelectedValue);
                    cmdPhieuDat.Parameters.AddWithValue("@MaPhong", maPhong);

                    cmdPhieuDat.ExecuteNonQuery();

                    // Lưu thông tin vào bảng CHITIETPHONG
                    string insertChiTietPhong = @"INSERT INTO CHITIETPHONG (MaPhong, MaKhachHang, MaDichVu) 
                              VALUES (@MaPhong, @MaKhachHang, @MaDichVu);";

                    SqlCommand cmdChiTietPhong = new SqlCommand(insertChiTietPhong, conn, transaction);
                    cmdChiTietPhong.Parameters.AddWithValue("@MaPhong", maPhong);

                    // Giả sử bạn có một ComboBox cb_ThietBi để chọn thiết bị
                    cmdChiTietPhong.Parameters.AddWithValue("@MaKhachHang", maKH);
                    cmdChiTietPhong.Parameters.AddWithValue("@MaDichVu", cb_DichVu.SelectedValue);

                    cmdChiTietPhong.ExecuteNonQuery();


                    // Cập nhật trạng thái phòng
                    string updatePhong = "UPDATE PHONG SET TinhTrang = N'Đang sử dụng' WHERE MaPhong = @MaPhong";
                    SqlCommand cmdUpdatePhong = new SqlCommand(updatePhong, conn, transaction);
                    cmdUpdatePhong.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdUpdatePhong.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Đặt phòng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
