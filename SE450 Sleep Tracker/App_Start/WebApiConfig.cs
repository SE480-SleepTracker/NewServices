using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using SE450_Sleep_Tracker.Models;
using System.Net.Http.Formatting;

namespace SE450_Sleep_Tracker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<CaffeineLogModel>("CaffeineLogModels");
            builder.EntitySet<ChainAnalysisModel>("ChainAnalysisModels");
            builder.EntitySet<ExerciseLogModel>("ExerciseLogModels");
            builder.EntitySet<EmotionLogModel>("EmotionLogModels");
            builder.EntitySet<ApplicationUser>("User");
            builder.EntitySet<FatigueLogModel>("FatigueLog");
            builder.EntitySet<SleepLogModel>("SleepLog");
            builder.EntitySet<ProductModel>("Product");
            builder.EntitySet<ExerciseIntensityModel>("ExerciseIntensityModels");
            builder.EntitySet<ExerciseTypeModel>("ExerciseTypeModels");
            builder.EntitySet<FatigueLogModel>("FatigueLogModels");
            //builder.EntitySet<PredefinedEmotionModel>("PredefinedEmotionModels");
            config.Routes.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.EnableQuerySupport();
        }
    }
}
