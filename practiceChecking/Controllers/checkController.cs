using practiceChecking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace practiceChecking.Controllers
{
    [RoutePrefix("api/check")]
    public class checkController : ApiController
    {
        datecheckEntities db = new datecheckEntities();

        [Route("InsertDate")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertDate([FromBody] Table_1 d)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = DateTime.Now;

                    TimeSpan diff = d2.Subtract(d1);

                    d.diff = diff.Minutes;
                    d.secondtime = d2;
                    d.firsttime = d1;

                    db.Table_1.Add(d);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }
            return Ok();
        }
    }
}
