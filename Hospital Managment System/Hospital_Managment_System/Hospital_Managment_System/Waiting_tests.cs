using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public partial class Waiting_tests : Form
    {
        public Waiting_tests()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

        private void Waiting_tests_Load(object sender, EventArgs e)
        {
            refresh();
            richTextBox1.Enabled = false;
            guna2DateTimePicker1.Enabled = false;
        }

        public void refresh()
        {
            DataTable dt = waiting_tests.test_refresh();
            dataGridView1.DataSource = dt;
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Lab_main frm = new Lab_main();
            frm.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 2)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dataGridView1.Rows[selectedrowindex];

                string id = selectedrow.Cells[0].Value.ToString();
                string information = selectedrow.Cells[3].Value.ToString();
                global_id = id;
                global_information = information;
                label1.Text = "Selected test : "+id;
                richTextBox1.Enabled = true;
            }           
        }
        string global_information;
        string global_id;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (global_id != null)
                {
                    test_results.result(richTextBox1.Text, guna2DateTimePicker1.Text, global_id);
                    refresh();
                }
                else
                {
                    MessageBox.Show("Please Select Test request");
                }
            }
        }

        private void Waiting_tests_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
