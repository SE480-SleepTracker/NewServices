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
        public IHttpActionResult GetSleepLogModel([FromODataUri] int key)
        {
            using (SleepMonitor monitor = new SleepMonitor(connectionString))
            {
                var dbM = monitor.Slp_SleepLog.FirstOrDefault(slp => slp.Slp_ID == key);

                var model = new SleepLogModel()
                {
                    SleepQuality = (ushort?)dbM.Slp_SleepQuality,
                    TimeToSleepUserLogged = new DateTime(dbM.Slp_TimeToSleepUserLogged.HasValue ? dbM.Slp_TimeToSleepUserLogged.Value.Ticks : DateTime.Now.Ticks), // TODO: this is wrong
                    AssociatedUser = new UserModel(monitor.Usr_User.FirstOrDefault(usr => usr.Usr_ID == dbM.Slp_usr_ID)),
                    Date = dbM.Slp_date,
                    ID = dbM.Slp_ID,
                    TimeToBed = new DateTime(dbM.Slp_TimeToBed.Ticks, DateTimeKind.Unspecified) // TODO: this is wrong
                };

                return Json<SleepLogModel>(model);
            }

            // return Ok<SleepLogModel>(sleepLogModel);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/SleepLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<SleepLogModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(sleepLogModel);

            // TODO: Save the patched entity.

            // return Updated(sleepLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/SleepLogModels
        public IHttpActionResult Post(SleepLogModel sleepLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(sleepLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
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
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
