using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Hospital_Managment_System
{
    public class waiting_tests
    {
        public static DataTable test_refresh()
        {
            DataTable dataTable = new DataTable();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Test where result ='"+"Waiting"+"'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            con.Close();
            return dataTable;           
        }
    }

    public static class test_results
    {
        public static void result(string test_result,string sent_time,string global_id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand result = new SqlCommand("update Test set result=@result , delivered_date=@time where ID like'%" + global_id + "%' ", con);
            result.Parameters.AddWithValue("@result", test_result);
            result.Parameters.AddWithValue("@time", sent_time);
            result.ExecuteNonQuery();
            con.Close();
        }

        public static void doctor_test_delete(string global_id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand delete = new SqlCommand("delete from Test where ID like '%" + global_id + "%' ", con);
            delete.ExecuteNonQuery();
            con.Close();
        }
    }


    public class Doctor_diagnosis
    {
        public static DataTable results()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");

            con.Open();
            SqlCommand diagnosis = new SqlCommand("select * from Test where Doctor_information like '%" + Variables.id + "%' ", con);
            SqlDataReader read = diagnosis.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            con.Close();
            return dt;
        }
    }
}
