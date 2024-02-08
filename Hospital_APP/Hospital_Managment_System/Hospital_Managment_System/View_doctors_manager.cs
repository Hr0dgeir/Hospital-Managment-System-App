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
    public partial class View_doctors_manager : Form
    {
        public View_doctors_manager()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void View_doctors_manager_Load(object sender, EventArgs e)
        {
            doctors();
        }

        public void doctors()
        {
            DataTable dt = See_Doctors.doctors();
            dataGridView1.DataSource = dt;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string full_name;
            if (dataGridView1.SelectedCells.Count > 2)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dataGridView1.Rows[selectedrowindex];

                string Mail = selectedrow.Cells[4].Value.ToString();
                string name = selectedrow.Cells[0].Value.ToString();
                string surname = selectedrow.Cells[1].Value.ToString();
                full_name = name + " " + surname;
                Variables.manager_doctormail = Mail;
                manager_doctor_informations frm = new manager_doctor_informations();
                frm.ShowDialog();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand doctor_surname = new SqlCommand("select Name , Surname , Area , Section ,E_mail from Doctor_Register WHERE Name + ' ' + Surname LIKE '%" + guna2TextBox1.Text + "%'", con);
            SqlDataReader read_surname = doctor_surname.ExecuteReader();
            DataTable dt_surname = new DataTable();
            dt_surname.Load(read_surname);
            dataGridView1.DataSource = dt_surname;
            con.Close();
        }
    }
}
