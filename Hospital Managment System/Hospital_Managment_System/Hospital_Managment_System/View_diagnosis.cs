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
    public partial class View_diagnosis : Form
    {
        Doctor_Waiting_patients dwp;
        public View_diagnosis()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
        private void View_diagnosis_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            DataTable dt = Doctor_diagnosis.results();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 2)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dataGridView1.Rows[selectedrowindex];

                string id = selectedrow.Cells[0].Value.ToString();
                string patient_id = selectedrow.Cells[7].Value.ToString();
                string result = selectedrow.Cells[4].Value.ToString();
                global_id = id;
                global_patient_id = patient_id;
                Variables.patient_id = global_patient_id;
                global_result = result;
            }
        }
        string global_result;
        string global_id;
        string global_patient_id;

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (global_id != null)
            {
                MessageBox.Show(global_id);
                test_results.doctor_test_delete(global_id);
                refresh();
            }
            else
            {
                MessageBox.Show("Please Select patient id");
            }
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Main_Window frm = new Main_Window();
            frm.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (global_patient_id != null)
            {
                if (global_result == "Waiting")
                {
                    MessageBox.Show("Test result not updated");
                }
                else
                {
                    dwp = new Doctor_Waiting_patients();
                    dwp.Show();
                    diagnosis_view.diagnosis();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please Check Patient id");
            }
        }

        private void View_diagnosis_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
