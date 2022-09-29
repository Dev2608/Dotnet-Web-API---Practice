using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using Connection;
using System.Data;
using WebApiOauth.Models;

namespace WebApiOauth.Controllers
{
    public class loginDetailTokenController : ApiController
    {
        connect ob1 = new connect();
        // select

        [Authorize]
        [HttpGet]
        public IHttpActionResult selectStudent()
        {
            try
            {
                ob1.connectionTostudents();
                DataSet ds = ob1.selectStudent("select * from facultyDetail");

                var list = ds.Tables[0].AsEnumerable().Select(dataRow => new facultyDetail
                {
                    f_id = dataRow.Field<String>("f_id"),
                    s_id = dataRow.Field<String>("s_id")
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return (IHttpActionResult)ex;
            }
        }
    }
}
