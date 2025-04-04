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
    public partial class DMK : Form
    {
        private Model2 model = new Model2();
        private int failedAttempts = 0;
        public DMK()
        {
            InitializeComponent();
        }

        private void DMK_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentusername = txtUserDMK.Text;
            string oldpassword = txtOldPass.Text;
            string newpassword = txtNewPassword.Text;
            string currentpassword = txtCurrentPassword.Text;
            if (string.IsNullOrWhiteSpace(oldpassword) || string.IsNullOrWhiteSpace(newpassword) || string.IsNullOrWhiteSpace(currentpassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            if(newpassword!=currentpassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!");
                return;
            }
            var employee = model.Employee.FirstOrDefault(x => x.Username.Equals(currentusername));
            if (employee == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên!");
                return;
            }
            if (employee.Password != oldpassword)
            {
                failedAttempts++;
                if (failedAttempts >= 3)
                {
                    MessageBox.Show("Bạn đã nhập sai mật khẩu quá 3 lần. Vui lòng thử lại sau!");
                    this.Close(); // Đóng form hoặc khóa tài khoản nếu cần
                    return;
                }
                MessageBox.Show($"Mật khẩu cũ không đúng! Bạn còn {3 - failedAttempts} lần thử.");
                return;
            }
            employee.Password = newpassword;
            model.SaveChanges();
            MessageBox.Show("Đổi mật khẩu thành công!");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
