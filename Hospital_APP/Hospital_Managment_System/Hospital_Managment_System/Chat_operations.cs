using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public static class Chat_operations
    {
        public static string sender_name_ { get; set; }
        public static string sender_surname_ { get; set; }
        public static string sender_fullname_ { get; set; }
        public static string sender_area_ { get; set; }
        public static void msg_sender()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            string sender_Name;
            string sender_Surname;
            string sender_full_name;
            string sender_area;

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctor_Register where E_Mail like '%" + Variables.id + "%'", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                sender_Name = sqlDataReader[1].ToString();
                sender_Surname = sqlDataReader[2].ToString();
                sender_area = sqlDataReader[3].ToString();
                sender_full_name = sender_Name + " " + sender_Surname;

                sender_name_ = sender_Name;
                sender_surname_ = sender_Surname;
                sender_fullname_ = sender_full_name;
                sender_area_ = sender_area;

                //System.Windows.Forms.MessageBox.Show(sender_area_);
                //System.Windows.Forms.MessageBox.Show(sender_fullname_);
            }
            con.Close();
        }

        public static string name_ { get; set; }
        public static string surname_ { get; set; }
        public static string fullname_ { get; set; }
        public static string area_ { get; set; }
        public static List<string> receiver_fullnames { get; set; } = new List<string>();
        public static List<string> receiver_areas { get; set; } = new List<string>();

        public static void receiver()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            string name;
            string surname;
            string full_name;
            string area;
            con.Open();
            SqlCommand receiver = new SqlCommand("select * from Doctor_Register", con);
            SqlDataReader rdr = receiver.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr[1].ToString();
                surname = rdr[2].ToString();
                area = rdr[3].ToString();
                full_name = name + " " +surname + ":" + area_;

                name_ = name;
                surname_ = surname;
                fullname_ = full_name;
                area_ = area;

                receiver_fullnames.Add(fullname_);
                receiver_areas.Add(area_);
            }
            con.Close();

        }

        public static void sent_message(string receiver_fullname, string text, string receiver_area)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand msg = new SqlCommand("insert into Chat (Receiver_fullname,Receiver_Area,Sender_Fullname,Sender_Area,Message) values (@r_fullname,@r_area,@s_fullname,@s_area,@msg)", con);
            msg.Parameters.AddWithValue("@r_fullname", receiver_fullname);
            msg.Parameters.AddWithValue("@r_area", receiver_area);
            msg.Parameters.AddWithValue("@s_fullname", Chat_operations.sender_fullname_);
            msg.Parameters.AddWithValue("@s_area", Chat_operations.sender_area_);
            msg.Parameters.AddWithValue("@msg", text);           
            msg.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Succesfully");
        }

        public static List<string> incoming_messages { get; set; } = new List<string>();

        public static void view_msg()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            string msg_id;
            string sender_name;
            string message;
            string total;
            con.Open();
            SqlCommand receiver = new SqlCommand("select * from Chat where Receiver_fullname like'%" + Chat_operations.sender_fullname_ + "%' ", con);
            SqlDataReader rdr = receiver.ExecuteReader();
            while (rdr.Read())
            {
                msg_id = rdr[0].ToString();
                sender_name = rdr[3].ToString();
                message = rdr[5].ToString();
                total = msg_id + ":" + sender_name + ":" + message;
                incoming_messages.Add(total);
            }
            con.Close();
        }

        public static void delete_msg(string message_id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand delete_msg = new SqlCommand("delete from Chat where ID='" + message_id + "' ", con);
            delete_msg.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("succesfully");
        }

    }
}
