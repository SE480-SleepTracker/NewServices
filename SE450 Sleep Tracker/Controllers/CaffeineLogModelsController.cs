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
    builder.EntitySet<CaffeineLogModel>("CaffeineLogModels");
    builder.EntitySet<CaffeineTypeModel>("CaffeineTypeModels"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CaffeineLogModelsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/CaffeineLogModels
        [EnableQuery]
        public IQueryable<CaffeineLogModel> GetCaffeineLogModels()
        {
            return db.CaffeineLogModels;
        }

        // GET: odata/CaffeineLogModels(5)
        [EnableQuery]
        public SingleResult<CaffeineLogModel> GetCaffeineLogModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.CaffeineLogModels.Where(caffeineLogModel => caffeineLogModel.ID == key));
        }

        // PUT: odata/CaffeineLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<CaffeineLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CaffeineLogModel caffeineLogModel = db.CaffeineLogModels.Find(key);
            if (caffeineLogModel == null)
            {
                return NotFound();
            }

            patch.Put(caffeineLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaffeineLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(caffeineLogModel);
        }

        // POST: odata/CaffeineLogModels
        public IHttpActionResult Post(CaffeineLogModel caffeineLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CaffeineLogModels.Add(caffeineLogModel);
            db.SaveChanges();

            return Created(caffeineLogModel);
        }

        // PATCH: odata/CaffeineLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<CaffeineLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CaffeineLogModel caffeineLogModel = db.CaffeineLogModels.Find(key);
            if (caffeineLogModel == null)
            {
                return NotFound();
            }

            patch.Patch(caffeineLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaffeineLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(caffeineLogModel);
        }

        // DELETE: odata/CaffeineLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            CaffeineLogModel caffeineLogModel = db.CaffeineLogModels.Find(key);
            if (caffeineLogModel == null)
            {
                return NotFound();
            }

            db.CaffeineLogModels.Remove(caffeineLogModel);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CaffeineLogModels(5)/CaffeineType
        [EnableQuery]
        public SingleResult<CaffeineTypeModel> GetCaffeineType([FromODataUri] int key)
        {
            return SingleResult.Create(db.CaffeineLogModels.Where(m => m.ID == key).Select(m => m.CaffeineType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaffeineLogModelExists(int key)
        {
            return db.CaffeineLogModels.Count(e => e.ID == key) > 0;
        }
    }
}
