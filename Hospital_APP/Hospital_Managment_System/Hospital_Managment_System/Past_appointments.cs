using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public partial class Past_appointments : Form
    {
        public Past_appointments()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void Past_appointments_Load(object sender, EventArgs e)
        {
            DataTable dt = Past_appointment.Doctor_Past_Appointments();
            dataGridView1.DataSource = dt;
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Main_Window frm =new Main_Window();
            frm.Show();
            this.Hide();
        }
    }
}
