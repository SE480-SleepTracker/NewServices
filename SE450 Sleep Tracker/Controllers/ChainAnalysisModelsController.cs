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
using SE450Database;
using System.Configuration;

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
    public class ChainAnalysisModelsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private readonly string connectionString;

        public ChainAnalysisModelsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        // GET: odata/ChainAnalysisModels
        public IHttpActionResult GetChainAnalysisModels(ODataQueryOptions<ChainAnalysisModel> queryOptions)
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

            // return Ok<IEnumerable<ChainAnalysisModel>>(chainAnalysisModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/ChainAnalysisModels(5)
        public IHttpActionResult GetChainAnalysisModel([FromODataUri] int key, ODataQueryOptions<ChainAnalysisModel> queryOptions)
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

            // return Ok<ChainAnalysisModel>(chainAnalysisModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        /// <summary>
        /// Get an action for
        /// </summary>
        /// <param name="chn_id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetSleepLogModel(int chn_id)
        {
            using (SleepMonitor model = new SleepMonitor(connectionString))
            {
                var analysis = model.Chn_ChainAnalysis.FirstOrDefault(chn => chn.Chn_ID == chn_id);
                if (analysis == null)
                    return BadRequest("Does not exist");
                else
                {
                    var user = model.Usr_User.FirstOrDefault(usr => usr.Usr_ID == analysis.Chn_usr_ID);

                    // TODO: should this be the email address or full name?
                    // Also, migrate this to the new Accounts token
                    if (user == null || !user.Usr_EmailAddress.Equals(user.Usr_EmailAddress))
                        return Unauthorized();
                    else
                    {
                        var chn = new ChainAnalysisModel(analysis);

                        return Json<ChainAnalysisModel>(chn);
                    }
                }
            } // Dispose of connection to database
        }

        [HttpGet]
        public IHttpActionResult GetAllAnalysisForUser([FromODataUri] int usr_id)
        {
            using (SleepMonitor monitor = new SleepMonitor(connectionString))
            {
                IEnumerable<ChainAnalysisModel> analysis = monitor.Chn_ChainAnalysis.Where(chn => chn.Chn_usr_ID == usr_id).Select(chn => new ChainAnalysisModel(chn));

                return Json<IEnumerable<ChainAnalysisModel>>(analysis);
            }
        }

        // PUT: odata/ChainAnalysisModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ChainAnalysisModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(chainAnalysisModel);

            // TODO: Save the patched entity.

            // return Updated(chainAnalysisModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/ChainAnalysisModels
        public IHttpActionResult Post(ChainAnalysisModel chainAnalysisModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (SleepMonitor db = new SleepMonitor(connectionString))
            {
                var associatedUser = db.Usr_User.FirstOrDefault(usr => usr.Usr_ID == chainAnalysisModel.AssociatedUser.ID);
            }

            // return Created(chainAnalysisModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/ChainAnalysisModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ChainAnalysisModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(chainAnalysisModel);

            // TODO: Save the patched entity.

            // return Updated(chainAnalysisModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/ChainAnalysisModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
