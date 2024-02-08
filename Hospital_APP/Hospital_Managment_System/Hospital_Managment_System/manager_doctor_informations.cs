using Guna.UI2.WinForms;
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
    public partial class manager_doctor_informations : Form
    {
        public manager_doctor_informations()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void manager_doctor_informations_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from Doctor_Register where E_mail = '"+Variables.manager_doctormail+"' ",con);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                string name = read[1].ToString();
                string surname = read[2].ToString();
                string area = read[3].ToString();
                string number = read[4].ToString();
                string E_mail = read[6].ToString();
                string section = read[7].ToString();
                
                lbl_name.Text = "Name : " + name;
                lbl_surname.Text = "Surame : " + surname;
                lbl_area.Text = "Area : " + area;
                lbl_section.Text = "Section : " + section;
                lbl_number.Text = "Number : " + number;
                lbl_email.Text = "E-Mail : " + E_mail;              
            }
            read.Close();

            try
            {
                SqlCommand picture_retrieve = new SqlCommand("select Picture from Doctor_Register where E_mail='" + Variables.manager_doctormail + "'", con);
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
            }
            catch 
            {
            }
        }
    }
}
