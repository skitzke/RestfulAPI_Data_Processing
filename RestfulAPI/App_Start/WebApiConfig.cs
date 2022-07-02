using System.Web.Http;
using System.Web.Http.Cors;

namespace RestfulAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);
            // using jsonp Formater to avoid cross origin exception
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter

            // These two lines formats the RAW data response from the sever to a nice Json structure
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Remove XML formater completely, can do the same for JSON (change XmlFormatter to jsonFormatter)
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}