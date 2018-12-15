namespace TestApp
{
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="WebApiConfig" />
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="config">The config<see cref="HttpConfiguration"/></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
