using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SE450_Sleep_Tracker;

namespace SE450_Sleep_Tracker.Controllers
{
    [Authorize]
    public class CaffeineConsumptionController : ApiController
    {
        private SleepMonitorEntities db = new SleepMonitorEntities();

        // GET: api/CaffeineConsumption
        public IQueryable<cfn_CaffeineConsumption> Getcfn_CaffeineConsumption()
        {
            return db.cfn_CaffeineConsumption;
        }

        // GET: api/CaffeineConsumption/5
        [ResponseType(typeof(cfn_CaffeineConsumption))]
        public IHttpActionResult Getcfn_CaffeineConsumption(int id)
        {
            cfn_CaffeineConsumption cfn_CaffeineConsumption = db.cfn_CaffeineConsumption.Find(id);
            if (cfn_CaffeineConsumption == null)
            {
                return NotFound();
            }

            return Ok(cfn_CaffeineConsumption);
        }

        // PUT: api/CaffeineConsumption/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcfn_CaffeineConsumption(int id, cfn_CaffeineConsumption cfn_CaffeineConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cfn_CaffeineConsumption.cfn_ID)
            {
                return BadRequest();
            }

            db.Entry(cfn_CaffeineConsumption).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cfn_CaffeineConsumptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CaffeineConsumption
        [ResponseType(typeof(cfn_CaffeineConsumption))]
        public IHttpActionResult Postcfn_CaffeineConsumption(cfn_CaffeineConsumption cfn_CaffeineConsumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cfn_CaffeineConsumption.Add(cfn_CaffeineConsumption);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cfn_CaffeineConsumption.cfn_ID }, cfn_CaffeineConsumption);
        }

        // DELETE: api/CaffeineConsumption/5
        [ResponseType(typeof(cfn_CaffeineConsumption))]
        public IHttpActionResult Deletecfn_CaffeineConsumption(int id)
        {
            cfn_CaffeineConsumption cfn_CaffeineConsumption = db.cfn_CaffeineConsumption.Find(id);
            if (cfn_CaffeineConsumption == null)
            {
                return NotFound();
            }

            db.cfn_CaffeineConsumption.Remove(cfn_CaffeineConsumption);
            db.SaveChanges();

            return Ok(cfn_CaffeineConsumption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cfn_CaffeineConsumptionExists(int id)
        {
            return db.cfn_CaffeineConsumption.Count(e => e.cfn_ID == id) > 0;
        }
    }
}