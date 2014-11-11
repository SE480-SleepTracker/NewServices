using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using SE450_Sleep_Tracker.Models;

namespace SE450_Sleep_Tracker.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SE450_Sleep_Tracker.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ExerciseLogModel>("ExerciseLogModels");
    builder.EntitySet<ExerciseIntensityModel>("ExerciseIntensityModels"); 
    builder.EntitySet<ExerciseTypeModel>("ExerciseTypeModels"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ExerciseLogModelsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/ExerciseLogModels
        [EnableQuery]
        public IQueryable<ExerciseLogModel> GetExerciseLogModels()
        {
            return db.ExerciseLogModels;
        }

        // GET: odata/ExerciseLogModels(5)
        [EnableQuery]
        public SingleResult<ExerciseLogModel> GetExerciseLogModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.ExerciseLogModels.Where(exerciseLogModel => exerciseLogModel.ID == key));
        }

        // PUT: odata/ExerciseLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ExerciseLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExerciseLogModel exerciseLogModel = db.ExerciseLogModels.Find(key);
            if (exerciseLogModel == null)
            {
                return NotFound();
            }

            patch.Put(exerciseLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(exerciseLogModel);
        }

        // POST: odata/ExerciseLogModels
        public IHttpActionResult Post(ExerciseLogModel exerciseLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseLogModels.Add(exerciseLogModel);
            db.SaveChanges();

            return Created(exerciseLogModel);
        }

        // PATCH: odata/ExerciseLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ExerciseLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExerciseLogModel exerciseLogModel = db.ExerciseLogModels.Find(key);
            if (exerciseLogModel == null)
            {
                return NotFound();
            }

            patch.Patch(exerciseLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(exerciseLogModel);
        }

        // DELETE: odata/ExerciseLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ExerciseLogModel exerciseLogModel = db.ExerciseLogModels.Find(key);
            if (exerciseLogModel == null)
            {
                return NotFound();
            }

            db.ExerciseLogModels.Remove(exerciseLogModel);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ExerciseLogModels(5)/Intensity
        [EnableQuery]
        public SingleResult<ExerciseIntensityModel> GetIntensity([FromODataUri] int key)
        {
            return SingleResult.Create(db.ExerciseLogModels.Where(m => m.ID == key).Select(m => m.Intensity));
        }

        // GET: odata/ExerciseLogModels(5)/Type
        [EnableQuery]
        public SingleResult<ExerciseTypeModel> GetType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ExerciseLogModels.Where(m => m.ID == key).Select(m => m.Type));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseLogModelExists(int key)
        {
            return db.ExerciseLogModels.Count(e => e.ID == key) > 0;
        }
    }
}
