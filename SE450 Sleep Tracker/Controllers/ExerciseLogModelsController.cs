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
    builder.EntitySet<ExerciseLogModel>("ExerciseLogModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ExerciseLogModelsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private readonly string connectionString;

        public ExerciseLogModelsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        // GET: odata/ExerciseLogModels
        public IHttpActionResult GetExerciseLogModels(ODataQueryOptions<ExerciseLogModel> queryOptions)
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
                result = queryOptions.ApplyTo(db.Exr_Exercise.AsQueryable());
            }

            var toReturn = result as IEnumerable<Exr_Exercise>;

            if (toReturn == null)
                return NotFound();
            else
            {
                var converted = toReturn.Select(ret => new ExerciseLogModel(ret));

                return Json(converted);
            }
        }

        // GET: odata/ExerciseLogModels(5)
        public IHttpActionResult GetExerciseLogModel([FromODataUri] int key)
        {
            Exr_Exercise exercise;
            using (var db = new SleepMonitor(connectionString))
            {
                exercise = db.Exr_Exercise.FirstOrDefault(ex => ex.Exr_ID == key);
            }

            if (exercise == null)
                return NotFound();
            else
                return Json(new ExerciseLogModel(exercise));
        }

        // PUT: odata/ExerciseLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, [FromBody] ExerciseLogModel delta)
        {
            //Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(exerciseLogModel);

            // TODO: Save the patched entity.

            // return Updated(exerciseLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/ExerciseLogModels
        public IHttpActionResult Post(ExerciseLogModel exerciseLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var db = DataCurator.GetConnection())
            {
                db.Exr_Exercise.InsertOnSubmit(exerciseLogModel.ToDbObject());

                db.SubmitChanges();
            }

            // TODO: Add create logic here.

            return Created(exerciseLogModel);
        }

        // PATCH: odata/ExerciseLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ExerciseLogModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(exerciseLogModel);

            // TODO: Save the patched entity.

            // return Updated(exerciseLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/ExerciseLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
