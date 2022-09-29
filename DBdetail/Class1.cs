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
        SqlConnection conTostudents;
        SqlConnection conTofacultyDetail;

        // Connection
        public void connectionTostudents()
        {
            conTostudents = new SqlConnection("Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; Initial Catalog = checking; Integrated Security = true;");
        }
        
        public void connectionTofacultyDetail()
        {
            conTofacultyDetail = new SqlConnection("Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; Initial Catalog = checking; Integrated Security = true;");
        }

        // delete
        public void deleteFromstudents(string ID)
        {
            conTostudents.Open();

            SqlDataAdapter adp = new SqlDataAdapter("delete from students where s_id = '" + ID + "'", conTostudents);
            adp.SelectCommand.ExecuteNonQuery();

            conTostudents.Close();
        }

        public void deleteFromfacultyDetail(string ID)
        {
            conTofacultyDetail.Open();

            SqlDataAdapter adp = new SqlDataAdapter("delete from facultyDetail where s_id = '" + ID + "'", conTofacultyDetail);
            adp.SelectCommand.ExecuteNonQuery();

            conTofacultyDetail.Close();
        }

        // insert

        //public void insertWithoutFaculty(String ID, String Name, long mob, int Age)
        //{
        //    conTostudents.Open();

        //    SqlDataAdapter adp = new SqlDataAdapter("insert into students (s_id,s_name,s_mobile,s_age,f_id) values ('" + ID + "','" + Name + "','" + mob + "','" + Age + "',null)", conTostudents);
        //    adp.SelectCommand.ExecuteNonQuery();

        //    conTostudents.Close();
        //}
        public void insertTostudents(String ID, String Name, long mob, int Age)
        {
            conTostudents.Open();

            SqlDataAdapter adp = new SqlDataAdapter("insert into students (s_id,s_name,s_mobile,s_age) values ('" + ID + "','" + Name + "','" + mob + "','" + Age + "')", conTostudents);
            adp.SelectCommand.ExecuteNonQuery();

            conTostudents.Close();
        }

        public void insertTofacultyDetail(String F_ID, String S_ID)
        {
            conTofacultyDetail.Open();

            SqlDataAdapter adp = new SqlDataAdapter("insert into facultyDetail (f_id,s_id) values ('"+F_ID+"','"+S_ID+"')", conTofacultyDetail);
            adp.SelectCommand.ExecuteNonQuery();

            conTofacultyDetail.Close();
        }

        // update
        public void updateTostudents(String ID, String Name, long mob, int Age)
        {
            conTostudents.Open();

            SqlDataAdapter adp = new SqlDataAdapter("update student set s_name = '" + Name + "',s_mobile = '" + mob + "',s_age = '" + Age + "' where s_id = '" + ID + "'", conTostudents);
            adp.SelectCommand.ExecuteNonQuery();

            conTostudents.Close();
        }

        public void updateTofacultyDetail(String F_ID, String S_ID)
        {
            conTofacultyDetail.Open();

            SqlDataAdapter adp = new SqlDataAdapter("update facultyDetail set f_id = '" + F_ID + "' where s_id = '" + S_ID + "'", conTofacultyDetail);
            adp.SelectCommand.ExecuteNonQuery();

            conTofacultyDetail.Close();
        }

        public DataSet selectStudent(String p)
        {
            conTostudents.Open();

            SqlDataAdapter a = new SqlDataAdapter(p, conTostudents);
            DataSet ds = new DataSet();
            a.Fill(ds);

            return (ds);

            conTostudents.Close();
        }

    }
}
