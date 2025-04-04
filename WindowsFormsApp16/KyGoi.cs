using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp16.Models2;

namespace WindowsFormsApp16
{
    public partial class KyGoi : Form
    {
        Model2 model = new Model2();
        public KyGoi()
        {
            InitializeComponent();
        }

        private void KyGoi_Load(object sender, EventArgs e)
        {
            try
            {
                Model2 model = new Model2();
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
                Model2 model = new Model2();
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
                Model2 model = new Model2();
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
                Model2 model = new Model2();
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
                var searchResult = model.BoardingInfo .Where(u => u.OwnerName != null && u.OwnerName.ToLower().Contains(keyword.ToLower())).ToList();
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
                // dòng đuọc chọn đầu tiên 
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int boardingInfoID = Convert.ToInt32(selectedRow.Cells[0].Value); // Giả sử cột đầu tiên là ID

                Model2 model = new Model2();
                var boardingInfo = model.BoardingInfo.FirstOrDefault(b => b.ID == boardingInfoID);

                if (boardingInfo != null)
                {
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
                DateTime startDate = NgayDen.Value;
                DateTime endDate = NgayVe.Value;

                // Tính số ngày giữa ngày bắt đầu và ngày kết thúc
                int days = (endDate - startDate).Days;

                if (days == 0)
                {
                    days = 1; // Nếu ngày đến và ngày về trùng nhau, xem như 1 ngày
                }


                // Giá tiền theo ngày, tuần và tháng
                double pricePerDay = 200000; // 1 ngày
                double pricePerWeek = 400000; // 1 tuần (7 ngày)
                double pricePerMonth = 600000; // 1 tháng (30 ngày)

                double totalPrice = 0;

                // Xử lý tùy theo số ngày
                if (days >= 30) // Nếu là 1 tháng (hoặc nhiều tháng)
                {
                    totalPrice = pricePerMonth * (days / 30); // Tính theo tháng
                }
                else if (days >= 7) // Nếu là 1 tuần (hoặc nhiều tuần)
                {
                    totalPrice = pricePerWeek * (days / 7); // Tính theo tuần
                }
                else // Nếu là số ngày nhỏ hơn 1 tuần
                {
                    totalPrice = pricePerDay * days; // Tính theo ngày
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}











