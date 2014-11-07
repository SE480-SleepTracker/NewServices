using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using SE450_Sleep_Tracker.Models;
using Microsoft.Data.OData;
using System.Configuration;
using SE450Database;
using System.Threading.Tasks;

namespace SE450_Sleep_Tracker.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SE450_Sleep_Tracker.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<SleepLogModel>("SleepLogModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [Authorize]
    public class SleepLogModelsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private readonly string connectionString;

        public SleepLogModelsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        // GET: odata/SleepLogModels
        [HttpGet]
        [EnableQuery]
        public IHttpActionResult GetSleepLogModels(ODataQueryOptions<SleepLogModel> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<SleepLogModel>>(sleepLogModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/SleepLogModels(5)
        /// <summary>
        /// Get a sleep log by ID
        /// </summary>
        /// <param name="key">ID of the log</param>
        /// <returns>Either a HTTP unauthorized code, Http 404 (not found), or a JSON-serialized <see cref="SleepLogModel"/> object</returns>
        [HttpGet]
        public IHttpActionResult GetSleepLogModel([FromODataUri] int key)
        {
            Slp_SleepLog dbM;

            using (var monitor = new SleepMonitor(connectionString))
            {
                dbM = monitor.Slp_SleepLog.FirstOrDefault(slp => slp.Slp_ID == key);
            }

            if (dbM == null)
                return NotFound();

            var model = new SleepLogModel()
            {
                SleepQuality = (ushort?)dbM.Slp_SleepQuality,
                TimeToSleepUserLogged = new DateTime(dbM.Slp_TimeToSleepUserLogged.HasValue ? dbM.Slp_TimeToSleepUserLogged.Value.Ticks : DateTime.Now.Ticks), // TODO: this is wrong
                UserID = dbM.Slp_aur_id,
                Date = dbM.Slp_date,
                ID = dbM.Slp_ID,
                TimeToBed = new DateTime(dbM.Slp_TimeToBed.Ticks, DateTimeKind.Unspecified) // TODO: this is wrong
            };

            return Json(model);

            // return Ok<SleepLogModel>(sleepLogModel);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/SleepLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, SleepLogModel delta)
        {
            //Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var db = new SleepMonitor(connectionString))
            {
                var item = db.Slp_SleepLog.FirstOrDefault(itm => itm.Slp_ID == key);
                if (item == null)
                    return NotFound();

                var tm = new SleepLogModel(item);
                tm = delta;

                item = tm.ToDBObject().Result;

                db.SubmitChanges();
            }

            // TODO: Get the entity here.

            // delta.Put(sleepLogModel);

            // TODO: Save the patched entity.

            // return Updated(sleepLogModel);
            return Updated(delta);
        }

        // POST: odata/SleepLogModels
        /// <summary>
        /// Asynchronously create a new sleep log
        /// </summary>
        /// <param name="sleepLogModel">JSON-serialized <see cref="SleepLogModel"/></param>
        /// <returns>HTTP Created or Bad Request</returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] SleepLogModel sleepLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await sleepLogModel.ToDBObject();

            using (var monitor = new SleepMonitor(connectionString))
            {
                monitor.Slp_SleepLog.InsertOnSubmit(model);

                monitor.SubmitChanges();
            }

            return Created<SleepLogModel>(sleepLogModel);
        }

        // PATCH: odata/SleepLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<SleepLogModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(sleepLogModel);

            // TODO: Save the patched entity.

            // return Updated(sleepLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/SleepLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            using (var monitor = new SleepMonitor(connectionString))
            {
                var toRemove = monitor.Slp_SleepLog.FirstOrDefault(log => log.Slp_ID == key);

                if (toRemove == null)
                    return NotFound();

                monitor.Slp_SleepLog.DeleteOnSubmit(toRemove);

                monitor.SubmitChanges();
            }

            return Ok();
        }
    }
}
