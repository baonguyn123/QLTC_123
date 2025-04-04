using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp16.Models;

namespace WindowsFormsApp16
{
    public partial class BanHang : Form
    {
        Model1 model = new Model1();
        public BanHang()
        {
            InitializeComponent();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Product> products = model.Product.ToList();
                List<Employee> employees = model.Employee.ToList();
                BindGrid(products);
                FillFalcutyComboBox(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<Product> products)
        {
            List<VMNBanHang> lstVMNBanHang = new List<VMNBanHang>();
            foreach (var item in products)
            {
                VMNBanHang VM = new VMNBanHang
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Description = item.Description,
                    ProductCategory=item.ProductCategory,
                    SaleDate = item.SaleDate,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    TotalPricef = item.Price * item.Quantity,
                    FullName = item.Employee.FullName,
                };
                lstVMNBanHang.Add(VM);
            }
            dataGridView1.DataSource = lstVMNBanHang;
        }
        private void FillFalcutyComboBox(List<Employee> employees)
        {
            this.cbNVSP.DataSource = employees;
            this.cbNVSP.DisplayMember = "FullName";
            this.cbNVSP.ValueMember = "ID";
        }

        private void btnthemSP_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                // Lấy danh sách BoardingInfo hiện có
                List<Product> products= model.Product.ToList();

                // Kiểm tra nếu chưa chọn nhân viên
                if (cbNVSP.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ép kiểu SelectedValue sang int
                int maNhanVien = Convert.ToInt32(cbNVSP.SelectedValue);

                 //Tạo sản phẩm mới
                var newSP = new Product
                {
                    DisplayName = txttenSP.Text,
                    Description = txtTT.Text,
                    ProductCategory = txtLoai.Text,
                    SaleDate = DateTime.Parse(dateNB.Text),
                    Price = double.Parse(txtgiaSP.Text),
                    Quantity = int.Parse(txtslSP.Text),
                    TotalPricef = double.Parse(txtgiaSP.Text) * int.Parse(txtslSP.Text),
                    EmployeeID = maNhanVien // Gán mã danh mục
                };

                // Thêm thông tin ký gửi vào cơ sở dữ liệu
                model.Product.Add(newSP);
                model.SaveChanges();

                // Cập nhật lại GridView
                BindGrid(model.Product.ToList());

                // Thông báo thành công
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDSP.Clear();
                txttenSP.Clear();
                txtTTSP.Clear();
                txtLoai.Clear();
                dateNB.Value = DateTime.Now;
                txtgiaSP.Clear();
                txtslSP.Clear();
                txtTTSP.Clear();
                cbNVSP.SelectedIndex = -1;


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

        private void btnxoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Product> products = model.Product.ToList();
                var product = products.FirstOrDefault(s => s.ID == int.Parse(txtIDSP.Text));
                if (product != null)
                {
                    model.Product.Remove(product);
                    model.SaveChanges();
                    BindGrid(model.Product.ToList());
                    MessageBox.Show("Xóa sản phẩm thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại  .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa ký gởi  : {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtIDSP.Text = selectedRow.Cells[0].Value?.ToString();
                txttenSP.Text = selectedRow.Cells[1].Value?.ToString();
                txtgiaSP.Text = selectedRow.Cells[2].Value?.ToString();
                txtTT.Text = selectedRow.Cells[3].Value?.ToString();
                txtslSP.Text = selectedRow.Cells[4].Value?.ToString();
                txtTTSP.Text = selectedRow.Cells[5].Value?.ToString();
                txtLoai.Text = selectedRow.Cells[6].Value?.ToString();
                dateNB.Text = selectedRow.Cells[7].Value?.ToString();
                cbNVSP.Text = selectedRow.Cells[8].Value?.ToString();
      
            }
        }

        private void btnsuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Product> products = model.Product.ToList();
                var product = products.FirstOrDefault(p => p.ID == int.Parse(txtIDSP.Text));
                if (product != null)
                {
                    if (products.Any(p => p.ID == int.Parse(txtIDSP.Text) && p.ID != product.ID))
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }

                    product.DisplayName = txttenSP.Text;
                    product.Description = txtTT.Text;
                    product.ProductCategory = txtLoai.Text;
                    product.SaleDate = DateTime.Parse(dateNB.Text);
                    product.Price = double.Parse(txtgiaSP.Text);
                    product.Quantity = int.Parse(txtslSP.Text);
                    product.TotalPricef = double.Parse(txtgiaSP.Text) * int.Parse(txtslSP.Text);
                    product.EmployeeID = Convert.ToInt32(cbNVSP.SelectedValue);
                    model.SaveChanges();
                    //hiển thị toàn bộ danh sách
                    BindGrid(model.Product.ToList());
                    MessageBox.Show("Sửa sản phẩm thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIDSP.Clear();
                    txttenSP.Clear();
                    txtTTSP.Clear();
                    txtLoai.Clear();
                    dateNB.Value = DateTime.Now;
                    txtgiaSP.Clear();
                    txtslSP.Clear();
                    txtTTSP.Clear();
                    cbNVSP.SelectedIndex = -1;

                }
                else
                {
                    MessageBox.Show("Sản phẩm đã tồn tại  .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sản phẩm : {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTim.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var searchResult = model.Product.Where(s => s.DisplayName.ToLower().Contains(keyword)).ToList();
                // lây danh sách đã lọc 
                BindGrid(searchResult);
                if (!searchResult.Any())
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHUYSP_Click(object sender, EventArgs e)
        {
            try
            {
                List<Product> products = model.Product.ToList();
                txtTim.Text = "";
                BindGrid(products);
                MessageBox.Show("Danh sách đã được làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới danh sách: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTTSP_Click(object sender, EventArgs e)
        {

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Show();
        }

        private void BanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            this.Hide();
            hoaDon.ShowDialog();
        }
    }
    }


