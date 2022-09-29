using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work21May
{
    public class Class1
    {
        SqlConnection con;

        // Connection
        public void connection()
        {
            con = new SqlConnection("Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; Initial Catalog = internship_db; Integrated Security = true;");
        }

        // Select
        public void selection(String query)
        {

        }

        // Insert
        public void Insert(String ID,String Name,int mob,int a)
        {
            con.Open();

            SqlDataAdapter insertData = new SqlDataAdapter("insert into student (s_id,s_name,s_mobile,s_age) values (ID,Name,mob,a);",con);

            insertData.SelectCommand.ExecuteNonQuery();

            con.Close();
        }

        // Update
        //public void Update(String ID, String Name, int mob, int a)
        //{
        //    con.Open();            
        //    SqlDataAdapter updateData = new SqlDataAdapter("update student set s_name=Name,s_mobile=mob,s_age=a where s_id=ID;", con);

        //    con.Close();
        //}


    }
}
