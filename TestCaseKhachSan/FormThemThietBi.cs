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

namespace TestCaseKhachSan
{
    public partial class FormThemThietBi : Form
    {
        private int maPhong;
        private Database db = new Database();
        public FormThemThietBi(int maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
            LoadThietBi();
        }

        private void LoadThietBi()
        {
            string connectionString = db.GetDatabase();
            string query = "SELECT MaThietBi, TenThietBi, SoLuongThietBi, TinhTrang FROM THIET_BI";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    data_ThietBi.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách thiết bị: " + ex.Message);
            }
        }

        private void btn_ThemThietBi_Click(object sender, EventArgs e)
        {
            if (data_ThietBi.CurrentRow != null)
            {
                int maThietBi = Convert.ToInt32(data_ThietBi.CurrentRow.Cells["MaThietBi"].Value);
                string tenThietBi = data_ThietBi.CurrentRow.Cells["TenThietBi"].Value.ToString();
                int soLuongTon = Convert.ToInt32(data_ThietBi.CurrentRow.Cells["SoLuongThietBi"].Value);
                string tinhTrang = data_ThietBi.CurrentRow.Cells["TinhTrang"].Value.ToString();
                int soLuongThem;

                if (!int.TryParse(txtSoLuong.Text, out soLuongThem) || soLuongThem <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ lớn hơn 0.");
                    return;
                }
                if (soLuongThem > soLuongTon)
                {
                    MessageBox.Show("Số lượng nhập vượt quá số lượng tồn kho.");
                    return;
                }
                if (tinhTrang == "Bảo trì")
                {
                    MessageBox.Show("Thiết bị đang bảo trì, không thể thêm.");
                    return;
                }

                string connectionString = db.GetDatabase();

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Kiểm tra xem thiết bị đã có trong phòng chưa
                        string checkQuery = @"
                    SELECT SoLuongSuDung FROM CHI_TIET_THIET_BI 
                    WHERE MaPhong = @MaPhong AND MaThietBi = @MaThietBi";

                        SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@MaPhong", maPhong);
                        checkCmd.Parameters.AddWithValue("@MaThietBi", maThietBi);

                        object result = checkCmd.ExecuteScalar();

                        if (result != null) // Nếu thiết bị đã tồn tại => Cập nhật số lượng
                        {
                            int soLuongHienTai = Convert.ToInt32(result);
                            int soLuongMoi = soLuongHienTai + soLuongThem;

                            string updateQuery = @"
                        UPDATE CHI_TIET_THIET_BI 
                        SET SoLuongSuDung = @SoLuongMoi 
                        WHERE MaPhong = @MaPhong AND MaThietBi = @MaThietBi";

                            SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                            updateCmd.Parameters.AddWithValue("@SoLuongMoi", soLuongMoi);
                            updateCmd.Parameters.AddWithValue("@MaPhong", maPhong);
                            updateCmd.Parameters.AddWithValue("@MaThietBi", maThietBi);

                            updateCmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật số lượng thiết bị thành công!");
                        }
                        else // Nếu thiết bị chưa có => Thêm mới
                        {
                            string insertQuery = @"
                        INSERT INTO CHI_TIET_THIET_BI (MaPhong, MaThietBi, SoLuongSuDung) 
                        VALUES (@MaPhong, @MaThietBi, @SoLuong)";

                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@MaPhong", maPhong);
                            insertCmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
                            insertCmd.Parameters.AddWithValue("@SoLuong", soLuongThem);

                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm thiết bị thành công!");
                        }

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm/cập nhật thiết bị: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thiết bị.");
            }
        }

        private void data_ThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenThietBi.Text = data_ThietBi.Rows[e.RowIndex].Cells["TenThietBi"].Value.ToString();
            }
        }
    }
}
