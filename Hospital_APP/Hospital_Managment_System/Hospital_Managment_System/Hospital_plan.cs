using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public partial class Hospital_plan : Form
    {
        public Hospital_plan()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Reception_window frm = new Reception_window();
            frm.Show();
            this.Hide();
        }

        private void btn_Entry_hall_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            pictureBox2.Hide();
            pictureBox3.Hide();
            this.Size = new Size(816, 489);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Show();
            pictureBox3.Hide();
            pictureBox1.Hide();
            this.Size = new Size(816, 489);
        }

        private void Hospital_plan_Load(object sender, EventArgs e)
        {
            pictureBox1.Show();
            pictureBox2.Hide();
            pictureBox3.Hide();
            this.Size = new Size(816, 489);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pictureBox3.Show();
            pictureBox1.Hide();
            pictureBox2.Hide();
            this.Size = new Size(816, 706);
            pictureBox3.Size = new Size(649, 643);
        }
    }
}
