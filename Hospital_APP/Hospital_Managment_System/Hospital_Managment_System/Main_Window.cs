﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public partial class Main_Window : Form
    {
        public Main_Window()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void Main_Window_Load(object sender, EventArgs e)
        {
            check_messages();
            con.Open();
            string name;
            string surname;
            string department;
            string id;
            SqlCommand cmd = new SqlCommand("select * from Doctor_Register where E_Mail like '%" + Variables.id + "%'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader[0].ToString();
                name = reader[1].ToString();
                surname = reader[2].ToString();
                department = reader[3].ToString();
                label1.Text = name + " " + surname;
                label2.Text = department;
                global_id = id;
            }
            con.Close();
            
            try
            {
                con.Open();
                SqlCommand picture_retrieve = new SqlCommand("select Picture from Doctor_Register where ID='" + global_id + "'", con);
                byte[] pictureData = (byte[])picture_retrieve.ExecuteScalar();
                if (pictureData != null)
                {
                    using (MemoryStream ms = new MemoryStream(pictureData))
                    {
                        Image retrievedImage = Image.FromStream(ms);

                        guna2CirclePictureBox1.Image = retrievedImage;
                        guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {

                }
                con.Close();
            }
            catch
            {

            }
        }
        string global_id;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please Sellect your picture";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox1.Image = null;
                string dosya_yolu = ofd.FileName;
                guna2CirclePictureBox1.Image = Image.FromFile(dosya_yolu);
                guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] picture = br.ReadBytes((int)fs.Length);
                br.Close();

                SqlCommand picture_add = new SqlCommand("update Doctor_Register set Picture=@picture where ID='" + global_id + "' ", con);
                picture_add.Parameters.AddWithValue("@picture", picture);
                con.Open();
                picture_add.ExecuteNonQuery();
                MessageBox.Show("succesfully");
                con.Close();
            }
        }
        string global_fullname;
        public void check_messages()
        {
            con.Open();
            string receiver_name;
            string receiver_surname;
            string receiver_fullname;
            SqlCommand msg_check = new SqlCommand("select * from Doctor_Register where E_mail like'%" + Variables.id + "%' ", con);
            SqlDataReader rdr = msg_check.ExecuteReader();
            while (rdr.Read())
            {
                receiver_name = rdr[1].ToString();
                receiver_surname = rdr[2].ToString();
                receiver_fullname = receiver_name + " " + receiver_surname;
                global_fullname = receiver_fullname;
            }
            rdr.Close();
            SqlCommand msg = new SqlCommand("select Count(*) from Chat where Receiver_fullname like'%" + global_fullname + "%' ", con);
            int data = (int)msg.ExecuteScalar();
            label4.Text = data.ToString();
            con.Close();
        }

        private void btn_Message_send_Click(object sender, EventArgs e)
        {
            Chat frm = new Chat();
            frm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Doctor_Waiting_patients frm = new Doctor_Waiting_patients();
            frm.Show();
            this.Close();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Variables.id = null;
            Variables.patient_id = null;
            Variables.manager_doctormail = null;
            Variables.surname = null;
            Chat_operations.sender_surname_ = null;
            Chat_operations.surname_ = null;
            Chat_operations.area_ = null;
            Chat_operations.incoming_messages = null;
            Chat_operations.fullname_ = null;
            Chat_operations.sender_name_ = null;
            Chat_operations.sender_area_ = null;
            Chat_operations.sender_fullname_ = null;
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            View_diagnosis frm = new View_diagnosis();
            frm.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Doctor_appointments frm = new Doctor_appointments();
            frm.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            User_settings frm = new User_settings();
            frm.ShowDialog();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Past_appointments frm = new Past_appointments();
            frm.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Surgery_window frm = new Surgery_window();
            frm.Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            View_Doctor_Surgerys frm = new View_Doctor_Surgerys();
            frm.Show();
            this.Hide();
        }
    }
}
