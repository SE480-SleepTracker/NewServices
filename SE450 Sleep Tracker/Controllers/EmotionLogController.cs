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
    public class EmotionLogController : ApiController
    {
        private SleepMonitorEntities db = new SleepMonitorEntities();

        // GET: api/EmotionLog
        public IQueryable<eml_EmotionLog> Geteml_EmotionLog()
        {
            return db.eml_EmotionLog;
        }

        // GET: api/EmotionLog/5
        [ResponseType(typeof(eml_EmotionLog))]
        public IHttpActionResult Geteml_EmotionLog(int id)
        {
            eml_EmotionLog eml_EmotionLog = db.eml_EmotionLog.Find(id);
            if (eml_EmotionLog == null)
            {
                return NotFound();
            }

            return Ok(eml_EmotionLog);
        }

        // PUT: api/EmotionLog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puteml_EmotionLog(int id, eml_EmotionLog eml_EmotionLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eml_EmotionLog.eml_ID)
            {
                return BadRequest();
            }

            db.Entry(eml_EmotionLog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eml_EmotionLogExists(id))
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

        // POST: api/EmotionLog
        [ResponseType(typeof(eml_EmotionLog))]
        public IHttpActionResult Posteml_EmotionLog(eml_EmotionLog eml_EmotionLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.eml_EmotionLog.Add(eml_EmotionLog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eml_EmotionLog.eml_ID }, eml_EmotionLog);
        }

        // DELETE: api/EmotionLog/5
        [ResponseType(typeof(eml_EmotionLog))]
        public IHttpActionResult Deleteeml_EmotionLog(int id)
        {
            eml_EmotionLog eml_EmotionLog = db.eml_EmotionLog.Find(id);
            if (eml_EmotionLog == null)
            {
                return NotFound();
            }

            db.eml_EmotionLog.Remove(eml_EmotionLog);
            db.SaveChanges();

            return Ok(eml_EmotionLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool eml_EmotionLogExists(int id)
        {
            return db.eml_EmotionLog.Count(e => e.eml_ID == id) > 0;
        }
    }
}