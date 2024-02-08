using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Hospital_Managment_System
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");


        private void Chat_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            guna2HtmlLabel1.Hide();
            lbl_sendername.Hide();
            combobox_incoming_msg.Hide();
            btn_sent_msg.Hide();
            combobox_fullname.Hide();
            guna2Button1.Hide();
            

            Chat_operations.msg_sender();
            Chat_operations.receiver();

            //List<string> combinedList = CombineLists(Chat_operations.receiver_fullnames, Chat_operations.receiver_areas);

            //foreach (var item in combinedList)
            //{
            //    combobox_fullname.Items.Add(item);
            //}

            foreach (var item in Chat_operations.receiver_fullnames)
            {
                combobox_fullname.Items.Add(item);
            }

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            Chat_operations.sent_message(combobox_fullname.Text,richTextBox1.Text,receiver_area);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            guna2HtmlLabel1.Hide();
            combobox_incoming_msg.Items.Clear();
            combobox_incoming_msg.Show();
            btn_show_msg.Hide();
            lbl_sendername.Show();
            guna2Button2.Show();
            guna2Button1.Show();
            btn_sent_msg.Hide();
            combobox_fullname.Hide();
            guna2Button1.Show();
            Chat_operations.incoming_messages.Clear();
            Chat_operations.view_msg();
            foreach (var item in Chat_operations.incoming_messages)
            {
                combobox_incoming_msg.Items.Add(item);
            }
        }
        private void combobox_incoming_msg_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = combobox_incoming_msg.SelectedItem.ToString();

            string[] test = data.Split(':');

            if (test.Length >= 2)
            {
                string id = test[0].Trim();
                string first_part = test[1].Trim();
                string second_part = test[2].Trim();
                lbl_sendername.Text = "Sender = " + first_part;
                richTextBox1.Text = second_part;
                global_msgid = id;
            }
            richTextBox1.Enabled = true;
        }
        string global_msgid;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            guna2HtmlLabel1.Show();
            richTextBox1.Clear();
            combobox_fullname.Show();
            btn_sent_msg.Show();
            guna2Button2.Hide();
            guna2Button1.Hide();
            btn_show_msg.Show();
            lbl_sendername.Hide();
            combobox_incoming_msg.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Chat_operations.delete_msg(global_msgid);
            string selected_message = combobox_incoming_msg.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selected_message))
            {
                combobox_incoming_msg.Items.Remove(selected_message);
                Chat_operations.incoming_messages.Remove(selected_message);
            }
        }
        string receiver_area;
        private void combobox_fullname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = combobox_fullname.SelectedItem.ToString();

            string[] test = data.Split(':');

            if (test.Length >= 2)
            {
                string name = test[0].Trim();
                string area = test[1].Trim();
                receiver_area = area;
                guna2HtmlLabel1.Text = "Receiver = " + name;
            }
            richTextBox1.Enabled = true;
        }

        //public List<string> CombineLists(List<string> list1, List<string> list2)
        //{
        //    List<string> combinedList = new List<string>(); 

        //    for (int i = 0; i < Math.Max(list1.Count, list2.Count); i++)
        //    {
        //        if (i < list1.Count)
        //        {
        //            combinedList.Add(list1[i]);
        //        }

        //        if (i < list2.Count)
        //        {
        //            combinedList.Add(list2[i]);
        //        }
        //    }

        //    return combinedList;
        //}
    }
}
