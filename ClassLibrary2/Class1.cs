using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdetail
{
    public class Class1
    {
        SqlConnection con;        

        // Connection
        public void connectionTostudents()
        {
            con = new SqlConnection("Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; Initial Catalog = newChecking; Integrated Security = true;");
        }

        public DataSet selectStudent(String p)
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
