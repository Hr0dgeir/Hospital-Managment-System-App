using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System
{
    public class Worker
    {
        public static void check(string mail)
        {
            Reception_window rc;
            Main_Window dc;
            Manager_Main mm;
            Lab_main lm;
            string Name;
            string Surname;
            string department;
            string branch;
            string id;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctor_Register where E_Mail like '%" + mail + "%'", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                id = sqlDataReader[0].ToString();
                Name = sqlDataReader[1].ToString();
                Surname =sqlDataReader[2].ToString();
                department = sqlDataReader[3].ToString();
                branch = sqlDataReader[7].ToString();
                Variables.name = Name;
                Variables.surname = Surname;
                if (department == "Reception")
                {
                    rc  = new Reception_window();
                    rc.lbl_name_surname.Text = Name +" "+ Surname;
                    rc.guna2HtmlLabel1.Text = department;
                    rc.Show();
                }               
                if (department == "Doctor")
                {
                    dc = new Main_Window();
                    dc.label1.Text = Name +" "+ Surname;
                    dc.label2.Text = department;
                    dc.label3.Text = branch;
                    dc.Show();
                }
                if(department == "Manager")
                {
                    mm = new Manager_Main();
                    mm.lbl_name_surname.Text = Name + " " + Surname;
                    mm.lbl_statue_show.Text = department;
                    mm.Show();
                }
                if (department == "Laboratory")
                {
                    lm = new Lab_main();
                    lm.lbl_name_surname.Text = Name + " " + Surname;
                    lm.lbl_statue_show.Text = department;
                    lm.Show();
                }
            }
            con.Close();
        }
    }   
}
