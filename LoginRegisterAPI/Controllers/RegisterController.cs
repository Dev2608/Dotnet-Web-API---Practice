using connection_loginRegister;
using System;
using System.Collections.Generic;
namespace LoginRegisterAPI.Models
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace LoginRegisterAPI.Controllers
{
    public class RegisterController : ApiController
    {
        loginRegisterDBEntities db = new loginRegisterDBEntities();
        Class1 obj = new Class1();        

        [Authorize]
        [HttpGet]
        public IHttpActionResult selectStudent()
        {
            try
            {
                obj.connection();
                DataSet ds = obj.select("select * from register");

                var list = ds.Tables[0].AsEnumerable().Select(dataRow => new register
                {
                    name = dataRow.Field<String>("name"),
                    userid = dataRow.Field<String>("userid"),
                    password = dataRow.Field<String>("password"),
                    mobile = dataRow.Field<String>("mobile")
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return (IHttpActionResult)ex;
            }
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertStudent([FromBody] register d)
        {
            if (db.registers.Any(
                loginDetail => loginDetail.mobile.Equals(d.mobile, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest("User Already Exist!!");
            }
            else
            {
                obj.connection();

                MembershipUser n_user = Membership.CreateUser(d.userid, d.password);
                obj.insert(d.name, d.userid, d.password, d.mobile);

                return Ok();
            }
        }
    }
}
