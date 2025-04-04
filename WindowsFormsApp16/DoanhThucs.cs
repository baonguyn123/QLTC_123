using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp16.Models2;

namespace WindowsFormsApp16
{
    public partial class DoanhThucs : Form
    {
        private Model2 context; // Thay đổi tên DbContext thành Model1

        public DoanhThucs()
        {
            InitializeComponent();
            context = new Model2(); // Khởi tạo DbContext

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            MessageBox.Show($"Ngày bắt đầu: {startDate:dd/MM/yyyy}\nNgày kết thúc: {endDate:dd/MM/yyyy}");

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                return;
            }

            FilterPaidBillsByDate(startDate, endDate);
        }
        private DataTable GetRevenueByDate(DateTime startDate, DateTime endDate)
        {
            // Truy vấn dữ liệu từ bảng Bill và BillInfo
            var query = from b in context.Bill
                        join bi in context.BillInfo on b.ID equals bi.IdBill
                        where b.DateOutput >= startDate && b.DateOutput <= endDate
                        group bi by b.DateOutput into g
                        select new
                        {
                            NgayXuat = g.Key,
                            TongDoanhThu = g.Sum(x => x.TotalPrice)
                        };

            // Chuyển kết quả sang DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày Xuất", typeof(string));
            dataTable.Columns.Add("Tổng Doanh Thu", typeof(decimal));

            foreach (var item in query)
            {
                dataTable.Rows.Add(item.NgayXuat?.ToString("dd/MM/yyyy"), item.TongDoanhThu);
            }

            return dataTable;
        }
        private void FormatDataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Ngày Xuất";
            dataGridView1.Columns[0].Width = 150;

            dataGridView1.Columns[1].HeaderText = "Tổng Doanh Thu";
            dataGridView1.Columns[1].DefaultCellStyle.Format = "C0"; // Format kiểu tiền tệ
            dataGridView1.Columns[1].Width = 200;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void DoanhThucs_Load(object sender, EventArgs e)
        {

            // Đặt giá trị mặc định cho DateTimePicker
            dateTimePicker1.Value = DateTime.Now.AddDays(-30); // 30 ngày trước
            dateTimePicker2.Value = DateTime.Now;
        }
        private void FilterPaidBillsByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                // Chỉnh endDate để bao gồm cả cuối ngày (23:59:59)
                endDate = endDate.AddDays(1).AddTicks(-1);

                // Lọc hóa đơn trong khoảng ngày
                var filteredBills = context.Bill
                    .Where(b => b.TotalPrice != null && b.DateOutput >= startDate && b.DateOutput <= endDate)
                    .Select(b => new
                    {
                        b.ID,
                        b.DateOutput,
                        b.TotalPrice
                    })
                    .ToList();

                // Hiển thị thông báo nếu không có hóa đơn nào
                if (!filteredBills.Any())
                {
                    MessageBox.Show($"Không tìm thấy hóa đơn nào trong khoảng từ {startDate:dd/MM/yyyy} đến {endDate:dd/MM/yyyy}.");
                    return;
                }

                // Hiển thị dữ liệu lên DataGridView
                dataGridView1.DataSource = filteredBills;

                // Định dạng DataGridView
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lọc hóa đơn: {ex.Message}");
            }
        }

        private void btnTrangCHu_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Show();
        }

        private void DoanhThucs_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ DataGridView
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Ngày thanh toán", typeof(string));
                dataTable.Columns.Add("Tổng tiền", typeof(decimal));

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["NgayThanhToan"]?.Value != null && row.Cells["TongTien"]?.Value != null)
                    {
                        string ngayThanhToan = Convert.ToDateTime(row.Cells["NgayThanhToan"].Value).ToString("dd/MM/yyyy");
                        decimal tongTien = Convert.ToDecimal(row.Cells["TongTien"].Value);
                        dataTable.Rows.Add(ngayThanhToan, tongTien);
                    }
                }

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị FormBieuDoDoanhThu
                frmKiemTraDoanhThu bieuDo = new frmKiemTraDoanhThu();
                bieuDo.LoadDataToChart(dataTable);
                bieuDo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
    
