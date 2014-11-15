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
    builder.EntitySet<NighttimeAwakeningsModel>("NighttimeAwakeningsModels");
    builder.EntitySet<SleepLogModel>("SleepLogModels"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class NighttimeAwakeningsModelsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/NighttimeAwakeningsModels
        [EnableQuery]
        public IQueryable<NighttimeAwakeningsModel> GetNighttimeAwakeningsModels()
        {
            return db.NighttimeAwakeningsModels;
        }

        // GET: odata/NighttimeAwakeningsModels(5)
        [EnableQuery]
        public SingleResult<NighttimeAwakeningsModel> GetNighttimeAwakeningsModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.NighttimeAwakeningsModels.Where(nighttimeAwakeningsModel => nighttimeAwakeningsModel.ID == key));
        }

        // PUT: odata/NighttimeAwakeningsModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<NighttimeAwakeningsModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NighttimeAwakeningsModel nighttimeAwakeningsModel = db.NighttimeAwakeningsModels.Find(key);
            if (nighttimeAwakeningsModel == null)
            {
                return NotFound();
            }

            patch.Put(nighttimeAwakeningsModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NighttimeAwakeningsModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(nighttimeAwakeningsModel);
        }

        // POST: odata/NighttimeAwakeningsModels
        public IHttpActionResult Post(NighttimeAwakeningsModel nighttimeAwakeningsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NighttimeAwakeningsModels.Add(nighttimeAwakeningsModel);
            db.SaveChanges();

            return Created(nighttimeAwakeningsModel);
        }

        // PATCH: odata/NighttimeAwakeningsModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<NighttimeAwakeningsModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NighttimeAwakeningsModel nighttimeAwakeningsModel = db.NighttimeAwakeningsModels.Find(key);
            if (nighttimeAwakeningsModel == null)
            {
                return NotFound();
            }

            patch.Patch(nighttimeAwakeningsModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NighttimeAwakeningsModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(nighttimeAwakeningsModel);
        }

        // DELETE: odata/NighttimeAwakeningsModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            NighttimeAwakeningsModel nighttimeAwakeningsModel = db.NighttimeAwakeningsModels.Find(key);
            if (nighttimeAwakeningsModel == null)
            {
                return NotFound();
            }

            db.NighttimeAwakeningsModels.Remove(nighttimeAwakeningsModel);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/NighttimeAwakeningsModels(5)/SleepLog
        [EnableQuery]
        public SingleResult<SleepLogModel> GetSleepLog([FromODataUri] int key)
        {
            return SingleResult.Create(db.NighttimeAwakeningsModels.Where(m => m.ID == key).Select(m => m.SleepLog));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NighttimeAwakeningsModelExists(int key)
        {
            return db.NighttimeAwakeningsModels.Count(e => e.ID == key) > 0;
        }
    }
}
