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
    public class FatigueLevelsController : ApiController
    {
        private SleepMonitorEntities db = new SleepMonitorEntities();

        // GET: api/FatigueLevels
        public IQueryable<ftg_FatigueLevels> Getftg_FatigueLevels()
        {
            return db.ftg_FatigueLevels;
        }

        // GET: api/FatigueLevels/5
        [ResponseType(typeof(ftg_FatigueLevels))]
        public IHttpActionResult Getftg_FatigueLevels(int id)
        {
            ftg_FatigueLevels ftg_FatigueLevels = db.ftg_FatigueLevels.Find(id);
            if (ftg_FatigueLevels == null)
            {
                return NotFound();
            }

            return Ok(ftg_FatigueLevels);
        }

        // PUT: api/FatigueLevels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putftg_FatigueLevels(int id, ftg_FatigueLevels ftg_FatigueLevels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ftg_FatigueLevels.ftg_ID)
            {
                return BadRequest();
            }

            db.Entry(ftg_FatigueLevels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ftg_FatigueLevelsExists(id))
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

        // POST: api/FatigueLevels
        [ResponseType(typeof(ftg_FatigueLevels))]
        public IHttpActionResult Postftg_FatigueLevels(ftg_FatigueLevels ftg_FatigueLevels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ftg_FatigueLevels.Add(ftg_FatigueLevels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ftg_FatigueLevels.ftg_ID }, ftg_FatigueLevels);
        }

        // DELETE: api/FatigueLevels/5
        [ResponseType(typeof(ftg_FatigueLevels))]
        public IHttpActionResult Deleteftg_FatigueLevels(int id)
        {
            ftg_FatigueLevels ftg_FatigueLevels = db.ftg_FatigueLevels.Find(id);
            if (ftg_FatigueLevels == null)
            {
                return NotFound();
            }

            db.ftg_FatigueLevels.Remove(ftg_FatigueLevels);
            db.SaveChanges();

            return Ok(ftg_FatigueLevels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ftg_FatigueLevelsExists(int id)
        {
            return db.ftg_FatigueLevels.Count(e => e.ftg_ID == id) > 0;
        }
    }
}