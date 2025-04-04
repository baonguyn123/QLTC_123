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
using WindowsFormsApp16.Models;

namespace WindowsFormsApp16
{
    public partial class HoaDon : Form
    {
      
        private Model1 _context;
        private int lastBillID = 0; // Biến lưu lại ID hóa đơn cuối cùng
        public HoaDon()
        {
            InitializeComponent();
            _context = new Model1();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            // Làm trống DataGridView khi khởi động form
            dataGridView1.DataSource = null;

            // Reset tổng tiền về 0
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";

            // Nạp danh sách sản phẩm
            LoadProducts();

            // Nạp chi tiết hóa đơn (chỉ hiển thị dữ liệu mới)
            LoadBillDetails();
        }
        private void LoadProducts()
        {
            try
            {
                var products = _context.Product.ToList(); // Lấy danh sách sản phẩm từ cơ sở dữ liệu
                cbSPHD.DataSource = products; // Gán danh sách sản phẩm cho ComboBox
                cbSPHD.DisplayMember = "DisplayName"; // Hiển thị tên sản phẩm
                cbSPHD.ValueMember = "ID"; // Giá trị là ID sản phẩm
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải sản phẩm: {ex.Message}");
            }
        }
        private void LoadBillDetails()
        { 
            // Lọc chỉ các chi tiết hóa đơn chưa được thanh toán (IdBill == null)
            var billDetails = _context.BillInfo
                .Where(b => b.IdBill == null) // Lọc các bản ghi chưa thanh toán
                .Select(b => new
                {
                    b.ID,
                    ProductName = b.Product.DisplayName, // Lấy tên sản phẩm từ Product
                    b.Quantity,
                    b.Price,
                    TotalPrice = b.Price * b.Quantity // Tính tổng tiền
                })
                .ToList();

            // Gán dữ liệu vào DataGridView
            dataGridView1.DataSource = billDetails;

            // Tính tổng tiền hiển thị
            decimal totalAmount = (decimal)billDetails.Sum(b => b.TotalPrice);
            lblTongTien.Text = $"Tổng tiền: {totalAmount:N0} VNĐ"; // Định dạng số tiền
        }
        private void cbSPHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSPHD.SelectedItem != null)
            {
                // Lấy sản phẩm đã chọn
                var selectedProduct = cbSPHD.SelectedItem as Product;

                if (selectedProduct != null)
                {
                    // Hiển thị giá sản phẩm
                    txtGiaHD.Text = selectedProduct.Price.ToString();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbSPHD.SelectedItem != null && int.TryParse(txtSL.Text, out int quantity) && quantity > 0)
            {
                // Lấy sản phẩm đã chọn
                var selectedProduct = cbSPHD.SelectedItem as Product;

                if (selectedProduct != null)
                {
                    // Tạo đối tượng VMNBillinfo mới
                    var billInfo = new BillInfo 
                    {
                        IdProduct = selectedProduct.ID,  
                        Quantity = quantity,
                        Price = Convert.ToDecimal(selectedProduct.Price),
                        TotalPrice = Convert.ToDecimal(selectedProduct.Price) * quantity,
                    };

                    try
                    {
                        // Lưu vào cơ sở dữ liệu
                        _context.BillInfo.Add(billInfo);
                        _context.SaveChanges();

                        // Thông báo thành công
                        MessageBox.Show("Thêm hóa đơn thành công!");

                        // Cập nhật lại danh sách hóa đơn hiển thị
                        LoadBillDetails();
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi khi lưu vào cơ sở dữ liệu
                        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng hợp lệ.");
            }
        }

        private void txtGiaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
             // Kiểm tra xem người dùng có chọn dòng nào trong DataGridView không
    if (dataGridView1.SelectedRows.Count > 0)
    {
        // Lấy ID của dòng được chọn
        int selectedBillInfoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

        try
        {
            // Tìm đối tượng BillInfo trong cơ sở dữ liệu
            var billInfoToDelete = _context.BillInfo.FirstOrDefault(b => b.ID == selectedBillInfoId);
            
            if (billInfoToDelete != null)
            {
                // Xóa đối tượng BillInfo
                _context.BillInfo.Remove(billInfoToDelete);
                _context.SaveChanges();

                // Thông báo thành công
                MessageBox.Show("Xóa hóa đơn thành công!");

                // Cập nhật lại danh sách hóa đơn hiển thị
                LoadBillDetails();
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn để xóa.");
            }
        }
        catch (Exception ex)
        {
            // Xử lý lỗi khi xóa
            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
        }
    }
    else
    {
        MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.");
    }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtIDHD.Text = selectedRow.Cells[0].Value?.ToString();
                cbSPHD.Text = selectedRow.Cells[1].Value?.ToString();
                txtSL.Text = selectedRow.Cells[2].Value?.ToString();
                txtGiaHD.Text = selectedRow.Cells[3].Value?.ToString();

            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Lấy chi tiết hóa đơn từ DataGridView
            var billDetails = _context.BillInfo.Where(b => b.IdBill == null).ToList(); // Chỉ lấy các dòng chưa có IdBill
            if (billDetails.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào để thanh toán.");
                return;
            }

            // Tính tổng tiền
            decimal totalAmount = (decimal)billDetails.Sum(b => b.TotalPrice);

            // Xác nhận thanh toán
            var result = MessageBox.Show($"Tổng tiền cần thanh toán: {totalAmount:N0} VNĐ\nBạn có chắc chắn muốn thanh toán?",
                                          "Xác nhận thanh toán",
                                          MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Tạo hóa đơn mới
                    var newBill = new Bill
                    {
                        DateOutput = DateTime.Now,
                        TotalPrice = totalAmount,
                        EmployeeID = 1 // Giả sử ID nhân viên là 1
                    };

                    // Thêm hóa đơn vào bảng Bill
                    _context.Bill.Add(newBill);
                    _context.SaveChanges();

                    // Gắn IdBill cho các chi tiết hóa đơn
                    foreach (var detail in billDetails)
                    {
                        detail.IdBill = newBill.ID; // Gắn IdBill của hóa đơn mới tạo
                    }
                    _context.SaveChanges();

                    // Lưu IdBill của hóa đơn vừa thanh toán
                    lastBillID = newBill.ID;

                    // Xóa dữ liệu hiển thị trên DataGridView
                    dataGridView1.DataSource = null; // Gán null để xóa dữ liệu hiển thị
                    lblTongTien.Text = "Tổng tiền: 0 VNĐ"; // Reset lại tổng tiền

                    MessageBox.Show("Thanh toán thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi thanh toán: {ex.Message}");
                }
            }
        }
        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (lastBillID == 0)
            {
                MessageBox.Show("Không có hóa đơn nào để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin hóa đơn từ CSDL
            var bill  = _context.Bill.FirstOrDefault(b => b.ID == lastBillID);
            if (bill == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị PrintPreviewDialog
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, ev) => PrintBill(ev, bill);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };

            printPreviewDialog.ShowDialog();
        }
        private void PrintBill(PrintPageEventArgs e, Bill bill)
        {
            int y = 20; // Vị trí dòng đầu tiên
            int x = 50; // Tọa độ x
            int lineHeight = 30; // Khoảng cách giữa các dòng
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontContent = new Font("Arial", 12);
            Pen pen = new Pen(Color.Black);

            // Tiêu đề hóa đơn
            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", fontTitle, Brushes.Red, new Point(x + 200, y));
            y += 50;

            // In thông tin hóa đơn
            e.Graphics.DrawString($"Mã hóa đơn: {bill.ID}", fontContent, Brushes.Black, new Point(x, y));
            y += lineHeight;
            e.Graphics.DrawString($"Ngày: {bill.DateOutput:dd/MM/yyyy HH:mm:ss}", fontContent, Brushes.Black, new Point(x, y));
            y += lineHeight;
        
            // Kẻ đường ngang
            e.Graphics.DrawLine(pen, x, y, x + 700, y);
            y += 10;

            // In tiêu đề bảng
            e.Graphics.DrawString("Tên sản phẩm", fontHeader, Brushes.Blue, new Point(x, y));
            e.Graphics.DrawString("Số lượng", fontHeader, Brushes.Blue, new Point(x + 200, y));
            e.Graphics.DrawString("Giá", fontHeader, Brushes.Blue, new Point(x + 350, y));
            e.Graphics.DrawString("Tổng", fontHeader, Brushes.Blue, new Point(x + 500, y));
            y += lineHeight;

            // Kẻ đường ngang
            e.Graphics.DrawLine(pen, x, y, x + 700, y);
            y += 10;

            // Lấy chi tiết hóa đơn từ BillInfo
            var billDetails = _context.BillInfo.Where(bi => bi.IdBill == bill.ID).ToList();
            foreach (var detail in billDetails)
            {
                // Lấy tên sản phẩm từ bảng Product
                var product = _context.Product.FirstOrDefault(p => p.ID == detail.IdProduct);
                string productName = product != null ? product.DisplayName : "Không xác định";

                // In chi tiết sản phẩm
                e.Graphics.DrawString(productName, fontContent, Brushes.Black, new Point(x, y));
                e.Graphics.DrawString(detail.Quantity.ToString(), fontContent, Brushes.Black, new Point(x + 200, y));
                e.Graphics.DrawString(Convert.ToDecimal(detail.Price).ToString("N0"), fontContent, Brushes.Black, new Point(x + 350, y));
                e.Graphics.DrawString(Convert.ToDecimal(detail.TotalPrice).ToString("N0"), fontContent, Brushes.Black, new Point(x + 500, y));
                y += lineHeight;
            }

            // Tổng tiền
            y += 20;
            e.Graphics.DrawString($"Tổng tiền: {bill.TotalPrice:N0} VNĐ", fontHeader, Brushes.Red, new Point(x, y));
            y += lineHeight;  
        }

        private void btnTrangCHu_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Show();
        }

        private void HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;

            }
        }
    }
}
