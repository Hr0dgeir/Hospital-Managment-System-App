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
    public partial class Add_patient : Form
    {
        public Add_patient()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            check_social_number();
            if (Combobox_doctor.SelectedItem != null)
            {
                string data = Combobox_doctor.SelectedItem.ToString();
                
                string[] test = data.Split(':');

                if (test.Length >= 2)
                {
                    string first_part = test[0];
                    string second_part = test[1];
                    global_dmail = second_part;
                    global_dfullname = first_part;
                }
            }

            if (txtbox_id.Text != null)
            {
                if (ID_list.Contains(txtbox_id.Text))
                {
                    if (txtbox_name.Text != null)
                    {
                        if (txtbox_surname.Text != null)
                        {
                            if (txtbox_phone.Text == null && txtbox_phone.Text.Length != 12)
                            {
                                MessageBox.Show("Check phone number please");
                            }
                            else
                            {
                                if (txtbox_socialnumber.Text == null && txtbox_socialnumber.Text.Length != 11)
                                {
                                    MessageBox.Show("Please Check your social number");
                                }
                                else
                                {
                                    if (combobox_blood.Text != null)
                                    {
                                        if (Combobox_doctor.Text != null)
                                        {
                                            if (Combobox_section.Text != null)
                                            {
                                                Patient_operations.update(txtbox_name.Text, txtbox_surname.Text, txtbox_socialnumber.Text, Convert.ToInt32(txtbox_id.Text), guna2DateTimePicker1.Text, Combobox_section.Text, txtbox_phone.Text, combobox_blood.Text, global_dfullname, global_dmail);
                                                refresh();
                                                txtbox_search_number.Text = null;
                                                clear();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please Check Section");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Check Doctor");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Check blood type");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Surname Cannot be Empty");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Name cannot be empty");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check id");
                }
            }
            else
            {
                MessageBox.Show("ID textbox cannot be empty when updating");
            }
        }

        private void Add_patient_Load(object sender, EventArgs e)
        {
            refresh();
            check_id();
        }

        public void refresh()
        {
            DataTable dt = Patient_refresh.refresh();
            Data_grid.DataSource = dt;
        }

        public void doctor_update()
        {
            con.Open();
            SqlCommand get_doctor = new SqlCommand("select * from Doctor_Register where Section like'%"+Combobox_section.SelectedItem +"%'",con);
            SqlDataReader reader = get_doctor.ExecuteReader();
            while (reader.Read())
            {
                string full_name;
                string name = reader[1].ToString();
                string surname = reader[2].ToString();
                string email = reader[6].ToString();
                full_name = name+ " "+ surname;
                Combobox_doctor.Items.Add(full_name + ":"+email);               
            }        
            con.Close();
        }
        string global_dmail;
        string global_dfullname;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtbox_name.Text != null && txtbox_surname.Text != null && txtbox_name.Text != txtbox_surname.Text)
            {
                if (txtbox_phone.Text != null && txtbox_phone.Text.Length == 12)
                {
                    if (txtbox_socialnumber.Text != null && txtbox_socialnumber.Text.Length == 11)
                    {
                        if (Combobox_doctor.Text != null)
                        {
                            if (Combobox_section.Text != null)
                            {
                                if (combobox_blood.Text != null)
                                {
                                    if (guna2DateTimePicker1.Text != null)
                                    {
                                        Patient_operations.add(txtbox_name.Text,txtbox_surname.Text,txtbox_socialnumber.Text,global_dfullname,Combobox_section.Text,combobox_blood.Text,txtbox_phone.Text,global_dmail,guna2DateTimePicker1.Text);
                                        refresh();
                                        txtbox_name.Text = null;
                                        txtbox_surname.Text = null;
                                        txtbox_phone.Text = null;
                                        txtbox_socialnumber.Text = null;
                                        combobox_blood.Text = null;
                                        Combobox_doctor.Text = null;
                                        Combobox_section.Text = null;
                                        guna2DateTimePicker1.Value = DateTime.Now;
                                        clear();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Date incorrect");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please select patient blood");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select a section");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a doctor");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Check Social Security Number");
                    }
                }
                else
                {
                    MessageBox.Show("Please check Areas");
                }
            }
            else
            {
                MessageBox.Show("Please Check Name and Surname");
            }
        }

        private void Combobox_section_SelectedIndexChanged(object sender, EventArgs e)
        {          
            Combobox_doctor.Items.Clear();
            doctor_update();
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Reception_window frm = new Reception_window();
            frm.Show();
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand search = new SqlCommand("select * from Doctor_Appointment where Patient_social_number like'%" + txtbox_search_number.Text + "%' ", con);
            DataTable dt = new DataTable();
            SqlDataReader dr = search.ExecuteReader();
            dt.Load(dr);
            con.Close();
            Data_grid.DataSource = dt;
        }
        public static List<string> ID_list = new List<string>();
        public void check_id()
        {
            con.Open();
            SqlCommand id = new SqlCommand("select ID from Doctor_Appointment", con);
            SqlDataReader read = id.ExecuteReader();
            while (read.Read())
            {
                string ID = read[0].ToString();
                ID_list.Add(ID);
            }
            con.Close();
        }

        private void btn_patient_delete_Click(object sender, EventArgs e)
        {
            if (txtbox_id.Text != null)
            {
                if (ID_list.Contains(txtbox_id.Text))
                {
                    Patient_operations.delete(txtbox_id.Text);
                    refresh();
                    txtbox_search_number.Text = null;
                    clear();
                }
                else
                {
                    MessageBox.Show("Please check id");
                }
            }
            else
            {
                MessageBox.Show("Please fill ID area");
            }
        }
        private void Combobox_doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = Combobox_doctor.SelectedItem.ToString();

            string[] test = data.Split(':');

            if (test.Length >= 2)
            {
                string first_part = test[0];
                string second_part = test[1];
                global_dmail = second_part;
                global_dfullname = first_part;
            }
        }

        private void txtbox_socialnumber_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_socialnumber.Text.Length == 3 || txtbox_socialnumber.Text.Length == 6)
            {
                txtbox_socialnumber.Text += "-";
                txtbox_socialnumber.SelectionStart = txtbox_socialnumber.Text.Length;
            }
            string input = txtbox_socialnumber.Text;

            string cleanInput = new string(input.Where(c => char.IsDigit(c) || c == '-' || c == '\b').ToArray());

            txtbox_socialnumber.Text = cleanInput;

            txtbox_socialnumber.SelectionStart = txtbox_socialnumber.Text.Length;
        }

        private void txtbox_phone_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_phone.Text.Length == 3 || txtbox_phone.Text.Length == 7)
            {
                txtbox_phone.Text += "-";
                txtbox_phone.SelectionStart = txtbox_phone.Text.Length;
            }
            string input = txtbox_phone.Text;

            string cleanInput = new string(input.Where(c => char.IsDigit(c) || c == '-' || c == '\b').ToArray());

            txtbox_phone.Text = cleanInput;

            txtbox_phone.SelectionStart = txtbox_phone.Text.Length;
        }
        private void Data_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Data_grid.SelectedCells.Count > 2)
            {
                int selectedrowindex = Data_grid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = Data_grid.Rows[selectedrowindex];

                string patient_id = selectedrow.Cells[0].Value.ToString();
                string doctor = selectedrow.Cells[1].Value.ToString();
                string name = selectedrow.Cells[2].Value.ToString();
                string surname = selectedrow.Cells[3].Value.ToString();
                string social_number = selectedrow.Cells[4].Value.ToString();
                string section = selectedrow.Cells[5].Value.ToString();
                string blood = selectedrow.Cells[6].Value.ToString();
                string phone = selectedrow.Cells[7].Value.ToString();
                string mail = selectedrow.Cells[8].Value.ToString();
                string date = selectedrow.Cells[9].Value.ToString();

                txtbox_id.Text = patient_id;
                txtbox_name.Text = name;
                txtbox_surname.Text = surname;
                txtbox_socialnumber.Text = social_number;
                txtbox_phone.Text = phone;
                Combobox_section.Text = section;
                guna2DateTimePicker1.Text = date;
                combobox_blood.SelectedItem = blood;
                Combobox_doctor.SelectedItem = doctor +":"+ mail;
            }
        }

        private void txtbox_id_TextChanged(object sender, EventArgs e)
        {
            string input = txtbox_id.Text;

            string cleanInput = new string(input.Where(c => char.IsDigit(c) || c == '-' || c == '\b').ToArray());

            txtbox_id.Text = cleanInput;

            txtbox_id.SelectionStart = txtbox_id.Text.Length;
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            txtbox_id.Clear();
            txtbox_name.Clear();
            txtbox_phone.Clear();
            txtbox_socialnumber.Clear();
            txtbox_surname.Clear();
            combobox_blood.Text = null;
            Combobox_doctor.Text = null;
            Combobox_section.Text = null;

            if (txtbox_search_number.Text != null)
            {
                txtbox_search_number.Clear();
            }
            guna2DateTimePicker1.Value = DateTime.Now;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        public static List<string> social_security_list = new List<string>();
        public void check_social_number()
        {
            con.Open();
            SqlCommand numbers = new SqlCommand("select Patient_social_number from Doctor_Appointment",con);
            SqlDataReader read = numbers.ExecuteReader();
            while (read.Read())
            {
                string security_numbers = read[0].ToString();
                social_security_list.Add(security_numbers);
            }
            con.Close();
        }
    }
}
