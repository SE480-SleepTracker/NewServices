using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
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
    builder.EntitySet<UserModel>("UserModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    /// <summary>
    /// Model of user data (email address, etc.). This is separate from the User Account.
    /// </summary>
    [Authorize]
    public class UserModelsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private readonly string connectionString;

        public UserModelsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        // GET: odata/UserModels
        public IHttpActionResult GetUserModels(ODataQueryOptions<UserModel> queryOptions)
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

            // return Ok<IEnumerable<UserModel>>(userModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/UserModels(5)
        public IHttpActionResult GetUserModel([FromODataUri] int id, ODataQueryOptions<UserModel> queryOptions)
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

            using (SleepMonitor monitor = new SleepMonitor(connectionString))
            {
                var deft = monitor.Usr_User.FirstOrDefault(usr => usr.Usr_ID == id);

                return Json<UserModel>(new UserModel(deft));
            }
        }

        // PUT: odata/UserModels(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<UserModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (SleepMonitor monitor = new SleepMonitor(connectionString))
            {
                var user = monitor.Usr_User.FirstOrDefault(usr => usr.Usr_ID == key);

                UserModel model = new UserModel(user);
                delta.CopyChangedValues(model);

            }

            // TODO: Get the entity here.

            // delta.Put(userModel);

            // TODO: Save the patched entity.

            // return Updated(userModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/UserModels
        [Authorize]
        public IHttpActionResult Post(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(userModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/UserModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<UserModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(userModel);

            // TODO: Save the patched entity.

            // return Updated(userModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/UserModels(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
