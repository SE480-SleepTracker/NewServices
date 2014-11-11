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
    builder.EntitySet<ChainAnalysisModel>("ChainAnalysisModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [Authorize]
    public class ChainAnalysisModelsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/ChainAnalysisModels
        [EnableQuery]
        public IQueryable<ChainAnalysisModel> GetChainAnalysisModels()
        {
            return db.ChainAnalysisModels;
        }

        // GET: odata/ChainAnalysisModels(5)
        [EnableQuery]
        public SingleResult<ChainAnalysisModel> GetChainAnalysisModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.ChainAnalysisModels.Where(chainAnalysisModel => chainAnalysisModel.ID == key));
        }

        // PUT: odata/ChainAnalysisModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ChainAnalysisModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChainAnalysisModel chainAnalysisModel = db.ChainAnalysisModels.Find(key);
            if (chainAnalysisModel == null)
            {
                return NotFound();
            }

            patch.Put(chainAnalysisModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChainAnalysisModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chainAnalysisModel);
        }

        // POST: odata/ChainAnalysisModels
        public IHttpActionResult Post(ChainAnalysisModel chainAnalysisModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChainAnalysisModels.Add(chainAnalysisModel);
            db.SaveChanges();

            return Created(chainAnalysisModel);
        }

        // PATCH: odata/ChainAnalysisModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ChainAnalysisModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChainAnalysisModel chainAnalysisModel = db.ChainAnalysisModels.Find(key);
            if (chainAnalysisModel == null)
            {
                return NotFound();
            }

            patch.Patch(chainAnalysisModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChainAnalysisModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(chainAnalysisModel);
        }

        // DELETE: odata/ChainAnalysisModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ChainAnalysisModel chainAnalysisModel = db.ChainAnalysisModels.Find(key);
            if (chainAnalysisModel == null)
            {
                return NotFound();
            }

            db.ChainAnalysisModels.Remove(chainAnalysisModel);
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

        private bool ChainAnalysisModelExists(int key)
        {
            return db.ChainAnalysisModels.Count(e => e.ID == key) > 0;
        }
    }
}
