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
    public partial class Doctor_appointments : Form
    {
        public Doctor_appointments()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void Doctor_appointments_Load(object sender, EventArgs e)
        {
            refresh();
            guna2DateTimePicker1.Enabled = false;
        }
        public void refresh()
        {
            DataTable doctorAppointments = Oppeintment_refresh.GetDoctorAppointments(Variables.id);
            dataGridView1.DataSource = doctorAppointments;
        }
        private void Return_main_Click(object sender, EventArgs e)
        {
            Main_Window frm = new Main_Window();
            frm.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (global_id != null)
            {
                Doctor_operations.doctor_appointment_delete(global_id);
                refresh();
            }
            else
            {
                MessageBox.Show("Please Select appointment");
            }
        }
        string global_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 2)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dataGridView1.Rows[selectedrowindex];

                string id = selectedrow.Cells[0].Value.ToString();
                global_id = id;
            }
            if (global_id == null)
            {
                guna2DateTimePicker1.Enabled = false;
            }
            else
            {
                guna2DateTimePicker1.Enabled = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Doctor_operations.doctor_appointment_update(guna2DateTimePicker1.Text,global_id);
            refresh();
            MessageBox.Show("Succesully");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
