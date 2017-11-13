using Boomerang.OData;
using Boomerang.Models;
using Microsoft.OData;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Formatter;
using System.Web.OData.Formatter.Serialization;
using System.Web.OData.Routing.Conventions;
using System.IO;
using Microsoft.OData.Tests;
using System.Text;

namespace Boomerang
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.MapODataServiceRoute(
                "ODataRoute",
                "api",
                containerBuilder => containerBuilder
                .AddService<IEdmModel>(ServiceLifetime.Singleton, s => BuildEdmModelForOData())
                .AddService<IEnumerable<IODataRoutingConvention>>(ServiceLifetime.Singleton, sp =>
                    ODataRoutingConventions.CreateDefaultWithAttributeRouting("ODataRoute", config))
                .AddService<ODataSerializerProvider>(ServiceLifetime.Singleton, s => new CustomODataSerializerProvider(s))
                );

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
        }

        public static IEdmModel BuildEdmModelForOData()
        {
            ODataConventionModelBuilder
                oDataConventionModelBuilder = new ODataConventionModelBuilder();

            // Build model here
            oDataConventionModelBuilder.EntitySet<Post>("Posts");
            oDataConventionModelBuilder.EntitySet<Feeling>("Feelings");
            
            return oDataConventionModelBuilder.GetEdmModel();
        }
    }
}
