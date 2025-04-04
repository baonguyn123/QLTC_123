using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp16.Models2;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        private Model2 model = new Model2();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
            }
            var employees = model.Employee.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (employees != null)
            {
                MessageBox.Show("Đăng nhập thành công");
                Main main= new Main();
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            DMK dmk= new DMK();
            this.Hide();
            dmk.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
