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
    public partial class Manager_patient_requests : Form
    {
        public Manager_patient_requests()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
        private void Manager_patient_requests_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand request = new SqlCommand("select * from Patient_Message",con);
            SqlDataReader read = request.ExecuteReader();
            while (read.Read())
            {
                string msg = read[1].ToString();
                string id = read[0].ToString();
                string full = id + "-" + msg;
                guna2ComboBox1.Items.Add(full);
            }
            con.Close();
        }
        string global_id;
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = guna2ComboBox1.SelectedItem.ToString();

            string[] test = data.Split('-');

            if (test.Length >= 2)
            {
                string id = test[0].Trim();
                string msg = test[1].Trim();
                richTextBox1.Text = msg;
                global_id = id;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (global_id != null)
            {
                con.Open();
                SqlCommand delete = new SqlCommand("delete from Patient_Message where ID='" + global_id + "' ", con);
                delete.ExecuteReader();
                con.Close();
                MessageBox.Show("Succesfully deleted");
                richTextBox1.Text = null;
                guna2ComboBox1.Text = null;
                global_id = null;
            }
        }
    }
}
