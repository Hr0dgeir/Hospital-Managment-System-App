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
    public partial class Form1 : Form
    {
        Main_Window main_window;
        Reception_window reception_window;
        public string Veri { get; set; }
        
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public string data;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtbox_e_mail.Text.ToLower();
            if (txtbox_e_mail.Text != "" && txtbox_Password.Text != "")
            {
                if (txtbox_Password.Text.Length <= 4)
                {
                    MessageBox.Show("Your password cannot be less than 4 character");
                }
                else
                {
                    if (txtbox_e_mail.Text.Contains("@gmail.com") || txtbox_e_mail.Text.Contains("@hotmail.com") || txtbox_e_mail.Text.Contains("@windowslive.com"))
                    {
                        if (check_acc_list.Contains(txtbox_e_mail.Text))
                        {
                            Variables.id = txtbox_e_mail.Text;
                            Login.login(txtbox_Password.Text, txtbox_e_mail.Text, txtbox_Password.Text);
                            if (Variables.safe == true)
                            {
                                Worker.check(txtbox_e_mail.Text);
                                this.Hide();
                            }
                            else
                            {
                                
                            }
                            Variables.safe = false;
                        }
                        else
                        {
                            MessageBox.Show("There is no such account");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your E-mail incorrect");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all required areas");
            }
        }
        public static List<string> check_acc_list { get; set; } = new List<string>();
        public void check_acc()
        {
            con.Open();
            SqlCommand check = new SqlCommand("select E_mail from Doctor_Register",con);
            SqlDataReader read = check.ExecuteReader();
            while (read.Read())
            {
                string mail = read[0].ToString();
                check_acc_list.Add(mail);
            }
            con.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register frm = new Register();
            frm.Show();
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            check_acc();
            txtbox_Password.UseSystemPasswordChar = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Btn_Login_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Btn_Login_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtbox_Password.UseSystemPasswordChar = false;
            }
            else
            {
                txtbox_Password.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password_Forget frm = new Password_Forget();
            frm.ShowDialog();
        }

        private void txtbox_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
