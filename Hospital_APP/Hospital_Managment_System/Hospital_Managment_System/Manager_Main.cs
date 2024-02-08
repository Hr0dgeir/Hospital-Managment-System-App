using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public partial class Manager_Main : Form
    {
        public Manager_Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            User_settings frm = new User_settings();
            frm.ShowDialog();
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            View_doctors_manager frm = new View_doctors_manager();
            frm.Show();
            this.Hide();
        }

        private void btn_Message_send_Click(object sender, EventArgs e)
        {
            Chat frm = new Chat();
            frm.ShowDialog();
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

                SqlCommand picture_add = new SqlCommand("update Doctor_Register set Picture=@picture where E_mail='" + Variables.id + "' ", con);
                picture_add.Parameters.AddWithValue("@picture", picture);
                con.Open();
                picture_add.ExecuteNonQuery();
                MessageBox.Show("succesfully");
                con.Close();
            }
        }

        private void Manager_Main_Load(object sender, EventArgs e)
        {
            check_messages();
            
            try
            {
                con.Open();
                SqlCommand picture_retrieve = new SqlCommand("select Picture from Doctor_Register where E_mail='" + Variables.id + "'", con);
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
                con.Close();
            }
            catch
            {

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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Manager_patient_requests frm = new Manager_patient_requests();
            frm.ShowDialog();
        }
    }
}
