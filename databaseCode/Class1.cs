using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaseCode
{
    public class Class1
    {
        SqlConnection con;

        // Connection
        public void connect()
        {
            con = new SqlConnection("Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; Initial Catalog = internship_db; Integrated Security = true;");
        }        
        

        // delete
        public void delete(string ID)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("delete from student where s_id = '"+ID+"'", con);
            adp.SelectCommand.ExecuteNonQuery();

            con.Close();
        }

        // insert

        public void insert(String ID,String Name,long mob,int Age)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("insert into student (s_id,s_name,s_mobile,s_age) values ('"+ID+ "','" + Name + "','" + mob + "','" + Age + "')", con);
            adp.SelectCommand.ExecuteNonQuery();

            con.Close();
        }

        public void update(String ID, String Name, long mob, int Age)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("update student set s_name = '"+Name+"',s_mobile = '"+mob+"',s_age = '"+Age+"' where s_id = '"+ID+"'", con);
            adp.SelectCommand.ExecuteNonQuery();
            
            con.Close();
        }

        //public void select(String Query)
        //{
        //    con.Open();

        //    String query;


        //    SqlDataAdapter adp = new SqlDataAdapter(query, con);

        //    con.Close();
        //}
    }
}
