using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void Btn_register_Click(object sender, EventArgs e)
        {
            check_social_number();
            txt_box_email.Text.ToLower();
            if (txtbox_name.Text != "" && txtbox_surname.Text != "" && txt_box_email.Text !="" && txtbox_phone.Text != "" && txtbox_Password.Text != "" && combobox_area.Text != "" && combobox_section.Text != null)
            {
                if (txtbox_Password.Text.Length <= 4)
                {
                    MessageBox.Show("Your password to weak");
                }
                else
                {
                    if (txt_box_email.Text.Contains("@gmail.com") || txt_box_email.Text.Contains("@hotmail.com") || txt_box_email.Text.Contains("@windowslive.com"))
                    {
                        if (txtbox_Password.Text == txtbox_password2.Text)
                        {
                            if (registered_mail_list.Contains(txt_box_email.Text.ToLower()))
                            {
                                MessageBox.Show("This mail aldready used");
                            }
                            else
                            {
                                if (phone_number_list.Contains(txtbox_phone.Text))
                                {
                                    MessageBox.Show("This phone number already used");
                                }
                                else
                                {
                                    if (security_number_list.Contains(txt_social_number.Text))
                                    {
                                        MessageBox.Show("This Social Security number already using");
                                    }
                                    else
                                    {
                                        if (txtbox_phone.Text.Length == 12 && txt_social_number.Text.Length == 11)
                                        {
                                            Add.add_doctor(txtbox_name.Text, txtbox_surname.Text, combobox_area.Text, txtbox_phone.Text, txtbox_Password.Text, txt_box_email.Text, txtbox_Password.Text, combobox_section.Text, txt_social_number.Text);
                                            Add.doctor_information(txtbox_name.Text, txtbox_surname.Text, combobox_section.Text);

                                            txtbox_name.Clear();
                                            txtbox_surname.Clear();
                                            txtbox_Password.Clear();
                                            txtbox_phone.Clear();
                                            txt_box_email.Clear();

                                            MessageBox.Show("Succesfully");
                                            Form1 frm = new Form1();
                                            frm.Show();
                                            this.Hide();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please check your phone number and social security number");
                                        }
                                    }
                                }                               
                            }                           
                        }
                        else
                        {
                            MessageBox.Show("Please Check your password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your mail must be gmail,hotmail or windowslive");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill all required areas");
            }
        }
      

        public static void add_doctor()
        {

        }
        public static List<string> security_number_list = new List<string>();
        public void check_social_number()
        {
            con.Open();
            SqlCommand check = new SqlCommand("select Social_security_number from Doctor_Register",con);
            SqlDataReader read = check.ExecuteReader();
            while (read.Read())
            {
                string numbers = read[0].ToString();
                security_number_list.Add(numbers);
            }
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        private void Register_Load(object sender, EventArgs e)
        {
            txtbox_Password.UseSystemPasswordChar = true;
            txtbox_password2.UseSystemPasswordChar = true;
            combobox_section.Enabled = false;
            progresbar_red.Hide();
            progresbar_yellow.Hide();
            progresbar_green.Hide();
            registered_mails();
            registered_phone_number();
        }
        public static List<string> registered_mail_list { get; set; } = new List<string>();
        public void registered_mails()
        {
            con.Open();
            SqlCommand mails = new SqlCommand("select E_mail from Doctor_Register",con);
            SqlDataReader read = mails.ExecuteReader();
            while (read.Read())
            {
                string mail = read[0].ToString();
                registered_mail_list.Add(mail);
            }
            con.Close();
        }
        public static List<string> phone_number_list { get; set; } = new List<string>();
        public void registered_phone_number()
        {
            con.Open();
            SqlCommand numbers = new SqlCommand("select Phone_number from Doctor_Register",con);
            SqlDataReader read = numbers.ExecuteReader();
            while (read.Read())
            {
                string number = read[0].ToString();
                phone_number_list.Add(number);
            }
            con.Close();    
        }

        private void combobox_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_area.Text == "Doctor")
            {
                combobox_section.Enabled = true;
            }
            else
            {
                combobox_section.Enabled=false;
            }
        }

        private void txtbox_Password_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_Password.Text == null || txtbox_Password.Text == "" || txtbox_Password.Text == " ")
            {
                progresbar_red.Hide();
                progresbar_yellow.Hide();
                progresbar_green.Hide();
                progresbar_red.FillColor = Color.White;
                progresbar_yellow.FillColor = Color.White;
                progresbar_green.FillColor = Color.White;
            }
            else
            {
                progresbar_red.Show();
                progresbar_yellow.Show();
                progresbar_green.Show();
            }

            if (txtbox_Password.Text.Length >= 4 )
            {
                progresbar_red.FillColor = Color.Green;
            }
            else
            {
                progresbar_red.FillColor = Color.White;
            }

            if (txtbox_Password.Text.Length >= 8)
            {
                progresbar_yellow.FillColor = Color.Green;
            }
            else
            {
                progresbar_yellow.FillColor = Color.White;
            }

            if (txtbox_Password.Text.Length >= 5 && Anycapitalcharacter(txtbox_Password.Text))
            {
                progresbar_red.FillColor= Color.Green;
                progresbar_yellow.FillColor = Color.Green;
            }

            if (txtbox_Password.Text.Length >= 7 && ContainsSpecialCharacters(txtbox_Password.Text))
            {
                if (progresbar_yellow.FillColor == Color.Green)
                {
                    progresbar_green.FillColor = Color.Green;
                }
                if (progresbar_yellow.FillColor != Color.Green)
                {
                    progresbar_yellow.FillColor = Color.Green;
                }
            }
            else
            {
                progresbar_green.FillColor = Color.White;
            }

            if (containsanynumber(txtbox_Password.Text) && txtbox_Password.Text.Length >= 7)
            {
                progresbar_yellow.FillColor = Color.Green;
            }
        }

        //static char[] GetAlfabeninBuyukHarfleri()
        //{
        //    char[] capital_letters = new char[26];
        //    for (int i = 0; i < 26; i++)
        //    {
        //        capital_letters[i] = (char)('A' + i);
        //    }

        //    return capital_letters;
        //}

        static bool Anycapitalcharacter(string text)
        {
            foreach (char character in text)
            {
                if (char.IsUpper(character))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ContainsSpecialCharacters(string text)
        {
            char[] specialCharacters = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '[', ']', '{', '}', ';', ':', '\'', '"', '<', '>', ',', '.', '/', '?' };

            return text.Any(c => specialCharacters.Contains(c));
        }

        public bool containsanynumber(string text)
        {
            char[] numbers = {'1','2','3','4','5','6','7','8','9','0'};

            return text.Any(c => numbers.Contains(c));
        }

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtbox_Password.UseSystemPasswordChar = false;
                txtbox_password2.UseSystemPasswordChar = false;
            }
            else
            {
                txtbox_Password.UseSystemPasswordChar = true;
                txtbox_password2.UseSystemPasswordChar = true;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txt_social_number.Text.Length == 3 || txt_social_number.Text.Length == 6)
            {
                txt_social_number.Text += "-";
                txt_social_number.SelectionStart = txt_social_number.Text.Length;
            }
            string input = txt_social_number.Text;

            string cleanInput = new string(input.Where(c => char.IsDigit(c) || c == '-' || c == '\b').ToArray());

            txt_social_number.Text = cleanInput;

            txt_social_number.SelectionStart = txt_social_number.Text.Length;
        }
    }
}
