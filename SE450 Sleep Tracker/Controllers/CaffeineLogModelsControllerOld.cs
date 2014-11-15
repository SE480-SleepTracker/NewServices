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
using SE450Database;
using SE450_Sleep_Tracker.Models;
using Microsoft.Data.OData;
using System.Configuration;

namespace SE450_Sleep_Tracker.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SE450_Sleep_Tracker.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<CaffeineLogModel>("CaffeineLogModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[Authorize]
    public class CaffeineLogModelsControllerOld : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private readonly string connectionString;

        public CaffeineLogModelsControllerOld()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        public IHttpActionResult GetCaffeineLogModel([FromODataUri] int id)
        {
            try
            {
                var product = new CaffeineLogModel(id);
                return Json(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: odata/CaffeineLogModels
        [HttpGet]
        public IHttpActionResult GetCaffeineLogModels(ODataQueryOptions<CaffeineLogModel> queryOptions)
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

            // return Ok<IEnumerable<CaffeineLogModel>>(caffeineLogModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/CaffeineLogModels(5)
        [HttpGet]
        public IHttpActionResult GetCaffeineLogModel([FromODataUri] int key, ODataQueryOptions<CaffeineLogModel> queryOptions)
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

            // return Ok<CaffeineLogModel>(caffeineLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/CaffeineLogModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<CaffeineLogModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(caffeineLogModel);

            // TODO: Save the patched entity.

            // return Updated(caffeineLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/CaffeineLogModels
        public IHttpActionResult Post(CaffeineLogModel caffeineLogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var db = new SleepMonitor(connectionString))
            {
                db.Cfn_CaffeineConsumption.InsertOnSubmit(caffeineLogModel.ToDbObject());

                db.SubmitChanges();
            }

            return Created(caffeineLogModel);
        }

        // PATCH: odata/CaffeineLogModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<CaffeineLogModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(caffeineLogModel);

            // TODO: Save the patched entity.

            // return Updated(caffeineLogModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/CaffeineLogModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
