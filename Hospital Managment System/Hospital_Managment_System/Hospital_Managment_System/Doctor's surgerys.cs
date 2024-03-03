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
    public partial class View_Doctor_Surgerys : Form
    {
        public View_Doctor_Surgerys()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public static List<string> date_and_room  = new List<string>();
        //{ get; set; }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
        string global_date;
        public void data()
        {
            con.Open();
            SqlCommand room_date = new SqlCommand("select Date , Room from Surgery", con);
            SqlDataReader read = room_date.ExecuteReader();
            date_and_room = new List<string>();
            while (read.Read())
            {
                string date = read[0].ToString();
                string room = read[1].ToString();
                date_and_room.Add(date + "-" + room);
            }
            read.Close();
            con.Close();
        }
        private void View_Doctor_Surgerys_Load(object sender, EventArgs e)
        {
            string date_combobox = datetimepicker_date.Text;
            global_date = date_combobox;
            combobox_room.Enabled = false;
            refresh_data();
            data();
            

            //foreach (var item in date_and_room)
            //{
            //    string[] parts = item.Split('-');
            //}
        }
        public void refresh_data()
        {
            DataTable surgery = Doctor_surgerys.Doctor_Surgerys(global_id);
            Datagrid.DataSource = surgery;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (global_id != null)
            {
                Doctor_surgerys.doctor_surgery_delete(global_id);
                refresh_data();
                MessageBox.Show("Succesfully deleted");
            }
            else
            {
                MessageBox.Show("Please choose which 1 you delete");
            }
        }
        string global_id;
        string global_social_number;
        private void Datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected_row_index = Datagrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedrow = Datagrid.Rows[selected_row_index];

            string id = selectedrow.Cells[0].Value.ToString();
            string social_number = selectedrow.Cells[8].Value.ToString();
            global_id = id;
            global_social_number = social_number;
        }

        private void Return_main_Click(object sender, EventArgs e)
        {
            Main_Window frm = new Main_Window();
            frm.Show();
            this.Hide();
            date_and_room = null;
        }

        private void datetimepicker_date_ValueChanged(object sender, EventArgs e)
        {
            string today_date = datetimepicker_date.Text;
            string selectedDate = datetimepicker_date.Text;

            combobox_room.Items.Clear();

            for (int i = 1; i <= 6; i++)
            {
                combobox_room.Items.Add(i.ToString());
            }
            if (datetimepicker_date.Text != global_date)
            {
                combobox_room.Enabled = true;
            }


            List<string> matchingRooms = date_and_room
                    .Where(item => item.StartsWith(selectedDate))
                    .ToList();

            if (matchingRooms.Count > 0)
            {
                foreach (string matchingRoom in matchingRooms)
                {
                    string[] roomData = matchingRoom.Split('-');

                    foreach (string roomNumber in roomData)
                    {
                        combobox_room.Items.Remove(roomNumber.Trim());
                    }
                }
            }
        }

        public void refresh()
        {
            con.Open();
            SqlCommand refresh = new SqlCommand("select * from Surgery where Doctor_Email like '%"+Variables.id+"%' ",con);
            SqlDataReader read = refresh.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            Datagrid.DataSource = dt;
            con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (global_social_number != null)
            {
                refresh();
                Doctor_surgerys.Doctor_surgery_update(global_social_number, datetimepicker_date.Text, combobox_room.Text);
                MessageBox.Show("Succesfully Updated");               
            }
            else
            {
                MessageBox.Show("Please select surgery");
            }
        }

        private void combobox_room_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Doctor_Surgerys_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
