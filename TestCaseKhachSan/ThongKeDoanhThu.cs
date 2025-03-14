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
    public partial class ThongKeDoanhThu : Form
    {
        Database db = new Database();
        public ThongKeDoanhThu()
        {
            InitializeComponent();
            LoadDoanhThuChart();
        }
        private void LoadDoanhThuChart()
        {
            string query = @"
        WITH ThangNam AS (
            SELECT 1 AS Thang UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4
            UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8
            UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12
        )
        SELECT 
            T.Thang, 
            COALESCE(SUM(HD.TongTienPhong), 0) AS DoanhThuPhong,
            COALESCE(SUM(HD.TongTienDichVu), 0) AS DoanhThuDichVu,
            COALESCE(SUM(HD.TongTienThanhToan), 0) AS TongDoanhThu
        FROM ThangNam T
        LEFT JOIN HOA_DON HD 
            ON T.Thang = MONTH(HD.NgayLapHoaDon) 
            AND YEAR(HD.NgayLapHoaDon) = YEAR(GETDATE())
        GROUP BY T.Thang
        ORDER BY T.Thang;";

            using (SqlConnection conn = new SqlConnection(db.GetDatabase()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();

                // Xóa dữ liệu cũ
                chart1.Series.Clear();
                chart1.Legends.Clear();

                // Thêm Legend
                System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend("Legend1");
                legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
                chart1.Legends.Add(legend);

                // Thêm các Series
                chart1.Series.Add("Doanh thu phòng");
                chart1.Series.Add("Doanh thu dịch vụ");
                chart1.Series.Add("Tổng doanh thu");

                foreach (var series in chart1.Series)
                {
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    series.Legend = "Legend1";
                    series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
                    series.LabelFormat = "N0"; // Định dạng số tiền
                }

                // Màu sắc
                chart1.Series["Doanh thu phòng"].Color = System.Drawing.Color.DarkBlue;
                chart1.Series["Doanh thu dịch vụ"].Color = System.Drawing.Color.Orange;
                chart1.Series["Tổng doanh thu"].Color = System.Drawing.Color.Crimson;

                // Lấy tổng doanh thu cả năm để tính phần trăm
                decimal tongDoanhThuNam = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["TongDoanhThu"]));

                foreach (DataRow row in dt.Rows)
                {
                    int thang = Convert.ToInt32(row["Thang"]);
                    decimal doanhThuPhong = Convert.ToDecimal(row["DoanhThuPhong"]);
                    decimal doanhThuDichVu = Convert.ToDecimal(row["DoanhThuDichVu"]);
                    decimal tongDoanhThu = Convert.ToDecimal(row["TongDoanhThu"]);

                    // Chuyển sang tỷ lệ phần trăm
                    decimal tyLePhong = (tongDoanhThuNam == 0) ? 0 : (doanhThuPhong / tongDoanhThuNam) * 100;
                    decimal tyLeDichVu = (tongDoanhThuNam == 0) ? 0 : (doanhThuDichVu / tongDoanhThuNam) * 100;
                    decimal tyLeTong = (tongDoanhThuNam == 0) ? 0 : (tongDoanhThu / tongDoanhThuNam) * 100;

                    chart1.Series["Doanh thu phòng"].Points.AddXY(thang, tyLePhong);
                    chart1.Series["Doanh thu dịch vụ"].Points.AddXY(thang, tyLeDichVu);
                    chart1.Series["Tổng doanh thu"].Points.AddXY(thang, tyLeTong);

                    // Hiển thị VNĐ trên cột
                    chart1.Series["Doanh thu phòng"].Points.Last().Label = $"{doanhThuPhong:N0} VNĐ";
                    chart1.Series["Doanh thu dịch vụ"].Points.Last().Label = $"{doanhThuDichVu:N0} VNĐ";
                    chart1.Series["Tổng doanh thu"].Points.Last().Label = $"{tongDoanhThu:N0} VNĐ";
                }

                // Thiết lập trục Y thành %
                chart1.ChartAreas[0].AxisY.Title = "Tỷ lệ doanh thu (%)";
                chart1.ChartAreas[0].AxisY.Maximum = 100;
                chart1.ChartAreas[0].AxisY.Interval = 10;
            }
        }


    }
}
