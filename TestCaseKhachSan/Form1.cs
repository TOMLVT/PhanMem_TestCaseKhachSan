using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseKhachSan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mànHìnhChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = true;
            hoaDon1.Visible = false;
            manHinhPhu1.Visible = false;
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            hoaDon1.Visible = true;
            manHinhPhu1.Visible = false;
        }

        private void mànHìnhPhụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manHinhChinh1.Visible = false;
            hoaDon1.Visible = false;
            manHinhPhu1.Visible = true;
        }
    }
}
