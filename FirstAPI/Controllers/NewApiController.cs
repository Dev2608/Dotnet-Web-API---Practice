using databaseCode;
using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace FirstAPI.Controllers
{
    public class NewApiController : ApiController
    {
        internship_dbEntities DB = new internship_dbEntities();
        Class1 ob1 = new Class1();
        

        // Select For All.
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllStudents()
        {
            List<student> obj = DB.students.ToList();
            return Ok(obj);
        }

        // Select By Id.
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudentsById(String id)
        {
            var obj = DB.students.Where(model => model.s_id.Equals(id)).FirstOrDefault();
            return Ok(obj);
        }

        // Insert
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertStudent([FromBody] student s)
        {
            //DB.students.Add(s);
            //DB.SaveChanges();

            ob1.connect();
            ob1.insert(s.s_id,s.s_name, (long)s.s_mobile,(int)s.s_age);

            return Ok();
        }

        // Update
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateStudent([FromBody] student s)
        {
            // DB.Entry(s).State = System.Data.Entity.EntityState.Modified;

            //var temp = DB.students.Where(model => model.s_id.Equals(s.s_id)).FirstOrDefault();            

            //if(temp != null)
            //{
            //    temp.s_name = s.s_name;
            //    temp.s_age = s.s_age;
            //    temp.s_mobile = s.s_mobile;
            //}

            //DB.SaveChanges();

            ob1.connect();
            ob1.update(s.s_id, s.s_name, (long)s.s_mobile, (int)s.s_age);

            return Ok();
        }

        // Delete
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteStudent(String id)
        {
            //var obj = DB.students.Where(model => model.s_id.Equals(id)).FirstOrDefault();
            ob1.connect();
            ob1.delete(id);

            //DB.Entry(obj).State = System.Data.Entity.EntityState.Deleted;

            //DB.SaveChanges();
            return Ok();
        }

    }
}
