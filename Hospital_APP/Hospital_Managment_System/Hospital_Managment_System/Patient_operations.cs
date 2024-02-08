using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public class Patient_operations
    {
        Add_patient ap;
        public static void update(string name, string surname, string number, int id, string date, string section, string phone, string blood,string doctor_name,string doctor_mail)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand add = new SqlCommand("update Doctor_Appointment set Patient_name=@name , Patient_Surname=@surname ,Date=@date, Patient_social_number=@number , Doctor_Section=@section , Patient_phone=@phone  ,Patient_blood=@blood ,Doctor_FullName=@doctor_name ,Doctor_Email=@mail where ID='" + id + "' ", con);
            add.Parameters.AddWithValue("@name", name);
            add.Parameters.AddWithValue("@surname", surname);
            add.Parameters.AddWithValue("@number", number);
            add.Parameters.AddWithValue("@date", date);
            add.Parameters.AddWithValue("@section", section);
            add.Parameters.AddWithValue("@phone", phone);
            add.Parameters.AddWithValue("@blood", blood);
            add.Parameters.AddWithValue("@doctor_name", doctor_name);
            add.Parameters.AddWithValue("@mail", doctor_mail);
            System.Windows.Forms.MessageBox.Show("Succesfully");
            add.ExecuteNonQuery();
            con.Close();
        }
            
        public static void add(string name,string surname,string p_number,string d_fullname, string d_section,string blood,string phone,string d_mail,string date)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand Add = new SqlCommand("insert into Doctor_Appointment (Patient_name,Patient_Surname,Patient_social_number,Doctor_FullName,Doctor_Section,Patient_blood,Patient_phone,Doctor_Email,Date) values (@p_name,@p_surname,@p_number,@d_fullname,@d_section,@p_blood,@p_phone,@d_mail,@date)", con);
            Add.Parameters.AddWithValue("@p_name",name);
            Add.Parameters.AddWithValue("@p_surname",surname);
            Add.Parameters.AddWithValue("@p_number",p_number);
            Add.Parameters.AddWithValue("@d_fullname",d_fullname);
            Add.Parameters.AddWithValue("@d_section",d_section);
            Add.Parameters.AddWithValue("@p_blood",blood);
            Add.Parameters.AddWithValue("@p_phone",phone);
            Add.Parameters.AddWithValue("@d_mail",d_mail);
            Add.Parameters.AddWithValue("@date",date);
            Add.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("Succesfully");
            con.Close() ;
        }       
        
        public static void delete(string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand delete = new SqlCommand("delete from Doctor_Appointment where ID='" + id + "'", con);
            delete.ExecuteNonQuery();
            con.Close();
        }
        
        public static void patient_request(string text)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand message = new SqlCommand("insert into Patient_Message (Patient_Message) values (@message)", con);
            message.Parameters.AddWithValue("@message", text);
            message.ExecuteNonQuery();
            con.Close();
        }
    }

    public class Patient_refresh
    {
        public static DataTable refresh()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand show = new SqlCommand("select * from Doctor_Appointment", con);
            DataTable dt = new DataTable();
            SqlDataReader dr = show.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }
    }
}
