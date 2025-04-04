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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp16
{
    public partial class KyGoi : Form
    {
        private string invoiceContent = ""; // Biến lưu nội dung hóa đơn
        private PrintDocument printDocument1 = new PrintDocument();
        private BoardingInfo selectedBoardingInfo; // Lưu thông tin ký gửi được chọn
        Model1 model = new Model1();
        public KyGoi()
        {
            InitializeComponent();
            printDocument1.PrintPage += printDocument1_PrintPage;
        }

        private void KyGoi_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<BoardingInfo> boardingInfos = model.BoardingInfo.ToList();
                List<Employee> employees = model.Employee.ToList();
                BindGrid(boardingInfos);
                FillFalcutyComboBox(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<BoardingInfo> boardingInfos)
        {
            List<VMNKyGoi> lstVMNKyGois = new List<VMNKyGoi>();
            foreach (var item in boardingInfos)
            {
                var days = (item.EndDate - item.StartDate).Days;

                VMNKyGoi VM = new VMNKyGoi
                {
                    ID = item.ID,
                    OwnerName = item.OwnerName,
                    Contact = item.Contact, // Kiểm tra null
                    PetName = item.PetName,
                    Quantity = item.Quantity,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Price = item.Price,
                    TotalPrice = item.Price * item.Quantity * days, // Tổng tiền tính theo số ngày
                    CageName = item.CageName,
                    FullName = item.Employee.FullName,
                };
                lstVMNKyGois.Add(VM);
            }
            dataGridView1.DataSource = lstVMNKyGois;
        }
        private void FillFalcutyComboBox(List<Employee> employees)
        {
            this.cbNV.DataSource = employees;
            this.cbNV.DisplayMember = "FullName";
            this.cbNV.ValueMember = "ID";
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtidPet.Text = selectedRow.Cells[0].Value?.ToString();
                txtTenChu.Text = selectedRow.Cells[1].Value?.ToString();
                txtSDTChu.Text = selectedRow.Cells[2].Value?.ToString();
                txttenPet.Text = selectedRow.Cells[3].Value?.ToString();
                txtslPet.Text = selectedRow.Cells[4].Value?.ToString();
                NgayDen.Text = selectedRow.Cells[5].Value?.ToString();
                NgayVe.Text = selectedRow.Cells[6].Value?.ToString();
                txtgiaPet.Text = selectedRow.Cells[7].Value?.ToString();
                txtTT.Text = selectedRow.Cells[8].Value?.ToString();
                txtSoChuong.Text = selectedRow.Cells[9].Value?.ToString();
                cbNV.Text = selectedRow.Cells[10].Value?.ToString();
            }
        }

        private void btnthemPet_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                // Lấy danh sách BoardingInfo hiện có
                List<BoardingInfo> boardingInfos = model.BoardingInfo.ToList();

                // Kiểm tra nếu số chuồng đã tồn tại trong cơ sở dữ liệu
                string cageName = txtSoChuong.Text.Trim().ToLower(); // Loại bỏ khoảng trắng và đồng bộ chữ thường
                //Khi bạn thêm một bản ghi mới, bạn chỉ cần kiểm tra xem số chuồng có tồn tại trong cơ sở dữ liệu không. Đơn giản vì bạn đang thêm mới, không quan tâm đến bản ghi cũ.
                if (boardingInfos.Any(s => s.CageName.Trim().ToLower() == cageName))
                {
                    MessageBox.Show("Số chuồng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Ngăn việc thêm dữ liệu
                }

                // Kiểm tra nếu chưa chọn nhân viên
                if (cbNV.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ép kiểu SelectedValue sang int
                int maNhanVien = Convert.ToInt32(cbNV.SelectedValue);
                var days = (DateTime.Parse(NgayVe.Text) - DateTime.Parse(NgayDen.Text)).Days;

                // Tạo thông tin ký gửi mới
                var newKyGoi = new BoardingInfo
                {
                    OwnerName = txtTenChu.Text,
                    Contact = txtSDTChu.Text,
                    PetName = txttenPet.Text,
                    Quantity = int.Parse(txtslPet.Text),
                    StartDate = DateTime.Parse(NgayDen.Text),
                    EndDate = DateTime.Parse(NgayVe.Text),
                    Price = float.Parse(txtgiaPet.Text),
                    TotalPrice = float.Parse(txtgiaPet.Text) * int.Parse(txtslPet.Text) * days, // Tính tổng tiền
                    CageName = txtSoChuong.Text,
                    EmployeeID = maNhanVien // Gán mã nhân viên
                };

                // Thêm thông tin ký gửi vào cơ sở dữ liệu
                model.BoardingInfo.Add(newKyGoi);
                model.SaveChanges();

                // Cập nhật lại GridView
                BindGrid(model.BoardingInfo.ToList());

                // Thông báo thành công
                MessageBox.Show("Thêm ký gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dữ liệu đã nhập (nếu cần)
                txtTenChu.Clear();
                txtSDTChu.Clear();
                txttenPet.Clear();
                txtslPet.Clear();
                NgayDen.Value = DateTime.Now; // Hoặc giá trị mặc định khác
                NgayVe.Value = DateTime.Now; // Hoặc giá trị mặc định khác
                txtgiaPet.Clear();
                txtSoChuong.Clear();
                cbNV.SelectedIndex = -1; // Hoặc giá trị mặc định khác

            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoaPet_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<BoardingInfo> boardingInfos = model.BoardingInfo.ToList();
                var boardingInfo = boardingInfos.FirstOrDefault(s => s.ID == int.Parse(txtidPet.Text));
                if (boardingInfo != null)
                {
                    model.BoardingInfo.Remove(boardingInfo);
                    model.SaveChanges();
                    BindGrid(model.BoardingInfo.ToList());
                    MessageBox.Show("Xóa ký gởi thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa ký gởi thất bại  .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa ký gởi  : {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsuaPet_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<BoardingInfo> boardingInfos = model.BoardingInfo.ToList();
                int id;
                if (!int.TryParse(txtidPet.Text, out id))
                {
                    MessageBox.Show("ID không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var boardingInfo = boardingInfos.FirstOrDefault(s => s.ID == id);
                if (boardingInfo == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin ký gửi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cageName = txtSoChuong.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(cageName))
                {
                    MessageBox.Show("Vui lòng nhập số chuồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra nếu số chuồng thay đổi và có tồn tại
                if (!boardingInfo.CageName.Trim().ToLower().Equals(cageName))
                {
                    if (boardingInfos.Any(s => s.CageName != null && s.CageName.Trim().ToLower() == cageName && s.ID != boardingInfo.ID))
                    {
                        MessageBox.Show("Số chuồng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (cbNV.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtslPet.Text, out int quantity))
                {
                    MessageBox.Show("Số lượng thú cưng phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!float.TryParse(txtgiaPet.Text, out float price))
                {
                    MessageBox.Show("Giá tiền phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var days = (DateTime.Parse(NgayVe.Text) - DateTime.Parse(NgayDen.Text)).Days;

                boardingInfo.OwnerName = txtTenChu.Text;
                boardingInfo.Contact = txtSDTChu.Text;
                boardingInfo.PetName = txttenPet.Text;
                boardingInfo.Quantity = quantity;
                boardingInfo.StartDate = DateTime.Parse(NgayDen.Text);
                boardingInfo.EndDate = DateTime.Parse(NgayVe.Text);
                boardingInfo.Price = price;
                boardingInfo.TotalPrice = price * quantity * days; // Cập nhật tổng tiền với số ngày
                boardingInfo.CageName = txtSoChuong.Text;
                boardingInfo.EmployeeID = Convert.ToInt32(cbNV.SelectedValue);

                model.SaveChanges();
                //Hiển thị toàn bộ dữ liệu từ cơ sở dữ liệu.
                BindGrid(model.BoardingInfo.ToList());
                MessageBox.Show("Sửa ký gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dữ liệu đã nhập (nếu cần)
                txtTenChu.Clear();
                txtSDTChu.Clear();
                txttenPet.Clear();
                txtslPet.Clear();
                NgayDen.Value = DateTime.Now;
                NgayVe.Value = DateTime.Now;
                txtgiaPet.Clear();
                txtSoChuong.Clear();
                cbNV.SelectedIndex = -1;
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox, loại bỏ kí tự trắng
                string keyword = txtTimKyGoi.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập tên cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Tìm kiếm người dùng từ cơ sở dữ liệu
                var searchResult = model.BoardingInfo.Where(u => u.OwnerName != null && u.OwnerName.ToLower().Contains(keyword.ToLower())).ToList();
                //lọc 
                BindGrid(searchResult);

                if (!searchResult.Any())
                {
                    MessageBox.Show("Không tìm thấy  !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHuyTim_Click(object sender, EventArgs e)
        {
            try
            {
                List<BoardingInfo> boardingInfos = model.BoardingInfo.ToList();

                txtTimKyGoi.Text = "";
                // Chỉ hiển thị danh sách đã lọc hoặc xử lý(danh sách tùy chỉnh).
                BindGrid(boardingInfos);
                MessageBox.Show("Danh sách đã được làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới danh sách: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToanTC_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu không có dòng nào được chọn trong GridView
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một ký gửi để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin ký gửi từ dòng đã chọn trong DataGridView
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int boardingInfoID = Convert.ToInt32(selectedRow.Cells[0].Value); // Giả sử cột đầu tiên là ID

                Model1 model = new Model1();
                var boardingInfo = model.BoardingInfo.Include("Employee").FirstOrDefault(b => b.ID == boardingInfoID);

                if (boardingInfo != null)
                {
                    // Lưu trữ thông tin để in hóa đơn
                    selectedBoardingInfo = boardingInfo;
                    GenerateInvoiceContent();

                    // Thực hiện in hóa đơn
                    PrintInvoice();

                    // Thực hiện thanh toán (hiển thị thông báo thành công)
                    MessageBox.Show($"Thanh toán thành công cho ký gửi ID: {boardingInfoID}!", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa bản ghi ký gửi đã thanh toán
                    model.BoardingInfo.Remove(boardingInfo);
                    model.SaveChanges();

                    // Cập nhật lại GridView sau khi xóa dữ liệu
                    BindGrid(model.BoardingInfo.ToList());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ký gửi để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateInvoiceContent()
        {
            if (selectedBoardingInfo == null)
                return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== HÓA ĐƠN KÝ GỬI =====");
            sb.AppendLine($"ID Ký Gửi: {selectedBoardingInfo.ID}");
            sb.AppendLine($"Tên Chủ: {selectedBoardingInfo.OwnerName}");
            sb.AppendLine($"SĐT Chủ: {selectedBoardingInfo.Contact}");
            sb.AppendLine($"Tên Thú Cưng: {selectedBoardingInfo.PetName}");
            sb.AppendLine($"Số Lượng: {selectedBoardingInfo.Quantity}");
            sb.AppendLine($"Ngày Đến: {selectedBoardingInfo.StartDate.ToShortDateString()}");
            sb.AppendLine($"Ngày Về: {selectedBoardingInfo.EndDate.ToShortDateString()}");
            sb.AppendLine($"Giá: {selectedBoardingInfo.Price:C}");
            sb.AppendLine($"Tổng Tiền: {selectedBoardingInfo.TotalPrice:C}");
            sb.AppendLine($"Số Chuồng: {selectedBoardingInfo.CageName}");
            sb.AppendLine($"Nhân Viên Chăm Sóc: {selectedBoardingInfo.Employee.FullName}");
            sb.AppendLine("============================");

            invoiceContent = sb.ToString();
        }
        private void PrintInvoice()
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            printPreviewDialog.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Cài đặt font và màu sắc
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font contentFont = new Font("Arial", 12);
            Brush blackBrush = Brushes.Black;
            Brush redBrush = Brushes.Red;

            float y = e.MarginBounds.Top;
            float x = e.MarginBounds.Left;

            // Vẽ tiêu đề hóa đơn
            e.Graphics.DrawString("HÓA ĐƠN KÝ GỬI", titleFont, redBrush, x + 200, y);
            y += 40;

            // Vẽ thông tin mã hóa đơn và ngày
            e.Graphics.DrawString($"Mã ký gửi: {selectedBoardingInfo.ID}", contentFont, blackBrush, x, y);
            e.Graphics.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", contentFont, blackBrush, x + 400, y);
            y += 30;

            // Vẽ thông tin khách hàng
            e.Graphics.DrawString("Thông tin khách hàng:", headerFont, blackBrush, x, y);
            y += 30;
            e.Graphics.DrawString($"Tên chủ: {selectedBoardingInfo.OwnerName}", contentFont, blackBrush, x, y);
            e.Graphics.DrawString($"SĐT: {selectedBoardingInfo.Contact}", contentFont, blackBrush, x + 300, y);
            y += 30;

            // Vẽ thông tin thú cưng
            e.Graphics.DrawString("Thông tin thú cưng:", headerFont, blackBrush, x, y);
            y += 30;
            e.Graphics.DrawString($"Tên thú cưng: {selectedBoardingInfo.PetName}", contentFont, blackBrush, x, y);
            e.Graphics.DrawString($"Số lượng: {selectedBoardingInfo.Quantity}", contentFont, blackBrush, x + 300, y);
            y += 30;
            e.Graphics.DrawString($"Số chuồng: {selectedBoardingInfo.CageName}", contentFont, blackBrush, x, y);
            y += 30;

            // Vẽ thông tin ngày gửi và ngày trả
            e.Graphics.DrawString($"Ngày đến: {selectedBoardingInfo.StartDate:dd/MM/yyyy}", contentFont, blackBrush, x, y);
            e.Graphics.DrawString($"Ngày về: {selectedBoardingInfo.EndDate:dd/MM/yyyy}", contentFont, blackBrush, x + 300, y);
            y += 30;

            // Vẽ thông tin giá
            e.Graphics.DrawString("Chi tiết giá:", headerFont, blackBrush, x, y);
            y += 30;
            e.Graphics.DrawString($"Giá combo: {selectedBoardingInfo.Price:N0} VND", contentFont, blackBrush, x, y);
            e.Graphics.DrawString($"Tổng tiền: {selectedBoardingInfo.TotalPrice:N0} VND", contentFont, redBrush, x + 300, y);
            y += 30;

            // Vẽ thông tin nhân viên
            e.Graphics.DrawString($"Nhân viên chăm sóc: {selectedBoardingInfo.Employee.FullName}", contentFont, blackBrush, x, y);
        }




        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Show();
        }

        private void KyGoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;

            }
        }
        private void tinhGiaTien()
        {
            try
            {
                // Lấy ngày bắt đầu và ngày kết thúc
                DateTime startDate = NgayDen.Value.Date; // Chỉ lấy ngày, bỏ qua giờ
                DateTime endDate = NgayVe.Value.Date;   // Chỉ lấy ngày, bỏ qua giờ

                // Tính số ngày giữa ngày bắt đầu và ngày kết thúc
                int days = (endDate - startDate).Days;
                // Nếu ngày về sớm hơn ngày đến (trường hợp sai logic), đặt days = 0
                if (days < 0)
                {
                    MessageBox.Show("Ngày về không được sớm hơn ngày đến!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    days = 0;
                }



                // Giá tiền theo ngày, tuần và tháng
                double pricePerDayCombo = 100000; // Giá combo cố định trong ngày
                double pricePerDay = 200000; // 1 ngày
                double pricePerWeek = 400000; // 1 tuần (7 ngày)
                double pricePerMonth = 600000; // 1 tháng (30 ngày)

                double totalPrice = 0;
                if (days == 0) {
                    totalPrice = pricePerDayCombo ; // Tính theo tháng
                                                                 // Kiểm tra nếu khách lấy sớm trong cùng ngày
                    DateTime currentTime = DateTime.Now; // Thời gian hiện tại
                    if (currentTime.Date == startDate && currentTime < endDate) // Lấy sớm trong ngày
                    {
                        MessageBox.Show("Khách đã lấy thú cưng sớm hơn dự kiến, nhưng giá vẫn giữ nguyên (100000 VND),bạn vẫn muốn lấy chứ.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
          
                // Xử lý tùy theo số ngày
               else  if (days >= 30) // Nếu là 1 tháng (hoặc nhiều tháng)
                {
                    int fullMonths = days / 30;  // Số tháng đầy đủ
                    int remainingDays = days % 30;  // Số ngày lẻ
                    totalPrice = pricePerMonth * fullMonths + pricePerDay * remainingDays;
                }
                else if (days >= 7) // Nếu là 1 tuần (hoặc nhiều tuần)
                {
                    int fullWeeks = days / 7;  // Số tuần đầy đủ
                    int remainingDays = days % 7;  // Số ngày lẻ
                    totalPrice = pricePerWeek * fullWeeks + pricePerDay * remainingDays;
                }
                //else if (days > 0 && days < 7) // Nếu số ngày lớn hơn 0 và nhỏ hơn 7
                //{
                //    totalPrice = pricePerDay * (days + 1); // Tính giá theo số ngày thực tế (bao gồm cả ngày đầu tiên)
                //}
                else // Từ 1 đến 6 ngày
                {
                    totalPrice = pricePerDay * days ; // Giá theo ngày thực tế, bao gồm cả ngày bắt đầu
                }


                // Cập nhật giá vào ô text
                txtgiaPet.Text = totalPrice.ToString("N0"); // Định dạng số có dấu phân cách ngàn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính giá tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTT_TextChanged(object sender, EventArgs e)
        {

        }

        private void NgayDen_ValueChanged(object sender, EventArgs e)
        {
            tinhGiaTien();
        }

        private void NgayVe_ValueChanged(object sender, EventArgs e)
        {
            tinhGiaTien();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            
        }
     
    }
}











