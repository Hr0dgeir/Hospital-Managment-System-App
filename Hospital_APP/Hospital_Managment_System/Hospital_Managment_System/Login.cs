using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System
{
    public class Login
    {
        public static void login(string password , string mail, string hashed_password)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NT9V6AB;Initial Catalog=Hospital_Managment_App;Integrated Security=True");
            con.Open();
            SqlCommand login = new SqlCommand("select * from Doctor_Register where E_mail=@mail and Password=@password",con);
            hashed_password = Sha256convertor.sha256hash_(password);
            login.Parameters.AddWithValue("@mail",mail);
            login.Parameters.AddWithValue("@password",hashed_password);

            SqlDataAdapter da = new SqlDataAdapter(login);

            DataTable dt = new DataTable(); 
            da.Fill(dt);

            Variables.safe = false;

            if (dt.Rows.Count > 0 )
            {
                System.Windows.Forms.MessageBox.Show("Succesfully");
                Variables.safe = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Password or mail incorrect");
                Variables.safe = false;
            }           
        }
    }
}
