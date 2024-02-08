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
using static System.Net.Mime.MediaTypeNames;

namespace Hospital_Managment_System
{
    public partial class Doctor_Waiting_patients : Form
    {
        public Doctor_Waiting_patients()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void Doctor_Waiting_patients_Load(object sender, EventArgs e)
        {
            again();
            if (Variables.patient_id == null)
            {
                show_appointment();
            }
            if (Variables.patient_id != null)
            {    
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
                con.Open();
                SqlCommand diagnosis = new SqlCommand("select * from Test where patient_id ='" + Variables.patient_id + "' ", con);
                SqlDataReader read = diagnosis.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                dataGridView1.DataSource = dt;
                con.Close();
                
                lbl_blood.Hide();
                lbl_name.Hide();
                lbl_socialnumber.Hide();
                lbl_surname.Hide();
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
                guna2Button3.Hide();
                guna2Button1.Hide();
                guna2HtmlLabel8.Hide();
            }
            
        }

        public void show_appointment()
        {
            con.Open();
            SqlCommand patients = new SqlCommand("select * from Doctor_Appointment where Doctor_Email like'%" + Variables.id + "%' ", con);
            SqlDataReader dr = patients.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
            
            guna2DateTimePicker1.Enabled = false;
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            lbl_blood.Hide();
            lbl_name.Hide();
            lbl_socialnumber.Hide();
            lbl_surname.Hide();
            guna2Button3.Hide();
            guna2Button1.Hide();
            guna2HtmlLabel8.Hide();
        }
        public void choose_diagnosis()
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[selectedrowindex];

            string patient_name = selectedrow.Cells[3].Value.ToString();
            string result = selectedrow.Cells[4].Value.ToString();
            string request_tests = selectedrow.Cells[8].Value.ToString();
            string patient_id = selectedrow.Cells[7].Value.ToString();

            lbl_name.Text = patient_name;
            richTextBox4.Text = result;
            guna2HtmlLabel4.Text = "Patient id : " + patient_id;
            richTextBox5.Text = request_tests;

            groupBox3.Show();
            guna2Button1.Show();
            groupBox1.Hide();
            groupBox2.Hide();
            guna2Button3.Hide();
            guna2DateTimePicker1.Enabled = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string global_doctor_name;
        string global_patient_name;
        string global_social_number;
        string global_patient_id;

        string global_patient_nameb;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Variables.patient_id == null)
            {
                if (dataGridView1.SelectedCells.Count > 2)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedrow = dataGridView1.Rows[selectedrowindex];

                    string doctor_name = selectedrow.Cells[1].Value.ToString();
                    string patient_name = selectedrow.Cells[2].Value.ToString();
                    string patient_surname = selectedrow.Cells[3].Value.ToString();
                    string patient_social_number = selectedrow.Cells[4].Value.ToString();
                    string patient_blood = selectedrow.Cells[6].Value.ToString();
                    string patient_id = selectedrow.Cells[0].Value.ToString();

                    dataGridView1.Hide();
                    global_patient_nameb = patient_name;
                    lbl_name.Text = "Name : " + patient_name;
                    lbl_surname.Text = "Surname : " + patient_surname;
                    lbl_socialnumber.Text = "Social Number : " + patient_social_number;
                    lbl_blood.Text = "Blood Group : " + patient_blood;
                    global_doctor_name = doctor_name;
                    global_patient_name = patient_name;
                    guna2HtmlLabel8.Text = patient_social_number;
                    global_patient_id = patient_id;
                    dataGridView1.Hide();
                    guna2Button1.Show();
                    guna2Button3.Show();
                    lbl_blood.Show();
                    lbl_name.Show();
                    lbl_socialnumber.Show();
                    lbl_surname.Show();
                }
            }
            else
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dataGridView1.Rows[selectedrowindex];

                string patient_name = selectedrow.Cells[3].Value.ToString();
                string result = selectedrow.Cells[4].Value.ToString();
                string request_tests = selectedrow.Cells[8].Value.ToString();
                string patient_id = selectedrow.Cells[7].Value.ToString();

                guna2HtmlLabel4.Text = "Patient Name : "+ patient_name;
                richTextBox4.Text = result;
                guna2HtmlLabel7.Text = "Patient id : " + patient_id;
                richTextBox5.Text = request_tests;

                groupBox3.Show();
                guna2Button1.Show();
                groupBox1.Hide();
                groupBox2.Hide();
                guna2Button3.Show();
                guna2DateTimePicker1.Enabled = false;
            }
            dataGridView1.Hide();
        }
        string patient_name2;
        string patient_surname2;
        public void again()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctor_Appointment where ID ='"+Variables.patient_id+"' ",con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                patient_name2 = rdr[2].ToString();
                patient_surname2 = rdr[3].ToString();
            }
            con.Close();
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobobx_tests.SelectedItem != null)
            {
                if (richTextBox1.Text == "")
                {
                    richTextBox1.Text += combobobx_tests.SelectedItem.ToString();
                }
                else
                {
                    richTextBox1.Text += "+ "+combobobx_tests.SelectedItem.ToString();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            combobobx_tests.SelectedItem = null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
                SqlCommand sent = new SqlCommand("insert into Test (Doctor_who_wants,Doctor_information,Patient_name,result,request_date,patient_id,request_tests) values (@doctor,@information,@patient_name,@result,@date,@id,@tests)", con);
                sent.Parameters.AddWithValue("@doctor", global_doctor_name);
                sent.Parameters.AddWithValue("@information", Variables.id);
                sent.Parameters.AddWithValue("@patient_name", global_patient_name);
                sent.Parameters.AddWithValue("@result", "Waiting");
                sent.Parameters.AddWithValue("@date", guna2DateTimePicker1.Text);
                sent.Parameters.AddWithValue("@id", global_patient_id);
                sent.Parameters.AddWithValue("@tests", richTextBox1.Text);
                con.Open();
                sent.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Succesfully");
                groupBox1.Hide();
                guna2Button1.Show();
                richTextBox1.Text = null;
                combobobx_tests.Text = null;
            }
            else
            {
                MessageBox.Show("Test Cannot be empty");
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Show();
            guna2Button1.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear();
        }

        public void delete()
        {
            con.Open();
            SqlCommand delete_patient = new SqlCommand("delete from Doctor_Appointment where Patient_social_number='" + guna2HtmlLabel8.Text + "' ", con);
            delete_patient.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Succesfully");
            dataGridView1.Show();
        }
        //--------------------------------------------//
        public void add_treated_patient()
        {
            con.Open();
            SqlCommand add = new SqlCommand("insert into Treated_patient (Name,Surname,Doctor_name,Doctor_surname,Doctor_section,diagnosis,prescriptions,Doctor_information) values (@name,@surname,@d_name,@d_surname,@d_section,@diagnosis,@prescriptipns,@mail)", con);
            MessageBox.Show(patient_name2 + patient_surname2);
            add.Parameters.AddWithValue("@name", patient_name2);
            add.Parameters.AddWithValue("@surname", patient_surname2);
            add.Parameters.AddWithValue("@d_name", global_doctorname);
            add.Parameters.AddWithValue("@d_surname", global_doctorsurname);
            add.Parameters.AddWithValue("@d_section", global_doctorsection);
            add.Parameters.AddWithValue("@diagnosis", richTextBox2.Text);
            add.Parameters.AddWithValue("@prescriptipns", richTextBox3.Text);
            add.Parameters.AddWithValue("@mail", Variables.id);
            add.ExecuteNonQuery();
            con.Close();
        }
        string global_name;
        string global_surname;
        string global_doctorname;
        string global_doctorsurname;
        string global_doctorsection;
        public void patient()
        {
            
            if (Variables.patient_id == null)
            {
                con.Open();
                SqlCommand insert = new SqlCommand("select * from Doctor_Appointment where Patient_social_number='"+guna2HtmlLabel8.Text+"' ",con);
                SqlDataReader read = insert.ExecuteReader();
                while (read.Read())
                {
                    string patient_name = read[2].ToString();
                    string patient_surname = read[3].ToString();                  
                    global_name = patient_name;
                    global_surname= patient_surname;
                }
                read.Close();
                con.Close();
            }
            else
            {
                string global_id;
                string data = guna2HtmlLabel4.Text.ToString();

                string[] test = data.Split(':');

                if (test.Length >= 2)
                {
                    string id = test[1].Trim();
                    global_id = id;
                    con.Open();
                    SqlCommand insert = new SqlCommand("select * from Doctor_appointment where Patient_social_number='" + global_id + "' ", con);
                    SqlDataReader read = insert.ExecuteReader();
                    while (read.Read())
                    {
                        string doctor_name = read[2].ToString();
                        string doctor_surname = read[3].ToString();
                        global_name = doctor_name;
                        global_surname = doctor_surname;
                    }
                    read.Close();
                    con.Close();
                }
            }

            con.Open();
            SqlCommand doctor = new SqlCommand("select * from Doctor_Register where E_mail='"+Variables.id+"' ",con);
            SqlDataReader read_doctor = doctor.ExecuteReader();
            while (read_doctor.Read())
            {
                string doctor_name = read_doctor[1].ToString();
                string doctor_surname = read_doctor[2].ToString();
                string doctor_section = read_doctor[7].ToString();
                global_doctorname = doctor_name;
                global_doctorsurname = doctor_surname;
                global_doctorsection = doctor_section;
            }
            read_doctor.Close();
            con.Close();
        }
        //--------------------------------------------//
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text != null && richTextBox3.Text != null)
            {
                patient();
                add_treated_patient();

                if (Variables.patient_id == null)
                {
                    delete();
                }
                else
                {
                    con.Open();
                    SqlCommand delete_patient = new SqlCommand("delete from Test where patient_id='" + Variables.patient_id + "' ", con);
                    delete_patient.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Succesfully");
                    dataGridView1.Show();
                    con.Open();
                    SqlCommand delete_patient2 = new SqlCommand("delete from Doctor_Appointment where ID='" + Variables.patient_id + "' ", con);
                    delete_patient2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Succesfully");
                    dataGridView1.Show();
                }
            }
            else
            {
                MessageBox.Show("Diagnosis and prescriptions cannot be empty");
            }                  
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            guna2Button3.Hide();
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Main_Window frm = new Main_Window();
            frm.Show();
            this.Hide();
        }
    }
}
