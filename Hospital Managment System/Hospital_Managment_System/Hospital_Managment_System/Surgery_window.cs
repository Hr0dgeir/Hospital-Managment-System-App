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
    public partial class Surgery_window : Form
    {
        public Surgery_window()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public static List<string> dates { get; set; } = new List<string>();
        //public static List<string> rooms { get; set; } = new List<string>();
        public static List<string> date_and_room = new List<string>();
        public static List<string> surgery_date { get; set; } = new List<string>();
        public static List<string> surgery_room { get; set; } = new List<string>();


        string Today_date;
        private void Surgery_window_Load(object sender, EventArgs e)
        {
            string today_date = datetimepicker_date.Text;
            if (datetimepicker_date.Text == today_date)
            {
                combobox_room.Enabled = false;
            }

            con.Open();
            SqlCommand room_date = new SqlCommand("select Date , Room from Surgery",con);
            SqlDataReader read = room_date.ExecuteReader();
            date_and_room = new List<string>();
            while (read.Read())
            {
                string date = read[0].ToString();
                string room = read[1].ToString();
                date_and_room.Add(date + "-" + room);
            }
            con.Close();

            foreach (var item in date_and_room)
            {
                string[] parts = item.Split('-');

                surgery_date.Add(parts[0].ToString());
                surgery_room.Add(parts[1].ToString());
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (check_date_room() == true)
            {
                if (txtbox_Patient_fullname.Text != null && txtbox_Patient_fullname.Text != null && combobox_gender.Text != null && combobox_room.Text != null && combobox_surgerytype.Text != null && richTextBox1_medicine.Text != null && richTextBox2_relatives.Text != null)
                {
                    if (txtbox_Patient_fullname.Text != null)
                    {
                        if (txtbox_socail_number.Text != null)
                        {
                            if (combobox_gender.Text != null)
                            {
                                if (combobox_room.Text != null)
                                {
                                    if (combobox_surgerytype.Text != null)
                                    {
                                        if (richTextBox1_medicine.Text != null)
                                        {
                                            if (richTextBox2_relatives.Text != null)
                                            {
                                                con.Open();
                                                SqlCommand insert = new SqlCommand("insert into Surgery (Patient_Fullname,Patient_gender,Type_of_surgery,Date,Room,Medicines_to_be_used,Patient_relatieves_informations,Patient_Socialnumber,Doctor_Fullname,Doctor_Email) values (@fullname,@gender,@surgery,@date,@room,@medicine,@relatieves,@socialnumber,@d_fullname,@d_email)", con);
                                                insert.Parameters.AddWithValue("@fullname", txtbox_Patient_fullname.Text);
                                                insert.Parameters.AddWithValue("@gender", combobox_gender.Text);
                                                insert.Parameters.AddWithValue("@surgery", combobox_surgerytype.Text);
                                                insert.Parameters.AddWithValue("@date", datetimepicker_date.Text);
                                                insert.Parameters.AddWithValue("@room", combobox_room.Text);
                                                insert.Parameters.AddWithValue("@medicine", richTextBox1_medicine.Text);
                                                insert.Parameters.AddWithValue("@relatieves", richTextBox2_relatives.Text);
                                                insert.Parameters.AddWithValue("@socialnumber", txtbox_socail_number.Text);
                                                insert.Parameters.AddWithValue("@d_fullname", Variables.name + " " + Variables.surname);
                                                insert.Parameters.AddWithValue("@d_email", Variables.id);
                                                insert.ExecuteNonQuery();
                                                con.Close();
                                                txtbox_Patient_fullname.Text = null;
                                                txtbox_socail_number.Text = null;
                                                datetimepicker_date.Value = DateTime.Now;
                                                combobox_gender.Text = null;
                                                combobox_room.Text = null;
                                                combobox_surgerytype.Text = null;
                                                richTextBox1_medicine.Text = null;
                                                richTextBox2_relatives.Text = null;
                                                MessageBox.Show("Succesfully Added");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please fill relatives area");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please fill medicine Area");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Select Surgerytype");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Select Surgery room");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Select Patient Gender");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Fill Patient Name");
                        }
                    }            
                }
                else
                {
                    MessageBox.Show("Please Fill Patient Name");
                }                             
            }
        }

        public bool check_date_room()
        {
            //string data = date_and_room.ToString();
            //string[] test = data.Split('-');

            ////if (test.Length >= 0)
            ////{
            ////    string date = test[0].Trim();
            ////    string room = test[1].Trim();
            ////}

            string selected_room = combobox_room.Text;
            string selected_date = datetimepicker_date.Text;
            string full = selected_date + "-" + selected_room;

            if (date_and_room.Contains(full))
            {
                MessageBox.Show("This date and room is full");
                return false;
            }
            return true;
        }

        private void datetimepicker_date_ValueChanged(object sender, EventArgs e)
        {          
            string selectedDate = datetimepicker_date.Text;

            combobox_room.Items.Clear();

            for (int i = 1; i <= 6; i++)
            {
                combobox_room.Items.Add(i.ToString());
            }

            if (datetimepicker_date.Text != Today_date)
            {
                combobox_room.Enabled = true;
            }

           


            List<string> matchingRooms = date_and_room
                .Where(item => item.StartsWith(selectedDate))
                .ToList();

            if (matchingRooms.Count > 0)
            {
                foreach (string matchingRoom in matchingRooms)
                {
                    MessageBox.Show(matchingRoom);

                    string[] roomData = matchingRoom.Split('-');

                    foreach (string roomNumber in roomData)
                    {
                        combobox_room.Items.Remove(roomNumber.Trim());
                    }
                }
            }
            //selectedDate = null;
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Main_Window frm = new Main_Window();
            frm.Show();
            this.Hide();
            date_and_room = null;
        }

        private void txtbox_socail_number_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_socail_number.Text.Length == 3 || txtbox_socail_number.Text.Length == 6)
            {
                txtbox_socail_number.Text += "-";
                txtbox_socail_number.SelectionStart = txtbox_socail_number.Text.Length;
            }
            string input = txtbox_socail_number.Text;

            string cleanInput = new string(input.Where(c => char.IsDigit(c) || c == '-' || c == '\b').ToArray());

            txtbox_socail_number.Text = cleanInput;

            txtbox_socail_number.SelectionStart = txtbox_socail_number.Text.Length;
        }

        private void Surgery_window_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void Surgery_window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
            date_and_room.Clear();
            surgery_date.Clear();
            surgery_room.Clear();
        }
    }
}
