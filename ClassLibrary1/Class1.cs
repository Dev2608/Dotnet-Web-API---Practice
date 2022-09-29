using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        SqlConnection con;        

        // Connection
        public void connectionTostudents()
        {
            con = new SqlConnection("Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; Initial Catalog = newChecking; Integrated Security = true;");
        }


        // insert
        // simple student insertion

        public void insertWithoutFaculty(String ID, String Name, long mob, int Age)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter(
                "insert into students (s_id,s_name,s_mobile,s_age)" +
                " values ('" + ID + "','" + Name + "','" + mob + "','" + Age + "')", con);
            adp.SelectCommand.ExecuteNonQuery();

            con.Close();
        }

        
        public void insertTofacultyDetail(String F_ID, String ID)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter(
                "insert into facultyDetail " +
                "(f_id,s_id) " +
                "values " +
                "('" + F_ID + "','" + ID + "')", con);
            adp.SelectCommand.ExecuteNonQuery();

            con.Close();
        }

    }
}
