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
using System.Threading;
using System.Threading.Tasks;

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
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private readonly string connectionString;

        public ChainAnalysisModelsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        // GET: odata/ChainAnalysisModels
        /// <summary>
        /// Query this
        /// </summary>
        /// <param name="queryOptions">OData query options; currently only filter, orderby, top, and skip are supported</param>
        /// <returns>Not Implemented code currently; this isn't done yet</returns>
        [HttpGet]
        [EnableQuery]
        public IHttpActionResult Get(ODataQueryOptions<ChainAnalysisModel> queryOptions)
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


        /// <summary>
        /// Get a chain analysis
        /// </summary>
        /// <param name="chn_id">ID of the chain analysis</param>
        /// <returns>Either a 404 Not Found code, Unauthorized code, or a JSON-serialized <see cref="ChainAnalysisModel"/> instance</returns>
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int chn_id)
        {
            // http://localhost:12345/api/ChainAnalysisModels/5
            using (var model = new SleepMonitor(connectionString))
            {
                var analysis = model.Chn_ChainAnalysis.FirstOrDefault(chn => chn.Chn_ID == chn_id);
                if (analysis == null)
                    return NotFound();
                else
                {
                    //var user = model.Usr_User.FirstOrDefault(usr => usr.Usr_ID == analysis.Chn_usr_ID);

                    var user = model.AspNetUsers.FirstOrDefault(usr => usr.Id.Trim().ToLower().Equals(analysis.Chn_aur_id.Trim().ToLower()));

                    // TODO: is this right?
                    if (user == null || !User.Identity.Name.Trim().ToLower().Equals(user.UserName.Trim().ToLower()))
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
        public IHttpActionResult GetAllAnalysisForUser([FromODataUri] string usr_id)
        {
            IEnumerable<ChainAnalysisModel> analysis;

            using (var monitor = new SleepMonitor(connectionString))
            {
                analysis = monitor.Chn_ChainAnalysis.Where(chn => chn.Chn_aur_id == usr_id).Select(chn => new ChainAnalysisModel(chn));
            }

            return Json(analysis);
            //return Json<IEnumerable<ChainAnalysisModel>>(analysis);
        }

        // PUT: odata/ChainAnalysisModels(5)
        // TODO: improve security for this to restrict it to the user
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="key">ID of the chain analysis we're updating</param>
        /// <param name="model"><see cref="ChainAnalysisModel"/> to replace the instance with. Passed in on body.</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Put([FromODataUri] int key, [FromBody] ChainAnalysisModel model)
        {
            //Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var monitor = new SleepMonitor(connectionString))
            {
                var item = monitor.Chn_ChainAnalysis.FirstOrDefault(chn => chn.Chn_ID == key);

                if (item == null)
                    return NotFound();

                item = await model.ToDBObject();

                monitor.SubmitChanges();
                //item.Bhv_Behavior = model.BehaviorChain.Select(bhv => new Bhv_Behavior { })
            } // Dispose of DB connection

            // return Updated(chainAnalysisModel);
            return Ok();
        }

        // POST: odata/ChainAnalysisModels
        /// <summary>
        /// Create a new chain analysis
        /// </summary>
        /// <param name="chainAnalysisModel"><see cref="ChainAnalysisModel"/> to add.</param>
        /// <returns>Either Bad Request, Unauthorized, or Created</returns>
        public async Task<IHttpActionResult> Post([FromBody] ChainAnalysisModel chainAnalysisModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbObj = await chainAnalysisModel.ToDBObject();

            using (var db = new SleepMonitor(connectionString))
            {
                //var associatedUser = db.AspNetUsers.FirstOrDefault(usr => usr.Id.Trim().ToLower().Equals(chainAnalysisModel.UserID.Trim().ToLower()));

                db.Chn_ChainAnalysis.InsertOnSubmit(dbObj);

                db.SubmitChanges();
            }

            // return Created(chainAnalysisModel);
            return Created(dbObj);
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
