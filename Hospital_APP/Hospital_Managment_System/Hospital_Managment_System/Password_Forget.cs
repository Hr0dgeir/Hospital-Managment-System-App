using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Hospital_Managment_System
{
    public partial class Password_Forget : Form
    {
        public Password_Forget()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Password_Forget_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Hide();
            guna2HtmlLabel3.Hide();
            txtbox_code.Hide();
            guna2TextBox1.Hide();
            guna2Button2.Hide();
            
        }
        string global_code;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            check_mail();
            if (mail_list.Contains(txtbox_mail.Text))
            {
                if (txtbox_mail.Text.Contains("gmail.com") || txtbox_mail.Text.Contains("hotmail.com") || txtbox_mail.Text.Contains("outlook.com"))
                {
                    guna2HtmlLabel2.Show();
                    guna2HtmlLabel3.Show();
                    txtbox_code.Show();
                    guna2Button1.Hide();
                    guna2HtmlLabel1.Hide();
                    txtbox_mail.Hide();
                    Random code = new Random();
                    int password_code = code.Next(0, 1000000);
                    user_mail = txtbox_mail.Text;
                    global_code = password_code.ToString();

                    try
                    {
                        string fromAddress = "enter your mail here";
                        string toAddress = txtbox_mail.Text;
                        string subject = "Password Forget";
                        string body = global_code;

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new NetworkCredential("enter your mail here", "enter your code here");
                        smtpClient.EnableSsl = true;

                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(fromAddress);
                        mailMessage.To.Add(toAddress);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;

                        smtpClient.Send(mailMessage);

                        MessageBox.Show("Please Check Your Email");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error: " + ex.Message);
                    }
                    //MessageBox.Show(global_code);
                }
                else
                {
                    MessageBox.Show("Your mail must be gmail hotmail or outlook");
                }
            }
            else
            {
                MessageBox.Show("Please Check your mail");
            }           
        }
        string global_hashed_password;
        string user_mail;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        public void get_password()
        {
            con.Open();
            SqlCommand password = new SqlCommand("select Password from Doctor_Register where E_mail = '"+txtbox_mail.Text+"' ",con);
            SqlDataReader read = password.ExecuteReader();
            while (read.Read())
            {
                string hashed_password = read[0].ToString();
                global_hashed_password = hashed_password;
            }
            con.Close();
            
            MessageBox.Show(global_hashed_password);        

        }
        private void txtbox_code_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_code.Text == global_code)
            {
                guna2TextBox1.Show();
                guna2HtmlLabel2.Hide();
                guna2HtmlLabel3.Hide();
                txtbox_code.Hide();
                guna2Button2.Hide();
                guna2Button2.Show();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        public static List<string> mail_list { get; set; } = new List<string>();
        public void check_mail()
        {
            con.Open();
            SqlCommand mails = new SqlCommand("select E_mail from Doctor_Register",con);
            SqlDataReader read = mails.ExecuteReader();
            while (read.Read())
            {
                string mail = read[0].ToString();
                mail_list.Add(mail);
            }
            con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand new_password = new SqlCommand("update Doctor_Register Set Password=@pass where E_mail = '" + user_mail + "' ", con);
            string hashed_password = Sha256convertor.sha256hash_(guna2TextBox1.Text);
            new_password.Parameters.AddWithValue("@pass", hashed_password);
            new_password.ExecuteNonQuery();
            MessageBox.Show("Succesfully");
            con.Close();
        }
    }  
}
