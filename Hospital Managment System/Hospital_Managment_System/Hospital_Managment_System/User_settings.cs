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
    public partial class User_settings : Form
    {
        public User_settings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void User_settings_Load(object sender, EventArgs e)
        {
            phone_check();
            password_check();
            mail_check();
            txtbox_newpassword.UseSystemPasswordChar = true;
            txtbox_newpassword2.UseSystemPasswordChar = true;
            txtbox_oldpassword.UseSystemPasswordChar = true;
            con.Open();
            SqlCommand settings = new SqlCommand("select * from Doctor_Register where E_mail like '%" + Variables.id + "%' ", con);
            SqlDataReader rdr = settings.ExecuteReader();
            while (rdr.Read())
            {
                string phone_number = rdr[4].ToString();
                txtbox_phone.Text = phone_number;
                string email = rdr[6].ToString();
                txtbox_email.Text = email;
                string password = rdr[5].ToString();
                global_hashed_psswrd = password;
                global_phone = phone_number;
                global_mail = email;
            }
            con.Close();
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
                else
                {

                }
                con.Close();
            }
            catch
            {

            }
        }
        string global_hashed_psswrd;
        string global_mail;
        private void txtbox_oldpassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtbox_oldpassword.Text;
            string hashed_password = Sha256convertor.sha256hash_(password);
            if (hashed_password == global_hashed_psswrd)
            {
                txtbox_oldpassword.ForeColor = Color.Green;
            }
            else
            {
                txtbox_oldpassword.ForeColor = Color.Red;
            }
        }
        string global_password;
        public static List<string> mail_checklist { get; set; } = new List<string>();
        public void password_check()
        {
            con.Open();
            SqlCommand password = new SqlCommand("select Password from Doctor_Register where E_mail='" + Variables.id + "'", con);
            SqlDataReader read = password.ExecuteReader();
            while (read.Read())
            {
                string passwordcheck = read[0].ToString();
                global_password = passwordcheck;
            }
            con.Close();
        }
        public void mail_check()
        {
            con.Open();
            SqlCommand mail = new SqlCommand("select E_mail from Doctor_Register",con);
            SqlDataReader read = mail.ExecuteReader();
            while (read.Read())
            {
                string mailcheck = read[0].ToString();
                mail_checklist.Add(mailcheck);
            }
            con.Close();
        }
        public static List<string> phone_number_list { get; set; } = new List<string>();
        public void phone_check()
        {
            con.Open();
            SqlCommand phone = new SqlCommand("select Phone_number from Doctor_Register",con);
            SqlDataReader read = phone.ExecuteReader();
            while (read.Read())
            {
                string phone_numbers = read[0].ToString();
                phone_number_list.Add(phone_numbers);
            }
            con.Close();
        }

        bool quit = false;
        private void btn_update_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txtbox_newpassword.Text == txtbox_newpassword2.Text && txtbox_oldpassword.ForeColor == Color.Green)
            {
                string new_password1 = Sha256convertor.sha256hash_(txtbox_newpassword.Text);
                string new_password2 = Sha256convertor.sha256hash_(txtbox_newpassword2.Text);
                if (new_password1 == global_password && new_password2 == global_password)
                {
                    MessageBox.Show("Your password is the same as your previous password");
                    quit = false;
                }
                else
                {
                    string hashed_password = Sha256convertor.sha256hash_(txtbox_newpassword2.Text);
                    SqlCommand password = new SqlCommand("update Doctor_Register set Password='" + hashed_password + "' where E_mail like  '%" + Variables.id + "%'", con);
                    password.ExecuteNonQuery();
                    quit = true;
                }
            }
            if (global_phone != txtbox_phone.Text)
            {
                if (phone_number_list.Contains(txtbox_phone.Text))
                {
                    MessageBox.Show("This Phone number already using");
                    quit = false;
                }
                else
                {
                    SqlCommand password = new SqlCommand("update Doctor_Register set Phone_number='" + txtbox_phone.Text + "' where E_mail like  '%" + Variables.id + "%'", con);
                    password.ExecuteNonQuery();
                    quit = true;
                }
            }
            if (txtbox_email.Text != global_mail)
            {
                if (txtbox_email.Text.Contains("gmail.com") || txtbox_email.Text.Contains("hotmail.com") || txtbox_email.Text.Contains("outlook.com"))
                {
                    if (mail_checklist.Contains(txtbox_email.Text))
                    {
                        MessageBox.Show("This E-mail already using");
                        quit = false;
                    }
                    else
                    {
                        SqlCommand password = new SqlCommand("update Doctor_Register set E_mail='" + txtbox_email.Text + "' where E_mail like  '%" + Variables.id + "%'", con);
                        password.ExecuteNonQuery();
                        quit = true;
                    }
                }
                else
                {
                    MessageBox.Show("Your mail must be gmail , hotmail or outlook");
                }           
            }
            if (quit == false)
            {

            }
            else
            {
                con.Close();
                this.Close();
            }
            con.Close();
        }
        string global_phone;
        private void txtbox_phone_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_phone.Text.Length == 3 || txtbox_phone.Text.Length == 7)
            {
                txtbox_phone.Text += "-";
                txtbox_phone.SelectionStart = txtbox_phone.Text.Length;
            }

            string input = txtbox_phone.Text;

            string cleaninput = new string(input.Where(c => char.IsDigit(c) || c == '-' || c == '\b').ToArray());

            txtbox_phone.Text = cleaninput;

            txtbox_phone.SelectionStart = txtbox_phone.Text.Length;

            txtbox_phone.MaxLength = 12;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtbox_newpassword.UseSystemPasswordChar = false;
                txtbox_newpassword2.UseSystemPasswordChar = false;
                txtbox_oldpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtbox_newpassword.UseSystemPasswordChar = true;
                txtbox_newpassword2.UseSystemPasswordChar = true;
                txtbox_oldpassword.UseSystemPasswordChar = true;
            }
        }
    }
}
