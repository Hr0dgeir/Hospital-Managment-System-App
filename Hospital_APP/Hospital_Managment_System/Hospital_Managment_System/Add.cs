using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;

namespace Hospital_Managment_System
{  
    public class Add
    {
        public static void add_doctor(string name, string surname, string area, string phone_number, string hashed_password, string mail,string password,string section,string social_number)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            string add_new_doctor = "insert into Doctor_Register (Name,Surname,Area,Phone_number,Password,E_mail,Section,Social_security_number) values (@name,@surname,@area,@phone,@password,@mail,@section,@social_number)";
            hashed_password = Sha256convertor.sha256hash_(password);
            SqlCommand add = new SqlCommand(add_new_doctor,con);
            add.Parameters.AddWithValue("@name",name);
            add.Parameters.AddWithValue("@surname",surname);
            add.Parameters.AddWithValue("@area",area);
            add.Parameters.AddWithValue("@phone",phone_number);
            add.Parameters.AddWithValue("@password",hashed_password);
            add.Parameters.AddWithValue("@section",section);
            add.Parameters.AddWithValue("@mail",mail);
            add.Parameters.AddWithValue("@social_number", social_number);
            add.ExecuteNonQuery();                          
        }

        public static void patient_doctor_add(string name,string surname,string section,int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand add = new SqlCommand("update Doctor_Appointment set Patient_name=@name , Patient_Surname=@surname , Patient_social_number=@number where ID='" + id + "' ", con);
            add.Parameters.AddWithValue("@name", name);
            add.Parameters.AddWithValue("@surname", surname);
            add.Parameters.AddWithValue("@number", section);
            System.Windows.Forms.MessageBox.Show("Succesfully");
            add.ExecuteNonQuery();
            con.Close();
        }

        public static void doctor_information(string name,string surname,string section)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand add = new SqlCommand("insert into Doctor_informations (Doctor_Fullname,Doctor_section) values (@name,@section)", con);
            string full_name;
            full_name = name + " " + surname;
            add.Parameters.AddWithValue("@name",full_name);
            add.Parameters.AddWithValue("@section",section);
            add.ExecuteNonQuery();
            con.Close();
        }    
    }
}
