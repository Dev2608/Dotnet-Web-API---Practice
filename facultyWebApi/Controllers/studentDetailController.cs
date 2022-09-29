using DBdetail;
using facultyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace facultyWebApi.Controllers
{
    public class studentDetailController : ApiController
    {
        checkingEntities DB = new checkingEntities();
        Class1 ob1 = new Class1();


        // select
        [HttpGet]
        public IHttpActionResult selectStudent()
        {
            try 
            {
                ob1.connectionTostudents();
                DataSet ds = ob1.selectStudent("spgetAllStudent");

                var list = ds.Tables[0].AsEnumerable().Select(dataRow => new facultyDetail
                {
                    f_id = dataRow.Field<String>("f_id"),
                    s_id = dataRow.Field<String>("s_id")
                });

                return Ok(list);
            }
            catch(Exception ex)
            {
                return (IHttpActionResult)ex;
            }
        }

        // Insert
        [Route("api/studentDetail/InsertStudent")]    // to call this api using method name
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertStudent([FromBody] student s)
        {
            //DB.students.Add(s);
            //DB.SaveChanges();

            ob1.connectionTostudents();
            ob1.connectionTofacultyDetail();

            //ob1.insertTostudents(s.s_id, s.s_name, (long)s.s_mobile, (int)s.s_age,s.f_id);

            if (s.f_id != null)
            {
                //s.f_id = null;
                //ob1.insertTostudents(s.s_id, s.s_name, (long)s.s_mobile, (int)s.s_age);
                
                ob1.insertTofacultyDetail(s.f_id, s.s_id);
            }
            
            ob1.insertTostudents(s.s_id, s.s_name, (long)s.s_mobile, (int)s.s_age);
            return Ok();
        }

        // insert JSON array
        [Route("api/studentDetail/InsertMultipleStudent")]      // to call this api using method name
        [HttpPost]
        public IHttpActionResult InsertMultipleStudent([FromBody] student[] s)
        {
            int l = s.Length;

            ob1.connectionTostudents();
            ob1.connectionTofacultyDetail();

            for (int i = 0; i < l; i++)
            {
                String ID = s[i].s_id;
                String Name = s[i].s_name;
                long mob = (long)s[i].s_mobile;
                int Age = (int)s[i].s_age;
                String F_ID = s[i].f_id;

                if (s[i].f_id != null)
                {
                    ob1.insertTofacultyDetail(s[i].f_id, s[i].s_id);
                }

                ob1.insertTostudents(s[i].s_id, s[i].s_name, (long)s[i].s_mobile, (int)s[i].s_age);
            }
            return Ok();
        }
    }
}
