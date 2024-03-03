using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
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
    public static class Doctor_operations
    {
        public static void doctor_appointment_delete(string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand delete = new SqlCommand("delete from Doctor_Appointment where ID like '%" + id + "%' ", con);
            delete.ExecuteNonQuery();
            con.Close();
        }

        public static void doctor_appointment_update(string date,string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand update_date = new SqlCommand("update Doctor_Appointment set Date='" + date + "' where ID ='"+id+"' ", con);
            update_date.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Succesully");
        }       
    }
    public class Oppeintment_refresh
    {
        public static DataTable GetDoctorAppointments(string doctorEmail)
        {
            DataTable dataTable = new DataTable();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctor_Appointment where Doctor_Email LIKE @DoctorEmail", con);
            cmd.Parameters.AddWithValue("@DoctorEmail", "%" + doctorEmail + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            con.Close();
            return dataTable;
        }
    }

    public static class Doctor_informations
    {
        
        public static void Set_doctor_worktime(string time,string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand set = new SqlCommand("update Doctor_informations set Doctor_Working_time='" + time + "' where ID='" + id + "' ", con);
            set.ExecuteNonQuery();
            con.Close();
        }
        public static void Set_doctor_freetime(string freetime, string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand set = new SqlCommand("update Doctor_informations set Doctor_freetime='" + freetime + "' where ID='" + id + "' ", con);
            set.ExecuteNonQuery();
            con.Close();
        }
        public static void Set_doctor_request(string request, string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand set = new SqlCommand("update Doctor_informations set Doctor_requests='" + request + "' where ID='" + id + "' ", con);
            set.ExecuteNonQuery();
            con.Close();
        }
        public static void Set_doctor_offdays(string offdays, string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand set = new SqlCommand("update Doctor_informations set Doctor_offdays='" + offdays + "' where ID='" + id + "' ", con);
            set.ExecuteNonQuery();
            con.Close();
        }       
    }
    public class Doctor_information_refresh
    {
        public static DataTable Doctors_information()
        {
            DataTable dataTable = new DataTable();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctor_informations", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            con.Close();
            return dataTable;
        }
    }

    public class Doctor_patient
    {
        public static DataTable patient()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand patients = new SqlCommand("select * from Doctor_Appointment where Doctor_Email like'%" + Variables.id + "%' ", con);
            SqlDataReader dr = patients.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }
    }

    public class Doctor_selected_patient 
    {
        public static DataTable selected_patient()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand diagnosis = new SqlCommand("select * from Test where patient_id ='" + Variables.patient_id + "' ", con);
            SqlDataReader read = diagnosis.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }
    }

    public static class doctor_patient_test
    {
        public static void patient_test(string doctor_name,string doctor_email,string patient_name,string time,string patient_id,string tests)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            SqlCommand sent = new SqlCommand("insert into Test (Doctor_who_wants,Doctor_information,Patient_name,result,request_date,patient_id,request_tests) values (@doctor,@information,@patient_name,@result,@date,@id,@tests)", con);
            sent.Parameters.AddWithValue("@doctor", doctor_name);
            sent.Parameters.AddWithValue("@information", doctor_email);
            sent.Parameters.AddWithValue("@patient_name", patient_name);
            sent.Parameters.AddWithValue("@result", "Waiting");
            sent.Parameters.AddWithValue("@date",time);
            sent.Parameters.AddWithValue("@id", patient_id);
            sent.Parameters.AddWithValue("@tests", tests);
            con.Open();
            sent.ExecuteNonQuery();
            con.Close();
        }

        public static void patient_delete(string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand delete_patient = new SqlCommand("delete from Doctor_Appointment where Patient_social_number='" + id + "' ", con);
            delete_patient.ExecuteNonQuery();
            con.Close();
        }

        public static void treated_patient(string patient_name,string patient_surname,string doctor_name,string doctor_surname,string doctor_section,string diagnosis,string prescriptipns)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand add = new SqlCommand("insert into Treated_patient (Name,Surname,Doctor_name,Doctor_surname,Doctor_section,diagnosis,prescriptions,Doctor_information) values (@name,@surname,@d_name,@d_surname,@d_section,@diagnosis,@prescriptipns,@mail)", con);
            add.Parameters.AddWithValue("@name", patient_name);
            add.Parameters.AddWithValue("@surname", patient_surname);
            add.Parameters.AddWithValue("@d_name", doctor_name);
            add.Parameters.AddWithValue("@d_surname", doctor_surname);
            add.Parameters.AddWithValue("@d_section", doctor_section);
            add.Parameters.AddWithValue("@diagnosis", diagnosis);
            add.Parameters.AddWithValue("@prescriptipns", prescriptipns);
            add.Parameters.AddWithValue("@mail", Variables.id);
            add.ExecuteNonQuery();
            con.Close();
        }

        public static void patient()
        {

        }
    }
    public static class Delete
    {
        public static void delete_patient_tests()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand delete_patient = new SqlCommand("delete from Test where patient_id='" + Variables.patient_id + "' ", con);
            delete_patient.ExecuteNonQuery();
            con.Close();
        }
        public static void patient()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand delete_patient2 = new SqlCommand("delete from Doctor_Appointment where ID='" + Variables.patient_id + "' ", con);
            delete_patient2.ExecuteNonQuery();
            con.Close();
        }
    }

    public static class Past_appointment
    {
        public static DataTable Doctor_Past_Appointments()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand past = new SqlCommand("select * from Treated_patient where Doctor_information='" + Variables.id + "' ", con);
            SqlDataReader rdr = past.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            con.Close();
            return dt;
        }
    }

    public static class Doctor_surgerys
    {
        public static DataTable Doctor_Surgerys(string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand select = new SqlCommand("select ID,Patient_Fullname,Patient_gender,Type_of_surgery,Date,Room,Medicines_to_be_used,Patient_relatieves_informations,Patient_Socialnumber,Doctor_Fullname,Doctor_Email from Surgery where Doctor_Email like'%" + Variables.id + "%' ", con);
            SqlDataReader read = select.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }

        public static void doctor_surgery_delete(string id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand delete = new SqlCommand("delete from Surgery where ID ='" + id + "' ", con);
            delete.ExecuteNonQuery();
            con.Close();
        }

        public static void Doctor_surgery_update(string patient_number,string date,string room)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand update_date = new SqlCommand("update Surgery set Date=@Date, Room=@Room where Patient_Socialnumber='" + patient_number + "' ", con);
            update_date.Parameters.AddWithValue("@Date", date);
            update_date.Parameters.AddWithValue("@Room", room);
            update_date.ExecuteNonQuery();
            con.Close();
        }
    }
}
