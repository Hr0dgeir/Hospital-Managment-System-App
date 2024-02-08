using Guna.UI2.WinForms;
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
    public partial class Patient_recommendations : Form
    {
        public Patient_recommendations()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int maxcharacter = 500;
            if (richTextBox1.Text.Length > maxcharacter)
            {
                richTextBox1.Text = richTextBox1.Text.Substring(0, maxcharacter);
                richTextBox1.SelectionStart = maxcharacter;
            }
            int remaining_character;
            remaining_character = maxcharacter - richTextBox1.Text.Length;
            guna2HtmlLabel2.Text = remaining_character.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
                Patient_operations.patient_request(richTextBox1.Text);
                this.Close();
            }
        }

        private void Patient_recommendations_Load(object sender, EventArgs e)
        {

        }
    }
}
