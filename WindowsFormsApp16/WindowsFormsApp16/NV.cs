using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp16.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp16
{
    public partial class NV : Form
    {
        Model1 model = new Model1();
        public NV()
        {
            InitializeComponent();
        }

        private void btnthemNV_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Employee> employees = model.Employee.ToList();
                var newEmployee = new Employee
                {
                    FullName = txthoTen.Text,
                    Address = txtDiaChi.Text,
                    Phone = txtSDT.Text,
                    Username = txttaiKhoan.Text,
                    Password = txtMK.Text,
                    DateOfBirth = DateTime.Parse(dateNS.Text), // Thêm ngày sinh
                };
                model.Employee.Add(newEmployee);
                model.SaveChanges();
                BindGrid(model.Employee.ToList());
                MessageBox.Show("Thêm nhân viên thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên : {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NV_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Employee> employees = model.Employee.ToList();

                BindGrid(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<Employee> employees)
        {
            dtgNV.Rows.Clear();
            foreach (var item in employees)
            {
                int index = dtgNV.Rows.Add();
                dtgNV.Rows[index].Cells[0].Value = item.ID;
                dtgNV.Rows[index].Cells[1].Value = item.FullName;
                dtgNV.Rows[index].Cells[2].Value = item.Address;
                dtgNV.Rows[index].Cells[3].Value = item.Phone;
                dtgNV.Rows[index].Cells[4].Value = item.Username;
                dtgNV.Rows[index].Cells[5].Value = item.Password;
                dtgNV.Rows[index].Cells[6].Value = item.DateOfBirth;

            }
        }
        private void ClearTextFields()
        {
            txtIDNV.Clear();
            txthoTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txttaiKhoan.Clear();
            txtMK.Clear();
            dateNS.Value = DateTime.Now;
        }

        private void btnxoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có muốn xóa nhân viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    Model1 model = new Model1();
                    List<Employee> employees = model.Employee.ToList();
                    var employee = employees.FirstOrDefault(s => s.ID == int.Parse(txtIDNV.Text));
                    if (employee != null)
                    {
                        model.Employee.Remove(employee);
                        model.SaveChanges();
                        BindGrid(model.Employee.ToList());
                        MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTextFields();
                    }
                    else
                    {
                        MessageBox.Show(" Nhân viên không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa : {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnsuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Employee> employees = model.Employee.ToList();
                var employee = employees.FirstOrDefault(s => s.ID == int.Parse(txtIDNV.Text));
                if (employee != null)
                {
                    if (employees.Any(s => s.ID == int.Parse(txtIDNV.Text) && s.ID != employee.ID))
                    {
                        MessageBox.Show("Mã số nhân viên đã tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    employee.FullName = txthoTen.Text;
                    employee.Address = txtDiaChi.Text;
                    employee.Phone = txtSDT.Text;
                    employee.Username = txttaiKhoan.Text;
                    employee.Password = txtMK.Text;
                    employee.DateOfBirth = DateTime.Parse(dateNS.Text); // Thêm ngày sinh
                    model.SaveChanges();// Lưu thay đổi vào cơ sở dữ liệu
                    BindGrid(model.Employee.ToList()); // Cập nhật lại lưới
                    MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextFields();


                }
                else
                {
                    MessageBox.Show("Nhân viên không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgNV.Rows[e.RowIndex];
                txtIDNV.Text = selectedRow.Cells[0].Value?.ToString();
                txthoTen.Text = selectedRow.Cells[1].Value?.ToString();
                txtDiaChi.Text = selectedRow.Cells[2].Value?.ToString();
                txtSDT.Text = selectedRow.Cells[3].Value?.ToString();
                txttaiKhoan.Text = selectedRow.Cells[4].Value?.ToString();
                txtMK.Text = selectedRow.Cells[5].Value?.ToString();
                dateNS.Text = selectedRow.Cells[6].Value?.ToString();
         

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox, loại bỏ kí tự trắng
                string keyword = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập tên cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Tìm kiếm người dùng từ cơ sở dữ liệu
                var searchResult = model.Employee.Where(u => u.FullName.ToLower().Contains(keyword)).ToList();
                //lọc 
                BindGrid(searchResult);

                if (!searchResult.Any())
                {
                    MessageBox.Show("Không tìm thấý nhân viên phù hợp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
