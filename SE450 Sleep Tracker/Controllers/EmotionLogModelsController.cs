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
using SE450_Sleep_Tracker;
using SE450_Sleep_Tracker.Models;

namespace SE450_Sleep_Tracker.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SE450_Sleep_Tracker.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EmotionLogModel>("EmotionLogModels");
    builder.EntitySet<PredefinedEmotionModel>("PredefinedEmotionModels"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EmotionLogModelsController : ODataController
    {
        private ManualContext db = new ManualContext();

        // GET: odata/EmotionLogModels
        [EnableQuery]
        public IQueryable<EmotionLogModel> GetEmotionLogModels()
        {
            return db.EmotionLogs;
        }

        // GET: odata/EmotionLogModels(5)
        [EnableQuery]
        public SingleResult<EmotionLogModel> GetEmotionLogModel([FromODataUri] int key)
        {
            return SingleResult.Create(db.EmotionLogs.Where(emotionLogModel => emotionLogModel.ID == key));
        }

        // PUT: odata/EmotionLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EmotionLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmotionLogModel emotionLogModel = db.EmotionLogs.Find(key);
            if (emotionLogModel == null)
            {
                return NotFound();
            }

            patch.Put(emotionLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmotionLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(emotionLogModel);
        }

        // POST: odata/EmotionLogModels
        public IHttpActionResult Post(EmotionLogModel emotionLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmotionLogs.Add(emotionLogModel);
            db.SaveChanges();

            return Created(emotionLogModel);
        }

        // PATCH: odata/EmotionLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EmotionLogModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmotionLogModel emotionLogModel = db.EmotionLogs.Find(key);
            if (emotionLogModel == null)
            {
                return NotFound();
            }

            patch.Patch(emotionLogModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmotionLogModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(emotionLogModel);
        }

        // DELETE: odata/EmotionLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EmotionLogModel emotionLogModel = db.EmotionLogs.Find(key);
            if (emotionLogModel == null)
            {
                return NotFound();
            }

            db.EmotionLogs.Remove(emotionLogModel);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/EmotionLogModels(5)/PredefinedEmotion
        [EnableQuery]
        public SingleResult<PredefinedEmotionModel> GetPredefinedEmotion([FromODataUri] int key)
        {
            return SingleResult.Create(db.EmotionLogs.Where(m => m.ID == key).Select(m => m.PredefinedEmotion));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmotionLogModelExists(int key)
        {
            return db.EmotionLogs.Count(e => e.ID == key) > 0;
        }
    }
}
