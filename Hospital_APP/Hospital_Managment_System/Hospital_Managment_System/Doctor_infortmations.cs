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
    public partial class Doctor_infortmations : Form
    {
        public Doctor_infortmations()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void Doctor_infortmations_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            DataTable refresh = Doctor_information_refresh.Doctors_information();
            dataGridView1.DataSource = refresh;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int maxcharacter = 300;
            if (richTextBox1_request.Text.Length > maxcharacter)
            {
                richTextBox1_request.Text = richTextBox1_request.Text.Substring(0, maxcharacter);
                richTextBox1_request.SelectionStart = maxcharacter;
            }
            int remaining_character;
            remaining_character = maxcharacter - richTextBox1_request.Text.Length;
            guna2HtmlLabel5.Text = remaining_character.ToString();
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Reception_window frm = new Reception_window();
            frm.Show();
            this.Hide();
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string off_day = null;
            if (combobox_offdays.SelectedItem != null)
            {
                off_day = combobox_offdays.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(txtbox_offdays.Text))
                {
                    txtbox_offdays.Text += off_day;
                }
                else
                {
                    txtbox_offdays.Text += " + " + off_day;
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            txtbox_offdays.Clear();
            combobox_offdays.SelectedItem = null;
        }

        private void txtbox_workinetime_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            txtbox_wt_start.MaxLength = 5;
            if (txtbox_wt_start.Text.Length == 2)
            {
                txtbox_wt_start.Text = txtbox_wt_start.Text.Substring(0, 2) + ".";
                txtbox_wt_start.SelectionStart = txtbox_wt_start.Text.Length;
            }
        }

        private void txtbox_wt_end_TextChanged(object sender, EventArgs e)
        {
            txtbox_wt_end.MaxLength = 5;
            if (txtbox_wt_end.Text.Length == 2)
            {
                txtbox_wt_end.Text = txtbox_wt_end.Text.Substring(0, 2) + ".";
                txtbox_wt_end.SelectionStart = txtbox_wt_end.Text.Length;
            }
        }

        private void txtbox_ft_start_TextChanged(object sender, EventArgs e)
        {
            txtbox_ft_start.MaxLength = 5;
            if (txtbox_ft_start.Text.Length == 2)
            {
                txtbox_ft_start.Text = txtbox_ft_start.Text.Substring(0, 2) + ".";
                txtbox_ft_start.SelectionStart = txtbox_ft_start.Text.Length;
            }
        }

        private void txtbox_ft_end_TextChanged(object sender, EventArgs e)
        {
            txtbox_ft_end.MaxLength = 5;
            if (txtbox_ft_end.Text.Length == 2)
            {
                txtbox_ft_end.Text = txtbox_ft_end.Text.Substring(0, 2) + ".";
                txtbox_ft_end.SelectionStart = txtbox_ft_end.Text.Length;
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtbox_search.Text !="")
            {
                string free_time = txtbox_ft_start.Text + " - " + txtbox_ft_end.Text;
                string working_time = txtbox_wt_start.Text + " - " + txtbox_wt_end.Text;
                con.Open();
                if (txtbox_wt_start.Text != "" && txtbox_wt_end.Text != "")
                {
                    Doctor_informations.Set_doctor_worktime(working_time,txtbox_search.Text);
                    refresh();
                }
                if (txtbox_ft_start.Text != "" && txtbox_ft_end.Text != "")
                {
                    Doctor_informations.Set_doctor_freetime(free_time,txtbox_search.Text);
                    refresh();
                }
                if (richTextBox1_request.Text != "")
                {
                    Doctor_informations.Set_doctor_request(richTextBox1_request.Text,txtbox_search.Text);
                    refresh();
                }
                if (txtbox_offdays.Text != "")
                {
                    Doctor_informations.Set_doctor_offdays(combobox_offdays.Text,txtbox_search.Text);
                    refresh();
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Write the ID number of the doctor you will update.");
            }
        }

        private void txtbox_search_doctor_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand doctor_search = new SqlCommand("select * from Doctor_informations where Doctor_Fullname like'%" +txtbox_search_doctor.Text+ "%' ",con);           
            DataTable dt = new DataTable();
            SqlDataReader reader = doctor_search.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();        
        }
    }
}
