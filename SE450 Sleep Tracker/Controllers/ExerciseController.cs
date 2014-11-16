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
    public class ExerciseController : ApiController
    {
        private SleepMonitorEntities db = new SleepMonitorEntities();

        // GET: api/Exercise
        public IQueryable<exr_Exercise> Getexr_Exercise()
        {
            return db.exr_Exercise;
        }

        // GET: api/Exercise/5
        [ResponseType(typeof(exr_Exercise))]
        public IHttpActionResult Getexr_Exercise(int id)
        {
            exr_Exercise exr_Exercise = db.exr_Exercise.Find(id);
            if (exr_Exercise == null)
            {
                return NotFound();
            }

            return Ok(exr_Exercise);
        }

        // PUT: api/Exercise/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putexr_Exercise(int id, exr_Exercise exr_Exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exr_Exercise.exr_ID)
            {
                return BadRequest();
            }

            db.Entry(exr_Exercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!exr_ExerciseExists(id))
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

        // POST: api/Exercise
        [ResponseType(typeof(exr_Exercise))]
        public IHttpActionResult Postexr_Exercise(exr_Exercise exr_Exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.exr_Exercise.Add(exr_Exercise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exr_Exercise.exr_ID }, exr_Exercise);
        }

        // DELETE: api/Exercise/5
        [ResponseType(typeof(exr_Exercise))]
        public IHttpActionResult Deleteexr_Exercise(int id)
        {
            exr_Exercise exr_Exercise = db.exr_Exercise.Find(id);
            if (exr_Exercise == null)
            {
                return NotFound();
            }

            db.exr_Exercise.Remove(exr_Exercise);
            db.SaveChanges();

            return Ok(exr_Exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool exr_ExerciseExists(int id)
        {
            return db.exr_Exercise.Count(e => e.exr_ID == id) > 0;
        }
    }
}