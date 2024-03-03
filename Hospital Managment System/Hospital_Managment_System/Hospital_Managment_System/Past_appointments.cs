using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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

        private void Past_appointments_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);           
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand name_and_surname = new SqlCommand("select * from Treated_patient where Concat (Name,' ' ,surname) like '%" + guna2TextBox1.Text + "%' ", con);
            DataTable dt = new DataTable();
            SqlDataReader read = name_and_surname.ExecuteReader();
            dt.Load(read);
            con.Close();
            dataGridView1.DataSource = dt;
        }       
    }
}
