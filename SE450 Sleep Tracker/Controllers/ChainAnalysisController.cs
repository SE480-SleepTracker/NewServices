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
    public class ChainAnalysisController : ApiController
    {
        private SleepMonitorEntities db = new SleepMonitorEntities();

        // GET: api/ChainAnalysis
        public IQueryable<chn_ChainAnalysis> Getchn_ChainAnalysis()
        {
            return db.chn_ChainAnalysis;
        }

        // GET: api/ChainAnalysis/5
        [ResponseType(typeof(chn_ChainAnalysis))]
        public IHttpActionResult Getchn_ChainAnalysis(int id)
        {
            chn_ChainAnalysis chn_ChainAnalysis = db.chn_ChainAnalysis.Find(id);
            if (chn_ChainAnalysis == null)
            {
                return NotFound();
            }

            return Ok(chn_ChainAnalysis);
        }

        // PUT: api/ChainAnalysis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putchn_ChainAnalysis(int id, chn_ChainAnalysis chn_ChainAnalysis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chn_ChainAnalysis.chn_ID)
            {
                return BadRequest();
            }

            db.Entry(chn_ChainAnalysis).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!chn_ChainAnalysisExists(id))
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

        // POST: api/ChainAnalysis
        [ResponseType(typeof(chn_ChainAnalysis))]
        public IHttpActionResult Postchn_ChainAnalysis(chn_ChainAnalysis chn_ChainAnalysis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.chn_ChainAnalysis.Add(chn_ChainAnalysis);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chn_ChainAnalysis.chn_ID }, chn_ChainAnalysis);
        }

        // DELETE: api/ChainAnalysis/5
        [ResponseType(typeof(chn_ChainAnalysis))]
        public IHttpActionResult Deletechn_ChainAnalysis(int id)
        {
            chn_ChainAnalysis chn_ChainAnalysis = db.chn_ChainAnalysis.Find(id);
            if (chn_ChainAnalysis == null)
            {
                return NotFound();
            }

            db.chn_ChainAnalysis.Remove(chn_ChainAnalysis);
            db.SaveChanges();

            return Ok(chn_ChainAnalysis);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool chn_ChainAnalysisExists(int id)
        {
            return db.chn_ChainAnalysis.Count(e => e.chn_ID == id) > 0;
        }
    }
}