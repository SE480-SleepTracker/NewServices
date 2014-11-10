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
using Microsoft.Ajax.Utilities;
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
    builder.EntitySet<FatigueLogModel>("FatigueLogModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [Authorize]
    public class FatigueLogModelsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private readonly string connectionString;

        public FatigueLogModelsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        /// <summary>
        /// Get the fatigue levels for a user
        /// </summary>
        /// <param name="userID">ID of the user we are getting the log for</param>
        /// <returns>JSON list</returns>
        [HttpGet]
        public IHttpActionResult GetFatigueLogModels([FromODataUri] string userID)
        {
            List<FatigueLogModel> list;

            using (var db = new SleepMonitor(connectionString))
            {
                list =
                    db.Ftg_FatigueLevels.Where(ftg => ftg.Ftg_aur_id.Trim().ToLower().Equals(userID.Trim().ToLower()))
                        .Select(item => new FatigueLogModel(item))
                        .ToList();
            }

            if (list.Any())
                return Json(list);
            else
                return NotFound();
        }

        /// <summary>
        /// Gefatigue levels for a uder by date
        /// </summary>
        /// <param name="userID">ID of the user. From URL.</param>
        /// <param name="date">Log date. Note that the time component will be ignored. From URL.</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFatigueLogModels([FromODataUri] string userID, [FromODataUri] DateTime date)
        {
            List<FatigueLogModel> list;
            using (var db = new SleepMonitor(connectionString))
            {
                list = db.Ftg_FatigueLevels
                    .Where(
                        ftg =>
                            ftg.Ftg_aur_id.Trim().ToLower().Equals(userID.Trim().ToLower()) &&
                            ftg.Ftg_logTime.Date.Day == date.Day && ftg.Ftg_logTime.Month == date.Month &&
                            ftg.Ftg_logTime.Year == date.Year)
                    .Select(log => new FatigueLogModel(log)).ToList();
            }

            if (list.Any())
                return Json(list);
            else
                return NotFound();
        }

        // GET: odata/FatigueLogModels
        [HttpGet]
        public IHttpActionResult GetFatigueLogModels(ODataQueryOptions<FatigueLogModel> queryOptions)
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

            IQueryable result;
            using (var db = new SleepMonitor(connectionString))
            {
                result = queryOptions.ApplyTo(db.Ftg_FatigueLevels.AsQueryable());
            }

            var toReturn = result as IEnumerable<Ftg_FatigueLevels>;

            if (toReturn == null)
                return NotFound();
            else
            {
                var converted = toReturn.Select(ftg => new FatigueLogModel(ftg));
                return Json(converted);
            }
        }



        // GET: odata/FatigueLogModels(5)
        [HttpGet]
        public IHttpActionResult GetFatigueLogModel([FromODataUri] int key)
        {
            // TODO validate the query/user

            Ftg_FatigueLevels item;
            using (var db = new SleepMonitor(connectionString))
            {
                item = db.Ftg_FatigueLevels.FirstOrDefault(log => log.Ftg_ID == key);
            }

            return Json(new FatigueLogModel(item));
        }

        // PUT: odata/FatigueLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, FatigueLogModel delta)
        {
            //Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // TODO check user

            using (var db = new SleepMonitor(connectionString))
            {
                var fatigueLogModel = db.Ftg_FatigueLevels.FirstOrDefault(ftg => ftg.Ftg_ID == key);

                if (fatigueLogModel == null)
                    return NotFound();

                fatigueLogModel.Ftg_level = delta.Level;
                fatigueLogModel.Ftg_logTime = delta.LogTime;
                db.SubmitChanges();
            }

            return Ok();
            // 

            // TODO: Save the patched entity.

            // return Updated(fatigueLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/FatigueLogModels
        public IHttpActionResult Post(FatigueLogModel fatigueLogModel)
        {
            // todo check user
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var db = new SleepMonitor(connectionString))
            {
                if (db.Ftg_FatigueLevels.FirstOrDefault(ftg => ftg.Ftg_ID == fatigueLogModel.ID) != null)
                    return BadRequest("Already exists");

                var log = new Ftg_FatigueLevels
                {
                    Ftg_aur_id = fatigueLogModel.UserID,
                    Ftg_level = fatigueLogModel.Level,
                    Ftg_logTime =  fatigueLogModel.LogTime
                };

                db.Ftg_FatigueLevels.InsertOnSubmit(log);

                db.SubmitChanges();
            }

            // TODO: Add create logic here.

            // return Created(fatigueLogModel);
            return Ok();
        }

        // PATCH: odata/FatigueLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<FatigueLogModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(fatigueLogModel);

            // TODO: Save the patched entity.

            // return Updated(fatigueLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/FatigueLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            using (var model = new SleepMonitor(connectionString))
            {
                var record = model.Ftg_FatigueLevels.FirstOrDefault(ftg => ftg.Ftg_ID == key);

                if (record == null)
                    return NotFound();

                model.Ftg_FatigueLevels.DeleteOnSubmit(record);

                model.SubmitChanges();
            }
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return Ok();
        }
    }
}
