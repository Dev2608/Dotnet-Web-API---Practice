using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection_loginRegister
{
    public class Class1
    {
        SqlConnection con;

        public void connection()
        {
            con = new SqlConnection("Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; Initial Catalog = loginRegisterDB; Integrated Security = true;");
        }

        public void insert(String Name, String UserId, String pass, String Mobile)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter(
                "insert into register (name,userid,password,mobile) " +
                "values " +
                "('" + Name + "','" + UserId + "','" + pass + "','" + Mobile + "')", con);

            adp.SelectCommand.ExecuteNonQuery();

            con.Close();
        }

        public DataSet select(String p)
        {
            con.Open();

            SqlDataAdapter a = new SqlDataAdapter(p, con);
            DataSet ds = new DataSet();
            a.Fill(ds);

            return (ds);

            con.Close();
        }

    }
}
