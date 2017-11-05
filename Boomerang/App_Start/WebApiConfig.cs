using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Formatter;

namespace Boomerang
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //var odataFormatters = ODataMediaTypeFormatters.Create(NonSerializedAttribute);
            //config.Formatters.Clear();
            //config.Formatters.AddRange(odataFormatters);

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Models.Post>("Posts");
            builder.EntitySet<Models.Feeling>("Feelings");
            config.MapODataServiceRoute(
                routeName: "ODataRoute", 
                routePrefix: "api", 
                model: builder.GetEdmModel());

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
        }
    }
}
