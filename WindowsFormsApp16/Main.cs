using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KyGoi kyGoi = new KyGoi();
            this.Hide();
            kyGoi.ShowDialog();
            this.Show();
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanHang banHang = new BanHang();
            this.Hide();
            banHang.ShowDialog();
            this.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            this.Hide();
            hoaDon.ShowDialog();
            this.Show();

        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanhThucs doanhThucs = new DoanhThucs();
            this.Hide();
            doanhThucs.ShowDialog();
            this.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NV nv = new NV();
            this.Hide();
            nv.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;

            }
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
