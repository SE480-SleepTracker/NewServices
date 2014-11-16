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
    public class NighttimeAwakeningsController : ApiController
    {
        private SleepMonitorEntities db = new SleepMonitorEntities();

        // GET: api/NighttimeAwakenings
        public IQueryable<awk_NighttimeAwakenings> Getawk_NighttimeAwakenings()
        {
            return db.awk_NighttimeAwakenings;
        }

        // GET: api/NighttimeAwakenings/5
        [ResponseType(typeof(awk_NighttimeAwakenings))]
        public IHttpActionResult Getawk_NighttimeAwakenings(int id)
        {
            awk_NighttimeAwakenings awk_NighttimeAwakenings = db.awk_NighttimeAwakenings.Find(id);
            if (awk_NighttimeAwakenings == null)
            {
                return NotFound();
            }

            return Ok(awk_NighttimeAwakenings);
        }

        // PUT: api/NighttimeAwakenings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putawk_NighttimeAwakenings(int id, awk_NighttimeAwakenings awk_NighttimeAwakenings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != awk_NighttimeAwakenings.awk_ID)
            {
                return BadRequest();
            }

            db.Entry(awk_NighttimeAwakenings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!awk_NighttimeAwakeningsExists(id))
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

        // POST: api/NighttimeAwakenings
        [ResponseType(typeof(awk_NighttimeAwakenings))]
        public IHttpActionResult Postawk_NighttimeAwakenings(awk_NighttimeAwakenings awk_NighttimeAwakenings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.awk_NighttimeAwakenings.Add(awk_NighttimeAwakenings);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = awk_NighttimeAwakenings.awk_ID }, awk_NighttimeAwakenings);
        }

        // DELETE: api/NighttimeAwakenings/5
        [ResponseType(typeof(awk_NighttimeAwakenings))]
        public IHttpActionResult Deleteawk_NighttimeAwakenings(int id)
        {
            awk_NighttimeAwakenings awk_NighttimeAwakenings = db.awk_NighttimeAwakenings.Find(id);
            if (awk_NighttimeAwakenings == null)
            {
                return NotFound();
            }

            db.awk_NighttimeAwakenings.Remove(awk_NighttimeAwakenings);
            db.SaveChanges();

            return Ok(awk_NighttimeAwakenings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool awk_NighttimeAwakeningsExists(int id)
        {
            return db.awk_NighttimeAwakenings.Count(e => e.awk_ID == id) > 0;
        }
    }
}