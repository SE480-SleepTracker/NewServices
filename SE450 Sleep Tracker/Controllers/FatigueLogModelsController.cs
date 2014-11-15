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
    builder.EntitySet<FatigueLogModel>("FatigueLogModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [Authorize]
    public class FatigueLogModelsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/FatigueLogModels
        [EnableQuery]
        public IQueryable<FatigueLogModel> GetFatigueLogModels()
        {
            return db.FatigueLogModels;
        }

        // GET: odata/FatigueLogModels(5)
        [EnableQuery]
        public SingleResult<FatigueLogModel> GetFatigueLogModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.FatigueLogModels.Where(fatigueLogModel => fatigueLogModel.ID == key));
        }

        // PUT: odata/FatigueLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<FatigueLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FatigueLogModel fatigueLogModel = db.FatigueLogModels.Find(key);
            if (fatigueLogModel == null)
            {
                return NotFound();
            }

            patch.Put(fatigueLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FatigueLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(fatigueLogModel);
        }

        // POST: odata/FatigueLogModels
        public IHttpActionResult Post(FatigueLogModel fatigueLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FatigueLogModels.Add(fatigueLogModel);
            db.SaveChanges();

            return Created(fatigueLogModel);
        }

        // PATCH: odata/FatigueLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<FatigueLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FatigueLogModel fatigueLogModel = db.FatigueLogModels.Find(key);
            if (fatigueLogModel == null)
            {
                return NotFound();
            }

            patch.Patch(fatigueLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FatigueLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(fatigueLogModel);
        }

        // DELETE: odata/FatigueLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            FatigueLogModel fatigueLogModel = db.FatigueLogModels.Find(key);
            if (fatigueLogModel == null)
            {
                return NotFound();
            }

            db.FatigueLogModels.Remove(fatigueLogModel);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FatigueLogModelExists(int key)
        {
            return db.FatigueLogModels.Count(e => e.ID == key) > 0;
        }
    }
}
