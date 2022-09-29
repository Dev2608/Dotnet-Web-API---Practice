using ClassLibrary1;
using NotMappedCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NotMappedCheck.Controllers
{
    public class studentDetailController : ApiController
    {

        Class1 ob1 = new Class1();

        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertStudent([FromBody] student s)
        {
            //DB.students.Add(s);
            //DB.SaveChanges();

            ob1.connectionTostudents();            

            //ob1.insertTostudents(s.s_id, s.s_name, (long)s.s_mobile, (int)s.s_age,s.f_id);

            if (s.f_id != null)
            {
                //s.f_id = null;
                //ob1.insertTostudents(s.s_id, s.s_name, (long)s.s_mobile, (int)s.s_age);

                ob1.insertTofacultyDetail(s.f_id, s.s_id);
            }

            ob1.insertWithoutFaculty(s.s_id, s.s_name, (long)s.s_mobile, (int)s.s_age);
            return Ok();
        }

    }
}
